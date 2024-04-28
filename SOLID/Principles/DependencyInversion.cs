namespace SOLID.Principles;

// High level modules should not depend on low level modules.
internal interface IDependencyInversion
{
    Customer Get(string id);
}

/// <summary>
/// Violates principle
/// </summary>
internal class CustomerQueryServiceViolation
{
    public Customer Get(string id) => new("1", "name");
}

internal class QueryServiceConsumerViolation
{
    private readonly CustomerQueryServiceViolation _customerQueryService;

    public QueryServiceConsumerViolation()
    {
        _customerQueryService = new CustomerQueryServiceViolation();
    }

    internal Customer GetCustomer(string id) => _customerQueryService.Get(id);
}

/// <summary>
/// Fulfills principle by only relying on abstractions
/// </summary>
internal class CustomerQueryService : IDependencyInversion
{
    public Customer Get(string id) => new("1", "name");
}

internal class QueryServiceConsumer
{
    private readonly IDependencyInversion _customerQueryService;

    public QueryServiceConsumer(IDependencyInversion customerQueryService)
    {
        _customerQueryService = customerQueryService;
    }

    internal Customer GetCustomer(string id) => _customerQueryService.Get(id);
}

/// <summary>
/// Also violates principle
/// </summary>
internal static class RandomStringGenerator
{
    internal static string Generate() => Guid.NewGuid().ToString()[..5];
}

/// <summary>
/// Static classes are considered dependencies
/// </summary>
internal class CreateCustomerService
{
    internal Customer Create() => new("id", RandomStringGenerator.Generate());
}