using RuleEngine.Domain.Exceptions;
using RuleEngine.Domain.Results;
using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain
{
    public class ExpertSystem
    {
        public ExpertSystem(List<ValueBase> variables, List<IRule> rules)
        {
            Variables = variables.ToDictionary(variable => variable.Name, v => v);
            Rules = rules.ToDictionary(rule => rule, rule => false);
        }
        public Dictionary<string, ValueBase> Variables { get; }
        public Dictionary<IRule, bool> Rules { get; }

        public Conclusion Result()
        {
            List<IRule> nextRules;
            while ((nextRules = RulesMet()).Any())
            {
                foreach (var rule in nextRules)
                {
                    Rules[rule] = true;
                    if (rule.Result is IActionResult action)
                        action.Act();
                    else if (rule.Result is Conclusion obj)
                        return obj;
                }
            }
            throw new ImpossibleScenario();
        }

        private List<IRule> RulesMet()
        {
            return Rules.Keys.Where(r => r.IsMet()).ToList();
        }
    }
}