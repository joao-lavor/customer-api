namespace Customer.Api.DTOs
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Sobrenome { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
