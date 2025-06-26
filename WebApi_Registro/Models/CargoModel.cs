using System.ComponentModel.DataAnnotations;

namespace WebApi_Registro.Models
{
    public class CargoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
