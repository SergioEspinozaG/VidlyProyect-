namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MasterUpdate : DbMigration
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
            
            AddColumn("dbo.Movies", "MovieDataId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Movies", "MovieDataId");
            AddForeignKey("dbo.Movies", "MovieDataId", "dbo.MovieDatas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieDataId", "dbo.MovieDatas");
            DropForeignKey("dbo.MovieDatas", "MoviesGenres_Id", "dbo.MoviesGenres");
            DropIndex("dbo.MovieDatas", new[] { "MoviesGenres_Id" });
            DropIndex("dbo.Movies", new[] { "MovieDataId" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "MovieDataId");
            DropTable("dbo.MoviesGenres");
            DropTable("dbo.MovieDatas");
        }
    }
}
