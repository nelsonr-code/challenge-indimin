using FluentValidation.Results;

namespace Indimin.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string>? Errors { get; }
    private const string DefaultMessage = "One or more validation failures have occurred.";
    
    public ValidationException() : base(DefaultMessage)
    {
        Errors = new List<string>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures.Select(f => f.ErrorMessage).ToList();
    }
}
