namespace HumanServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Empleados",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        CodigoEmp = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        Salario = c.Int(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                        Cargo_CargoId = c.Int(),
                        Departamento_DepartamentoId = c.Int(),
                    })
                .PrimaryKey(t => t.EmpleadoId)
                .ForeignKey("dbo.Cargos", t => t.Cargo_CargoId)
                .ForeignKey("dbo.Departamentos", t => t.Departamento_DepartamentoId)
                .Index(t => t.Cargo_CargoId)
                .Index(t => t.Departamento_DepartamentoId);
            
            CreateTable(
                "dbo.Cargos",
                c => new
                    {
                        CargoId = c.Int(nullable: false, identity: true),
                        Cargo = c.String(),
                    })
                .PrimaryKey(t => t.CargoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleados", "Departamento_DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.Empleados", "Cargo_CargoId", "dbo.Cargos");
            DropIndex("dbo.Empleados", new[] { "Departamento_DepartamentoId" });
            DropIndex("dbo.Empleados", new[] { "Cargo_CargoId" });
            DropTable("dbo.Cargos");
            DropTable("dbo.Empleados");
            DropTable("dbo.Departamentos");
        }
    }
}
