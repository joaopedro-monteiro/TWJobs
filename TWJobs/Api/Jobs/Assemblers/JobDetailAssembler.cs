using TWJobs.Api.Commons.Assemblers;
using TWJobs.Api.Commons.Dtos;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Api.Jobs.Assemblers
{
    public class JobDetailAssembler(LinkGenerator linkGenerator) : IAssembler<JobDetailResponse>
    {
        public JobDetailResponse ToResource(JobDetailResponse resource, HttpContext context)
        {
            var selfieLink = new LinkResponse(
                linkGenerator.GetUriByName(context, "FindJobById", new { Id = resource.Id }),
                "GET",
                "self"
            );
            var updateLink = new LinkResponse(
                linkGenerator.GetUriByName(context, "UpdateJobById", new { Id = resource.Id }),
                "PUT",
                "update"
            );
            var deleteLink = new LinkResponse(
                linkGenerator.GetUriByName(context, "DeleteJobById", new { Id = resource.Id }),
                "DELETE",
                "delete"
            );
            resource.AddLinks(selfieLink, updateLink, deleteLink);

            return resource;
        }
    }
}
