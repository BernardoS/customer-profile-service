public class CreateCustomerRequest
{
    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime BirthDate { get; set; }

    public string Profession { get; set; }

    public CreateCustomerInput MapToInput()
    {
        var mappedCustomer = new CreateCustomerInput()
        {
            Name = this.Name,
            BirthDate = this.BirthDate,
            Email = this.Email,
            Profession = this.Profession
        };
        
        return mappedCustomer;
    }
}