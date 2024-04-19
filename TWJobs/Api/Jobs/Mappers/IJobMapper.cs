using TWJobs.Api.Commons.Dtos;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Core.Models;
using TWJobs.Core.Repositories;

namespace TWJobs.Api.Jobs.Mappers
{
    public interface IJobMapper
    {
        JobSummaryResponse ToSummaryResponse(Job job);
        JobDetailResponse ToDetailResponse(Job job);
        PagedResponse<JobSummaryResponse> ToPagedSummaryResponse(PagedResult<Job> pagesResult);
        Job ToModel(JobRequest jobRequest);
    }
}
