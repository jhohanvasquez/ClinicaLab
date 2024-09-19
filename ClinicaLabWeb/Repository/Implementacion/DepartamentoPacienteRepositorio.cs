using Microsoft.EntityFrameworkCore;
using SistemaClinicaLab.Models;
using SistemaClinicaLab.Repository.Contratos;
using Dapper;

namespace SistemaClinicaLab.Repository.Implementacion
{
    public class DepartamentoPacienteRepositorio : IDepartamentoPacienteRepositorio
    {
        private readonly DBPacientesLabContext _context;

        public DepartamentoPacienteRepositorio(DBPacientesLabContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<DepartamentoPaciente>> Lista()
        {
            try
            {
                var query = "SELECT * FROM DepartamentoPaciente";
                using (var connection = _context.CreateConnection())
                {
                    var companies = await connection.QueryAsync<DepartamentoPaciente>(query);
                    return companies.ToList();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
