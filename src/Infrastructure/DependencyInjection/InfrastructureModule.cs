using Microsoft.EntityFrameworkCore;
using CustomerProfileService.Domain.Interfaces;
using CustomerProfileService.Application.Services;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<ICustomerService,CustomerService>();
        services.AddScoped<ICustomerRepository,CustomerRepository>();
        services.AddScoped<IFormService,FormService>();
        services.AddScoped<IFormRepository,FormRepository>();
        services.AddScoped<IQuestionRepository,QuestionRepository>();
        services.AddScoped<IQuestionOptionRepository,QuestionOptionRepository>();

        return services;
    }
}