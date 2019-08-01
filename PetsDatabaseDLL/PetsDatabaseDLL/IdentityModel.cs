using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace PetsDatabaseDLL
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<Posts> Posts { get; set; } = new List<Posts>();
        public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();
        public int UserType { get; set; }


    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region cascade
            //modelBuilder.Entity<Trainer>()
            //   .HasOptional<ApplicationUser>(s => s.user)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<HomePets>()
            //   .HasOptional<ApplicationUser>(s => s.User)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Doctor>()
            //   .HasOptional<ApplicationUser>(s => s.user)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Clients>()
            //   .HasOptional<ApplicationUser>(s => s.user)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<HomePets>()
            //    .HasMany<HomePetsPhoto>(sd=>sd.homePetsPhoto)
            //    .WithOptional()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<DoctorClinics>()
            //   .HasOptional<Doctor>(s => s.doctor)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<DoctorClinics>()
            //   .HasOptional<Clinic>(s => s.clinic)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);


            //modelBuilder.Entity<Animals>()
            //   .HasOptional<Clients>(s => s.clients)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<AnimalsPhoto>()
            //   .HasOptional<Animals>(s => s.Animal)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Animals>()
            //   .HasOptional<Category>(s => s.category)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Posts>()
            //   .HasOptional<ApplicationUser>(s => s.User)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<PostPhotos>()
            //   .HasOptional<Posts>(s => s.Posts)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Comments>()
            //   .HasOptional<Posts>(s => s.posts)
            //   .WithMany()
            //   .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Comments>()
            //   .HasOptional<ApplicationUser>(s => s.user)
            //   .WithMany()
            //   .WillCascadeOnDelete(true); 
            #endregion

            //AspNetUsers -> User
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("User");
            //AspNetRoles -> Role
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");
            //AspNetUserRoles -> UserRole
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRole");
            //AspNetUserClaims -> UserClaim
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaim");
            //AspNetUserLogins -> UserLogin
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogin");
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Clients> Clinets { get; set; }
        public virtual DbSet<Animals> Animals { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<AnimalsPhoto> AnimalPhotos { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<DoctorClinics> doctorClinics { get; set; }
        public virtual DbSet<Posts> posts { get; set; }
        public virtual DbSet<PostPhotos> PostPhoto { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<HomePets> HomePets { get; set; }
        public virtual DbSet<HomePetsPhoto> HomePetsPhoto { get; set; }
        public virtual DbSet<UserLikes> UserLikes { get; set; }
    }
}