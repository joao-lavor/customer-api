using Customer.InfraStructure.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace Customer.InfraStructure.Repositories.Base
{
    public class MySqlDbConnection : IMySqlDbConnection
    {
        private readonly string _connectionString;
        public MySqlDbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType? commandType = null, int? commandTimeOut = 6000000)
        {
            using var sqlConnection = new MySqlConnection(_connectionString);
            return await sqlConnection.QueryAsync<T>(sql: sql, param: param, commandType: commandType, commandTimeout: commandTimeOut);
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CommandType? commandType = null, int? commandTimeOut = 6000000)
        {
            using var sqlConnection = new MySqlConnection(_connectionString);
            return await sqlConnection.QueryFirstOrDefaultAsync<T>(sql: sql, param: param, commandType: commandType, commandTimeout: commandTimeOut);
        }
        public async Task<int> ExecuteAsync<T>(string sql, object param = null, CommandType? commandType = null, int? commandTimeOut = 6000000)
        {
            using var sqlConnection = new MySqlConnection(_connectionString);
            return await sqlConnection.ExecuteAsync(sql: sql, param: param, commandType: commandType, commandTimeout: commandTimeOut);
        }

    }
}
