namespace TWJobs.Core.Exceptions;

public class ModelNotFoundException(string? message = "Model not found") : Exception(message);
