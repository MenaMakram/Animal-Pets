namespace PetsDatabaseDLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalsPhotoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        AnimalID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Animals", t => t.AnimalID,cascadeDelete:true)
                .Index(t => t.AnimalID);
            
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Gender = c.String(),
                        age = c.Int(nullable: false),
                        status = c.Boolean(nullable: false),
                        MarriedCount = c.Int(nullable: false),
                        Description = c.String(),
                        SonsCount = c.Int(nullable: false),
                        MarriedSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailableMarried = c.Boolean(nullable: false),
                        AvailableForBill = c.Boolean(nullable: false),
                        ClientID = c.Int(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID,cascadeDelete:true)
                .ForeignKey("dbo.Clients", t => t.ClientID,cascadeDelete:true)
                .Index(t => t.ClientID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID,cascadeDelete:true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Photo = c.String(),
                        UserType = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CommentDateTime = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        PostID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID,cascadeDelete:true)
                .ForeignKey("dbo.User", t => t.UserId,cascadeDelete:true)
                .Index(t => t.UserId)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Likes = c.Int(nullable: false),
                        PostDateTime = c.DateTime(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.PostPhotos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        PostID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID,cascadeDelete:true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DoctorClinics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(),
                        ClinicID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clinics", t => t.ClinicID,cascadeDelete:true)
                .ForeignKey("dbo.Doctors", t => t.DoctorID,cascadeDelete:true)
                .Index(t => t.DoctorID)
                .Index(t => t.ClinicID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HasClinic = c.Boolean(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID,cascadeDelete:true)
                .Index(t => t.UserID);

            CreateTable(
                "dbo.HomePets",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    AvailablePlace = c.Int(nullable: false),
                    NumberOfRooms = c.Int(nullable: false),
                    PriceForNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    UserId = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete:true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.HomePetsPhotoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        homePetsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HomePets", t => t.homePetsID, cascadeDelete: true)
                .Index(t => t.homePetsID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        Overview = c.String(),
                        Courses = c.String(),
                        TrainePlace = c.String(),
                        PricePerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID,cascadeDelete:true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "UserID", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.HomePets", "UserId", "dbo.User");
            DropForeignKey("dbo.HomePetsPhotoes", "homePetsID", "dbo.HomePets");
            DropForeignKey("dbo.DoctorClinics", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "UserID", "dbo.User");
            DropForeignKey("dbo.DoctorClinics", "ClinicID", "dbo.Clinics");
            DropForeignKey("dbo.AnimalsPhotoes", "AnimalID", "dbo.Animals");
            DropForeignKey("dbo.Animals", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Clients", "UserID", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.Comments", "UserId", "dbo.User");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "UserID", "dbo.User");
            DropForeignKey("dbo.PostPhotos", "PostID", "dbo.Posts");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.Animals", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Trainers", new[] { "UserID" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.HomePetsPhotoes", new[] { "homePetsID" });
            DropIndex("dbo.HomePets", new[] { "UserId" });
            DropIndex("dbo.Doctors", new[] { "UserID" });
            DropIndex("dbo.DoctorClinics", new[] { "ClinicID" });
            DropIndex("dbo.DoctorClinics", new[] { "DoctorID" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.PostPhotos", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.Clients", new[] { "UserID" });
            DropIndex("dbo.Animals", new[] { "CategoryID" });
            DropIndex("dbo.Animals", new[] { "ClientID" });
            DropIndex("dbo.AnimalsPhotoes", new[] { "AnimalID" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Role");
            DropTable("dbo.HomePetsPhotoes");
            DropTable("dbo.HomePets");
            DropTable("dbo.Doctors");
            DropTable("dbo.DoctorClinics");
            DropTable("dbo.Clinics");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserLogin");
            DropTable("dbo.PostPhotos");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
            DropTable("dbo.Animals");
            DropTable("dbo.AnimalsPhotoes");
        }
    }
}
