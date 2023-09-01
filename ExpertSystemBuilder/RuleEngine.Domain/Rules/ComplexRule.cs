using RuleEngine.Domain.Results;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain.Rules
{
    public class ComplexRule : IRule
    {
        public ComplexRule(string name, Result result, params (ActionRule, BoolOperator?)[] rules)
        {
            Name = name;
            Result = result;
            Rules = rules;
        }

        public (ActionRule, BoolOperator?)[] Rules { get; }

        public string Name { get; }
        public Result Result { get; }

        public bool IsMet()
        {
            var result = Rules[0].Item1.IsMet();
            for (int i = 1; i < Rules.Length; i++)
            {
                var rule = Rules[i].Item1;
                var operatorType = Rules[i - 1].Item2;
                if (operatorType == BoolOperator.And)
                {
                    result &= rule.IsMet();
                }
                else if (operatorType == BoolOperator.Or)
                {
                    result |= rule.IsMet();
                }
            }
            return result;
        }
        public override string ToString()
        {
            return $"Complex Rule: {Name} | {Result}";
        }
    }
}
