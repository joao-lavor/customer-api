namespace Customer.Api.DTOs
{
    public class UpdateCustomerRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Sobrenome { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
