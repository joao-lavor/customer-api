namespace Customer.Domain.Entities
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }


        public CustomerEntity NewCustomer(string name, string sobreNome, string cpf, DateTime birthDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            SobreNome = sobreNome;
            CPF = cpf;
            BirthDate = birthDate;
            return this;
        }

        public CustomerEntity UpdateCustomer(Guid id,string name, string sobreNome, string cpf, DateTime birthDate)
        {
            Id = id;
            Name = name;
            SobreNome = sobreNome;
            CPF = cpf;
            BirthDate = birthDate;
            return this;
        }
    }
}
