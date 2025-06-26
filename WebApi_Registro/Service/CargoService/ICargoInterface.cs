using WebApi_Registro.Models;

namespace WebApi_Registro.Service.CargoService
{
    public interface ICargoInterface
    {
        Task<ServiceResponse<List<CargoModel>>> GetCargos();
        Task<ServiceResponse<CargoModel>> GetCargoById(int id);
        Task<ServiceResponse<List<CargoModel>>> CreateCargo(CargoModel novoCargo);
        Task<ServiceResponse<List<CargoModel>>> UpdateCargo(CargoModel cargo);
        Task<ServiceResponse<List<CargoModel>>> DeleteCargo(int id);
    }
}
