namespace RuleEngine.Domain.Results
{
    public class Conclusion : Result
    {
        public Conclusion(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public override string ToString()
        {
            return Message;
        }
    }
}