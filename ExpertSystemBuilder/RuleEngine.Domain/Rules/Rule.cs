using RuleEngine.Domain.Results;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain.Rules;

public abstract class Rule : IRule
{
    public abstract string Name { get; }
    public abstract bool IsMet();
    public abstract Result Result { get; }
    public abstract Value Variable { get; }
        
    public static (Rule?, string) Create(string name, OperatorType type, Value value, string targetValue, Result result) 
    {
        if(value.Type == VariableType.Bool && bool.TryParse(targetValue, out bool boolResult))
            return (new Rule<bool?>(name, (BoolValue)value, type, boolResult, result), "OK");

        if (value.Type == VariableType.Numeric && double.TryParse(targetValue, out double doubleResult))
            return (new Rule<double?>(name, (NumericValue)value, type, doubleResult, result), "OK");

        if (value.Type == VariableType.Objective && value is ObjectiveValue objValue && objValue.PossibleValues.TryGetValue(targetValue, out _))
            return (new Rule<string?>(name, objValue, type, targetValue, result), "OK");

        return (null, "Target value is not valid for this variable type");
    }
}

public class Rule<T> : Rule
{
    public Rule(string name, Value<T?> variable, OperatorType operatorType, T? targetValue, Result? result = null)
    {
        Variable = variable;
        Operator = operatorType;
        TargetValue = targetValue;
        Result = result ?? Result.NoOp;
        Name = name;
    }

    public override Value<T?> Variable { get; }

    public OperatorType Operator { get; }

    public T? TargetValue { get; }

    public override Result Result { get; }

    public override string Name { get; }

    public override bool IsMet()
    {
        return Variable.EvaluateDefault(Operator, TargetValue);
    }

    public override string ToString()
    {
        return $"{Variable} | {Operator} | {TargetValue} = {Result}";
    }
}