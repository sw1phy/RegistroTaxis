using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistroTaxis.Data.Entidades;

namespace RegistroTaxis.Data
{
	public class EntityConfig
	{
		public class RegistroDiarioConfig : IEntityTypeConfiguration<RegistroDiario>
		{
			public void Configure(EntityTypeBuilder<RegistroDiario> builder)
			{
				builder.HasKey(x => x.RegistroId);
				builder.Property(s  => s.TotalDia).HasColumnType("decimal(5,2)").HasColumnName("TotalDia");
				builder.Property(s => s.Combustible).HasColumnType("decimal(5,2)").HasColumnName("Combustible");
				builder.Property(s => s.PagoBase).HasColumnType("decimal(5,2)").HasColumnName("PagoBase");
				builder.Property(s => s.PagoConductor).HasColumnType("decimal(5,2)").HasColumnName("PagoConductor");
				builder.Property(s => s.PagoDueño).HasColumnType("decimal(5,2)").HasColumnName("PagoDueño");
				builder.Property(s => s.Gastos).HasColumnType("decimal(5,2)").HasColumnName("Gastos");
				builder.Property(s => s.Observacion).HasColumnType("varchar(255)").HasColumnName("Observacion");
				builder.Property(s => s.Fecha).HasColumnType("datetime").HasColumnName("Fecha");
			}
		}


		public class UsuariosConfig : IEntityTypeConfiguration<Usuarios>
		{
			public void Configure(EntityTypeBuilder<Usuarios> builder)
			{
				builder.HasKey(x => x.UsuarioId);
				builder.Property(s => s.NombreUsuario).HasColumnType("varchar(255)").HasColumnName("NombreUsuario");
				builder.Property(s => s.Contraseña).HasColumnType("varchar(255)").HasColumnName("Contraseña");
			}
		}


		public class TaxisConfig : IEntityTypeConfiguration<Taxis>
		{
			public void Configure(EntityTypeBuilder<Taxis> builder)
			{
				builder.HasKey(x => x.TaxiId);
				builder.Property(s => s.Placa).HasColumnType("varchar(255)").HasColumnName("Placa");
				builder.Property(s => s.Observacion).HasColumnType("varchar(255)").HasColumnName("Observacion");
				builder.HasMany(a => a.RegistrosDiarios).WithOne(a => a.Taxis).HasForeignKey(a => a.TaxiId);

			}
		}

	}
}
