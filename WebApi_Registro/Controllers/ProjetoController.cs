using Microsoft.AspNetCore.Mvc;
using WebApi_Registro.Models;
using WebApi_Registro.Service.ProjetoService;

namespace WebApi_Registro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoInterface _projetoInterface;
        public ProjetoController(IProjetoInterface projetoInterface)
        {
            _projetoInterface = projetoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProjetoModel>>>> GetProjetos()
        {
            return Ok(await _projetoInterface.GetProjetos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProjetoModel>>> GetProjetoById(int id)
        {
            return Ok(await _projetoInterface.GetProjetoById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProjetoModel>>>> CreateProjeto(ProjetoModel novoProjeto)
        {
            return Ok(await _projetoInterface.CreateProjeto(novoProjeto));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ProjetoModel>>>> UpdateProjeto(ProjetoModel projeto)
        {
            return Ok(await _projetoInterface.UpdateProjeto(projeto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ProjetoModel>>>> DeleteProjeto(int id)
        {
            return Ok(await _projetoInterface.DeleteProjeto(id));
        }
    }
}
