using WebApi_Registro.Models;

namespace WebApi_Registro.Service.DepartamentoService
{
    public interface IDepartamentoInterface
    {
        Task<ServiceResponse<List<DepartamentoModel>>> GetDepartamentos();
        Task<ServiceResponse<DepartamentoModel>> GetDepartamentoById(int id);
        Task<ServiceResponse<List<DepartamentoModel>>> CreateDepartamento(DepartamentoModel novoDepartamento);
        Task<ServiceResponse<List<DepartamentoModel>>> UpdateDepartamento(DepartamentoModel departamento);
        Task<ServiceResponse<List<DepartamentoModel>>> DeleteDepartamento(int id);
    }
}
