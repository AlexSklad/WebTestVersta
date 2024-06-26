using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebTestVersta.Models;

public partial class SuppliesDbContext : DbContext
{
    public SuppliesDbContext()
    {
    }

    public SuppliesDbContext(DbContextOptions<SuppliesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Recipient> Recipients { get; set; }

    public virtual DbSet<Sender> Senders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SuppliesDB;Integrated Security=SSPI;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07B0749FA1");

            entity.Property(e => e.CargoWeight).HasMaxLength(50);
            entity.Property(e => e.OrderNum)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.PickupDate).HasColumnType("date");
            entity.Property(e => e.RecId).HasColumnName("RecID");
            entity.Property(e => e.SenderId).HasColumnName("SenderID");

            entity.HasOne(d => d.Rec).WithMany(p => p.Orders)
                .HasForeignKey(d => d.RecId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__RecID__3A81B327");

            entity.HasOne(d => d.Sender).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__SenderID__5AEE82B9");
        });

        modelBuilder.Entity<Recipient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC073A34F04B");

            entity.HasIndex(e => e.RecAddress, "UQ__Recipien__2CB74F3B5F3A8B1E").IsUnique();
            entity.Property(e => e.RecAddress).HasMaxLength(50);
            entity.Property(e => e.RecCity).HasMaxLength(50);
        });

        modelBuilder.Entity<Sender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0710339CA3");
            
            entity.HasIndex(e => e.SenderAddress, "UQ__Senders__DF28C57E3E6D9496").IsUnique();
            entity.Property(e => e.SenderAddress).HasMaxLength(50);
            entity.Property(e => e.SenderCity).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
