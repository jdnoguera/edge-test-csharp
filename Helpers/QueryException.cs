namespace backend_test;

public class QueryException: Exception
{
    public QueryException(string message, Exception exception) : base(message, exception) { }
}