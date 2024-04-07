using RuleEngine.Domain.Results;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain.Rules;

public abstract class Rule : IRule
{
    public abstract string Name { get; }
    public abstract bool IsMet();
    public abstract Result Result { get; }
    public abstract Value Variable { get; }
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