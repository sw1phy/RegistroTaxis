using Microsoft.AspNetCore.Mvc.Rendering;
using RegistroTaxis.Data.Entidades;

namespace RegistroTaxis.Models
{
	public class RegistroDiarioVm
	{
		public Guid RegistroId { get; set; }
		public Decimal TotalDia { get; set; }
		public Decimal Combustible { get; set; }
		public Decimal PagoBase { get; set; }
		public Decimal PagoConductor { get; set; }
		public Decimal PagoDueño { get; set; }
		public Decimal Gastos { get; set; }
		public string Observacion { get; set; }
		public DateTime Fecha { get; set; }

		public Guid TaxiId { get; set; }

		public TaxisVm Taxis { get; set; }

		public List<SelectListItem> Taxi { set; get; }
	}
}
