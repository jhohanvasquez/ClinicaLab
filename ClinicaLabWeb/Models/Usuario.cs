using System;
using System.Collections.Generic;

namespace SistemaClinicaLab.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? NombreApellidos { get; set; }
        public string? Correo { get; set; }
        public int? idDepartamentoPaciente { get; set; }
        public string? Clave { get; set; }
        public bool? EsActivo { get; set; }
        public virtual DepartamentoPaciente? IdDepartamentoPacienteNavigation { get; set; }
    }
}
