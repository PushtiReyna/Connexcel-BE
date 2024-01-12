using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CourseMst> CourseMsts { get; set; }

    public virtual DbSet<TokenMst> TokenMsts { get; set; }

    public virtual DbSet<TutorOfferingDetail> TutorOfferingDetails { get; set; }

    public virtual DbSet<UserMst> UserMsts { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;user=sa;password=123;Database=ConnexcelDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CourseMs__3214EC07257E5156");

            entity.ToTable("CourseMst");

            entity.Property(e => e.CourseConversion).HasMaxLength(50);
            entity.Property(e => e.CourseName).HasMaxLength(100);
            entity.Property(e => e.CourseStatus).HasMaxLength(50);
            entity.Property(e => e.CourseType).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Frequency).HasMaxLength(50);
            entity.Property(e => e.NoofLessons).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.StudentDefaultRate).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Subject).HasMaxLength(100);
            entity.Property(e => e.Tutors).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TokenMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TokenMst__3214EC071112EFF6");

            entity.ToTable("TokenMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.RefreshTokenExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.TokenExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TutorOfferingDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TutorOff__3214EC0796FB69E1");

            entity.Property(e => e.AgeGroup).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.HourlyRate).HasMaxLength(50);
            entity.Property(e => e.Subject).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserMst__3214EC07867F614A");

            entity.ToTable("UserMst");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateofBirth).HasColumnType("datetime");
            entity.Property(e => e.DefaultRate).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.GuardianName).HasMaxLength(100);
            entity.Property(e => e.GuardianPhone).HasMaxLength(30);
            entity.Property(e => e.HourlyRate).HasMaxLength(50);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Localization).HasMaxLength(50);
            entity.Property(e => e.PhoneNo).HasMaxLength(30);
            entity.Property(e => e.PlatformPreference).HasMaxLength(50);
            entity.Property(e => e.School).HasMaxLength(100);
            entity.Property(e => e.SchoolYearGroup).HasMaxLength(50);
            entity.Property(e => e.TimeZone).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UseableHours).HasMaxLength(50);
            entity.Property(e => e.UserType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
