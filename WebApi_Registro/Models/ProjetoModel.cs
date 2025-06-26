using System.ComponentModel.DataAnnotations;

namespace WebApi_Registro.Models
{
    public class ProjetoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
