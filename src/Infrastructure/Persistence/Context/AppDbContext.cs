using Microsoft.EntityFrameworkCore;

public class AppDbContext:DbContext
{
    public DbSet<Customer> Customers {get;set;}
    public DbSet<Profile> Profiles {get;set;}
    public DbSet<Question> Questions {get;set;}
    public DbSet<QuestionOption> QuestionOptions {get;set;}
    public DbSet<QuestionForm> QuestionForm {get;set;}
    public DbSet<FormAnswer> FormAnswers {get;set;}
    
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }
}