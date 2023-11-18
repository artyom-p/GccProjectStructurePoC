using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Project.Api.Extensions;

public static class ValidationResultExtensions
{
    public static ValidationProblem ToValidationProblem(this ValidationResult result)
    {
        return TypedResults.ValidationProblem(result.ToDictionary());
    }
}