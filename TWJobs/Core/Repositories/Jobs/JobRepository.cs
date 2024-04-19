using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TWJobs.Core.Data.Contexts;
using TWJobs.Core.Models;

namespace TWJobs.Core.Repositories.Jobs
{
    public class JobRepository(TWJobsDbContext context) : IJobRepository
    {
        public Job Create(Job model)
        {
            context.Jobs.Add(model);
            context.SaveChanges();

            return model;
        }
        public Job Update(Job model)
        {
            context.Jobs.Update(model);
            context.SaveChanges();

            return model;
        }

        public void DeleteById(int id)
        {
            var job = context.Jobs.Find(id);
            if (job == null) return;
            context.Jobs.Remove(job);
            context.SaveChanges();
        }

        public bool ExistsById(int id)
        {
            var result = context.Jobs.Any(x => x.Id == id);
            return result;
        }

        public ICollection<Job> FindAll()
        {
            var result = context.Jobs.AsNoTracking().ToList();
            return result;
        }

        public Job? FindById(int id)
        {           
            var result = context.Jobs.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return result;           
        }

        public PagedResult<Job> FindAll(PaginationOption options)
        {
            var totalElements = context.Jobs.Count();
            var items = context.Jobs
                .Skip((options.PageNumber - 1) * options.PageSize)
                .Take(options.PageSize)
                .ToList();
            return new PagedResult<Job>(items, options.PageNumber, options.PageSize, totalElements);
        }
    }
}
