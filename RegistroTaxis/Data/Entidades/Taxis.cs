namespace RegistroTaxis.Data.Entidades
{
	public class Taxis
	{
		public Guid TaxiId { get; set; }

		public string Placa { get; set; }

		public string Observacion { get; set; }

		public bool Eliminado { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Guid ModifiedBy { get; set; }

		public ICollection<RegistroDiario> RegistrosDiarios { get; set; } = new HashSet<RegistroDiario>();


	}
}
