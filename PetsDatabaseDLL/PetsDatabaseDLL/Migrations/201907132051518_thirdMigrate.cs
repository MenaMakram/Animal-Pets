namespace PetsDatabaseDLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigrate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clinics", "StartDate", c => c.String());
            AlterColumn("dbo.Clinics", "EndDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clinics", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clinics", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
