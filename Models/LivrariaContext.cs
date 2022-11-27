using Microsoft.EntityFrameworkCore;

namespace Livraria.Models;

public class LivrariaContext : DbContext
{
    public DbSet<Autor>? Autor { get; set; }
    public DbSet<Categoria>? Categoria { get; set; }
    public DbSet<Editora>? Editora { get; set; }
    public DbSet<Leitor>? Leitor { get; set; }
    public DbSet<Livro>? Livro { get; set; }
    public DbSet<Secao>? Secao { get; set; }
    
    public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options)
    {
        
    }
}