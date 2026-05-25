using CustomerProfileService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using CustomerProfileService.Domain.Interfaces;
using CustomerProfileService.Application.Services;
using CustomerProfileService.Infrastructure.Auth;
using CustomerProfileService.Infrastructure.Messaging;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<RabbitMqPublisher>();
        services.AddSingleton<IEventPublisher>(sp => sp.GetRequiredService<RabbitMqPublisher>());
        services.AddHostedService(sp => sp.GetRequiredService<RabbitMqPublisher>());
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<ICustomerService,CustomerService>();
        services.AddScoped<ICustomerService,CustomerService>();
        services.AddScoped<IFormService,FormService>();
        services.AddScoped<IProfileService,ProfileService>();
        services.AddScoped<ITokenService,TokenService>();
        services.AddScoped<IAuthService,AuthService>();
        
        
        services.AddScoped<ICustomerRepository,CustomerRepository>();
        services.AddScoped<IFormRepository,FormRepository>();
        services.AddScoped<IQuestionRepository,QuestionRepository>();
        services.AddScoped<IQuestionOptionRepository,QuestionOptionRepository>();
        services.AddScoped<IProfileRepository,ProfileRepository>();
        

        return services;
    }
}