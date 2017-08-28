namespace EFMVCTestMySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE membershiptypes SET Name = 'Pay as You Go' WHERE SignUpFee = 0");
            Sql("UPDATE membershiptypes SET Name = 'Monthly' WHERE SignUpFee = 30");
            Sql("UPDATE membershiptypes SET Name = 'Quarterly' WHERE SignUpFee = 90");
            Sql("UPDATE membershiptypes SET Name = '7 Months' WHERE SignUpFee = 210");
        }
        
        public override void Down()
        {
        }
    }
}
