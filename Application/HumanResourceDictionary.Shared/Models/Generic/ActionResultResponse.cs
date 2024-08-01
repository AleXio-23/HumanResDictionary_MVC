namespace HumanResourceDictionary.Shared.Models.Generic;

public class ActionResultResponse<T>
{
    public bool? Success { get; set; } = false;
    public bool? ErrorOccured { get; set; } = null;
    public string? ErrorMessage { get; set; } = null;

    public T? Data { get; set; } = default(T);


    public static ActionResultResponse<T> SuccessResult(T? data)
    {
        return new ActionResultResponse<T>()
        {
            Success = true,
            ErrorOccured = false,
            Data = data
        };
    }

    public static ActionResultResponse<T> ErrorResult(string? error)
    {
        return new ActionResultResponse<T>()
        {
            Success = false,
            ErrorOccured = true,
            ErrorMessage = error ?? "UNEXPECTED_ERROR_MESSAGE"
        };
    }
}