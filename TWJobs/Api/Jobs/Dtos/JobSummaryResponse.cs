using TWJobs.Api.Commons.Dtos;

namespace TWJobs.Api.Jobs.Dtos
{
    public class JobSummaryResponse : ResourceResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
