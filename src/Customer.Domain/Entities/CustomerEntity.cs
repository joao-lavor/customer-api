using System.ComponentModel.Design;

namespace Customer.Domain.Entities
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public CustomerEntity NewCustomer(string name, string lastName, string cpf, DateTime birthDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            CPF = cpf;
            BirthDate = birthDate;
            Active = true;
            return this;
        }

        public CustomerEntity UpdateCustomer(Guid id,string name, string lastName, string cpf, DateTime birthDate, bool active)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            CPF = cpf;
            BirthDate = birthDate;
            Active = active;
            return this;
        }
    }
}
