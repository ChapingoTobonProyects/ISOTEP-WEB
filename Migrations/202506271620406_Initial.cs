namespace ISOTEP_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Departamento = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EscuelaNMSCarreras",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EscuelaNMSID = c.Int(nullable: false),
                        CarreraID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Carreras", t => t.CarreraID, cascadeDelete: true)
                .ForeignKey("dbo.EscuelaNMS", t => t.EscuelaNMSID, cascadeDelete: true)
                .Index(t => t.EscuelaNMSID)
                .Index(t => t.CarreraID);
            
            CreateTable(
                "dbo.EscuelaNMS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Ubicacion = c.String(maxLength: 200),
                        Responsable = c.String(maxLength: 100),
                        TituloResponsable = c.String(maxLength: 100),
                        CCT = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Etapas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        NombreCompetencia = c.String(maxLength: 100),
                        Semestre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PracticanteEtapaResponsableID = c.Int(nullable: false),
                        Dia = c.String(nullable: false, maxLength: 10),
                        HoraEntrada = c.Time(nullable: false, precision: 7),
                        HoraSalida = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PracticanteEtapaResponsables", t => t.PracticanteEtapaResponsableID, cascadeDelete: true)
                .Index(t => t.PracticanteEtapaResponsableID);
            
            CreateTable(
                "dbo.PracticanteEtapaResponsables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EtapaID = c.Int(nullable: false),
                        PracticanteID = c.Int(nullable: false),
                        ResponsableID = c.Int(nullable: false),
                        Grupo = c.String(nullable: false, maxLength: 50),
                        FechaInicio = c.DateTime(nullable: false, storeType: "date"),
                        FechaTermino = c.DateTime(nullable: false, storeType: "date"),
                        TotalHoras = c.Int(nullable: false),
                        Estatus = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Etapas", t => t.EtapaID, cascadeDelete: true)
                .ForeignKey("dbo.Practicantes", t => t.PracticanteID, cascadeDelete: true)
                .ForeignKey("dbo.Responsables", t => t.ResponsableID, cascadeDelete: true)
                .Index(t => t.EtapaID)
                .Index(t => t.PracticanteID)
                .Index(t => t.ResponsableID);
            
            CreateTable(
                "dbo.Practicantes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 50),
                        ApellidoMaterno = c.String(nullable: false, maxLength: 50),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Matricula = c.String(nullable: false, maxLength: 20),
                        EscuelaNMSCarreraID = c.Int(nullable: false),
                        Turno = c.String(nullable: false, maxLength: 20),
                        CURP = c.String(nullable: false, maxLength: 18),
                        TelefonoAlumno = c.String(nullable: false, maxLength: 15),
                        TelefonoTutor = c.String(nullable: false, maxLength: 15),
                        Correo_electronico = c.String(nullable: false),
                        Domicilio = c.String(nullable: false),
                        NSS = c.String(nullable: false, maxLength: 20),
                        Genero = c.String(nullable: false, maxLength: 10),
                        Promedio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EscuelaNMSCarreras", t => t.EscuelaNMSCarreraID, cascadeDelete: true)
                .Index(t => t.EscuelaNMSCarreraID);
            
            CreateTable(
                "dbo.Responsables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Cargo = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(nullable: false, maxLength: 15),
                        Correo = c.String(nullable: false),
                        AreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Areas", t => t.AreaID, cascadeDelete: true)
                .Index(t => t.AreaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Horarios", "PracticanteEtapaResponsableID", "dbo.PracticanteEtapaResponsables");
            DropForeignKey("dbo.PracticanteEtapaResponsables", "ResponsableID", "dbo.Responsables");
            DropForeignKey("dbo.Responsables", "AreaID", "dbo.Areas");
            DropForeignKey("dbo.PracticanteEtapaResponsables", "PracticanteID", "dbo.Practicantes");
            DropForeignKey("dbo.Practicantes", "EscuelaNMSCarreraID", "dbo.EscuelaNMSCarreras");
            DropForeignKey("dbo.PracticanteEtapaResponsables", "EtapaID", "dbo.Etapas");
            DropForeignKey("dbo.EscuelaNMSCarreras", "EscuelaNMSID", "dbo.EscuelaNMS");
            DropForeignKey("dbo.EscuelaNMSCarreras", "CarreraID", "dbo.Carreras");
            DropIndex("dbo.Responsables", new[] { "AreaID" });
            DropIndex("dbo.Practicantes", new[] { "EscuelaNMSCarreraID" });
            DropIndex("dbo.PracticanteEtapaResponsables", new[] { "ResponsableID" });
            DropIndex("dbo.PracticanteEtapaResponsables", new[] { "PracticanteID" });
            DropIndex("dbo.PracticanteEtapaResponsables", new[] { "EtapaID" });
            DropIndex("dbo.Horarios", new[] { "PracticanteEtapaResponsableID" });
            DropIndex("dbo.EscuelaNMSCarreras", new[] { "CarreraID" });
            DropIndex("dbo.EscuelaNMSCarreras", new[] { "EscuelaNMSID" });
            DropTable("dbo.Responsables");
            DropTable("dbo.Practicantes");
            DropTable("dbo.PracticanteEtapaResponsables");
            DropTable("dbo.Horarios");
            DropTable("dbo.Etapas");
            DropTable("dbo.EscuelaNMS");
            DropTable("dbo.EscuelaNMSCarreras");
            DropTable("dbo.Carreras");
            DropTable("dbo.Areas");
        }
    }
}
