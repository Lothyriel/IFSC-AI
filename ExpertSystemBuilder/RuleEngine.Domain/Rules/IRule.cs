using RuleEngine.Domain.Results;

namespace RuleEngine.Domain.Rules
{
    public interface IRule
    {
        public string Name { get; }
        public bool IsMet();
        public Result Result { get; }
    }
}