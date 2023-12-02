using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebRestaurante.Models;

public partial class LabRestauranteMpContext : DbContext
{
    public LabRestauranteMpContext()
    {
    }

    public LabRestauranteMpContext(DbContextOptions<LabRestauranteMpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bebidum> Bebida { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Comidum> Comida { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Usuario1> Usuarios1 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LabRestauranteMP;User ID=usrrestaurantemp;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bebidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bebida__3213E83FA8875684");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precio");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())")
                .HasColumnName("usuarioRegistro");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3213E83F6BDEE978");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CedulaIdentidad)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cedulaIdentidad");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("primerApellido");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("segundoApellido");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())")
                .HasColumnName("usuarioRegistro");
        });

        modelBuilder.Entity<Comidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comida__3213E83F489D9E9E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precio");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())")
                .HasColumnName("usuarioRegistro");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3213E83F047EA22C");

            entity.ToTable("Empleado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cargo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("primerApellido");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("segundoApellido");
            entity.Property(e => e.Telefono)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())")
                .HasColumnName("usuarioRegistro");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Factura__3213E83F3D819AB2");

            entity.ToTable("Factura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdBebida).HasColumnName("idBebida");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdComida).HasColumnName("idComida");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())")
                .HasColumnName("usuarioRegistro");

            entity.HasOne(d => d.IdBebidaNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdBebida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Factura_Bebida");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Factura_Cliente");

            entity.HasOne(d => d.IdComidaNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdComida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Factura_Comida");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Factura_Empleado");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F7E2ADD3A");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usuario");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())")
                .HasColumnName("usuarioRegistro");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuario_Empleado");
        });

        modelBuilder.Entity<Usuario1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3213E83F61A007F8");

            entity.ToTable("Usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Usuario)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usuario");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())")
                .HasColumnName("usuarioRegistro");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Usuario1s)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuarios_Empleado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
