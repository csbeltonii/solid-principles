namespace SOLID.Principles;

/// <summary>
/// Objects should be open for extension and closed for modification
/// </summary>
internal interface IOpenClosed
{
    void MethodToBeExtended();
}

/// <summary>
/// Extend with decorator pattern
/// </summary>
internal class OpenClosed : IOpenClosed
{
    public void MethodToBeExtended()
    {
        Console.WriteLine($"Writing from {typeof(OpenClosed)}");

    }
}

/// <summary>
/// Two classes 
/// </summary>
internal class Decorator : IOpenClosed
{
    protected readonly IOpenClosed _extendedClass;

    public Decorator(IOpenClosed extendedClass)
    {
        _extendedClass = extendedClass;
    }

    public void MethodToBeExtended()
    {
        _extendedClass.MethodToBeExtended();
        Console.WriteLine($"Writing from {typeof(Decorator)}");
    }
}