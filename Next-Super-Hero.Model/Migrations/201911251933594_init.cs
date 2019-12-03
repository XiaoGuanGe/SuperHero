namespace Next_Super_Hero.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carousels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImgUrl = c.String(unicode: false),
                        MovieId = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carousels");
        }
    }
}
