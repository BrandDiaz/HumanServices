using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HumanServices.Models
{
    public class Salidas
    {
        [Key]
        public int SalidaId { get; set; }
        [ForeignKey("Empleados")]
        public int EmpleadoId { get; set; }
        public string TipoSalida { get; set; }
        public string Motivo { get; set; }
        public string FechaSalida { get; set; }

        public Empleados Empleados { get; set; }


    }
}