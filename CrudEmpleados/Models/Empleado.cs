using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEmpleados.Models
{
    public class Empleado
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string sNombre { get; set; }
        public string sCorreo { get; set; }
        public DateTime dtFechaIngreso { get; set; }
        public DateTime dtFechaCreacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public bool lActivo { get; set; }
    }
}
