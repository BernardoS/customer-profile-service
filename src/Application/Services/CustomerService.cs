public class CustomerService : ICustomerService
{
    public Customer CreateCustomer(CreateCustomerInput request)
    {
        try
        {
            if(request.Name.Length < 3)
            {
                throw new Exception("Nome de usuário muito curto, digite um nome acima de 3 caracteres");
            }


            var createdCustomer = new Customer(
                name: request.Name,
                email: request.Email,
                birthdate: request.BirthDate,
                profession: request.Profession
            );
            
            Console.WriteLine(createdCustomer);

            return createdCustomer;
        }
        catch (System.Exception)
        {
            throw ;
        }
    }

    public Customer GetCustomer(Guid id)
    {
        throw new NotImplementedException();
    }
}