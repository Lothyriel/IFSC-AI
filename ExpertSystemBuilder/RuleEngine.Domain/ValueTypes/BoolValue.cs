namespace RuleEngine.Domain.ValueTypes;

public class BoolValue : Value<bool?>
{
    public override string Name { get; }
    protected sealed override bool? CurrentValue { get; set; }
    public override bool UserInputable { get; }

    public override VariableType Type => VariableType.Bool;

    public BoolValue(string name, bool? currentValue, bool userInputable = true)
    {
        Name = name;
        CurrentValue = currentValue;
        UserInputable = userInputable;
    }

    public override bool Equals(bool? v2)
    {
        return v2 is not null && CurrentValue == v2;
    }

    public override bool NotEquals(bool? v2)
    {
        return Equals(v2);
    }

    protected override bool EvaluateFurther(OperatorType operatorTypeValue, bool? value)
    {
        throw new InvalidOperator(operatorTypeValue, typeof(BoolValue));
    }
}