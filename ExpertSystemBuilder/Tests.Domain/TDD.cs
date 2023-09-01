using FluentAssertions;
using NUnit.Framework;
using RuleEngine.Domain;
using RuleEngine.Domain.Results;
using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;
using System.Collections.Generic;

namespace Tests.Domain
{
    public class TDD
    {
        [Test]
        public void ShouldConcludeSimpleRule()
        {
            var variable = new NumericValue("var", 50);
            var result = new Conclusion("you should get some rest it's already 7:12 AM");

            var rules = new List<IRule>
            {
                new ActionRule<double?>("simpleRule", variable, OperatorType.Equals, 50, result)
            };

            var variables = new List<ValueBase>
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
                new ActionRule<double?>("rule1",variable, OperatorType.Lesser, 50, action),
                new ActionRule<double?>("rule2",variable, OperatorType.Equals, 50, conclusion)
            };

            var variables = new List<ValueBase>
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
                new ActionRule<double?>("rule1",variable, OperatorType.Equals, 50, conclusion),
                new ActionRule<double?>("rule2",variable, OperatorType.Lesser, 50, action)
            };

            var variables = new List<ValueBase>
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
            var pratoPrincipal = new ObjectiveValue("PratoPrincipal", "frango", new() { "carneVermelha", "frango", "peixe" });
            var melhorCor = new ObjectiveValue("MelhorCor", null, new() { "tinto", "branco" });

            var resultbranco = new ActionResult<string?>(melhorCor, "branco");
            var ruleFrango = new ActionRule<string?>("ruleFrango", pratoPrincipal, OperatorType.Equals, "frango", Result.Empty);
            var rulePeixe = new ActionRule<string?>("rulePeixe", pratoPrincipal, OperatorType.Equals, "peixe", Result.Empty);
            var regraFrangoOuPeixe = new ComplexRule("ruleFrangoOuPeixe", resultbranco, (ruleFrango, boolOperator), (rulePeixe, null));

            regraFrangoOuPeixe.IsMet().Should().Be(expectedResul);
        }

        [Test]
        public void ShouldPickRiesling()
        {
            var es = ExamplesES.BestWinePicker();
            es.Variables["PratoPrincipal"].Value = "frango";
            es.Variables["TipoMolho"].Value = "picante";
            es.Variables["TemMolho"].Value = true;

            es.Result().Message.Should().Be("Melhor vinho para esta refeição é um Riesling");
        }
        [Test]
        public void ShouldPickRiesling2()
        {
            var es = ExamplesES.BestWinePicker();
            es.Variables["PratoPrincipal"].Value = "peixe";
            es.Variables["TemMolho"].Value = false;

            es.Result().Message.Should().Be("Melhor vinho para esta refeição é um Riesling");
        }
    }
}