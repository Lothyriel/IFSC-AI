using RuleEngine.Domain.Results;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain.Rules;

public class ComplexRule : IRule
{
    public ComplexRule(string name, Result result, Rule rule1, BoolOperator op, Rule rule2)
    {
        Name = name;
        Result = result;
        Operator = op;
        Rule1 = rule1;
        Rule2 = rule2;
    }

    public Rule Rule1 { get; }
    public Rule Rule2 { get; }
    public BoolOperator Operator { get; }
    public string Name { get; }
    public Result Result { get; }

    public bool IsMet()
    {
        return Operator switch
        {
            BoolOperator.And => Rule1.IsMet() && Rule2.IsMet(),
            BoolOperator.Or => Rule1.IsMet() || Rule2.IsMet(),
            _ => throw new InvalidOperationException()
        };
    }
        
    public override string ToString()
    {
        return $"Complex Rule: {Name} | {Result}";
    }
}