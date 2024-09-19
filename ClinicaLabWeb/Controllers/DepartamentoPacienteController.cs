using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaClinicaLab.DTOs;
using SistemaClinicaLab.Repository.Contratos;
using SistemaClinicaLab.Utilidades;

namespace SistemaClinicaLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoPacienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDepartamentoPacienteRepositorio _DepartamentoPacienteRepositorio;
        public DepartamentoPacienteController(IDepartamentoPacienteRepositorio DepartamentoPacienteRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _DepartamentoPacienteRepositorio = DepartamentoPacienteRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            Response<List<DepartamentoPacienteDTO>> _response = new Response<List<DepartamentoPacienteDTO>>();

            try
            {
                List<DepartamentoPacienteDTO> _listaDepartamentoPacientes = new List<DepartamentoPacienteDTO>();
                _listaDepartamentoPacientes = _mapper.Map<List<DepartamentoPacienteDTO>>(await _DepartamentoPacienteRepositorio.Lista());

                if (_listaDepartamentoPacientes.Count > 0)
                    _response = new Response<List<DepartamentoPacienteDTO>>() { status = true, msg = "ok", value = _listaDepartamentoPacientes };
                else
                    _response = new Response<List<DepartamentoPacienteDTO>>() { status = false, msg = "sin resultados", value = null };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<DepartamentoPacienteDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
