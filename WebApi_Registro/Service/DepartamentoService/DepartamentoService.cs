using WebApi_Registro.DataContext;
using WebApi_Registro.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi_Registro.Service.DepartamentoService
{
    public class DepartamentoService : IDepartamentoInterface
    {
        private readonly ApplicationDbContext _context;
        public DepartamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<DepartamentoModel>>> GetDepartamentos()
        {
            var response = new ServiceResponse<List<DepartamentoModel>>();
            response.Dados = await _context.Departamentos.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<DepartamentoModel>> GetDepartamentoById(int id)
        {
            var response = new ServiceResponse<DepartamentoModel>();
            response.Dados = await _context.Departamentos.FindAsync(id);
            if (response.Dados == null)
            {
                response.Sucesso = false;
                response.Mensagem = "Departamento não encontrado";
            }
            return response;
        }

        public async Task<ServiceResponse<List<DepartamentoModel>>> CreateDepartamento(DepartamentoModel novoDepartamento)
        {
            var response = new ServiceResponse<List<DepartamentoModel>>();
            _context.Departamentos.Add(novoDepartamento);
            await _context.SaveChangesAsync();
            response.Dados = await _context.Departamentos.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<List<DepartamentoModel>>> UpdateDepartamento(DepartamentoModel departamento)
        {
            var response = new ServiceResponse<List<DepartamentoModel>>();
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();
            response.Dados = await _context.Departamentos.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<List<DepartamentoModel>>> DeleteDepartamento(int id)
        {
            var response = new ServiceResponse<List<DepartamentoModel>>();
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                response.Sucesso = false;
                response.Mensagem = "Departamento não encontrado";
                return response;
            }
            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            response.Dados = await _context.Departamentos.ToListAsync();
            return response;
        }
    }
}
