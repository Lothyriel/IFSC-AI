using RuleEngine.Domain.Results;
using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;

namespace RuleEngine.Domain;

public static class ExamplesEs
{
    public static ExpertSystem BestWinePicker()
    {
        //criando variaveis
        var pratoPrincipal = new ObjectiveValue("PratoPrincipal", null, ["carneVermelha", "frango", "peixe", "massa"]);
        var temMolho = new BoolValue("TemMolho", null);
        var tipoMolho = new ObjectiveValue("TipoMolho", null, ["picante", "tomate"]);
        var melhorCor = new ObjectiveValue("MelhorCor", null, ["tinto", "branco"], false);
        var melhorTipo = new ObjectiveValue("MelhorTipo", null, ["suave", "seco"], false);

        //SE prato == carne vermelha ENTAO cor = tinto
        var resultTinto = new ActionResult<string>(melhorCor, "tinto");
        var ruleCarneVermelha_Tinto = new Rule<string>("ruleCarneVermelha", pratoPrincipal, OperatorType.Equals, "carneVermelha", resultTinto);

        //SE prato == peixe || frango ENTAO cor = branco
        var resultBranco = new ActionResult<string>(melhorCor, "branco");
        var ruleFrango = new Rule<string>("ruleFrango", pratoPrincipal, OperatorType.Equals, "frango");
        var rulePeixe = new Rule<string>("rulePeixe", pratoPrincipal, OperatorType.Equals, "peixe");
        var ruleFrangoOuPeixe_Branco = new ComplexRule("ruleFrangoOuPeixe", resultBranco, ruleFrango, BoolOperator.Or, rulePeixe);

        //SE temMolho == false ENTAO tipo = suave
        var resultSuave = new ActionResult<string>(melhorTipo, "suave");
        var ruleNaoTemMolho_Suave = new Rule<bool?>("ruleNaoTemMolho", temMolho, OperatorType.Equals, false, resultSuave);

        //SE temMolho == true && tipoMolho == picante ENTAO tipo = suave
        var ruleTemMolho = new Rule<bool?>("ruleTemMolho", temMolho, OperatorType.Equals, true);
        var rulePicante = new Rule<string>("rulePicante", tipoMolho, OperatorType.Equals, "picante");
        var ruleTemMolhoPicante_Suave = new ComplexRule("ruleTemMolhoPicante", resultSuave, ruleTemMolho, BoolOperator.And, rulePicante);

        //SE temMolho == true && tipoMolho == tomate ENTAO tipo = seco
        var resultSeco = new ActionResult<string>(melhorTipo, "seco");
        var ruleTomate = new Rule<string>("ruleTomate", tipoMolho, OperatorType.Equals, "tomate");
        var ruleTemMolhoTomate_Seco = new ComplexRule("ruleTemMolhoTomate", resultSeco, ruleTemMolho, BoolOperator.And, ruleTomate);

        //SE tipo == suave && cor == branco ENTAO conclui que o melhor vinho é um riesling
        var conclusionRiesling = new Conclusion("Melhor vinho para esta refeição é um Riesling");
        var ruleBranco = new Rule<string>("ruleBranco", melhorCor, OperatorType.Equals, "branco");
        var ruleSuave = new Rule<string>("ruleSuave", melhorTipo, OperatorType.Equals, "suave");
        var ruleBrancoSuave_Riesling = new ComplexRule("ruleBrancoSuave", conclusionRiesling, ruleBranco, BoolOperator.And, ruleSuave);

        //SE tipo == seco && cor == branco ENTAO conclui que o melhor vinho é um sauvignon blanc
        var conclusionSauvignon = new Conclusion("Melhor vinho para esta refeição é um Sauvignon Blanc");
        var ruleSeco = new Rule<string>("ruleSeco", melhorTipo, OperatorType.Equals, "seco");
        var ruleBrancoSeco_Sauvignon = new ComplexRule("ruleBrancoSuave", conclusionSauvignon, ruleBranco, BoolOperator.And, ruleSeco);

        //SE tipo == suave && cor == tinto ENTAO conclui que o melhor vinho é um pinot noir
        var conclusionPinot = new Conclusion("Melhor vinho para esta refeição é um Pinot Noir");
        var ruleTinto = new Rule<string>("ruleTinto", melhorCor, OperatorType.Equals, "suave");
        var ruleTintoSuave_Pinot = new ComplexRule("ruleBrancoSuave", conclusionPinot, ruleTinto, BoolOperator.And, ruleSuave);

        //SE tipo == seco && cor == tinto ENTAO conclui que o melhor vinho é um cabbenet sauvignon
        var conclusionCabennet = new Conclusion("Melhor vinho para esta refeição é um Cabbenet Sauvignon");
        var ruleTintoSeco_Cabbenet = new ComplexRule("ruleBrancoSuave", conclusionCabennet, ruleTinto, BoolOperator.And, ruleSeco);

        //SE pratoPrincipal == massa ENTAO conclui que o melhor vinho é um cabbenet sauvignon
        var ruleMassa_Cabbenet = new Rule<string>("ruleMassa", pratoPrincipal, OperatorType.Equals, "massa", conclusionCabennet);

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

        var variables = new List<Value>
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