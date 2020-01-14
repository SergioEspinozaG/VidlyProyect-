namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeignKeyMovieData : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MovieDatas", "GenreId");
            RenameColumn(table: "dbo.MovieDatas", name: "MoviesGenres_Id", newName: "GenreId");
            RenameIndex(table: "dbo.MovieDatas", name: "IX_MoviesGenres_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MovieDatas", name: "IX_GenreId", newName: "IX_MoviesGenres_Id");
            RenameColumn(table: "dbo.MovieDatas", name: "GenreId", newName: "MoviesGenres_Id");
            AddColumn("dbo.MovieDatas", "GenreId", c => c.Byte(nullable: false));
        }
    }
}
