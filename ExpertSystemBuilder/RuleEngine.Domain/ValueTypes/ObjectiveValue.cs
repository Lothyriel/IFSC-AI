namespace RuleEngine.Domain.ValueTypes;

public class ObjectiveValue : Value<string?>
{
    public override string Name { get; }
    protected sealed override string? CurrentValue { get; set; }
    public HashSet<string> PossibleValues { get; }
    public override VariableType Type => VariableType.Objective;
    public override bool UserInputable { get; }

    public ObjectiveValue(string name, string? initialValue, HashSet<string> possibleValues, bool userInputable = true)
    {
        if (initialValue is not null && !possibleValues.TryGetValue(initialValue, out _))
            throw new Exception($"Actual Value {initialValue} must be in PossibleValues");

        Name = name;
        CurrentValue = initialValue;
        UserInputable = userInputable;
        PossibleValues = possibleValues;
    }

    public override bool Evaluate(OperatorType op, string? value)
    {
        return op switch
        {
            OperatorType.Equals => value == CurrentValue,
            OperatorType.NotEquals => value != CurrentValue,
            _ => throw new InvalidOperator(op, typeof(BoolValue)),
        };
    }
}