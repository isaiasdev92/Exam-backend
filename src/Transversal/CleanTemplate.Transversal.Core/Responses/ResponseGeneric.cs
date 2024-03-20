using FluentValidation.Results;

namespace CleanTemplate.Transversal.Core;

public class ResponseGeneric<T>
{
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}
