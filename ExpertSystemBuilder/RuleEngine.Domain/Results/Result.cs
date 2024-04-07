namespace RuleEngine.Domain.Results;

public abstract class Result
{
    public static readonly NoOp NoOp = new();
}

public class NoOp : Result
{
    public override string ToString() => "NoOp";
}