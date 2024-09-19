using System;
using System.Collections.Generic;

namespace SistemaClinicaLab.Models
{
    public partial class DepartamentoPaciente
    {
        public DepartamentoPaciente()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int idDepartamentoPaciente { get; set; }
        public string? DescripcionDepartamento { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
