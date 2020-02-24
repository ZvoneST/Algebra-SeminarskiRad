namespace SeminarskiRad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeminarDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seminars",
                c => new
                    {
                        IdSeminar = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                        Opis = c.String(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        BrojPolaznika = c.Int(nullable: false),
                        Popunjen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdSeminar);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seminars");
        }
    }
}
