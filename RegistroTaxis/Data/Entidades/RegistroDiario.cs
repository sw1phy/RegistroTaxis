namespace RegistroTaxis.Data.Entidades
{
	public class RegistroDiario
	{
		public Guid RegistroId { get; set; }
		public Decimal TotalDia { get; set; }
		public Decimal Combustible { get; set; }
		public Decimal PagoBase { get; set; }
		public Decimal PagoConductor { get; set; }
		public Decimal PagoDueño { get; set; }
		public Decimal Gastos {  get; set; }
		public string Observacion { get; set; }
		public DateTime Fecha { get; set; }

		public bool Eliminado { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Guid ModifiedBy { get; set; }

		public Guid TaxiId { get; set; }

		public Taxis Taxis { get; set; }



	}
}
