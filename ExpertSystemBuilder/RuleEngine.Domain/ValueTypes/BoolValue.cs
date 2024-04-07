namespace RuleEngine.Domain.ValueTypes;

public class BoolValue : Value<bool?>
{
    public override string Name { get; }
    public override bool UserInputable { get; }
    public override VariableType Type => VariableType.Bool;
    protected sealed override bool? CurrentValue { get; set; }

    public BoolValue(string name, bool? currentValue, bool userInputable = true)
    {
        Name = name;
        CurrentValue = currentValue;
        UserInputable = userInputable;
    }
    
    public override bool Evaluate(OperatorType op, bool? value)
    {
        return op switch
        {
            OperatorType.Equals => CurrentValue == value,
            OperatorType.NotEquals => CurrentValue != value,
            _ => throw new InvalidOperator(op, typeof(BoolValue)),
        };
    }
}