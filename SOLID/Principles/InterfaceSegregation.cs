namespace SOLID.Principles;

/// <summary>
/// Clients should not be forced to depend on interfaces they do not use.
/// </summary>
internal interface IInterfaceSegregation
{
    void DoSomething();
    void DoSomethingElse();
}

/// <summary>
/// Violates principle
/// </summary>
internal class BadService : IInterfaceSegregation
{
    public void DoSomething()
    {
        Console.Write("to do something");
    }

    public void DoSomethingElse()
    {
        Console.Write("can do something else.");
    }
}

internal class NeedsToDoSomethingViolation
{
    private readonly IInterfaceSegregation _interfaceSegregation;

    public NeedsToDoSomethingViolation(IInterfaceSegregation interfaceSegregation)
    {
        _interfaceSegregation = interfaceSegregation;
    }

    public void Execute()
    {
        Console.WriteLine("I only need ");
        _interfaceSegregation.DoSomething();
        Console.WriteLine(", but I can also call");
        _interfaceSegregation.DoSomethingElse();
    }
}

/// <summary>
/// Abides by principle
/// </summary>
internal interface IDoSomething
{
    void DoSomething();
}

internal interface IDoSomethingElse
{
    void DoSomethingElse();
}

internal class GoodService : IDoSomething, IDoSomethingElse
{
    public void DoSomething()
    {
        Console.WriteLine("I can only do something");
    }

    public void DoSomethingElse()
    {
        Console.WriteLine("I can only do something else.");
    }
}

internal class NeedsToDoSomething
{
    private readonly IDoSomething _doSomething;

    public NeedsToDoSomething(IDoSomething doSomething)
    {
        _doSomething = doSomething;
    }

    public void Execute()
    {
        _doSomething.DoSomething();
    }
}