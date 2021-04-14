using Microsoft.EntityFrameworkCore;

namespace cadastro_cliente_mvc.Models
{
    public class PessoaContexto : DbContext
    {
        public PessoaContexto(DbContextOptions<PessoaContexto> options) : base(options)
        {
        }
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
