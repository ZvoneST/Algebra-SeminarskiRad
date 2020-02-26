namespace SeminarskiRad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Predbiljezbas", "Datum", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Predbiljezbas", "Datum", c => c.DateTime(nullable: false));
        }
    }
}
