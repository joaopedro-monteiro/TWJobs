namespace TWJobs.Core.Repositories
{
    public interface IPagedRespository<TModel>
    {
        PagedResult<TModel> FindAll(PaginationOption options);
    }
}
