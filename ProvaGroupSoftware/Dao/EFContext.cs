using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProvaGroupSoftware.Models;

namespace ProvaGroupSoftware.Dao
{
  public class EFContext : DbContext
  {
    public EFContext() : base("EFConnectionString") { }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      base.OnModelCreating(modelBuilder);
    }
    public DbSet<Condominio> Condominios { get; set; }
    public DbSet<Unidade> Unidades { get; set; }

    public DbSet<Morador> Moradors { get; set; }
  }
}