using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Food4You.Services.Database;

public partial class Food4YouContext : DbContext
{
    public Food4YouContext()
    {
    }

    public Food4YouContext(DbContextOptions<Food4YouContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Drzava> Drzavas { get; set; }

    public virtual DbSet<Grad> Grads { get; set; }

    public virtual DbSet<Kategorija> Kategorijas { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<KorisnikUloga> KorisnikUlogas { get; set; }

    public virtual DbSet<Meni> Menis { get; set; }

    public virtual DbSet<Narudzba> Narudzbas { get; set; }

    public virtual DbSet<NarudzbaStavke> NarudzbaStavkes { get; set; }

    public virtual DbSet<Recenzije> Recenzijes { get; set; }

    public virtual DbSet<StatusNarudzbe> StatusNarudzbes { get; set; }

    public virtual DbSet<Uloga> Ulogas { get; set; }

    public virtual DbSet<Uplatum> Uplata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost, 1433;Initial Catalog=Food4You; User=sa; Password=test; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drzava>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drzava__3214EC077B24F9AE");

            entity.ToTable("Drzava");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Naziv).HasMaxLength(100);
        });

        modelBuilder.Entity<Grad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grad__3214EC0703D5B88E");

            entity.ToTable("Grad");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Naziv).HasMaxLength(100);
        });

        modelBuilder.Entity<Kategorija>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kategori__3214EC07F4A4B1B1");

            entity.ToTable("Kategorija");

            entity.Property(e => e.Naziv).HasMaxLength(100);
            entity.Property(e => e.Opis).HasMaxLength(100);
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Korisnik__3214EC079965D60E");

            entity.ToTable("Korisnik");

            entity.Property(e => e.Ime).HasMaxLength(100);
            entity.Property(e => e.KorisnickoIme).HasMaxLength(100);
            entity.Property(e => e.LozinkaHash).HasMaxLength(100);
            entity.Property(e => e.LozinkaSalt).HasMaxLength(100);
            entity.Property(e => e.Prezime).HasMaxLength(100);

            entity.HasOne(d => d.Drzava).WithMany(p => p.Korisniks)
                .HasForeignKey(d => d.DrzavaId)
                .HasConstraintName("FK__Korisnik__Drzava__71D1E811");

            entity.HasOne(d => d.Grad).WithMany(p => p.Korisniks)
                .HasForeignKey(d => d.GradId)
                .HasConstraintName("FK__Korisnik__GradId__70DDC3D8");
        });

        modelBuilder.Entity<KorisnikUloga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Korisnik__3214EC07396D9064");

            entity.ToTable("KorisnikUloga");

            entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisnikUlogas)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK__KorisnikU__Koris__76969D2E");

            entity.HasOne(d => d.Uloga).WithMany(p => p.KorisnikUlogas)
                .HasForeignKey(d => d.UlogaId)
                .HasConstraintName("FK__KorisnikU__Uloga__778AC167");
        });

        modelBuilder.Entity<Meni>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Meni__3214EC07AB24D271");

            entity.ToTable("Meni");

            entity.Property(e => e.Cijena).HasColumnType("money");

            entity.HasOne(d => d.Kategorija).WithMany(p => p.Menis)
                .HasForeignKey(d => d.KategorijaId)
                .HasConstraintName("FK__Meni__Kategorija__4E88ABD4");
        });

        modelBuilder.Entity<Narudzba>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Narudzba__3214EC077DAAB08D");

            entity.ToTable("Narudzba");

            entity.Property(e => e.DatumNarudzbe).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Narudzbas)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK__Narudzba__Korisn__7D439ABD");

            entity.HasOne(d => d.StatusNarudzbe).WithMany(p => p.Narudzbas)
                .HasForeignKey(d => d.StatusNarudzbeId)
                .HasConstraintName("FK__Narudzba__Status__7C4F7684");
        });

        modelBuilder.Entity<NarudzbaStavke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Narudzba__3214EC07CF813CCB");

            entity.ToTable("NarudzbaStavke");

            entity.Property(e => e.Cijena).HasColumnType("money");

            entity.HasOne(d => d.Meni).WithMany(p => p.NarudzbaStavkes)
                .HasForeignKey(d => d.MeniId)
                .HasConstraintName("FK__NarudzbaS__MeniI__00200768");

            entity.HasOne(d => d.Narudzba).WithMany(p => p.NarudzbaStavkes)
                .HasForeignKey(d => d.NarudzbaId)
                .HasConstraintName("FK__NarudzbaS__Narud__01142BA1");
        });

        modelBuilder.Entity<Recenzije>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recenzij__3214EC0775C908A4");

            entity.ToTable("Recenzije");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Recenzijes)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK__Recenzije__Koris__04E4BC85");

            entity.HasOne(d => d.Meni).WithMany(p => p.Recenzijes)
                .HasForeignKey(d => d.MeniId)
                .HasConstraintName("FK__Recenzije__MeniI__03F0984C");
        });

        modelBuilder.Entity<StatusNarudzbe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StatusNa__3214EC07AFE0E716");

            entity.ToTable("StatusNarudzbe");

            entity.Property(e => e.Naziv).HasMaxLength(100);
        });

        modelBuilder.Entity<Uloga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Uloga__3214EC07F993517F");

            entity.ToTable("Uloga");

            entity.Property(e => e.Naziv).HasMaxLength(100);
        });

        modelBuilder.Entity<Uplatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Uplata__3214EC07FEFF0C35");

            entity.Property(e => e.BrojTransakcije).HasMaxLength(100);
            entity.Property(e => e.DatumTransakcije).HasColumnType("datetime");
            entity.Property(e => e.Iznos).HasColumnType("money");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Uplata)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK__Uplata__Korisnik__07C12930");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
