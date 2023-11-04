using System;
using System.Collections.Generic;
using CovidAnalysis.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CovidAnalysis.Infrastructure.Data.EF;

public partial class CovidDbContext : DbContext
{
    public CovidDbContext(DbContextOptions<CovidDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CovidStatistic> CovidStatistics { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-95IB3M4H\\SQLSERVER;Initial Catalog=CovidDB;User ID=sa;Password=SqlServer; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CovidStatistic>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ActiveCases).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.DeathsPer1Mpopulation).HasColumnName("DeathsPer1MPopulation");
            entity.Property(e => e.NewCases).HasMaxLength(50);
            entity.Property(e => e.NewDeaths).HasMaxLength(50);
            entity.Property(e => e.NewRecovered).HasMaxLength(50);
            entity.Property(e => e.Population).HasMaxLength(50);
            entity.Property(e => e.SeriousCritical).HasMaxLength(50);
            entity.Property(e => e.TestsPer1Mpopulation)
                .HasMaxLength(50)
                .HasColumnName("TestsPer1MPopulation");
            entity.Property(e => e.TotCasesPer1Mpopulation).HasColumnName("TotCasesPer1MPopulation");
            entity.Property(e => e.TotalCases).HasMaxLength(50);
            entity.Property(e => e.TotalDeaths).HasMaxLength(50);
            entity.Property(e => e.TotalRecovered).HasMaxLength(50);
            entity.Property(e => e.TotalTests).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
