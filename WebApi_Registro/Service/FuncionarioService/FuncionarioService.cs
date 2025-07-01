using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi_Registro.DataContext;
using WebApi_Registro.Models;
using WebApi_Registro.DTOs;


namespace WebApi_Registro.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioDTO novoFuncionario)
        {
            var serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                var departamento = await _context.Departamentos.FindAsync(novoFuncionario.DepartamentoId);
                var cargo = await _context.Cargos.FindAsync(novoFuncionario.CargoId);
                ProjetoModel projeto = null;

                if (novoFuncionario.ProjetoId.HasValue)
                    projeto = await _context.Projetos.FindAsync(novoFuncionario.ProjetoId.Value);

                if (departamento == null || cargo == null || (novoFuncionario.ProjetoId.HasValue && projeto == null))
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem =
                        departamento == null ? "Departamento inválido!" :
                        cargo == null ? "Cargo inválido!" :
                        "Projeto inválido!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                var funcionario = new FuncionarioModel
                {
                    Nome = novoFuncionario.Nome,
                    Sobrenome = novoFuncionario.Sobrenome,
                    Ativo = novoFuncionario.Ativo,
                    Turno = novoFuncionario.Turno,
                    DepartamentoId = novoFuncionario.DepartamentoId,
                    CargoId = novoFuncionario.CargoId,
                    ProjetoId = novoFuncionario.ProjetoId,
                    DataDeCriacao = DateTime.Now.ToLocalTime(),
                    DataDeAlteracao = DateTime.Now.ToLocalTime()
                };

                _context.Funcionarios.Add(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Funcionarios
                    .Include(f => f.Departamento)
                    .Include(f => f.Cargo)
                    .Include(f => f.Projeto)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado!";
                    serviceResponse.Sucesso = false;
                }
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();
            try
            {
                FuncionarioModel funcionario = await _context.Funcionarios
                    .Include(f => f.Departamento)
                    .Include(f => f.Cargo)
                    .Include(f => f.Projeto)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = funcionario;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioDTO editadoFuncionario)
        {
            var serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == editadoFuncionario.Id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não encontrado!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                var departamento = await _context.Departamentos.FindAsync(editadoFuncionario.DepartamentoId);
                var cargo = await _context.Cargos.FindAsync(editadoFuncionario.CargoId);
                ProjetoModel projeto = null;

                if (editadoFuncionario.ProjetoId.HasValue)
                    projeto = await _context.Projetos.FindAsync(editadoFuncionario.ProjetoId.Value);

                if (departamento == null || cargo == null || (editadoFuncionario.ProjetoId.HasValue && projeto == null))
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem =
                        departamento == null ? "Departamento inválido!" :
                        cargo == null ? "Cargo inválido!" :
                        "Projeto inválido!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                funcionario.Nome = editadoFuncionario.Nome;
                funcionario.Sobrenome = editadoFuncionario.Sobrenome;
                funcionario.Ativo = editadoFuncionario.Ativo;
                funcionario.Turno = editadoFuncionario.Turno;
                funcionario.DepartamentoId = editadoFuncionario.DepartamentoId;
                funcionario.CargoId = editadoFuncionario.CargoId;
                funcionario.ProjetoId = editadoFuncionario.ProjetoId;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Funcionarios
                    .Include(f => f.Departamento)
                    .Include(f => f.Cargo)
                    .Include(f => f.Projeto)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

    }
}