using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain.Results
{
    public class ActionResult<T> : Result, IActionResult
    {
        public ActionResult(Value<T> variable, T newValue)
        {
            Variable = variable;
            NewValue = newValue;
        }

        public Value<T> Variable { get; set; }
        public T NewValue { get; }

        public void Act()
        {
            Variable.CurrentValue = NewValue;
        }

        public override string ToString()
        {
            return $"{nameof(Variable)}: {Variable} | {nameof(NewValue)}: {NewValue}";
        }
    }
}
