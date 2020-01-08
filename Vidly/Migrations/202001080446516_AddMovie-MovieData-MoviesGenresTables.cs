namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieMovieDataMoviesGenresTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieDatas",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                        AgeRestriction = c.Int(nullable: false),
                        GenreId = c.Byte(nullable: false),
                        MoviesGenres_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MoviesGenres", t => t.MoviesGenres_Id, cascadeDelete: true)
                .Index(t => t.MoviesGenres_Id);
            
            CreateTable(
                "dbo.MoviesGenres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        GenreName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MovieDataId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovieDatas", t => t.MovieDataId, cascadeDelete: true)
                .Index(t => t.MovieDataId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieDataId", "dbo.MovieDatas");
            DropForeignKey("dbo.MovieDatas", "MoviesGenres_Id", "dbo.MoviesGenres");
            DropIndex("dbo.Movies", new[] { "MovieDataId" });
            DropIndex("dbo.MovieDatas", new[] { "MoviesGenres_Id" });
            DropTable("dbo.Movies");
            DropTable("dbo.MoviesGenres");
            DropTable("dbo.MovieDatas");
        }
    }
}
