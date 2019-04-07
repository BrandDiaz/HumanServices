using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HumanServices.Models
{
    public class Nomina
    {
        public int NominaId { get; set; }
        [DisplayName("Año")]
        public int Anio { get; set; }
        [DisplayName("Mes")]
        public int Meses { get; set; }

        [ForeignKey("Empleados")]
        public int EmpleadoId { get; set; }
        public int NominaTotal { get; set; }

        public Empleados Empleados { get; set; }

    }
}