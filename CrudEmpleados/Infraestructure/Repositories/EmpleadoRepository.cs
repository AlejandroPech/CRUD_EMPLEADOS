using CrudEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEmpleados.Infraestructure.Repositories
{
    public class EmpleadoRepository
    {
        private readonly AppDbContext _context;
        public EmpleadoRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<bool> CreateEmpleado(Empleado empleado)
        {
            bool lSuccess = true;
            try
            {
                empleado.dtFechaCreacion = DateTime.Now;
                empleado.lActivo = true;
                _context.empleados.Add(empleado);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                lSuccess = false;
            }
            return lSuccess;
        }
        public async Task<bool> UpdateEmpleado(Empleado newEmpleado)
        {
            bool lSuccess = true;
            try
            {
                newEmpleado.dtFechaModificacion = DateTime.Now;
                _context.empleados.Update(newEmpleado);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                lSuccess = false;
            }
            return lSuccess;
        }
        public async Task<bool> DeleteEmpleado(int id)
        {
            bool lSuccess = true;
            try
            {
                var empleado = _context.empleados.FirstOrDefault(x => x.Id == id);
                _context.empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                lSuccess = false;
            }
            return lSuccess;
        }
        public IEnumerable<Empleado> GetEmpleados()
        {
            var empleados = _context.empleados.OrderByDescending(x=>x.dtFechaCreacion).ToList();
            return empleados;
        }
        public Empleado GetEmpleado(int id)
        {
            var empleado = _context.empleados.FirstOrDefault(x => x.Id == id);
            return empleado;
        }
    }
}
