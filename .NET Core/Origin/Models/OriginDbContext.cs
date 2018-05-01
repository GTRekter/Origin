using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Origin.Models.Store;

namespace Origin.Models
{
    public class OriginDbContext : IdentityDbContext<OR_User, OR_Role, int>
    {
        public OriginDbContext(DbContextOptions<OriginDbContext> options)
            : base(options)
        {
        }

        //public DbSet<OR_Role> OR_Roles { get; set; }

        public DbSet<OR_Form> OR_Forms { get; set; }

        public DbSet<OR_Property> OR_Properties { get; set; }

        public DbSet<OR_PropertyValue> OR_PropertyValues { get; set; }

        public DbSet<OR_Input> OR_Inputs { get; set; }

        public DbSet<OR_Item> OR_Items { get; set; }

        public DbSet<OR_ItemAction> OR_ItemActions { get; set; }

        public DbSet<OR_ItemType> OR_ItemTypes { get; set; }

        public DbSet<OR_Lookup> OR_Lookups { get; set; }

        public DbSet<OR_LookupValue> OR_LookupValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var user = modelBuilder.Entity<OR_User>();
            user.ToTable("OR_Users");
            //user.Property(p => p.Id).HasDefaultValueSql("NewId()");

            var role = modelBuilder.Entity<OR_Role>();
            role.ToTable("OR_Roles");
            //role.Property(p => p.Id).HasDefaultValueSql("NewId()");

            var userRole = modelBuilder.Entity<IdentityUserRole<int>>();
            userRole.ToTable("OR_UserRoles");
            userRole.HasKey(r => new { r.UserId, r.RoleId });

            var userClaim = modelBuilder.Entity<IdentityUserClaim<int>>();
            userClaim.ToTable("OR_UserClaims");

            var roleClaim = modelBuilder.Entity<IdentityRoleClaim<int>>();
            roleClaim.ToTable("OR_RoleClaims");

            var userToken = modelBuilder.Entity<IdentityUserToken<int>>();
            userToken.ToTable("OR_UserTokens");

            var userLogin = modelBuilder.Entity<IdentityUserLogin<int>>();
            userLogin.ToTable("OR_UserLogins");
            userLogin.HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
        }
    }
}