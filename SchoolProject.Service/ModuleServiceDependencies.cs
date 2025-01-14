using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.IServices;
using SchoolProject.Service.Services.Abstractions;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
