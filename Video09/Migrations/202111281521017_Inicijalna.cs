namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicijalna : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "SmjerId", "dbo.Smjers");
            DropForeignKey("dbo.Smjers", "FakultetId", "dbo.Fakultets");
            DropForeignKey("dbo.UpisGodines", "AkademskaGodinaId", "dbo.AkademskaGodinas");
            DropForeignKey("dbo.UpisGodines", "StudentId", "dbo.Students");
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.NPPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        AkademskaGodinaId = c.Int(nullable: false),
                        SmjerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AkademskaGodinas", t => t.AkademskaGodinaId)
                .ForeignKey("dbo.Smjers", t => t.SmjerId)
                .Index(t => t.AkademskaGodinaId)
                .Index(t => t.SmjerId);
            
            CreateTable(
                "dbo.Opstinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Opis = c.String(),
                        RegijaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regijas", t => t.RegijaId)
                .Index(t => t.RegijaId);
            
            CreateTable(
                "dbo.Regijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Predajes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        NastavnikId = c.Int(nullable: false),
                        AkademskaGodinaId = c.Int(nullable: false),
                        PredmetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AkademskaGodinas", t => t.AkademskaGodinaId)
                .ForeignKey("dbo.Nastavniks", t => t.NastavnikId)
                .ForeignKey("dbo.Predmets", t => t.PredmetId)
                .Index(t => t.NastavnikId)
                .Index(t => t.AkademskaGodinaId)
                .Index(t => t.PredmetId);
            
            CreateTable(
                "dbo.Predmets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Ects = c.Single(nullable: false),
                        NppId = c.Int(nullable: false),
                        GodinaStudija = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NPPs", t => t.NppId)
                .Index(t => t.NppId);
            
            CreateTable(
                "dbo.SlusaPredmets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        PredajeId = c.Int(nullable: false),
                        UpisGodineId = c.Int(nullable: false),
                        FinalnaOcjena = c.Int(),
                        DatumOcjene = c.DateTime(),
                        Priznato = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Predajes", t => t.PredajeId)
                .ForeignKey("dbo.UpisGodines", t => t.UpisGodineId)
                .Index(t => t.PredajeId)
                .Index(t => t.UpisGodineId);
            
            CreateTable(
                "dbo.Uplatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DatumUplate = c.DateTime(nullable: false),
                        Iznos = c.Single(nullable: false),
                        Svrha = c.String(),
                        EvidentiranoKorisnikId = c.Int(nullable: false),
                        EvidentiranoDatum = c.DateTime(nullable: false),
                        UpisGodineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.EvidentiranoKorisnikId)
                .ForeignKey("dbo.UpisGodines", t => t.UpisGodineId)
                .Index(t => t.EvidentiranoKorisnikId)
                .Index(t => t.UpisGodineId);
            
            AddColumn("dbo.Referents", "FakultetId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "DatumRodjenja", c => c.DateTime());
            AddColumn("dbo.Students", "OpstinaRodjenjaId", c => c.Int());
            AddColumn("dbo.Students", "OpstinaPrebivalistaId", c => c.Int());
            AddColumn("dbo.Students", "NppId", c => c.Int());
            AddColumn("dbo.UpisGodines", "Datum4_LjetniOvjera", c => c.DateTime());
            AddColumn("dbo.UpisGodines", "Datum3_LjetniUpis", c => c.DateTime());
            AddColumn("dbo.UpisGodines", "Datum2_ZimskiOvjera", c => c.DateTime());
            AddColumn("dbo.UpisGodines", "Datum1_ZimskiUpis", c => c.DateTime());
            AddColumn("dbo.UpisGodines", "Cijena", c => c.Single(nullable: false));
            CreateIndex("dbo.Referents", "FakultetId");
            CreateIndex("dbo.Students", "OpstinaRodjenjaId");
            CreateIndex("dbo.Students", "OpstinaPrebivalistaId");
            CreateIndex("dbo.Students", "NppId");
            AddForeignKey("dbo.Referents", "FakultetId", "dbo.Fakultets", "Id");
            AddForeignKey("dbo.Students", "NppId", "dbo.NPPs", "Id");
            AddForeignKey("dbo.Students", "OpstinaPrebivalistaId", "dbo.Opstinas", "Id");
            AddForeignKey("dbo.Students", "OpstinaRodjenjaId", "dbo.Opstinas", "Id");
            AddForeignKey("dbo.Students", "SmjerId", "dbo.Smjers", "Id");
            AddForeignKey("dbo.Smjers", "FakultetId", "dbo.Fakultets", "Id");
            AddForeignKey("dbo.UpisGodines", "AkademskaGodinaId", "dbo.AkademskaGodinas", "Id");
            AddForeignKey("dbo.UpisGodines", "StudentId", "dbo.Students", "Id");
            DropColumn("dbo.Korisniks", "DatumRodjenja");
            DropColumn("dbo.UpisGodines", "DatumUpisa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UpisGodines", "DatumUpisa", c => c.DateTime(nullable: false));
            AddColumn("dbo.Korisniks", "DatumRodjenja", c => c.DateTime());
            DropForeignKey("dbo.UpisGodines", "StudentId", "dbo.Students");
            DropForeignKey("dbo.UpisGodines", "AkademskaGodinaId", "dbo.AkademskaGodinas");
            DropForeignKey("dbo.Smjers", "FakultetId", "dbo.Fakultets");
            DropForeignKey("dbo.Students", "SmjerId", "dbo.Smjers");
            DropForeignKey("dbo.Uplatas", "UpisGodineId", "dbo.UpisGodines");
            DropForeignKey("dbo.Uplatas", "EvidentiranoKorisnikId", "dbo.Korisniks");
            DropForeignKey("dbo.SlusaPredmets", "UpisGodineId", "dbo.UpisGodines");
            DropForeignKey("dbo.SlusaPredmets", "PredajeId", "dbo.Predajes");
            DropForeignKey("dbo.Predajes", "PredmetId", "dbo.Predmets");
            DropForeignKey("dbo.Predmets", "NppId", "dbo.NPPs");
            DropForeignKey("dbo.Predajes", "NastavnikId", "dbo.Nastavniks");
            DropForeignKey("dbo.Predajes", "AkademskaGodinaId", "dbo.AkademskaGodinas");
            DropForeignKey("dbo.Students", "OpstinaRodjenjaId", "dbo.Opstinas");
            DropForeignKey("dbo.Students", "OpstinaPrebivalistaId", "dbo.Opstinas");
            DropForeignKey("dbo.Opstinas", "RegijaId", "dbo.Regijas");
            DropForeignKey("dbo.Students", "NppId", "dbo.NPPs");
            DropForeignKey("dbo.NPPs", "SmjerId", "dbo.Smjers");
            DropForeignKey("dbo.NPPs", "AkademskaGodinaId", "dbo.AkademskaGodinas");
            DropForeignKey("dbo.Referents", "FakultetId", "dbo.Fakultets");
            DropForeignKey("dbo.Administrators", "Id", "dbo.Korisniks");
            DropIndex("dbo.Uplatas", new[] { "UpisGodineId" });
            DropIndex("dbo.Uplatas", new[] { "EvidentiranoKorisnikId" });
            DropIndex("dbo.SlusaPredmets", new[] { "UpisGodineId" });
            DropIndex("dbo.SlusaPredmets", new[] { "PredajeId" });
            DropIndex("dbo.Predmets", new[] { "NppId" });
            DropIndex("dbo.Predajes", new[] { "PredmetId" });
            DropIndex("dbo.Predajes", new[] { "AkademskaGodinaId" });
            DropIndex("dbo.Predajes", new[] { "NastavnikId" });
            DropIndex("dbo.Opstinas", new[] { "RegijaId" });
            DropIndex("dbo.NPPs", new[] { "SmjerId" });
            DropIndex("dbo.NPPs", new[] { "AkademskaGodinaId" });
            DropIndex("dbo.Students", new[] { "NppId" });
            DropIndex("dbo.Students", new[] { "OpstinaPrebivalistaId" });
            DropIndex("dbo.Students", new[] { "OpstinaRodjenjaId" });
            DropIndex("dbo.Referents", new[] { "FakultetId" });
            DropIndex("dbo.Administrators", new[] { "Id" });
            DropColumn("dbo.UpisGodines", "Cijena");
            DropColumn("dbo.UpisGodines", "Datum1_ZimskiUpis");
            DropColumn("dbo.UpisGodines", "Datum2_ZimskiOvjera");
            DropColumn("dbo.UpisGodines", "Datum3_LjetniUpis");
            DropColumn("dbo.UpisGodines", "Datum4_LjetniOvjera");
            DropColumn("dbo.Students", "NppId");
            DropColumn("dbo.Students", "OpstinaPrebivalistaId");
            DropColumn("dbo.Students", "OpstinaRodjenjaId");
            DropColumn("dbo.Students", "DatumRodjenja");
            DropColumn("dbo.Referents", "FakultetId");
            DropTable("dbo.Uplatas");
            DropTable("dbo.SlusaPredmets");
            DropTable("dbo.Predmets");
            DropTable("dbo.Predajes");
            DropTable("dbo.Regijas");
            DropTable("dbo.Opstinas");
            DropTable("dbo.NPPs");
            DropTable("dbo.Administrators");
            AddForeignKey("dbo.UpisGodines", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UpisGodines", "AkademskaGodinaId", "dbo.AkademskaGodinas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Smjers", "FakultetId", "dbo.Fakultets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "SmjerId", "dbo.Smjers", "Id", cascadeDelete: true);
        }
    }
}
