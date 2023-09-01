using RuleEngine.Domain.Results;
using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain
{
    public static class ExamplesES
    {
        public static ExpertSystem BestWinePicker()
        {
            //criando variaveis
            var pratoPrincipal = new ObjectiveValue("PratoPrincipal", null, new() { "carneVermelha", "frango", "peixe", "massa" });
            var tipoMolho = new ObjectiveValue("TipoMolho", null, new() { "picante", "tomate" });
            var temMolho = new BoolValue("TemMolho", null);
            var melhorCor = new ObjectiveValue("MelhorCor", null, new() { "tinto", "branco" }, false);
            var melhorTipo = new ObjectiveValue("MelhorTipo", null, new() { "suave", "seco" }, false);

            //SE prato == carne vermelha ENTAO cor = tinto
            var resultTinto = new ActionResult<string?>(melhorCor, "tinto");
            var ruleCarneVermelha_Tinto = new ActionRule<string?>("ruleCarneVermelha", pratoPrincipal, OperatorType.Equals, "carneVermelha", resultTinto);

            //SE prato == peixe || frango ENTAO cor = branco
            var resultBranco = new ActionResult<string?>(melhorCor, "branco");
            var ruleFrango = new ActionRule<string?>("ruleFrango", pratoPrincipal, OperatorType.Equals, "frango", Result.Empty);
            var rulePeixe = new ActionRule<string?>("rulePeixe", pratoPrincipal, OperatorType.Equals, "peixe", Result.Empty);
            var ruleFrangoOuPeixe_Branco = new ComplexRule("ruleFrangoOuPeixe", resultBranco, (ruleFrango, BoolOperator.Or), (rulePeixe, null));

            //SE temMolho == false ENTAO tipo = suave
            var resultSuave = new ActionResult<string?>(melhorTipo, "suave");
            var ruleNaoTemMolho_Suave = new ActionRule<bool?>("ruleNaoTemMolho", temMolho, OperatorType.Equals, false, resultSuave);

            //SE temMolho == true && tipoMolho == picante ENTAO tipo = suave
            var ruleTemMolho = new ActionRule<bool?>("ruleTemMolho", temMolho, OperatorType.Equals, true, Result.Empty);
            var rulePicante = new ActionRule<string?>("rulePicante", tipoMolho, OperatorType.Equals, "picante", Result.Empty);
            var ruleTemMolhoPicante_Suave = new ComplexRule("ruleTemMolhoPicante", resultSuave, (ruleTemMolho, BoolOperator.And), (rulePicante, null));

            //SE temMolho == true && tipoMolho == tomate ENTAO tipo = seco
            var resultSeco = new ActionResult<string?>(melhorTipo, "seco");
            var ruleTomate = new ActionRule<string?>("ruleTomate", tipoMolho, OperatorType.Equals, "tomate", Result.Empty);
            var ruleTemMolhoTomate_Seco = new ComplexRule("ruleTemMolhoTomate", resultSeco, (ruleTemMolho, BoolOperator.And), (ruleTomate, null));

            //SE tipo == suave && cor == branco ENTAO conclui que o melhor vinho é um riesling
            var conclusionRiesling = new Conclusion("Melhor vinho para esta refeição é um Riesling");
            var ruleBranco = new ActionRule<string?>("ruleBranco", melhorCor, OperatorType.Equals, "branco", Result.Empty);
            var ruleSuave = new ActionRule<string?>("ruleSuave", melhorTipo, OperatorType.Equals, "suave", Result.Empty);
            var ruleBrancoSuave_Riesling = new ComplexRule("ruleBrancoSuave", conclusionRiesling, (ruleBranco, BoolOperator.And), (ruleSuave, null));

            //SE tipo == seco && cor == branco ENTAO conclui que o melhor vinho é um sauvignon blanc
            var conclusionSauvignon = new Conclusion("Melhor vinho para esta refeição é um Sauvignon Blanc");
            var ruleSeco = new ActionRule<string?>("ruleSeco", melhorTipo, OperatorType.Equals, "seco", Result.Empty);
            var ruleBrancoSeco_Sauvignon = new ComplexRule("ruleBrancoSuave", conclusionSauvignon, (ruleBranco, BoolOperator.And), (ruleSeco, null));

            //SE tipo == suave && cor == tinto ENTAO conclui que o melhor vinho é um pinot noir
            var conclusionPinot = new Conclusion("Melhor vinho para esta refeição é um Pinot Noir");
            var ruleTinto = new ActionRule<string?>("ruleTinto", melhorCor, OperatorType.Equals, "suave", Result.Empty);
            var ruleTintoSuave_Pinot = new ComplexRule("ruleBrancoSuave", conclusionPinot, (ruleTinto, BoolOperator.And), (ruleSuave, null));

            //SE tipo == seco && cor == tinto ENTAO conclui que o melhor vinho é um cabbenet sauvignon
            var conclusionCabennet = new Conclusion("Melhor vinho para esta refeição é um Cabbenet Sauvignon");
            var ruleTintoSeco_Cabbenet = new ComplexRule("ruleBrancoSuave", conclusionCabennet, (ruleTinto, BoolOperator.And), (ruleSeco, null));

            //SE pratoPrincipal == massa ENTAO conclui que o melhor vinho é um cabbenet sauvignon
            var ruleMassa_Cabbenet = new ActionRule<string?>("ruleMassa", pratoPrincipal, OperatorType.Equals, "massa", conclusionCabennet);

            var rules = new List<IRule>
            {
                ruleCarneVermelha_Tinto,
                ruleFrangoOuPeixe_Branco,
                ruleNaoTemMolho_Suave,
                ruleTemMolhoPicante_Suave,
                ruleTemMolhoTomate_Seco,
                ruleBrancoSuave_Riesling,
                ruleBrancoSeco_Sauvignon,
                ruleTintoSuave_Pinot,
                ruleTintoSeco_Cabbenet,
                ruleMassa_Cabbenet
            };

            var variables = new List<ValueBase>
            {
                pratoPrincipal,
                temMolho,
                tipoMolho,
                melhorCor,
                melhorTipo,
            };

            return new ExpertSystem(variables, rules);
        }
    }

}
