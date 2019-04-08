using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HumanServices.Models
{
    public class ServicesDB : DbContext
    {
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public System.Data.Entity.DbSet<HumanServices.Models.Cargos> Cargos { get; set; }
        public DbSet<Nomina> Nomina { get; set; }
        public System.Data.Entity.DbSet<HumanServices.Models.Salidas> Salidas { get; set; }
        public DbSet<Vacaciones> Vacaciones { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Licencias> Licencias { get; set; }
        public DbSet<TipoSalida> TipoSalidas { get; set; }





    }
}