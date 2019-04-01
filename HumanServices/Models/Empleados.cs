using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HumanServices.Models
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }
        public int CodigoEmp { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }

        [ForeignKey("Departamentos")]
        public int DepartamentoId { get; set; }

        [ForeignKey("Cargos")]
        public int CargoId { get; set; }

        public DateTime FechaIngreso { get; set; }
        public int Salario { get; set; }
        public bool Estatus { get; set; }

        public Departamentos Departamentos { get; set; }
        public Cargos Cargos { get; set; }


        public ICollection<Nomina> Nominas { get; set; }
        public ICollection<Salidas> Salidas { get; set; }
        public ICollection<Vacaciones> Vacaciones { get; set; }
        public ICollection<Permisos> Permisos { get; set; }
        public ICollection<Licencias> Licencias { get; set; }


    }
}