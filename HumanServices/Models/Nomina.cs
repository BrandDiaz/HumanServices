using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HumanServices.Models
{
    public class Nomina
    {
        public int NominaId { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("Empleados")]
        public int EmpleadoId { get; set; }
        public int NominaTotal { get; set; }

        public Empleados Empleados { get; set; }

    }
}