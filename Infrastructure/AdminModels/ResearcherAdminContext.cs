using System;
using Core.Entities.AdminModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.AdminModels
{
    public partial class ResearcherAdminContext : DbContext
    {
        public ResearcherAdminContext()
        {
        }

        public ResearcherAdminContext(DbContextOptions<ResearcherAdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionInRule> ActionInRule { get; set; }
        public virtual DbSet<RequestActions> RequestActions { get; set; }
        public virtual DbSet<RequestForms> RequestForms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "");

            modelBuilder.Entity<ActionInRule>(entity =>
            {
                entity.ToTable("ActionInRule", "dbo");

                entity.Property(e => e.ArName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.EnName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            

           

            modelBuilder.Entity<RequestActions>(entity =>
            {
                entity.ToTable("RequestActions", "dbo");

                entity.HasIndex(e => e.ActionId);

                entity.HasIndex(e => e.RequestFormId);

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.RequestActions)
                    .HasForeignKey(d => d.ActionId);

                entity.HasOne(d => d.RequestForm)
                    .WithMany(p => p.RequestActions)
                    .HasForeignKey(d => d.RequestFormId);
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
