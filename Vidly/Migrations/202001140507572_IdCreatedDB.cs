namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdCreatedDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieDataId", "dbo.MovieDatas");
            DropPrimaryKey("dbo.MovieDatas");
            AlterColumn("dbo.MovieDatas", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.MovieDatas", "Id");
            AddForeignKey("dbo.Movies", "MovieDataId", "dbo.MovieDatas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieDataId", "dbo.MovieDatas");
            DropPrimaryKey("dbo.MovieDatas");
            AlterColumn("dbo.MovieDatas", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.MovieDatas", "Id");
            AddForeignKey("dbo.Movies", "MovieDataId", "dbo.MovieDatas", "Id", cascadeDelete: true);
        }
    }
}
