using WebApi_Registro.DataContext;
using WebApi_Registro.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi_Registro.Service.CargoService
{
    public class CargoService : ICargoInterface
    {
        private readonly ApplicationDbContext _context;
        public CargoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CargoModel>>> GetCargos()
        {
            var response = new ServiceResponse<List<CargoModel>>();
            response.Dados = await _context.Cargos.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<CargoModel>> GetCargoById(int id)
        {
            var response = new ServiceResponse<CargoModel>();
            response.Dados = await _context.Cargos.FindAsync(id);
            if (response.Dados == null)
            {
                response.Sucesso = false;
                response.Mensagem = "Cargo não encontrado";
            }
            return response;
        }

        public async Task<ServiceResponse<List<CargoModel>>> CreateCargo(CargoModel novoCargo)
        {
            var response = new ServiceResponse<List<CargoModel>>();
            _context.Cargos.Add(novoCargo);
            await _context.SaveChangesAsync();
            response.Dados = await _context.Cargos.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<List<CargoModel>>> UpdateCargo(CargoModel cargo)
        {
            var response = new ServiceResponse<List<CargoModel>>();
            _context.Cargos.Update(cargo);
            await _context.SaveChangesAsync();
            response.Dados = await _context.Cargos.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<List<CargoModel>>> DeleteCargo(int id)
        {
            var response = new ServiceResponse<List<CargoModel>>();
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null)
            {
                response.Sucesso = false;
                response.Mensagem = "Cargo não encontrado";
                return response;
            }
            _context.Cargos.Remove(cargo);
            await _context.SaveChangesAsync();
            response.Dados = await _context.Cargos.ToListAsync();
            return response;
        }
    }
}
