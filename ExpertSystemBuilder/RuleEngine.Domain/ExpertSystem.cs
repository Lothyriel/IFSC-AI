using RuleEngine.Domain.Results;
using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain;

public class ExpertSystem
{
    public ExpertSystem(IEnumerable<Value> variables, IEnumerable<IRule> rules)
    {
        Variables = variables.ToDictionary(variable => variable.Name, v => v);
        Rules = rules.ToList();
    }
    
    public List<IRule> Rules { get; }
    private Dictionary<string, Value> Variables { get; }
    
    public void SetVariable(string variableName, object? value)
    {
        var variable = Variables[variableName];
        variable.SetValue(value);
    }

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
                if (rule.Result is IAction decision)
                {
                    decision.Make();
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