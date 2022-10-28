using CrudEmpleados.Infraestructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEmpleados.Test
{
    public class BasePruebas
    {
        protected AppDbContext ConstruirContext(string nombreDB)
        {
            var opciones = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(nombreDB).Options;
            var dbContext = new AppDbContext(opciones);

            return dbContext;
        }
    }
}
