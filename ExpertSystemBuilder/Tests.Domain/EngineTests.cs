using FluentAssertions;
using NUnit.Framework;
using RuleEngine.Domain;
using RuleEngine.Domain.Results;
using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;
using System.Collections.Generic;

namespace Tests.Domain
{
    public class EngineTests
    {
        [Test]
        public void ShouldConcludeSimpleRule()
        {
            var variable = new NumericValue("var", 50);
            var result = new Conclusion("you should get some rest it's already 7:12 AM");

            var rules = new List<IRule>
            {
                new Rule<double?>("simpleRule", variable, OperatorType.Equals, 50, result)
            };

            var variables = new List<Value>
            {
                variable
            };

            var es = new ExpertSystem(variables, rules);

            es.Result().Should().Be(result);
        }
        
        [Test]
        public void ShouldActAndResultSimleConclusion()
        {
            var variable = new NumericValue("var", 10);
            var action = new ActionResult<double?>(variable, 50);

            var conclusion = new Conclusion("it's easy when you big in japan");

            var rules = new List<IRule>
            {
                new Rule<double?>("rule1",variable, OperatorType.Lesser, 50, action),
                new Rule<double?>("rule2",variable, OperatorType.Equals, 50, conclusion)
            };

            var variables = new List<Value>
            {
                variable,
            };

            var es = new ExpertSystem(variables, rules);

            es.Result().Should().Be(conclusion);
        }
        
        [Test]
        public void ShouldDeriveRuleAndResultSimleConclusion()
        {
            var variable = new NumericValue("var", 10);
            var action = new ActionResult<double?>(variable, 50);

            var conclusion = new Conclusion("it's easy when you big in japan");

            var rules = new List<IRule>
            {
                new Rule<double?>("rule1",variable, OperatorType.Equals, 50, conclusion),
                new Rule<double?>("rule2",variable, OperatorType.Lesser, 50, action)
            };

            var variables = new List<Value>
            {
                variable,
            };

            var es = new ExpertSystem(variables, rules);

            es.Result().Should().Be(conclusion);
        }

        [Test]
        [TestCase(BoolOperator.Or, true)]
        [TestCase(BoolOperator.And, false)]
        public void ShouldResolveComplexRule(BoolOperator boolOperator, bool expectedResul)
        {
            var pratoPrincipal = new ObjectiveValue("PratoPrincipal", "frango", ["carneVermelha", "frango", "peixe"]);
            var melhorCor = new ObjectiveValue("MelhorCor", null, ["tinto", "branco"]);

            var resultbranco = new ActionResult<string?>(melhorCor, "branco");
            var ruleFrango = new Rule<string?>("ruleFrango", pratoPrincipal, OperatorType.Equals, "frango");
            var rulePeixe = new Rule<string?>("rulePeixe", pratoPrincipal, OperatorType.Equals, "peixe");
            var regraFrangoOuPeixe = new ComplexRule("ruleFrangoOuPeixe", resultbranco, ruleFrango, boolOperator, rulePeixe);

            regraFrangoOuPeixe.IsMet().Should().Be(expectedResul);
        }

        [Test]
        public void ShouldPickRiesling()
        {
            var es = ExamplesEs.BestWinePicker();
            es.SetVariable("PratoPrincipal", "frango");
            es.SetVariable("TipoMolho", "picante");
            es.SetVariable("TemMolho", true);

            es.Result().Message.Should().Be("Melhor vinho para esta refeição é um Riesling");
        }
        
        [Test]
        public void ShouldPickRiesling2()
        {
            var es = ExamplesEs.BestWinePicker();
            es.SetVariable("PratoPrincipal", "peixe");
            es.SetVariable("TemMolho", false);

            es.Result().Message.Should().Be("Melhor vinho para esta refeição é um Riesling");
        }
    }
}