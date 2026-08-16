using Customer.Domain.Entities;
using Customer.Domain.Interfaces.Repositories;
using Customer.InfraStructure.Interfaces;

namespace Customer.InfraStructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMySqlDbConnection _connection;
        public CustomerRepository(IMySqlDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> RegisterCustomer(CustomerEntity entity)
        {
            var sqlQuery = @"INSERT INTO customers(id, name, lastName,cpf, birthDate, active)
                        values(@id, @name, @lastName, @cpf, @birthDate, @active)";

            var param = new
            {
                id = entity.Id,
                name = entity.Name,
                lastName = entity.LastName,
                cpf = entity.CPF,
                active = entity.Active,
                birthDate = entity.BirthDate,
            };

            var result = await _connection.ExecuteAsync(sqlQuery, param);
            return result > 0;
        }

        public async Task<bool> UpdateCustomer(CustomerEntity entity)
        {
            var sqlQuery = @"UPDATE customers
                        SET
                            name = @name,
                            lastName = @lastName,
                            cpf = @cpf, 
                            birthDate = @birthDate
                        WHERE id = @id";

            var param = new
            {
                id = entity.Id,
                name = entity.Name,
                lastName = entity.LastName,
                cpf = entity.CPF,
                active = entity.Active,
                birthDate = entity.BirthDate,
            };

            var result = await _connection.ExecuteAsync(sqlQuery, param);
            return result > 0;
        }

        public async Task<CustomerEntity> GetCustomerById(Guid id)
        {
            var sqlQuery = "SELECT id, name, lastName,cpf, birthDate, active FROM customers WHERE id = @id";
            var param = new { id };
            var result = await _connection.QueryFirstOrDefaultAsync<CustomerEntity>(sqlQuery, param);
            return result;
        }

        public async Task<IEnumerable<CustomerEntity>> GetCustomers()
        {
            var sqlQuery = "SELECT id, name, lastName,cpf, birthDate, active FROM customers";
            var result = await _connection.QueryAsync<CustomerEntity>(sqlQuery);
            return result.ToList();
        }

        public async Task<bool> DeleteCustomerById(Guid id)
        {
            var sqlQuery = "DELETE FROM customers where id = @id ";
            var result = await _connection.ExecuteAsync(sqlQuery, new { id });
            return result > 0;
        }
    }
}
