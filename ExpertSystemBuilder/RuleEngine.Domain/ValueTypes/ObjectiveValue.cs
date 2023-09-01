using RuleEngine.Domain.Exceptions;

namespace RuleEngine.Domain.ValueTypes
{
    public class ObjectiveValue : Value<string?>
    {
        public override string Name { get; }
        public override string? CurrentValue { get; set; }
        public HashSet<string> PossibleValues { get; }
        public override VariableType Type => VariableType.Objective;

        public override bool UserInputable { get; }

        public ObjectiveValue(string name, string? actualValue, HashSet<string> possibleValues, bool userInputable = true)
        {
            if (actualValue is not null && !possibleValues.TryGetValue(actualValue, out _))
                throw new Exception($"Actual Value {actualValue} must be in PossibleValues");

            Name = name;
            CurrentValue = actualValue;
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

        public static (ObjectiveValue?, string) Valid(string name, string value, bool userInputable, HashSet<string> possibleValues)
        {
            if (possibleValues.Count < 2)
                return (null, "Too few possible values");

            if (value != "" & !possibleValues.TryGetValue(value, out string? currentValue))
            {
                return (null, "Value is not in possible values list");
            }

            return (new ObjectiveValue(name, currentValue, possibleValues, userInputable), "OK");
        }
    }
}