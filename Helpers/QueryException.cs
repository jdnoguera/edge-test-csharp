namespace edge_test_csharp;

public class QueryException: Exception
{
    public QueryException(string message, Exception exception) : base(message, exception) { }
}