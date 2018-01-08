using System;
using Microsoft.EntityFrameworkCore;
using Origin.Models.Store;

namespace Origin.Models
{
    public class OriginContext : DbContext
    {
        public OriginContext(DbContextOptions<OriginContext> options)
            : base(options)
        {
        }

        public DbSet<OR_Form> OR_Forms { get; set; }

        public DbSet<OR_Property> OR_Properties { get; set; }

        public DbSet<OR_Input> OR_Inputs { get; set; }

        public DbSet<OR_Item> OR_Items { get; set; }

        public DbSet<OR_ItemAction> OR_ItemActions { get; set; }

        public DbSet<OR_ItemType> OR_ItemTypes { get; set; }

        public DbSet<OR_Lookup> OR_Lookups { get; set; }

        public DbSet<OR_LookupValue> OR_LookupValues { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}