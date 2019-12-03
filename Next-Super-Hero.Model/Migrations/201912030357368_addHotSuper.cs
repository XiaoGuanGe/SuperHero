namespace Next_Super_Hero.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHotSuper : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carousels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ImgUrl = c.String(unicode: false),
                        MovieId = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HotHeroes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MoiveId = c.String(unicode: false),
                        MoiveName = c.String(unicode: false),
                        Poster = c.String(unicode: false),
                        Cover = c.String(unicode: false),
                        Trailer = c.String(unicode: false),
                        Score = c.Single(nullable: false),
                        PrisedCounts = c.Int(nullable: false),
                        PlotDesc = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HotHeroes");
            DropTable("dbo.Carousels");
        }
    }
}
