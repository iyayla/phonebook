namespace PhoneBook.Shared;

public class ApiResponse<T>
{
    public bool Success { get; set; }

    public T? Value { get; set; }

    public string[]? Errors { get; set; }

    public ApiResponse()
    {
        Success = true;
    }

    public ApiResponse(T? value)
    {
        Success = true;
        Value = value;
    }

    public ApiResponse(params string[] errors)
    {
        Success = false;
        Errors = errors;
    }

    public string? NormalizeErrors() =>
        Errors == null || Errors.Length == 0
            ? null
            : string.Join(" ", Errors);

    public static ApiResponse<T> SuccessResult() => new();

    public static ApiResponse<T> SuccessResult(T? value) => new(value);

    public static ApiResponse<T> ErrorResult(params string[] errors) => new(errors);
}