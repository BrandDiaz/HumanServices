using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HumanServices.Models
{
    public class Permisos
    {
        [Key]
        public int PermisosId { get; set; }
        [ForeignKey("Empleados")]
        public int EmpleadoId { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public string Comentarios { get; set; }

        public Empleados Empleados { get; set; }
    }
}