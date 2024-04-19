using FluentValidation;
using TWJobs.Api.Commons.Assemblers;
using TWJobs.Api.Jobs.Assemblers;
using TWJobs.Api.Jobs.Dtos;

namespace TWJobs.Core.Config
{
    public static class AssemblersConfig
    {
        public static void RegisterAssembler(this IServiceCollection services)
        {
            services.AddScoped<IAssembler<JobSummaryResponse>, JobSummaryAssembler>();
            services.AddScoped<IAssembler<JobDetailResponse>, JobDetailAssembler>();
            services.AddScoped<IPagedAssembler<JobSummaryResponse>, JobSummaryPagedAssembler>();
        }
    }
}
