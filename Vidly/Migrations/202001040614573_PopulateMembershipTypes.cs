namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SingUpFee, DurationInMonths, DiscountRate) Values (1, 0, 0, 0) ");
        }
        
        public override void Down()
        {
        }
    }
}
