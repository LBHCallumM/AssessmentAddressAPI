using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssessmentAddressAPI.Infrastructure
{
    public partial class AddressDbContext : DbContext
    {
        public AddressDbContext()
        {
        }

        public AddressDbContext(DbContextOptions<AddressDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HackneyAddress> HackneyAddresses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HackneyAddress>(entity =>
            {
                entity.HasKey(e => e.LpiKey)
                    .HasName("hackney_address_pkey");

                entity.ToTable("hackney_address");

                entity.Property(e => e.LpiKey)
                    .HasMaxLength(14)
                    .HasColumnName("lpi_key");

                entity.Property(e => e.BlpuClass)
                    .HasMaxLength(4)
                    .HasColumnName("blpu_class");

                entity.Property(e => e.BlpuEndDate).HasColumnName("blpu_end_date");

                entity.Property(e => e.BlpuLastUpdateDate).HasColumnName("blpu_last_update_date");

                entity.Property(e => e.BlpuStartDate).HasColumnName("blpu_start_date");

                entity.Property(e => e.BuildingNumber)
                    .HasMaxLength(17)
                    .HasColumnName("building_number");

                entity.Property(e => e.Easting).HasColumnName("easting");

                entity.Property(e => e.Gazetteer)
                    .HasMaxLength(8)
                    .HasColumnName("gazetteer");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Line1)
                    .HasMaxLength(200)
                    .HasColumnName("line1");

                entity.Property(e => e.Line2)
                    .HasMaxLength(200)
                    .HasColumnName("line2");

                entity.Property(e => e.Line3)
                    .HasMaxLength(200)
                    .HasColumnName("line3");

                entity.Property(e => e.Line4)
                    .HasMaxLength(100)
                    .HasColumnName("line4");

                entity.Property(e => e.Locality)
                    .HasMaxLength(100)
                    .HasColumnName("locality");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.LpiEndDate).HasColumnName("lpi_end_date");

                entity.Property(e => e.LpiLastUpdateDate).HasColumnName("lpi_last_update_date");

                entity.Property(e => e.LpiLogicalStatus)
                    .HasMaxLength(18)
                    .HasColumnName("lpi_logical_status");

                entity.Property(e => e.LpiStartDate).HasColumnName("lpi_start_date");

                entity.Property(e => e.Neverexport).HasColumnName("neverexport");

                entity.Property(e => e.Northing).HasColumnName("northing");

                entity.Property(e => e.Organisation)
                    .HasMaxLength(100)
                    .HasColumnName("organisation");

                entity.Property(e => e.PaoText)
                    .HasMaxLength(90)
                    .HasColumnName("pao_text");

                entity.Property(e => e.PaonStartNum).HasColumnName("paon_start_num");

                entity.Property(e => e.ParentUprn).HasColumnName("parent_uprn");

                entity.Property(e => e.PlanningUseClass)
                    .HasMaxLength(50)
                    .HasColumnName("planning_use_class");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(8)
                    .HasColumnName("postcode");

                entity.Property(e => e.PostcodeNospace)
                    .HasMaxLength(8)
                    .HasColumnName("postcode_nospace");

                entity.Property(e => e.PropertyShell).HasColumnName("property_shell");

                entity.Property(e => e.SaoText)
                    .HasMaxLength(90)
                    .HasColumnName("sao_text");

                entity.Property(e => e.StreetDescription)
                    .HasMaxLength(100)
                    .HasColumnName("street_description");

                entity.Property(e => e.Town)
                    .HasMaxLength(100)
                    .HasColumnName("town");

                entity.Property(e => e.UnitNumber).HasColumnName("unit_number");

                entity.Property(e => e.Uprn).HasColumnName("uprn");

                entity.Property(e => e.UsageDescription)
                    .HasMaxLength(160)
                    .HasColumnName("usage_description");

                entity.Property(e => e.UsagePrimary)
                    .HasMaxLength(160)
                    .HasColumnName("usage_primary");

                entity.Property(e => e.Usrn).HasColumnName("usrn");

                entity.Property(e => e.Ward)
                    .HasMaxLength(100)
                    .HasColumnName("ward");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
