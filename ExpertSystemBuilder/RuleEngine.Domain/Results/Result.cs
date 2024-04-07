using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain.Results;

public abstract class Result
{
    public static readonly NoOp NoOp = new();
    public override string ToString()
    {
        return "Empty Result";
    }

    public static Result Create(Value variable, string newValue)
    {
        if (variable.Type == VariableType.Bool && bool.TryParse(newValue, out var boolValue))
            return new ActionResult<bool?>((BoolValue)variable, boolValue);

        if (variable.Type == VariableType.Numeric && double.TryParse(newValue, out var doubleValue))
            return new ActionResult<double?>((NumericValue)variable, doubleValue);

        if (variable.Type == VariableType.Objective && variable is ObjectiveValue objValue && objValue.PossibleValues.TryGetValue(newValue, out _))
            return new ActionResult<string?>(objValue, newValue);

        return new Conclusion(newValue);
    }
}

public class NoOp : Result;