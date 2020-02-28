namespace SeminarskiRad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202002262119527_AddNullableDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Predbiljezbas", "Datum", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Predbiljezbas", "Datum", c => c.DateTime());
        }
    }
}
