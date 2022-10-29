using CrudEmpleados.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEmpleados.Test.Pruebas
{
    [TestClass]
    public class EmpleadoRepositoryTest : BasePruebas
    {
        [TestMethod]
        public async Task CrearEmpleados()
        {
            var nombreDb = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDb);
            context.empleados.Add(new Empleado() { 
                sNombre = "Alejandro Pech",
                sCorreo = "jesuspech@gmail.com",
                lActivo = true
            });
            await context.SaveChangesAsync();
            var context2 = ConstruirContext(nombreDb);
            var empleados = context2.empleados.ToList();

            Assert.AreNotEqual(null, empleados);
        }

        [TestMethod]
        public async Task ObtenerEmpleados()
        {
            var nombreDb = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDb);
            context.empleados.Add(new Empleado()
            {
                sNombre = "Alejandro Pech",
                sCorreo = "jesuspech@gmail.com",
                lActivo = true
            });
            await context.SaveChangesAsync();
            var context2 = ConstruirContext(nombreDb);
            var empleados = context2.empleados.ToList();

            Assert.AreEqual(1, empleados.Count);
        }

        [TestMethod]
        public async Task ObtenerEmpleado()
        {
            var nombreDb = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDb);
            context.empleados.Add(new Empleado()
            {
                sNombre = "Alejandro Pech",
                sCorreo = "jesuspech@gmail.com",
                lActivo = true
            });
            await context.SaveChangesAsync();
            var context2 = ConstruirContext(nombreDb);
            var empleado = context2.empleados.FirstOrDefault(x=> x.sCorreo == "jesuspech@gmail.com");

            Assert.AreNotEqual(null, empleado);
        }
        [TestMethod]
        public async Task ActualizarEmpleado()
        {
            var nombreDb = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDb);
            context.empleados.Add(new Empleado()
            {
                sNombre = "Alejandro Pech",
                sCorreo = "jesuspech@gmail.com",
                lActivo = true
            });
            await context.SaveChangesAsync();
            var context2 = ConstruirContext(nombreDb);
            var empleado = context2.empleados.FirstOrDefault(x => x.sCorreo == "jesuspech@gmail.com");
            empleado.lActivo = false;
            context2.SaveChanges();
            Assert.AreEqual(false, empleado.lActivo);
        }

        [TestMethod]
        public async Task EliminarEmpleado()
        {
            var nombreDb = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDb);
            context.empleados.Add(new Empleado()
            {
                sNombre = "Alejandro Pech",
                sCorreo = "jesuspech@gmail.com",
                lActivo = true
            });
            await context.SaveChangesAsync();
            var context2 = ConstruirContext(nombreDb);
            var empleado = context2.empleados.FirstOrDefault(x => x.sCorreo == "jesuspech@gmail.com");
            context2.empleados.Remove(empleado);
            await context2.SaveChangesAsync();
            var context3 = ConstruirContext(nombreDb);
            var empleado2 = context3.empleados.ToList();
            Assert.AreEqual(0, empleado2.Count);
        }
    }
}
