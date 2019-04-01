namespace HumanServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargos",
                c => new
                    {
                        CargoId = c.Int(nullable: false, identity: true),
                        Cargo = c.String(),
                    })
                .PrimaryKey(t => t.CargoId);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        CodigoEmp = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        CargoId = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        Salario = c.Int(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadoId)
                .ForeignKey("dbo.Cargos", t => t.CargoId, cascadeDelete: true)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId, cascadeDelete: true)
                .Index(t => t.DepartamentoId)
                .Index(t => t.CargoId);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        CodigoDepart = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Licencias",
                c => new
                    {
                        LicenciasId = c.Int(nullable: false, identity: true),
                        EmpleadoId = c.Int(nullable: false),
                        Desde = c.DateTime(nullable: false),
                        Hasta = c.DateTime(nullable: false),
                        Motivos = c.String(),
                        Comentarios = c.String(),
                    })
                .PrimaryKey(t => t.LicenciasId)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Nominas",
                c => new
                    {
                        NominaId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        NominaTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NominaId)
                .ForeignKey("dbo.Empleados", t => t.NominaTotal, cascadeDelete: true)
                .Index(t => t.NominaTotal);
            
            CreateTable(
                "dbo.Permisos",
                c => new
                    {
                        PermisosId = c.Int(nullable: false, identity: true),
                        EmpleadoId = c.Int(nullable: false),
                        Desde = c.DateTime(nullable: false),
                        Hasta = c.DateTime(nullable: false),
                        Comentarios = c.String(),
                    })
                .PrimaryKey(t => t.PermisosId)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Salidas",
                c => new
                    {
                        SalidaId = c.Int(nullable: false, identity: true),
                        EmpleadoId = c.Int(nullable: false),
                        TipoSalida = c.String(),
                        Motivo = c.String(),
                        FechaSalida = c.String(),
                    })
                .PrimaryKey(t => t.SalidaId)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Vacaciones",
                c => new
                    {
                        VacacionesId = c.Int(nullable: false, identity: true),
                        EmpleadoId = c.Int(nullable: false),
                        Desde = c.DateTime(nullable: false),
                        Hasta = c.DateTime(nullable: false),
                        AnioCorrespondiente = c.String(),
                        Comentarios = c.String(),
                    })
                .PrimaryKey(t => t.VacacionesId)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.EmpleadoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacaciones", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.Salidas", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.Permisos", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.Nominas", "NominaTotal", "dbo.Empleados");
            DropForeignKey("dbo.Licencias", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.Empleados", "DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.Empleados", "CargoId", "dbo.Cargos");
            DropIndex("dbo.Vacaciones", new[] { "EmpleadoId" });
            DropIndex("dbo.Salidas", new[] { "EmpleadoId" });
            DropIndex("dbo.Permisos", new[] { "EmpleadoId" });
            DropIndex("dbo.Nominas", new[] { "NominaTotal" });
            DropIndex("dbo.Licencias", new[] { "EmpleadoId" });
            DropIndex("dbo.Empleados", new[] { "CargoId" });
            DropIndex("dbo.Empleados", new[] { "DepartamentoId" });
            DropTable("dbo.Vacaciones");
            DropTable("dbo.Salidas");
            DropTable("dbo.Permisos");
            DropTable("dbo.Nominas");
            DropTable("dbo.Licencias");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Empleados");
            DropTable("dbo.Cargos");
        }
    }
}
