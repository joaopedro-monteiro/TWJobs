using TWJobs.Api.Commons.Assemblers;
using TWJobs.Api.Commons.Dtos;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Api.Jobs.Assemblers
{
    public class JobSummaryAssembler(LinkGenerator linkGenerator) : IAssembler<JobSummaryResponse>
    {
        public JobSummaryResponse ToResource(JobSummaryResponse resource, HttpContext context)
        {
            var selfieLink = new LinkResponse(
                linkGenerator.GetUriByName(context, "FindJobById", new { resource.Id }),
                "GET",
                "self"
            );
            var updateLink = new LinkResponse(
                linkGenerator.GetUriByName(context, "UpdateJobById", new { resource.Id }), 
                "PUT", 
                "update"
            );
            var deleteLink = new LinkResponse(
                linkGenerator.GetUriByName(context, "DeleteJobById", new { resource.Id }),
                "DELETE",
                "delete"
            );
            resource.AddLinks(selfieLink, updateLink, deleteLink);

            return resource;
        }
    }
}
