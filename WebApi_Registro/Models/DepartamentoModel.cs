using System.ComponentModel.DataAnnotations;

namespace WebApi_Registro.Models
{
    public class DepartamentoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
