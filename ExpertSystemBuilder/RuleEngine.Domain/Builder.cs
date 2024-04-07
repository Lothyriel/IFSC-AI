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
            VariableType.Bool => ValidateBool(name, value, userInputable),
            VariableType.Objective => ValidateObjective(name, value, userInputable, objectiveValues),
            VariableType.Numeric => ValidateNumber(name, value, userInputable),
            _ => throw new InvalidEnumType(type),
        };
    }
    
    public static Result CreateResult(Value variable, string newValue)
    {
        if (variable is BoolValue b && bool.TryParse(newValue, out var boolValue))
            return new ActionResult<bool?>(b, boolValue);

        if (variable is NumericValue n && double.TryParse(newValue, out var doubleValue))
            return new ActionResult<double?>(n, doubleValue);

        if (variable is ObjectiveValue o && o.PossibleValues.TryGetValue(newValue, out _))
            return new ActionResult<string>(o, newValue);

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
    
    private static (ObjectiveValue?, string) ValidateObjective(string name, string value, bool userInputable, HashSet<string> possibleValues)
    {
        if (possibleValues.Count < 2)
        {
            return (null, "Too few possible values");
        }

        if (value != "" & !possibleValues.TryGetValue(value, out var currentValue))
        {
            return (null, "Value is not in possible values list");
        }

        return (new ObjectiveValue(name, currentValue, possibleValues, userInputable), "OK");
    }
    
    private static (BoolValue?, string) ValidateBool(string name, string value, bool userInputable)
    {
        var isBool = bool.TryParse(value, out var boolValue);
        if (value != "" && !isBool)
        {
            return (null, "Value is not 'true' or 'false'");
        }

        bool? currentValue = isBool ? boolValue : null;
        return (new BoolValue(name, currentValue, userInputable), "OK");
    }
}

public enum VariableType
{
    Numeric,
    Bool,
    Objective,
}