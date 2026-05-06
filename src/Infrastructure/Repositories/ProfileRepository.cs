using CustomerProfileService.Domain.Interfaces;

public class ProfileRepository : IProfileRepository
{
    private readonly AppDbContext _context;

    public ProfileRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Profile> AddAsync(Profile profile)
    {
        await _context.Profiles.AddAsync(profile);
        await _context.SaveChangesAsync();
        
        return profile;
    }

    public async Task<Profile?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new Exception("Profile Id cannot be empty");
        
        await _context.Profiles.FindAsync(id);
        
        return _context.Profiles.FirstOrDefault();
    }
}