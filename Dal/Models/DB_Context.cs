using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class DB_Context : DbContext
{
    public DB_Context()
    {
    }

    public DB_Context(DbContextOptions<DB_Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<CovidDetail> CovidDetails { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<VaccineManufacturer> VaccineManufacturers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Owner\\תיכנות הכל\\תרגיל בית הדסים 4\\CoronaCare_HUb_exe_2\\db\\Database1.mdf\";Integrated Security=True;Connect Timeout=30");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__tmp_ms_x__091C2A1BA8DD9A19");

            entity.ToTable("Address");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.StreetId).HasColumnName("StreetID");
            entity.Property(e => e.StreetNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Street).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StreetId)
                .HasConstraintName("FK__Address__StreetI__6477ECF3");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__tmp_ms_x__F2D21A96007EFC0A");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<CovidDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__CovidDet__7AD04FF1799E8321");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.FirstVaccineDate).HasColumnType("date");
            entity.Property(e => e.FourthVaccineDate).HasColumnType("date");
            entity.Property(e => e.PositiveTestDate).HasColumnType("date");
            entity.Property(e => e.RecoveryDate).HasColumnType("date");
            entity.Property(e => e.SecondVaccineDate).HasColumnType("date");
            entity.Property(e => e.ThirdVaccineDate).HasColumnType("date");
            entity.Property(e => e.VaccineManufacturerId).HasColumnName("VaccineManufacturerID");

            entity.HasOne(d => d.Employee).WithOne(p => p.CovidDetail)
                .HasForeignKey<CovidDetail>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CovidDeta__Emplo__6754599E");

            entity.HasOne(d => d.VaccineManufacturer).WithMany(p => p.CovidDetails)
                .HasForeignKey(d => d.VaccineManufacturerId)
                .HasConstraintName("FK__CovidDeta__Vacci__68487DD7");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__tmp_ms_x__7AD04FF147DD8AEF");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Idnumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("IDNumber");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Address).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__Employee__Addres__656C112C");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.StreetId).HasName("PK__tmp_ms_x__6270EB1A03C2377B");

            entity.ToTable("Street");

            entity.Property(e => e.StreetId).HasColumnName("StreetID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.StreetName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.City).WithMany(p => p.Streets)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Street__CityID__66603565");
        });

        modelBuilder.Entity<VaccineManufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PK__tmp_ms_x__357E5CA1FA814C9C");

            entity.ToTable("VaccineManufacturer");

            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
