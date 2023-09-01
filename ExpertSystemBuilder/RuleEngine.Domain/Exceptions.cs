using RuleEngine.Domain.ValueTypes;
using System.Runtime.Serialization;

namespace RuleEngine.Domain.Exceptions
{
    [Serializable]
    internal class InvalidEnumType : Exception
    {
        public InvalidEnumType()
        {
        }

        public InvalidEnumType(VariableType type) : base($"Enum value dont't exist {type}") { }

        public InvalidEnumType(string? message) : base(message)
        {
        }

        public InvalidEnumType(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidEnumType(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class InvalidOperator : Exception
    {

        public InvalidOperator(OperatorType operatorTypeValue, Type type) : base($"Type{type} doesn't support the {operatorTypeValue} operator")
        {
        }

        public InvalidOperator(string? message) : base(message)
        {
        }

        public InvalidOperator(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidOperator(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class ImpossibleScenario : Exception
    {
        public ImpossibleScenario() : base("The system couldn't resolve this problem!")
        {
        }

        public ImpossibleScenario(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ImpossibleScenario(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}