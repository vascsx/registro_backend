using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApi_Registro.Enums;

namespace WebApi_Registro.DTOs
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool Ativo { get; set; }
        public TurnoEnum Turno { get; set; }
        public int DepartamentoId { get; set; }
        public int CargoId { get; set; }
        public int? ProjetoId { get; set; }
    }
}
