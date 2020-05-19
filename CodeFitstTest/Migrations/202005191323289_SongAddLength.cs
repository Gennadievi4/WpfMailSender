namespace CodeFitstTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongAddLength : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "Length", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "Length");
        }
    }
}
