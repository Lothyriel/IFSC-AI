using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain
{
    public class Builder
    {
        public Builder(List<IRule> rules, List<Value> variables)
        {
            Rules = rules;
            Variables = variables;
        }
        public Builder()
        {
            Rules = new();
            Variables = new();
        }

        public Builder(ExpertSystem system)
        {
            System = system;
            Rules = system.Rules;
            Variables = system.Variables.Values.ToList();
        }

        public List<IRule> Rules { get; }
        public List<Value> Variables { get; }
        public ExpertSystem? System { get; }

        public ExpertSystem Build() { return new ExpertSystem(Variables, Rules); }
    }
}