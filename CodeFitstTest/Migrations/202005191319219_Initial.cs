namespace CodeFitstTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BirthDay = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Destributors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Artist", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.DestributorArtists",
                c => new
                    {
                        Destributor_ID = c.Int(nullable: false),
                        Artist_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Destributor_ID, t.Artist_ID })
                .ForeignKey("dbo.Destributors", t => t.Destributor_ID, cascadeDelete: true)
                .ForeignKey("dbo.Artist", t => t.Artist_ID, cascadeDelete: true)
                .Index(t => t.Destributor_ID)
                .Index(t => t.Artist_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.DestributorArtists", "Artist_ID", "dbo.Artist");
            DropForeignKey("dbo.DestributorArtists", "Destributor_ID", "dbo.Destributors");
            DropIndex("dbo.DestributorArtists", new[] { "Artist_ID" });
            DropIndex("dbo.DestributorArtists", new[] { "Destributor_ID" });
            DropIndex("dbo.Songs", new[] { "ArtistId" });
            DropTable("dbo.DestributorArtists");
            DropTable("dbo.Songs");
            DropTable("dbo.Destributors");
            DropTable("dbo.Artist");
        }
    }
}
