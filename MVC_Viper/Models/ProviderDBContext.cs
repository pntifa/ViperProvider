using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_Viper.Models;

public partial class ProviderDBContext : DbContext
{
    public ProviderDBContext()
    {
    }

    public ProviderDBContext(DbContextOptions<ProviderDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Call> Calls { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Programs> Programs { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=providerDB;Trusted_Connection=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__admin__4A3006F74B196BEF");

            entity.Property(e => e.AdminId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Admins).HasConstraintName("FK__admin__User_Id__3F466844");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__bills__CF6E7D4378E44C25");

            entity.Property(e => e.BillId).ValueGeneratedNever();

            entity.HasOne(d => d.PhoneNumberNavigation).WithMany(p => p.Bills).HasConstraintName("FK__bills__PhoneNumb__46E78A0C");

            entity.HasMany(d => d.Calls).WithMany(p => p.Bills)
                .UsingEntity<Dictionary<string, object>>(
                    "Billcall",
                    r => r.HasOne<Call>().WithMany()
                        .HasForeignKey("CallId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__billcalls__Call___4CA06362"),
                    l => l.HasOne<Bill>().WithMany()
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__billcalls__Bill___4BAC3F29"),
                    j =>
                    {
                        j.HasKey("BillId", "CallId").HasName("PK__billcall__6EF0120D4829D6D4");
                        j.ToTable("billcalls");
                        j.IndexerProperty<int>("BillId").HasColumnName("Bill_ID");
                        j.IndexerProperty<int>("CallId").HasColumnName("Call_ID");
                    });
        });

        modelBuilder.Entity<Call>(entity =>
        {
            entity.HasKey(e => e.CallId).HasName("PK__calls__19E6F4EB2F82E63F");

            entity.Property(e => e.CallId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__clients__75A5D8F8F69852E9");

            entity.Property(e => e.ClientId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Clients).HasConstraintName("FK__clients__User_Id__3C69FB99");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.PhoneNumber).HasName("PK__phones__85FB4E391C49890F");

            entity.HasOne(d => d.ProgramNameNavigation).WithMany(p => p.Phones).HasConstraintName("FK__phones__Program___440B1D61");
        });

        modelBuilder.Entity<Programs>(entity =>
        {
            entity.HasKey(e => e.ProgramName).HasName("PK__programs__1DF87844D749C4E7");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.SellerId).HasName("PK__sellers__009FC2A9AA606066");

            entity.Property(e => e.SellerId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Sellers).HasConstraintName("FK__sellers__User_Id__398D8EEE");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__206D917065CDFAD4");

            entity.Property(e => e.UserId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
