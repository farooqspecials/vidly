namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingColumnInMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("Insert into MembershipTypes(Id,Name,SignUPFee,DurationInMonths,DiscountRate) Values(1,'Free',0,0,0)");
            Sql("Insert into MembershipTypes(Id,Name,SignUPFee,DurationInMonths,DiscountRate) Values(2,'Pay As you Go',30,1,10)");
            Sql("Insert into MembershipTypes(Id,Name,SignUPFee,DurationInMonths,DiscountRate) Values(3,'Quarterly',90,3,15)");
            Sql("Insert into MembershipTypes(Id,Name,SignUPFee,DurationInMonths,DiscountRate) Values(4,'Annual',300,12,20)");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
