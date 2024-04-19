namespace TWJobs.Core.Repositories
{
    public class PaginationOption(int pageNumber, int pageSize)
    {
        public int PageNumber { get; set; } = pageNumber < 1 ? 1 : pageNumber;
        public int PageSize { get; set; } = pageSize < 1 ? 10 : pageSize;
    }
}
