using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HumanServices.Models
{
    public class Cargos
    {
        [Key]
        public int CargoId { get; set; }
        public string Cargo { get; set; }

        public ICollection<Empleados> Empleados { get; set; }
    }
}