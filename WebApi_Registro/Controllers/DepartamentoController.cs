using Microsoft.AspNetCore.Mvc;
using WebApi_Registro.Models;
using WebApi_Registro.Service.DepartamentoService;

namespace WebApi_Registro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoInterface _departamentoInterface;
        public DepartamentoController(IDepartamentoInterface departamentoInterface)
        {
            _departamentoInterface = departamentoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DepartamentoModel>>>> GetDepartamentos()
        {
            return Ok(await _departamentoInterface.GetDepartamentos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<DepartamentoModel>>> GetDepartamentoById(int id)
        {
            return Ok(await _departamentoInterface.GetDepartamentoById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<DepartamentoModel>>>> CreateDepartamento(DepartamentoModel novoDepartamento)
        {
            return Ok(await _departamentoInterface.CreateDepartamento(novoDepartamento));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<DepartamentoModel>>>> UpdateDepartamento(DepartamentoModel departamento)
        {
            return Ok(await _departamentoInterface.UpdateDepartamento(departamento));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<DepartamentoModel>>>> DeleteDepartamento(int id)
        {
            return Ok(await _departamentoInterface.DeleteDepartamento(id));
        }
    }
}
