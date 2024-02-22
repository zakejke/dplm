using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace yeei.BdModels
{
    public partial class CoreModel : DbContext
    {
        private static CoreModel instanse;

        public static CoreModel init()
        {
              if(instanse==null)
            {
                instanse= new CoreModel();
            }
              return instanse;
        }

        public CoreModel()
        {
        }

        public CoreModel(DbContextOptions<CoreModel> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Polzovatel> Polzovatels { get; set; } = null!;
        public virtual DbSet<Sclad> Sclads { get; set; } = null!;
        public virtual DbSet<Sotrudniki> Sotrudnikis { get; set; } = null!;
        public virtual DbSet<Uslugi> Uslugis { get; set; } = null!;
        public virtual DbSet<Zakazi> Zakazis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=cfif31.ru;port=3306;database=ISPr22-43_CevelevAA_dplm;user id=ISPr22-43_CevelevAA;password=ISPr22-43_CevelevAA;character set=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Idclient)
                    .HasName("PRIMARY");

                entity.ToTable("client");

                entity.Property(e => e.Idclient).HasColumnName("idclient");

                entity.Property(e => e.Adress).HasMaxLength(45);

                entity.Property(e => e.Fio)
                    .HasMaxLength(45)
                    .HasColumnName("FIO");

                entity.Property(e => e.Phone).HasMaxLength(45);

                entity.Property(e => e.Usluga).HasMaxLength(45);
            });

            modelBuilder.Entity<Polzovatel>(entity =>
            {
                entity.HasKey(e => e.Idpolzovatel)
                    .HasName("PRIMARY");

                entity.ToTable("polzovatel");

                entity.Property(e => e.Idpolzovatel).HasColumnName("idpolzovatel");

                entity.Property(e => e.Login).HasMaxLength(45);

                entity.Property(e => e.Pass).HasMaxLength(45);

                entity.Property(e => e.Type).HasMaxLength(45);
            });

            modelBuilder.Entity<Sclad>(entity =>
            {
                entity.HasKey(e => e.Idsclad)
                    .HasName("PRIMARY");

                entity.ToTable("sclad");

                entity.Property(e => e.Idsclad).HasColumnName("idsclad");

                entity.Property(e => e.Colvo).HasMaxLength(100);

                entity.Property(e => e.Image).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasMaxLength(100);
            });

            modelBuilder.Entity<Sotrudniki>(entity =>
            {
                entity.HasKey(e => e.Idsotrudniki)
                    .HasName("PRIMARY");

                entity.ToTable("sotrudniki");

                entity.Property(e => e.Idsotrudniki).HasColumnName("idsotrudniki");

                entity.Property(e => e.Famsotr).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(45);

                entity.Property(e => e.PhoneSotr)
                    .HasMaxLength(11)
                    .HasColumnName("Phone_sotr");

                entity.Property(e => e.Surname).HasMaxLength(45);
            });

            modelBuilder.Entity<Uslugi>(entity =>
            {
                entity.HasKey(e => e.IdUslugi)
                    .HasName("PRIMARY");

                entity.ToTable("Uslugi");

                entity.Property(e => e.IdUslugi).HasColumnName("idUslugi");

                entity.Property(e => e.Cena).HasMaxLength(45);

                entity.Property(e => e.Nazvanie).HasMaxLength(45);

                entity.Property(e => e.Vremya).HasMaxLength(45);
            });

            modelBuilder.Entity<Zakazi>(entity =>
            {
                entity.HasKey(e => e.IdZakazi)
                    .HasName("PRIMARY");

                entity.ToTable("Zakazi");

                entity.Property(e => e.IdZakazi).HasColumnName("idZakazi");

                entity.Property(e => e.Adres).HasMaxLength(45);

                entity.Property(e => e.Familia).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(45);

                entity.Property(e => e.Nomer).HasMaxLength(45);

                entity.Property(e => e.Otchestvo).HasMaxLength(45);

                entity.Property(e => e.Status).HasMaxLength(45);

                entity.Property(e => e.Usluga).HasMaxLength(45);

                entity.Property(e => e.Vremya).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
