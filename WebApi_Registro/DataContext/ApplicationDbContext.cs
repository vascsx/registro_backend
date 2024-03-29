using Microsoft.EntityFrameworkCore;
using WebApi_Registro.Models;

namespace WebApi_Registro.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base (options) { 
            
        }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
