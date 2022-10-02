using CrudEmpleados.Infraestructure;
using CrudEmpleados.Infraestructure.Repositories;
using CrudEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEmpleados.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly AppDbContext _context;
        private readonly EmpleadoRepository repository;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            repository = new EmpleadoRepository(context);
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ObtenerRegistros()
        {
            var empleados = repository.GetEmpleados();
            return Ok(empleados);
        }
        public async Task<IActionResult> AgregarEmpleado([FromBody]Empleado empleado)
        {
            JObject oRespuesta = new JObject();
            oRespuesta["lSuccess"] = await repository.CreateEmpleado(empleado);
            return Ok(oRespuesta);
        }

        public async Task<IActionResult> ModificarEmpleado([FromBody]Empleado empleado)
        {
            JObject oRespuesta = new JObject();
            oRespuesta["lSuccess"] = await repository.UpdateEmpleado(empleado);
            return Ok(oRespuesta);
        }
        public async Task<IActionResult> EliminarEmpleado(int Id)
        {
            JObject oRespuesta = new JObject();
            oRespuesta["lSuccess"] = await repository.DeleteEmpleado(Id);
            return Ok(oRespuesta);
        }
    }
}
