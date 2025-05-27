namespace Kralizek.Results;

// public class FailedResult<T, TError> : Result<T>
// {
//     public FailedResult(TError error)
//     {
//         TError = error;
//         IsSuccess = false;
//         IsError = true;
//     }

//     public TError Error { get; }
// }

// public sealed class NotFoundResult<T>(string? message = null) : FailedResult<T, string>(message ?? "Item not found");

// public sealed class NotAuthorizedResult<T>(string? message = null) : FailedResult<T, string>(message ?? "Access not authorized");

// public sealed class ConflictResult<T>(string message) : FailedResult<T, string>(message);