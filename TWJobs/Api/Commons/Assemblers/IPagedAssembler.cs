using TWJobs.Api.Commons.Dtos;

namespace TWJobs.Api.Commons.Assemblers
{
    public interface IPagedAssembler<T> where T : ResourceResponse
    {
        PagedResponse<T> ToPagedResource(PagedResponse<T> pagedResponse, HttpContext context);
    }
}
