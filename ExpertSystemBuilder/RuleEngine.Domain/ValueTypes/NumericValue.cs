namespace RuleEngine.Domain.ValueTypes
{
    public class NumericValue : Value<double?>
    {
        public override string Name { get; }
        public override double? CurrentValue { get; set; }
        public override VariableType Type => VariableType.Numeric;

        public override bool UserInputable { get; }

        public NumericValue(string name, double? value, bool userInputable = true)
        {
            Name = name;
            CurrentValue = value;
            UserInputable = userInputable;
        }

        public override bool Equals(double? v2)
        {
            return CurrentValue == v2;
        }

        public override bool NotEquals(double? v2)
        {
            return CurrentValue != v2;
        }

        public bool Greater(double? v2)
        {
            return CurrentValue > v2;
        }

        public bool Lesser(double? v2)
        {
            return CurrentValue < v2;
        }

        public static (NumericValue?, string) Valid(string name, string value, bool userInputable)
        {
            var isNumber = double.TryParse(value, out double doubleValue);
            if (value != "" && !isNumber)
            {
                return (null, "Value is not a number");
            }

            double? currentValue = isNumber ? doubleValue : null;
            return (new NumericValue(name, currentValue, userInputable), "OK");
        }

        public bool GreaterOrEquals(double? v2)
        {
            return CurrentValue >= v2;
        }

        public bool LesserOrEquals(double? v2)
        {
            return CurrentValue <= v2;
        }

        protected override bool EvaluateFurther(OperatorType operatorTypeValue, double? value)
        {
            return operatorTypeValue switch
            {
                OperatorType.Lesser => Lesser(value),
                OperatorType.Greater => Greater(value),
                OperatorType.LesserOrEquals => LesserOrEquals(value),
                OperatorType.GreaterOrEquals => GreaterOrEquals(value),
                _ => throw new Exception($"Invalid enum value exception {operatorTypeValue}"),
            };
        }
    }
}