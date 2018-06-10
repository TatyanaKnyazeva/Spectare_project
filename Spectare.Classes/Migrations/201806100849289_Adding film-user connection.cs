namespace Spectare.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingfilmuserconnection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "User_Id", "dbo.Users");
            DropIndex("dbo.Films", new[] { "User_Id" });
            CreateTable(
                "dbo.UserFilms",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Film_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Film_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Film_Id);
            
            DropColumn("dbo.Films", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "User_Id", c => c.Int());
            DropForeignKey("dbo.UserFilms", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.UserFilms", "User_Id", "dbo.Users");
            DropIndex("dbo.UserFilms", new[] { "Film_Id" });
            DropIndex("dbo.UserFilms", new[] { "User_Id" });
            DropTable("dbo.UserFilms");
            CreateIndex("dbo.Films", "User_Id");
            AddForeignKey("dbo.Films", "User_Id", "dbo.Users", "Id");
        }
    }
}
