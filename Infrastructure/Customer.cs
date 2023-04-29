namespace edge_test_csharp.Infrastructure;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => FirstName + " " + LastName;
    public string DocumentNumber { get; set; }
}