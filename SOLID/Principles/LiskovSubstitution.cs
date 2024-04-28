namespace SOLID.Principles;

/// <summary>
/// Objects of a superclass should be replaceable by a subclass without breaking the application
/// </summary>
internal interface ILiskovSubstitution
{
    void Execute(IEnumerable<Customer> values);
}

/// <summary>
/// Example with interfaces
/// </summary>
internal static class SubstitutionData
{
    public static List<Customer> Data = new()
    {
        new Customer("1", "Customer1"),
        new Customer("2", "Customer2")
    };
}

internal class CustomerService : ILiskovSubstitution
{
    public void Execute(IEnumerable<Customer> values)
    {
        foreach (var customer in values)
        {
            Console.WriteLine(customer);
        }
    }
}

internal class CustomerServiceConsumer
{
    private readonly CustomerService _customerService;

    public CustomerServiceConsumer(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public void ExecuteExample()
    {
        var collection = (ICollection<Customer>) SubstitutionData.Data;
        var readOnlyList = (IReadOnlyList<Customer>) SubstitutionData.Data;
        var listInterface = (IList<Customer>) SubstitutionData.Data;

        _customerService.Execute(collection);
        _customerService.Execute(readOnlyList);
        _customerService.Execute(listInterface);
        _customerService.Execute(SubstitutionData.Data);
    }
}