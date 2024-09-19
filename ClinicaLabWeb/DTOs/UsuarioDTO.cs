namespace SistemaClinicaLab.DTOs
{

    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string? NombreApellidos { get; set; }
        public string? Correo { get; set; }
        public int idDepartamentoPaciente { get; set; }
        public string? DescripcionDepartamento { get; set; }
        public string? Clave { get; set; }

    }
}
