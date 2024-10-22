namespace FIAP.PhaseOne.Shared.ValueResult;

public class ValueResult
{
    public bool Succeeded { get; protected set; }
    public IReadOnlyCollection<FailureDetail> Failures => _failures.AsReadOnly();
    protected FailureDetail[] _failures = [];

    public static ValueResult Success() => new() { Succeeded = true };
    
    public static ValueResult Failure(string message) => new()
    {
        Succeeded = false, 
        _failures = [ new FailureDetail(string.Empty, message) ]
    };
    
    public static ValueResult Failure(FailureDetail[] failures) => new() { Succeeded = false, _failures = failures };
    
    public static ValueResult Failure(IEnumerable<FailureDetail> failures) => 
        new()
        {
            Succeeded = false, _failures = failures.ToArray()
        };
    
    public static ValueResult Failure((string Code, string Message)[] failures) => 
        new()
        {
            Succeeded = false, 
            _failures = failures.Select(x => new FailureDetail(x.Code, x.Message)).ToArray()
        };
}

public class ValueResult<T> : ValueResult
{
    public T Value { get; private set; }

    public static ValueResult<T> Success(T value) => new() { Succeeded = true, Value = value };
    
    public new static ValueResult<T> Failure(FailureDetail[] failures) => new() { Succeeded = false, _failures = failures };
    public static ValueResult<T> Failure(string message) => new()
    {
        Succeeded = false, 
        _failures = [ new FailureDetail(string.Empty, message) ]
    };
}

public record FailureDetail(string Code, string Message);