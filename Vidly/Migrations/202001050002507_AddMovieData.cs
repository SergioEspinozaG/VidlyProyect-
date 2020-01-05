namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieDatas",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Genre = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "MovieDataId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "MovieDataId");
            AddForeignKey("dbo.Movies", "MovieDataId", "dbo.MovieDatas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieDataId", "dbo.MovieDatas");
            DropIndex("dbo.Movies", new[] { "MovieDataId" });
            DropColumn("dbo.Movies", "MovieDataId");
            DropTable("dbo.MovieDatas");
        }
    }
}
