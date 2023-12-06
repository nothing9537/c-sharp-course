public class TransactionData
{
    public string Sender { get; init; }
    public string Receiver { get; init; }
    public decimal Amount { get; init; }
}

public class InvalidTransactionException : Exception
{
    public TransactionData TransactionData { get; }
    public InvalidTransactionException() { }
    public InvalidTransactionException(string message) : base(message) { }
    public InvalidTransactionException(string message, Exception innerException) : base(message, innerException) { }
    public InvalidTransactionException(string message, TransactionData transatctionData): base(message)
    {
        TransactionData = transatctionData;
    }
    public InvalidTransactionException(string message, TransactionData transatctionData, Exception innerException): base(message, innerException) { }
}