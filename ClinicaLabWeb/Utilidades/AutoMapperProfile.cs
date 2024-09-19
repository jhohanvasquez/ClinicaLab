using AutoMapper;
using SistemaClinicaLab.DTOs;
using SistemaClinicaLab.Models;
using System.Globalization;

namespace SistemaClinicaLab.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           

            #region DepartamentoPaciente
            CreateMap<DepartamentoPaciente, DepartamentoPacienteDTO>().ReverseMap();
            #endregion DepartamentoPaciente

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                    destino.DescripcionDepartamento,
                    opt => opt.MapFrom(origen => origen.IdDepartamentoPacienteNavigation.DescripcionDepartamento)
                );

            CreateMap<UsuarioDTO, Usuario>()
            .ForMember(destino =>
                destino.IdDepartamentoPacienteNavigation,
                opt => opt.Ignore()
            );
           
            #endregion Usuario

          


        }

    }
}
