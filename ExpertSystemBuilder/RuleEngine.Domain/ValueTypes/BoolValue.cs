using RuleEngine.Domain.Exceptions;

namespace RuleEngine.Domain.ValueTypes
{
    public class BoolValue : Value<bool?>
    {
        public override string Name { get; }
        public override bool? CurrentValue { get; set; }
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
        public static (BoolValue?, string) Valid(string name, string value, bool userInputable)
        {
            var isBool = bool.TryParse(value, out bool boolValue);
            if (value != "" && !isBool)
            {
                return (null, "Value is not 'true' or 'false'");
            }

            bool? currentValue = isBool ? boolValue : null;
            return (new BoolValue(name, currentValue, userInputable), "OK");
        }
    }
}