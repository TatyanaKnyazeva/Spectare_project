namespace Spectare.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changingtypeonfilmtype : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Types", newName: "FilmTypes");
            RenameTable(name: "dbo.TypeFilms", newName: "FilmTypeFilms");
            RenameColumn(table: "dbo.FilmTypeFilms", name: "Type_Id", newName: "FilmType_Id");
            RenameIndex(table: "dbo.FilmTypeFilms", name: "IX_Type_Id", newName: "IX_FilmType_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.FilmTypeFilms", name: "IX_FilmType_Id", newName: "IX_Type_Id");
            RenameColumn(table: "dbo.FilmTypeFilms", name: "FilmType_Id", newName: "Type_Id");
            RenameTable(name: "dbo.FilmTypeFilms", newName: "TypeFilms");
            RenameTable(name: "dbo.FilmTypes", newName: "Types");
        }
    }
}
