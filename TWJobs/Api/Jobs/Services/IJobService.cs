using TWJobs.Api.Commons.Dtos;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Core.Models;

namespace TWJobs.Api.Jobs.Services
{
    public interface IJobService
    {
        JobDetailResponse Create(JobRequest jobRequest);
        JobDetailResponse Update(int id, JobRequest jobRequest);
        void Delete(int id);
        ICollection<JobSummaryResponse> FindAll();
        PagedResponse<JobSummaryResponse> FindAll(int page, int size);
        JobDetailResponse FindById(int id);        
    }
}
