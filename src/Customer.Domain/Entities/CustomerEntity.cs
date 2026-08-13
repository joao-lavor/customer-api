namespace Customer.Domain.Entities
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }


        public CustomerEntity NewCustomer(string name, string lastName, string cpf, DateTime birthDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            CPF = cpf;
            BirthDate = birthDate;
            return this;
        }

        public CustomerEntity UpdateCustomer(Guid id,string name, string lastName, string cpf, DateTime birthDate)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            CPF = cpf;
            BirthDate = birthDate;
            return this;
        }
    }
}
