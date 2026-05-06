public class Customer
{
    public Guid Id {get; private set;}
    public string? Name {get; private set;}
    public string? Email {get;private set;}
    public DateTime BirthDate {get;private set;}
    public string? Profession {get;private set;}
    public DateTime CreatedAt {get;private set;}
    public DateTime UpdatedAt{get; private set;}
    
    public List<Profile> Profiles { get; private set; } = new();

    public Customer()
    {
    }

    public Customer(string name, string email, DateTime birthdate, string profession)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        BirthDate = birthdate;
        Profession = profession;
    }

    public override string ToString()
    {
        return @$"--------------------------------
                  Id: {Id}\n
                  Nome: {Name}\n 
                  Email: {Email}\n,
                  Birthdate: {BirthDate.ToString("dd/MM/YYYY")}\n
                  Profession: {Profession}\n
                  -------------------------------";
    }
}