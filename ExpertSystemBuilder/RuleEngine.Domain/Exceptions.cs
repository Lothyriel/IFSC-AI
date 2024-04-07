using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain;

[Serializable]
internal class InvalidEnumType : Exception
{
    public InvalidEnumType(VariableType type) : base($"Enum value dont't exist {type}")
    {
    }
}

[Serializable]
internal class InvalidOperator : Exception
{
    public InvalidOperator(OperatorType operatorTypeValue, Type type) : base($"Type {type} doesn't support the {operatorTypeValue} operator")
    {
    }
}

[Serializable]
internal class ImpossibleScenario : Exception
{
    public ImpossibleScenario() : base("The system couldn't resolve this problem with the current rules!")
    {
    }
}