using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain
{
    public class EsBuilder
    {
        public EsBuilder(List<IRule> rules, List<ValueBase> variables)
        {
            Rules = rules;
            Variables = variables;
        }
        public EsBuilder()
        {
            Rules = new();
            Variables = new();
        }

        public EsBuilder(ExpertSystem system)
        {
            System = system;
            Rules = system.Rules;
            Variables = system.Variables.Values.ToList();
        }

        public List<IRule> Rules { get; }
        public List<ValueBase> Variables { get; }
        public ExpertSystem? System { get; }

        public ExpertSystem Build() { return new ExpertSystem(Variables, Rules); }
    }
}