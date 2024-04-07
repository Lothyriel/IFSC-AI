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

    public override bool Equals(string? v2)
    {
        return v2 == CurrentValue;
    }

    public override bool NotEquals(string? v2)
    {
        return !Equals(v2);
    }

    protected override bool EvaluateFurther(OperatorType operatorTypeValue, string? value)
    {
        throw new InvalidOperator(operatorTypeValue, typeof(ObjectiveValue));
    }
}