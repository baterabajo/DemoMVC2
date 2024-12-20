using DemoMVC2.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC2.Data
{
    public class DataContext :DbContext
    { 

      public DataContext(DbContextOptions<DataContext> options) : base(options)
      {

      
      }

  public DbSet<Producto>? Productos { get; set; }
      
  public DbSet<Categoria>? Categorias { get; set; }

  public DbSet<Proveedor>? Proveedors { get; set; }

  public DbSet<Streamer> Streamers { get; set; }

    }        

   
}