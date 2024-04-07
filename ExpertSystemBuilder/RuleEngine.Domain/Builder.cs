using RuleEngine.Domain.Results;
using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain;

public class Builder
{
    public Builder(List<IRule> rules, List<Value> variables)
    {
        Rules = rules;
        Variables = variables;
    }
    public Builder()
    {
        Rules = new();
        Variables = new();
    }

    public Builder(ExpertSystem system)
    {
        System = system;
        Rules = system.Rules;
        Variables = system.Variables.Values.ToList();
    }

    public List<IRule> Rules { get; }
    public List<Value> Variables { get; }
    public ExpertSystem? System { get; }

    public ExpertSystem Build() { return new ExpertSystem(Variables, Rules); }
        
    public static (Rule?, string) CreateRule(string name, OperatorType type, Value value, string targetValue, Result result) 
    {
        if(value.Type == VariableType.Bool && bool.TryParse(targetValue, out var boolResult))
            return (new Rule<bool?>(name, (BoolValue)value, type, boolResult, result), "OK");

        if (value.Type == VariableType.Numeric && double.TryParse(targetValue, out var doubleResult))
            return (new Rule<double?>(name, (NumericValue)value, type, doubleResult, result), "OK");

        if (value.Type == VariableType.Objective && value is ObjectiveValue objValue && objValue.PossibleValues.TryGetValue(targetValue, out _))
            return (new Rule<string>(name, objValue, type, targetValue, result), "OK");

        return (null, "Target value is not valid for this variable type");
    }
        
    public static (Value?, string) CreateValue(VariableType type, string name, string value, bool userInputable, HashSet<string> objectiveValues)
    {
        if (name == "")
            return (null, "Please type a valid name");

        return type switch
        {
            VariableType.Bool => BoolValue.Valid(name, value, userInputable),
            VariableType.Objective => ObjectiveValue.Valid(name, value, userInputable, objectiveValues),
            VariableType.Numeric => ValidateNumber(name, value, userInputable),
            _ => throw new InvalidEnumType(type),
        };
    }
    
    public static Result CreateResult(Value variable, string newValue)
    {
        if (variable.Type == VariableType.Bool && bool.TryParse(newValue, out var boolValue))
            return new ActionResult<bool?>((BoolValue)variable, boolValue);

        if (variable.Type == VariableType.Numeric && double.TryParse(newValue, out var doubleValue))
            return new ActionResult<double?>((NumericValue)variable, doubleValue);

        if (variable.Type == VariableType.Objective && variable is ObjectiveValue objValue && objValue.PossibleValues.TryGetValue(newValue, out _))
            return new ActionResult<string>(objValue, newValue);

        return new Conclusion(newValue);
    }

    private static (NumericValue?, string) ValidateNumber(string name, string value, bool userInputable)
    {
        var isNumber = double.TryParse(value, out var doubleValue);
        if (value != "" && !isNumber)
        {
            return (null, "Value is not a number");
        }

        double? currentValue = isNumber ? doubleValue : null;
        return (new NumericValue(name, currentValue, userInputable), "OK");
    }
}

public enum VariableType
{
    Numeric,
    Bool,
    Objective,
}