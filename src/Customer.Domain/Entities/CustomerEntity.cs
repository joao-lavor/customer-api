namespace Customer.Domain.Entities
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
