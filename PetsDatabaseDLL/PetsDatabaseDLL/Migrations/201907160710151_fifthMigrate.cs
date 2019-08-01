namespace PetsDatabaseDLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifthMigrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLikes", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserLikes", "Status");
        }
    }
}
