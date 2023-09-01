using RuleEngine.Domain.Results;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain.Rules
{
    public abstract class ActionRule : IRule
    {
        public abstract string Name { get; }
        public abstract bool IsMet();
        public abstract Result Result { get; }
        public abstract ValueBase Variable { get; }


        public static (ActionRule?, string) Create(string name, OperatorType type, ValueBase value, string targetValue, Result result) 
        {
            if(value.Type == VariableType.Bool && bool.TryParse(targetValue, out bool boolResult))
                return (new ActionRule<bool?>(name, (BoolValue)value, type, boolResult, result), "OK");

            if (value.Type == VariableType.Numeric && double.TryParse(targetValue, out double doubleResult))
                return (new ActionRule<double?>(name, (NumericValue)value, type, doubleResult, result), "OK");

            if (value.Type == VariableType.Objective && value is ObjectiveValue objValue && objValue.PossibleValues.TryGetValue(targetValue, out _))
                return (new ActionRule<string?>(name, objValue, type, targetValue, result), "OK");

            return (null, "Target value is not valid for this variable type");
        }
        public static bool operator &(ActionRule a, ActionRule b)
        {
            return a.IsMet() && b.IsMet();
        }
    }
    public class ActionRule<T> : ActionRule
    {
        public ActionRule(string name, Value<T> variable, OperatorType operatorType, T targetValue, Result result)
        {
            Variable = variable;
            Operator = operatorType;
            TargetValue = targetValue;
            Result = result;
            Name = name;
        }

        public override Value<T> Variable { get; }

        public OperatorType Operator { get; }

        public T TargetValue { get; }

        public override Result Result { get; }

        public override string Name { get; }

        public override bool IsMet()
        {
            return Variable?.EvaluateDefault(Operator, TargetValue) ?? false;
        }

        public override string ToString()
        {
            return $"{Variable} | {Operator} | {TargetValue} = {Result}";
        }
    }
}