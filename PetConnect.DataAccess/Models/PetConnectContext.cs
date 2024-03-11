using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PetConnect.DataAccess.Models;

public partial class PetConnectContext : DbContext
{
    public PetConnectContext()
    {
    }

    public PetConnectContext(DbContextOptions<PetConnectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AdopterDetail> AdopterDetails { get; set; }

    public virtual DbSet<AdoptionApplication> AdoptionApplications { get; set; }

    public virtual DbSet<AdoptionFinalization> AdoptionFinalizations { get; set; }

    public virtual DbSet<Breed> Breeds { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3214EC07E2C33DE8");

            entity.Property(e => e.Address1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Address");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Addresses__CityI__30F848ED");

            entity.HasOne(d => d.Country).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Addresses__Count__32E0915F");

            entity.HasOne(d => d.State).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Addresses__State__31EC6D26");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Addresses__UserI__300424B4");
        });

        modelBuilder.Entity<AdopterDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdopterD__3214EC078160EA72");

            entity.Property(e => e.AdoptionMotivation)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("text");
            entity.Property(e => e.AdoptionTimeline).HasMaxLength(20);
            entity.Property(e => e.HomeOwnership)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OtherPetsDetails)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.PreviousPetExperience)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.Application).WithMany(p => p.AdopterDetails)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AdopterDetails_ApplicationId");
        });

        modelBuilder.Entity<AdoptionApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Adoption__3214EC07E3F80AA0");

            entity.ToTable("AdoptionApplication");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Pet).WithMany(p => p.AdoptionApplications)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdoptionRequests_Pets");

            entity.HasOne(d => d.User).WithMany(p => p.AdoptionApplications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdoptionRequests_Users");
        });

        modelBuilder.Entity<AdoptionFinalization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Adoption__3214EC07DED786B7");

            entity.ToTable("AdoptionFinalization");

            entity.Property(e => e.FinalizationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Application).WithMany(p => p.AdoptionFinalizations)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AdoptionFinalization_ApplicationId");
        });

        modelBuilder.Entity<Breed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Breeds__3214EC07B05AD376");

            entity.Property(e => e.AverageSize)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AverageWeight)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BreedName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Origin)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Breeds)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Breeds__Category__3B75D760");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC071717CE76");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cities__3214EC07F6B44F94");

            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Cities__StateId__29572725");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Countrie__3214EC07459811A5");

            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pets__3214EC077CFE8F6A");

            entity.Property(e => e.AvailableForAdoption).HasDefaultValue(true);
            entity.Property(e => e.BreedId).HasColumnName("BreedID");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsAltered).HasDefaultValue(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PetSize)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.VaccinationStatus).HasDefaultValue(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Breed).WithMany(p => p.Pets)
                .HasForeignKey(d => d.BreedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pets_Breeds");

            entity.HasOne(d => d.User).WithMany(p => p.Pets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pets_Users");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__States__3214EC07AC46D2F4");

            entity.Property(e => e.StateName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__States__CountryI__267ABA7A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0794DD507F");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
