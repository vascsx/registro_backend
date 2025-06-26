using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi_Registro.Enums;

namespace WebApi_Registro.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool Ativo { get; set; }
        public TurnoEnum Turno { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();

        public int DepartamentoId { get; set; }
        [ForeignKey("DepartamentoId")]
        public DepartamentoModel Departamento { get; set; }

        public int CargoId { get; set; }
        [ForeignKey("CargoId")]
        public CargoModel Cargo { get; set; }

        public int? ProjetoId { get; set; }
        [ForeignKey("ProjetoId")]
        public ProjetoModel Projeto { get; set; }
    }
}