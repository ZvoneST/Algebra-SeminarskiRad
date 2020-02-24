namespace SeminarskiRad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPredbiljezbaModelToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Predbiljezbas",
                c => new
                    {
                        IdPredbiljezba = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(nullable: false),
                        Adresa = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Telefon = c.String(),
                        IdSeminar = c.Int(nullable: false),
                        StatusPrijave = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPredbiljezba)
                .ForeignKey("dbo.Seminars", t => t.IdSeminar, cascadeDelete: true)
                .Index(t => t.IdSeminar);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Predbiljezbas", "IdSeminar", "dbo.Seminars");
            DropIndex("dbo.Predbiljezbas", new[] { "IdSeminar" });
            DropTable("dbo.Predbiljezbas");
        }
    }
}
