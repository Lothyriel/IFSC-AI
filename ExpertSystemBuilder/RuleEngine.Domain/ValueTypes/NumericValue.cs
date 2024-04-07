namespace RuleEngine.Domain.ValueTypes;

public class NumericValue : Value<double?>
{
    public override string Name { get; }
    protected sealed override double? CurrentValue { get; set; }
    public override VariableType Type => VariableType.Numeric;
    public override bool UserInputable { get; }

    public NumericValue(string name, double? value, bool userInputable = true)
    {
        Name = name;
        CurrentValue = value;
        UserInputable = userInputable;
    }
    
    public override bool Evaluate(OperatorType op, double? value)
    {
        return op switch
        {
            OperatorType.Equals => CurrentValue == value,
            OperatorType.NotEquals => CurrentValue != value,
            OperatorType.Lesser => CurrentValue < value,
            OperatorType.Greater => CurrentValue > value,
            OperatorType.LesserOrEquals => CurrentValue <= value,
            OperatorType.GreaterOrEquals => CurrentValue >= value,
            _ => throw new Exception($"Invalid enum value exception {op}"),
        };
    }
}