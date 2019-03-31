using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HumanServices.Models
{
    public class Departamentos
    {
        [Key]
        public int DepartamentoId { get; set; }
        public int CodigoDepart { get; set; }
        public String Nombre { get; set; }

        public ICollection<Empleados> Empleados { get; set; }

    }
}