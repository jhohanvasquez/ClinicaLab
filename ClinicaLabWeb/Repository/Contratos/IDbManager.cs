using Dapper;
using System.Data;

namespace SistemaClinicaLab.Repository.Contratos
{
    public interface IDbManager<T> where T : class
    {
        Task<IEnumerable<T>> GetAllQueryString(string query, object parameters = null);

        Task<int> ExecuteStoreProcedure(string spName, DynamicParameters parameters);

        Task<IEnumerable<Object>> ExecuteReaderStoreProcedure(string spName, DataTable dataTable);

        Task<IEnumerable<Object>> ExecuteReaderStoreProcedure(string spName, object dataTable);

        Task<IEnumerable<Object>> ExecuteReaderStoreProcedure(string spName, DynamicParameters parameters);
    }
}
