using WebApi_Registro.Models;

namespace WebApi_Registro.Service.ProjetoService
{
    public interface IProjetoInterface
    {
        Task<ServiceResponse<List<ProjetoModel>>> GetProjetos();
        Task<ServiceResponse<ProjetoModel>> GetProjetoById(int id);
        Task<ServiceResponse<List<ProjetoModel>>> CreateProjeto(ProjetoModel novoProjeto);
        Task<ServiceResponse<List<ProjetoModel>>> UpdateProjeto(ProjetoModel projeto);
        Task<ServiceResponse<List<ProjetoModel>>> DeleteProjeto(int id);
    }
}
