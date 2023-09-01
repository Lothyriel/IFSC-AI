using RuleEngine.Domain;
using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;

namespace WindowsForms
{
    public class ESBuilder
    {
        public ESBuilder(List<IRule> rules, List<ValueBase> variables)
        {
            Rules = rules;
            Variables = variables;
        }
        public ESBuilder()
        {
            Rules = new();
            Variables = new();
        }

        public ESBuilder(ExpertSystem system)
        {
            System = system;
            Rules = system.Rules.Keys.ToList();
            Variables = system.Variables.Values.ToList();
        }

        public List<IRule> Rules { get; }
        public List<ValueBase> Variables { get; }
        public ExpertSystem? System { get; }

        public ExpertSystem Build() { return new ExpertSystem(Variables, Rules); }
    }
}