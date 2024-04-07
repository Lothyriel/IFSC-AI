﻿namespace RuleEngine.Domain.ValueTypes;

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
    protected abstract T CurrentValue { get; set; }
    protected abstract bool EvaluateFurther(OperatorType operatorTypeValue, T value);
    public abstract bool Equals(T v2);
    public abstract bool NotEquals(T v2);
    public bool EvaluateDefault(OperatorType operatorTypeValue, T value)
    {
        return operatorTypeValue switch
        {
            OperatorType.Equals => Equals(value),
            OperatorType.NotEquals => NotEquals(value),
            _ => EvaluateFurther(operatorTypeValue, value),
        };
    }
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