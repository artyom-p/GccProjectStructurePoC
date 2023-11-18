using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Project.Api.Extensions;

public static class ResultExtensions
{
    public static ValidationProblem ToValidationProblem<T>(this Result<T> result)
    {
        var errors = result.Errors
            .Select(e =>
            {
                var key = e.Message;
                var reasons = e.Reasons
                    .Select(r => r.Message)
                    .ToArray();
                return new KeyValuePair<string, string[]>(key, reasons);
            })
            .ToDictionary(k => k.Key, v => v.Value);
        
        
        return TypedResults.ValidationProblem(errors);
    }
}