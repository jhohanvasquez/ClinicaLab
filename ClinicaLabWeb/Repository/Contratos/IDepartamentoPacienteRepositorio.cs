using SistemaClinicaLab.Models;

namespace SistemaClinicaLab.Repository.Contratos
{
    public interface IDepartamentoPacienteRepositorio
    {
        Task<List<DepartamentoPaciente>> Lista();
    }
}
