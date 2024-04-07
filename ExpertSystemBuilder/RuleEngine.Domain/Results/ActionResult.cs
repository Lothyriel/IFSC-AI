using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain.Results;

public class ActionResult<T> : Result, IAction
{
    public ActionResult(Value<T?> variable, T? newValue)
    {
        Variable = variable;
        NewValue = newValue;
    }

    public Value<T?> Variable { get; init; }
    public T? NewValue { get; }

    public void Perform()
    {
        Variable.CurrentValue = NewValue;
    }

    public override string ToString()
    {
        return $"{nameof(Variable)}: {Variable} | {nameof(NewValue)}: {NewValue}";
    }
}