using Kralizek;
using Kralizek.Results;

var operationResult = DoSomeOperation();

var result = operationResult switch
{
    SuccessResult<int> { Value: > 5 } => "Very successful",
    SuccessResult<int> => "Successful",
    FailedResult<int, string> failed => $"Failed: {failed.Error}",
    _ => throw new NotSupportedException()
};

Console.WriteLine($"The result was {result}");

return;

static Result<int> DoSomeOperation()
{
    var chance = Random.Shared.Next(0, 10);

    if (chance < 2)
    {
        return TypedResult.Fail<int>("Not good enough");
    }

    return chance;
}