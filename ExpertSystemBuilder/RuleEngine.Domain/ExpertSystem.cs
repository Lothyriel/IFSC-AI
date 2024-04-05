using RuleEngine.Domain.Results;
using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain
{
    public class ExpertSystem
    {
        public ExpertSystem(IEnumerable<ValueBase> variables, IEnumerable<IRule> rules)
        {
            Variables = variables.ToDictionary(variable => variable.Name, v => v);
            Rules = rules.ToList();
        }

        public Dictionary<string, ValueBase> Variables { get; }
        public List<IRule> Rules { get; }

        public Conclusion Result()
        {
            while (true)
            {
                var nextRules = RulesMet();

                if (!nextRules.Any())
                {
                    throw new ImpossibleScenario();
                }

                foreach (var rule in nextRules)
                {
                    if (rule.Result is IActionResult action)
                    {
                        action.Act();
                    }
                    else if (rule.Result is Conclusion obj)
                    {
                        return obj;
                    }
                }
            }
        }

        private List<IRule> RulesMet() => Rules.Where(r => r.IsMet()).ToList();
    }
}