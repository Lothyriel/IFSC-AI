using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain.Results;

public class Result
{
    public static Result Empty { get; } = new();

    public override string ToString()
    {
        return "Empty Result";
    }

    public static Result Create(Value variable, string newValue)
    {
        if (variable.Type == VariableType.Bool && bool.TryParse(newValue, out var boolValue))
            return new Action<bool?>((BoolValue)variable, boolValue);

        if (variable.Type == VariableType.Numeric && double.TryParse(newValue, out var doubleValue))
            return new Action<double?>((NumericValue)variable, doubleValue);

        if (variable.Type == VariableType.Objective && variable is ObjectiveValue objValue && objValue.PossibleValues.TryGetValue(newValue, out _))
            return new Action<string?>(objValue, newValue);

        return new Conclusion(newValue);
    }
}