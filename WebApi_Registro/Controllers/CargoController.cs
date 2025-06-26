using Microsoft.AspNetCore.Mvc;
using WebApi_Registro.Models;
using WebApi_Registro.Service.CargoService;

namespace WebApi_Registro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoInterface _cargoInterface;
        public CargoController(ICargoInterface cargoInterface)
        {
            _cargoInterface = cargoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CargoModel>>>> GetCargos()
        {
            return Ok(await _cargoInterface.GetCargos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CargoModel>>> GetCargoById(int id)
        {
            return Ok(await _cargoInterface.GetCargoById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CargoModel>>>> CreateCargo(CargoModel novoCargo)
        {
            return Ok(await _cargoInterface.CreateCargo(novoCargo));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<CargoModel>>>> UpdateCargo(CargoModel cargo)
        {
            return Ok(await _cargoInterface.UpdateCargo(cargo));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<CargoModel>>>> DeleteCargo(int id)
        {
            return Ok(await _cargoInterface.DeleteCargo(id));
        }
    }
}
