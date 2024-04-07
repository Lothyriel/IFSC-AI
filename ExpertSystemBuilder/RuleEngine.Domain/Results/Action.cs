using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain.Results;

public class Action<T> : Result, IAction
{
    public Action(Value<T> variable, T newValue)
    {
        Variable = variable;
        NewValue = newValue;
    }

    public Value<T> Variable { get; init; }
    public T NewValue { get; }

    public void Make()
    {
        Variable.CurrentValue = NewValue;
    }

    public override string ToString()
    {
        return $"{nameof(Variable)}: {Variable} | {nameof(NewValue)}: {NewValue}";
    }
}