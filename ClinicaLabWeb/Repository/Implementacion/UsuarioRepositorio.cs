using Microsoft.EntityFrameworkCore;
using SistemaClinicaLab.Models;
using SistemaClinicaLab.Repository.Contratos;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dapper;
using System.Data;
using ExpressionExtensionSQL;



namespace SistemaClinicaLab.Repository.Implementacion
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DBPacientesLabContext _dbContext;

        public UsuarioRepositorio(DBPacientesLabContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null)
        {
            var query = $@"SELECT * FROM [Usuario]
                            {{where}}";

            using (var connection = _dbContext.CreateConnection())
            {
                var list = await connection.QueryAsync<Usuario>(query, filtro);
                return list;
            }
        }

        public async Task<IEnumerable<Usuario>> Crear(Usuario entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("NombreApellidos", entidad.NombreApellidos);
                    parameters.Add("Correo", entidad.Correo);
                    parameters.Add("idDepartamentoPaciente", entidad.idDepartamentoPaciente);
                    parameters.Add("Clave", entidad.Clave);
                    parameters.Add("EsActivo", true);

                    var result = await connection.QueryAsync<Usuario>("SP_CrearUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Usuario entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("idUsuario", entidad.IdUsuario);
                    parameters.Add("NombreApellidos", entidad.NombreApellidos);
                    parameters.Add("Correo", entidad.Correo);
                    parameters.Add("idDepartamentoPaciente", entidad.idDepartamentoPaciente);
                    parameters.Add("Clave", entidad.Clave);
                    parameters.Add("EsActivo", entidad.EsActivo);

                    var result = await connection.QueryAsync<Usuario>("SP_EditarUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }

            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Usuario entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("IdUsuario", entidad.IdUsuario);

                    var result = await connection.QueryAsync<Usuario>("SP_EliminarUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Usuario>> Lista()
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    return await connection.QueryAsync<Usuario>("SP_ListarUsuario", null, commandType: CommandType.StoredProcedure);

                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> Obtener(string email, string clave)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("email", email);
                parameters.Add("clave", clave);

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<Usuario>("SP_ObtenerUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Usuario> Obtener(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("idUsuario", id);

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<Usuario>("SP_ObtenerUsuarioId", parameters, commandType: CommandType.StoredProcedure);

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
