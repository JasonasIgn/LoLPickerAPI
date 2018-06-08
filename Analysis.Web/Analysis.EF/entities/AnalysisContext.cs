﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Analysis.EF.entities
{
    public partial class AnalysisContext : DbContext
    {
        //konstruktorius
        public AnalysisContext(DbContextOptions<AnalysisContext> options)
        : base(options)
        { }

        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<GeneralData> GeneralData { get; set; }

        public virtual DbSet<Champion> Champion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=LOL;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("matches");

                entity.Property(e => e.Id).HasColumnName("Id");

                //entity.Property(e => e.TeamCode)
                //.HasColumnName("TeamCode")
                //.HasMaxLength(40);

                entity.Property(e => e.Team1Wins)
                    .HasColumnName("Team1Wins")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Team2Wins)
                    .HasColumnName("Team2Wins")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<GeneralData>(entity =>
            {
                entity.ToTable("general");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.ApiKey).HasColumnName("ApiKey");

                entity.Property(e => e.CurrentMatchId)
                .HasColumnName("CurrentMatchId");

                entity.Property(e => e.TotalTeamCombinations)
                    .HasColumnName("TotalTeamCombinations")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Champion>(entity =>
            {
                entity.ToTable("champion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                .HasColumnName("title");

                entity.Property(e => e.Name)
               .HasColumnName("name");

                entity.Property(e => e.Key)
                    .HasColumnName("keyy");
            });
        }
    }
}
