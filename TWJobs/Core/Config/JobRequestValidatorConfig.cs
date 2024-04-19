using FluentValidation;
using TWJobs.Api.Jobs.Dtos;
using TWJobs.Api.Jobs.Validators;

namespace TWJobs.Core.Config
{
    public static class JobRequestValidatorConfig
    {
        public static void RegisterJobRequestValidator(this IServiceCollection services)
        {
            services.AddScoped<IValidator<JobRequest>, JobRequestValidator>();
        }
    }
}
