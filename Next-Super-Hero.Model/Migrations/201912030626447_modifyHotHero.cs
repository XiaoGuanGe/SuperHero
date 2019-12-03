namespace Next_Super_Hero.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyHotHero : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HotHeroes", "MovieId", c => c.String(unicode: false));
            AddColumn("dbo.HotHeroes", "MovieName", c => c.String(unicode: false));
            DropColumn("dbo.HotHeroes", "MoiveId");
            DropColumn("dbo.HotHeroes", "MoiveName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HotHeroes", "MoiveName", c => c.String(unicode: false));
            AddColumn("dbo.HotHeroes", "MoiveId", c => c.String(unicode: false));
            DropColumn("dbo.HotHeroes", "MovieName");
            DropColumn("dbo.HotHeroes", "MovieId");
        }
    }
}
