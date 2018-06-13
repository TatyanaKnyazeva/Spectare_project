namespace Spectare.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Сделалировно3кадраизфильма : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "PhotoLink1", c => c.String());
            AddColumn("dbo.Films", "PhotoLink2", c => c.String());
            AddColumn("dbo.Films", "PhotoLink3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "PhotoLink3");
            DropColumn("dbo.Films", "PhotoLink2");
            DropColumn("dbo.Films", "PhotoLink1");
        }
    }
}
