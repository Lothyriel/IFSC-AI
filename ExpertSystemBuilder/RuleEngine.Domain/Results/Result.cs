using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain.Results
{
    public class Result
    {
        public static Result Empty { get; } = new();

        public override string ToString()
        {
            return "Empty Result";
        }

        public static Result Create(ValueBase variable, string newValue)
        {
            if (variable.Type == VariableType.Bool && bool.TryParse(newValue, out bool boolValue))
                return new ActionResult<bool?>((BoolValue)variable, boolValue);

            if (variable.Type == VariableType.Numeric && double.TryParse(newValue, out double doubleValue))
                return new ActionResult<double?>((NumericValue)variable, doubleValue);

            if (variable.Type == VariableType.Objective && variable is ObjectiveValue objValue && objValue.PossibleValues.TryGetValue(newValue, out _))
                return new ActionResult<string?>(objValue, newValue);

            return new Conclusion(newValue);
        }
    }
}