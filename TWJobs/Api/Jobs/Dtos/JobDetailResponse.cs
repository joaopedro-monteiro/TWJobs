using TWJobs.Api.Commons.Dtos;

namespace TWJobs.Api.Jobs.Dtos
{
    public class JobDetailResponse : ResourceResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public decimal Salary { get; set; }
        public ICollection<string>? Requirements { get; set; }
    }
}
