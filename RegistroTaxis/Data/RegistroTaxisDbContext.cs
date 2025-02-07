using Microsoft.EntityFrameworkCore;
using RegistroTaxis.Data.Entidades;
using static RegistroTaxis.Data.EntityConfig;

namespace RegistroTaxis.Data
{
	public class RegistroTaxisDbContext: DbContext
	{
		public RegistroTaxisDbContext(DbContextOptions<RegistroTaxisDbContext> options) : base(options) { }
		public DbSet<RegistroDiario> RegistroDiario { get; set; }
		public DbSet<Usuarios> Usuarios { get; set; }

		public DbSet<Taxis> Taxis { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new RegistroDiarioConfig());
			modelBuilder.ApplyConfiguration(new UsuariosConfig());
			modelBuilder.ApplyConfiguration(new TaxisConfig());
		}
	}
}
