using WebApi_Registro.DataContext;
using WebApi_Registro.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi_Registro.Service.ProjetoService
{
    public class ProjetoService : IProjetoInterface
    {
        private readonly ApplicationDbContext _context;
        public ProjetoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProjetoModel>>> GetProjetos()
        {
            var response = new ServiceResponse<List<ProjetoModel>>();
            response.Dados = await _context.Projetos.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<ProjetoModel>> GetProjetoById(int id)
        {
            var response = new ServiceResponse<ProjetoModel>();
            response.Dados = await _context.Projetos.FindAsync(id);
            if (response.Dados == null)
            {
                response.Sucesso = false;
                response.Mensagem = "Projeto não encontrado";
            }
            return response;
        }

        public async Task<ServiceResponse<List<ProjetoModel>>> CreateProjeto(ProjetoModel novoProjeto)
        {
            var response = new ServiceResponse<List<ProjetoModel>>();
            _context.Projetos.Add(novoProjeto);
            await _context.SaveChangesAsync();
            response.Dados = await _context.Projetos.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<List<ProjetoModel>>> UpdateProjeto(ProjetoModel projeto)
        {
            var response = new ServiceResponse<List<ProjetoModel>>();
            _context.Projetos.Update(projeto);
            await _context.SaveChangesAsync();
            response.Dados = await _context.Projetos.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<List<ProjetoModel>>> DeleteProjeto(int id)
        {
            var response = new ServiceResponse<List<ProjetoModel>>();
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                response.Sucesso = false;
                response.Mensagem = "Projeto não encontrado";
                return response;
            }
            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();
            response.Dados = await _context.Projetos.ToListAsync();
            return response;
        }
    }
}
