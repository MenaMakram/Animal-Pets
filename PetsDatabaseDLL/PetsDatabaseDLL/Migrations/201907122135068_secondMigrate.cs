namespace PetsDatabaseDLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLikes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostId = c.Int(),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostId,cascadeDelete:true)
                .ForeignKey("dbo.User", t => t.UserID,cascadeDelete:true)
                .Index(t => t.PostId)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLikes", "UserID", "dbo.User");
            DropForeignKey("dbo.UserLikes", "PostId", "dbo.Posts");
            DropIndex("dbo.UserLikes", new[] { "UserID" });
            DropIndex("dbo.UserLikes", new[] { "PostId" });
            DropTable("dbo.UserLikes");
        }
    }
}
