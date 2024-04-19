namespace TWJobs.Api.Commons.Dtos
{
    public class ErrorResponse
    {
        public int Status { get; set; }
        public string? Error { get; set; }
        public string? Cause { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
