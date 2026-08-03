using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KfSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace KfSoft.EFCore.Context
{
    public  class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Departamento>(entity =>
           {
               entity.HasKey(e => e.Codigo);
               entity.Property(e => e.Nome)
               .IsRequired()
               .HasMaxLength(50);

               entity.Property(e => e.Descricao)
               .IsRequired()
               .HasMaxLength(100);

               entity.Property(e => e.DataCriacao)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("GETDATE()");

           });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Responsavel)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.DataInicio)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.Status)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("1");

            });     

        }


    }
}
