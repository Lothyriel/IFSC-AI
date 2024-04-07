namespace RuleEngine.Domain.ValueTypes;

public abstract class Value
{
    public abstract string Name { get; }
    public abstract bool UserInputable { get; }
    public abstract object? GetValue();
    public abstract void SetValue(object? value);
    public abstract VariableType Type { get; }
}

public abstract class Value<T> : Value
{
    protected abstract T? CurrentValue { get; set; }
    public abstract bool Evaluate(OperatorType op, T value);
    public override object? GetValue() => CurrentValue;
    public override void SetValue(object? value) => CurrentValue = (T)value!;
    public override string ToString() => $"{Type}: {Name}: {(CurrentValue is null ? "null" : CurrentValue)}";
}
    
public enum BoolOperator
{
    Or,
    And
}

public enum OperatorType
{
    Equals,
    NotEquals,
    Lesser,
    Greater,
    LesserOrEquals,
    GreaterOrEquals
}