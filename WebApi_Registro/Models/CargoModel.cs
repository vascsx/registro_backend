using System.ComponentModel.DataAnnotations;

namespace WebApi_Registro.Models
{
    public class CargoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Salario { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
