using System.Runtime.CompilerServices;
using TWJobs.Api.Commons.Dtos;

namespace TWJobs.Api.Commons.Assemblers
{
    public interface IAssembler<T> where T : ResourceResponse
    {
        T ToResource(T resource, HttpContext context);

        ICollection<T> ToResourceCollection(ICollection<T> resources, HttpContext context)
        {
            return resources.Select(r => ToResource(r, context)).ToList();
        }
    }
}
