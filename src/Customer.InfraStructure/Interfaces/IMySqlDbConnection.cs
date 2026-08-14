using System.Data;

namespace Customer.InfraStructure.Interfaces
{
    public interface IMySqlDbConnection
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType? commandType = null, int? commandTimeOut = 6000000);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CommandType? commandType = null, int? commandTimeOut = 6000000);
        Task<int> ExecuteAsync<T>(string sql, object param = null, CommandType? commandType = null, int? commandTimeOut = 6000000);

    }
}

