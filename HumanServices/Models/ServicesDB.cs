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
    }
}