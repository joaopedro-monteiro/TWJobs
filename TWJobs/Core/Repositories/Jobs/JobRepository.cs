using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TWJobs.Core.Data.Contexts;
using TWJobs.Core.Models;

namespace TWJobs.Core.Repositories.Jobs
{
    public class JobRepository : IJobRepository
    {
        private readonly TWJobsDbContext _context;

        public JobRepository(TWJobsDbContext context)
        {
            _context = context;
        }

        public Job Create(Job model)
        {
            _context.Jobs.Add(model);
            _context.SaveChanges();

            return model;
        }
        public Job Update(Job model)
        {
            _context.Jobs.Update(model);
            _context.SaveChanges();

            return model;
        }

        public void DeleteById(int id)
        {
            var job = _context.Jobs.Find(id);
            if(job != null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
            }
        }

        public bool ExistsById(int id)
        {
            bool result = _context.Jobs.Any(x => x.Id == id);
            return result;
        }

        public ICollection<Job> FindAll()
        {
            var result = _context.Jobs.AsNoTracking().ToList();
            return result;
        }

        public Job? FindById(int id)
        {           
            var result = _context.Jobs.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return result;           
        }

    }
}
