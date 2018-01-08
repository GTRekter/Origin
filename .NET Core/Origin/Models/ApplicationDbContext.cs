using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Origin.Models.Store;

namespace Origin.Models
{
    public class ApplicationDbContext : IdentityDbContext<OR_User, OR_Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<OR_Role> OR_Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var user = modelBuilder.Entity<OR_User>();
            user.ToTable("OR_Users");
            user.Property(p => p.Id).HasDefaultValueSql("NewId()");

            var role = modelBuilder.Entity<OR_Role>();
            role.ToTable("OR_Roles");
            role.Property(p => p.Id).HasDefaultValueSql("NewId()");

            var userRole = modelBuilder.Entity<IdentityUserRole<Guid>>();
            userRole.ToTable("OR_UserRoles");
            userRole.HasKey(r => new { r.UserId, r.RoleId });

            var userClaim = modelBuilder.Entity<IdentityUserClaim<Guid>>();
            userClaim.ToTable("OR_UserClaims");

            var roleClaim = modelBuilder.Entity<IdentityRoleClaim<Guid>>();
            roleClaim.ToTable("OR_RoleClaims");

            var userToken = modelBuilder.Entity<IdentityUserToken<Guid>>();
            userToken.ToTable("OR_UserTokens");

            var userLogin = modelBuilder.Entity<IdentityUserLogin<Guid>>();
            userLogin.ToTable("OR_UserLogins");
            userLogin.HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
        }
    }
}