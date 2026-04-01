using Microsoft.EntityFrameworkCore;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICustomerService,CustomerService>();

        services.AddScoped<ICustomerRepository,CustomerRepository>();

        return services;
    }
}