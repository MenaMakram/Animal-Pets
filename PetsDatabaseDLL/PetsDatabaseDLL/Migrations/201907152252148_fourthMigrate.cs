namespace PetsDatabaseDLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthMigrate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clinics", "StartTime", c => c.String());
            AlterColumn("dbo.Clinics", "EndTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clinics", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clinics", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
