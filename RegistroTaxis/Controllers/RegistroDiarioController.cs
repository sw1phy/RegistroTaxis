using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegistroTaxis.Data;
using RegistroTaxis.Data.Entidades;
using RegistroTaxis.Models;

namespace RegistroTaxis.Controllers
{
	public class RegistroDiarioController : Controller
	{
		private RegistroTaxisDbContext _context;
		public RegistroDiarioController(RegistroTaxisDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var registrosDiarios = _context.RegistroDiario.Where(w => w.Eliminado == false).ProjectToType<RegistroDiarioVm>().ToList();

			return View(registrosDiarios);
		}
		[HttpGet]
		public IActionResult Insertar()
		{
			var taxis = _context.Taxis.Where(w => w.Eliminado == false).ProjectToType<TaxisVm>().ToList();
			var itemstaxis = taxis.ConvertAll(d =>
			{
				return new SelectListItem
				{
					Text = d.Placa,
					Value = d.TaxiId.ToString(),
					Selected = false
				};
			});

			var registroDiario = new RegistroDiarioVm { Taxi = itemstaxis };
			return View(registroDiario);
		}

		[HttpPost]
		public IActionResult Insertar(RegistroDiarioVm vm)
		{

			var taxis = _context.Taxis.Where(w => w.Eliminado == false).ProjectToType<TaxisVm>().ToList();
			var itemstaxis = taxis.ConvertAll(d =>
			{
				return new SelectListItem
				{
					Text = d.Placa,
					Value = d.TaxiId.ToString(),
					Selected = false
				};
			});
			vm.Taxi = itemstaxis;
			if (vm == null)
			{
				TempData["mensaje"] = "No envió información";
				return View(vm);
			}
			if (string.IsNullOrEmpty("Observacion"))
			{
				TempData["mensaje"] = "Por favor aseguresé de haber rellenado todos los campos";
				return View(vm);
			}

			if (vm.PagoBase <= 0)
			{
				TempData["mensaje"] = "El pago base debe ser un valor positivo";
				return View(vm);
			}

			if (vm.PagoConductor <= 0)
			{
				TempData["mensaje"] = "El pago del conductor debe ser un valor positivo";
				return View(vm);
			}

			if (vm.PagoDueño <= 0)
			{
				TempData["mensaje"] = "El pago del dueño debe ser un valor positivo";
				return View(vm);
			}

			if (vm.Gastos < 0)
			{
				TempData["mensaje"] = "Los gastos no pueden ser negativos";
				return View(vm);
			}

			if (vm.Fecha == DateTime.MinValue)
			{
				TempData["mensaje"] = "Por favor ingrese una fecha válida";
				return View(vm);
			}

			vm.TotalDia = vm.PagoBase + vm.PagoConductor + vm.PagoDueño - vm.Gastos;

			var registroDiario = new RegistroDiario
			{
				TaxiId = vm.TaxiId, 
				TotalDia = vm.TotalDia,
				Combustible = vm.Combustible,
				PagoBase = vm.PagoBase,
				PagoConductor = vm.PagoConductor,
				PagoDueño = vm.PagoDueño,
				Gastos = vm.Gastos,
				Observacion = vm.Observacion,
				Fecha = vm.Fecha,
				Eliminado = false,
				RegistroId = Guid.NewGuid(),
				CreatedBy = Guid.Empty,
				ModifiedBy = Guid.Empty,
				CreatedDate = DateTime.Now,
				ModifiedDate = DateTime.Now
			};
			_context.RegistroDiario.Add(registroDiario);
			_context.SaveChanges();
			TempData["mensaje"] = "Registro ingresado correctamente";


			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Editar(Guid RegistroId)
		{
			var registroDiarios = _context.RegistroDiario.Where(w=>w.Eliminado==false && w.RegistroId==RegistroId).ProjectToType<RegistroDiarioVm>().FirstOrDefault();
			var taxis = _context.Taxis.Where(w => w.Eliminado == false).ProjectToType<TaxisVm>().ToList();
			var itemstaxis = taxis.ConvertAll(d =>
			{
				return new SelectListItem
				{
					Text = d.Placa,
					Value = d.TaxiId.ToString(),
					Selected = false
				};
			});

			registroDiarios.Taxi = itemstaxis;
			return View(registroDiarios);
		}

		[HttpPost]
		public IActionResult Editar(RegistroDiarioVm vm)
		{

			var taxis = _context.Taxis.Where(w => w.Eliminado == false).ProjectToType<TaxisVm>().ToList();
			var itemstaxis = taxis.ConvertAll(d =>
			{
				return new SelectListItem
				{
					Text = d.Placa,
					Value = d.TaxiId.ToString(),
					Selected = false
				};
			});
			vm.Taxi = itemstaxis;
			if (vm == null)
			{
				TempData["mensaje"] = "No envió información";
				return View(vm);
			}
			if (string.IsNullOrEmpty("Observacion"))
			{
				TempData["mensaje"] = "Por favor aseguresé de haber rellenado todos los campos";
				return View(vm);
			}

			if (vm.PagoBase <= 0)
			{
				TempData["mensaje"] = "El pago base debe ser un valor positivo";
				return View(vm);
			}

			if (vm.PagoConductor <= 0)
			{
				TempData["mensaje"] = "El pago del conductor debe ser un valor positivo";
				return View(vm);
			}

			if (vm.PagoDueño <= 0)
			{
				TempData["mensaje"] = "El pago del dueño debe ser un valor positivo";
				return View(vm);
			}

			if (vm.Gastos < 0)
			{
				TempData["mensaje"] = "Los gastos no pueden ser negativos";
				return View(vm);
			}

			if (vm.Fecha == DateTime.MinValue)
			{
				TempData["mensaje"] = "Por favor ingrese una fecha válida";
				return View(vm);
			}

			// Calcular TotalDia como la suma de pagos menos gastos
			vm.TotalDia = vm.PagoBase + vm.PagoConductor + vm.PagoDueño - vm.Gastos;
			var registroDiario = _context.RegistroDiario.Where(w => w.Eliminado == false && w.RegistroId ==vm.RegistroId).FirstOrDefault();
			registroDiario.TotalDia = vm.TotalDia;
			registroDiario.Combustible = vm.Combustible;
			registroDiario.PagoBase = vm.PagoBase;
			registroDiario.PagoConductor = vm.PagoConductor;
			registroDiario.PagoDueño = vm.PagoDueño;
			registroDiario.Gastos = vm.Gastos;
			registroDiario.Observacion = vm.Observacion;
			registroDiario.Fecha = vm.Fecha;
			registroDiario.ModifiedDate=DateTime.Now;
			registroDiario.ModifiedBy = Guid.NewGuid();
			_context.SaveChanges();
			TempData["mensaje"] = "Registro modificado correctamente";


			return RedirectToAction("Index");
		}


		[HttpGet]
		public IActionResult Eliminar(Guid RegistroId)
		{
			var registroDiarios = _context.RegistroDiario.Where(w => w.Eliminado == false && w.RegistroId == RegistroId).ProjectToType<RegistroDiarioVm>().FirstOrDefault();
			return View(registroDiarios);
		}

		[HttpPost]
		public IActionResult Eliminar(RegistroDiarioVm vm)
		{

			var taxis = _context.Taxis.Where(w => w.Eliminado == false).ProjectToType<TaxisVm>().ToList();
			
			if (vm == null)
			{
				TempData["mensaje"] = "No envió información";
				return View(vm);
			}
			var registroDiario = _context.RegistroDiario.Where(w => w.Eliminado == false && w.RegistroId == vm.RegistroId).FirstOrDefault();
			registroDiario.Eliminado = true;
			registroDiario.ModifiedDate = DateTime.Now;
			registroDiario.ModifiedBy = Guid.NewGuid();
			_context.SaveChanges();
			TempData["mensaje"] = "Registro eliminado correctamente";


			return RedirectToAction("Index");
		}
	}
}
