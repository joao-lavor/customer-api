namespace Customer.Api.DTOs
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string SobreNome { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
