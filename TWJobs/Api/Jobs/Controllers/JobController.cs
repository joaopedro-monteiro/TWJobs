using Microsoft.AspNetCore.Mvc;
using TWJobs.Api.Commons.Assemblers;
using TWJobs.Api.Commons.Dtos;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Api.Jobs.Services;

namespace TWJobs.Api.Jobs.Controllers;

[ApiController]
[Route("/api/jobs")]
public class JobController(IJobService jobService, IPagedAssembler<JobSummaryResponse> jobSummaryPagedAssembler, IAssembler<JobDetailResponse> jobDetailAssembler) : ControllerBase
{
    [HttpPost(Name = "CreateJob")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(JobDetailResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
    public IActionResult Create([FromBody] JobRequest jobRequest)
    {
        var body = jobService.Create(jobRequest);

        return CreatedAtAction(nameof(FindById), new { body.Id }, jobDetailAssembler.ToResource(body, HttpContext));
        //return Created($"/api/jobs/{body.Id}", body);
    }

    [HttpPut("{id}", Name = "UpdateJobById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobDetailResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public IActionResult Update(int id, JobRequest jobRequest)
    {
        var body = jobService.Update(id, jobRequest);

        return Ok(jobDetailAssembler.ToResource(body, HttpContext));
    }

    [HttpDelete("{id:int}", Name = "DeleteJobById")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public IActionResult Delete(int id)
    {
        jobService.Delete(id);
        return NoContent();
    }

    [HttpGet(Name = "FindAllJobs")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<JobSummaryResponse>))]
    public IActionResult FindAll(int page, int size)
    {
        var body = jobService.FindAll(page, size);
        
        return Ok(jobSummaryPagedAssembler.ToPagedResource(body, HttpContext));
    }

    [HttpGet("{id:int}", Name = "FindJobById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobDetailResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public IActionResult FindById([FromRoute] int id)
    {
        var body = jobService.FindById(id);

        return Ok(jobDetailAssembler.ToResource(body, HttpContext));
    }
}
