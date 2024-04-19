using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation;
using TWJobs.Api.Commons.Dtos;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Api.Jobs.Mappers;
using TWJobs.Core.Exceptions;
using TWJobs.Core.Repositories;
using TWJobs.Core.Repositories.Jobs;

namespace TWJobs.Api.Jobs.Services;

public class JobService(IJobRepository jobRepository, IJobMapper jobMapper, IValidator<JobRequest> jobRequestValidator) : IJobService
{
    public JobDetailResponse Create(JobRequest jobRequest)
    {
        jobRequestValidator.ValidateAndThrow(jobRequest);

        var jobToCreate = jobMapper.ToModel(jobRequest);
        var createdJob = jobRepository.Create(jobToCreate);
        return jobMapper.ToDetailResponse(createdJob);
    }

    public JobDetailResponse Update(int id, JobRequest jobRequest)
    {
        jobRequestValidator.ValidateAndThrow(jobRequest);

        if (!jobRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Job with {id} not found");
        }

        var jobToUpdate = jobMapper.ToModel(jobRequest);
        jobToUpdate.Id = id;
        var updatedJob = jobRepository.Update(jobToUpdate);

        return jobMapper.ToDetailResponse(updatedJob);
    }
    public void Delete(int id)
    {
        jobRepository.DeleteById(id);   
    }
    public bool ExistsById(int id)
    {
        return jobRepository.ExistsById(id);
    }

    public ICollection<JobSummaryResponse> FindAll()
    {
        return jobRepository.FindAll().Select(jobMapper.ToSummaryResponse).ToList();
    }

    public PagedResponse<JobSummaryResponse> FindAll(int page, int size)
    {
        var paginationOption = new PaginationOption(page, size);
        var pagedResult = jobRepository.FindAll(paginationOption);
        return jobMapper.ToPagedSummaryResponse(pagedResult);
    }

    public JobDetailResponse FindById(int id)
    {
        var job = jobRepository.FindById(id);

        if(job == null)
            throw new ModelNotFoundException($"Job with {id} not found");

        return jobMapper.ToDetailResponse(job!)/* ?? throw new ModelNotFoundException($"Job with {id} not found")*/;
    }
}
