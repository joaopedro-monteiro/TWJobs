namespace TWJobs.Api.Commons.Dtos;

public class ValidationErrorResponse : ErrorResponse
{
    public IDictionary<string, string[]>? Errors { get; set; }
}

