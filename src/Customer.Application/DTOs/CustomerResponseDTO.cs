namespace Customer.Application.DTOs
{
    public class CustomerResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
