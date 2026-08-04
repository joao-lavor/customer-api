namespace Customer.Api.DTOs
{
    public class RegisterCustomerRequest
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
