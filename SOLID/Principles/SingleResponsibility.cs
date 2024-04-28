namespace SOLID.Principles;

internal record Customer(string Id, string Name);

/// <summary>
/// A class should have only one reason to change.
/// <see cref="object"/> type used for brevity.
/// </summary>
internal interface ISingleResponsibility
{
    /// <summary>
    /// Retrieves an entity by ID
    /// </summary>
    /// <param name="id"></param>
    Customer? GetWithId(string id);

    /// <summary>
    /// Retrieves an entity by a specific filter criteria
    /// </summary>
    /// <param name="filter"></param>
    IEnumerable<Customer> GetWithFilter(string filter);

    /// <summary>
    /// Retrieves all entities and adds to the name property
    /// </summary>
    /// <param name="appendedValue"></param>
    /// <returns></returns>
    IEnumerable<Customer> GetWithUpdatedName(string appendedValue);
}

internal class SingleResponsibility : ISingleResponsibility
{
    private readonly List<Customer> _data = new()
    {
       new Customer("1", "Customer1"),
       new Customer("2", "Customer2")
    };

    public Customer? GetWithId(string id) => _data.FirstOrDefault(customer => customer.Id == id);

    public IEnumerable<Customer> GetWithFilter(string filter) => _data.Where(customer => customer.Id.Contains(filter) || customer.Name.Contains(filter));

    /// <summary>
    /// Violates single responsibility and CQS
    /// </summary>
    /// <param name="appendedValue"></param>
    /// <returns></returns>
    public IEnumerable<Customer> GetWithUpdatedName(string appendedValue) =>
        _data.Select(
            customer => customer with
            {
                Name = customer.Name + appendedValue
            }
        );
}