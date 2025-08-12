using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Lookups
        public DbSet<TipoMasa> TiposMasa { get; set; }
        public DbSet<TipoRelleno> TiposRelleno { get; set; }
        public DbSet<TipoEnvoltura> TiposEnvoltura { get; set; }
        public DbSet<NivelPicante> NivelesPicante { get; set; }
        public DbSet<TipoBebida> TiposBebida { get; set; }
        public DbSet<TipoEndulzante> TiposEndulzante { get; set; }
        public DbSet<TipoTopping> TiposTopping { get; set; }

        // Core tables
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<TransaccionInventario> TransaccionesInventario { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ConfiguracionProducto> ConfiguracionesProducto { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ItemCombo> ItemsCombo { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<ItemOrden> ItemsOrden { get; set; }
        public DbSet<IngredienteReceta> IngredientesReceta { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<TemporizadorLote> TemporizadoresLote { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Nombres de tablas explícitos si quieres
            modelBuilder.Entity<TipoMasa>().ToTable("tipos_masa");
            modelBuilder.Entity<TipoRelleno>().ToTable("tipos_relleno");
            modelBuilder.Entity<TipoEnvoltura>().ToTable("tipos_envoltura");
            modelBuilder.Entity<NivelPicante>().ToTable("niveles_picante");
            modelBuilder.Entity<TipoBebida>().ToTable("tipos_bebida");
            modelBuilder.Entity<TipoEndulzante>().ToTable("tipos_endulzante");
            modelBuilder.Entity<TipoTopping>().ToTable("tipos_topping");

            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Sucursal>().ToTable("sucursales");
            modelBuilder.Entity<Ingrediente>().ToTable("ingredientes");
            modelBuilder.Entity<TransaccionInventario>().ToTable("transacciones_inventario");
            modelBuilder.Entity<Producto>().ToTable("productos");
            modelBuilder.Entity<ConfiguracionProducto>().ToTable("configuraciones_producto");
            modelBuilder.Entity<Combo>().ToTable("combos");
            modelBuilder.Entity<ItemCombo>().ToTable("items_combo");
            modelBuilder.Entity<Orden>().ToTable("ordenes");
            modelBuilder.Entity<ItemOrden>().ToTable("items_orden");
            modelBuilder.Entity<IngredienteReceta>().ToTable("ingredientes_receta");
            modelBuilder.Entity<Notificacion>().ToTable("notificaciones");
            modelBuilder.Entity<Proveedor>().ToTable("proveedores");
            modelBuilder.Entity<TemporizadorLote>().ToTable("temporizadores_lote");

            // Índices recomendados
            modelBuilder.Entity<Orden>()
                .HasIndex(o => o.FechaOrden)
                .HasDatabaseName("idx_ordenes_fecha");

            modelBuilder.Entity<TransaccionInventario>()
                .HasIndex(t => t.IdIngrediente)
                .HasDatabaseName("idx_inventario_ingrediente");

            modelBuilder.Entity<ItemOrden>()
                .HasIndex(i => i.IdOrden)
                .HasDatabaseName("idx_items_orden_orden");

            // Configuraciones adicionales (opcional)
            // Ejemplo: relaciones uno a muchos, claves foráneas, delete behavior, etc.
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Sucursal)
                .WithMany(s => s.Usuarios)
                .HasForeignKey(u => u.id_sucursal)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TransaccionInventario>()
                .HasOne(t => t.Ingrediente)
                .WithMany(i => i.TransaccionesInventario)
                .HasForeignKey(t => t.IdIngrediente);

            modelBuilder.Entity<TransaccionInventario>()
                .HasOne(t => t.Sucursal)
                .WithMany(s => s.TransaccionesInventario)
                .HasForeignKey(t => t.IdSucursal);

            modelBuilder.Entity<ConfiguracionProducto>()
                .HasOne(c => c.Producto)
                .WithMany(p => p.ConfiguracionesProducto)
                .HasForeignKey(c => c.IdProducto);

            modelBuilder.Entity<ItemCombo>()
                .HasOne(ic => ic.Combo)
                .WithMany(c => c.ItemsCombo)
                .HasForeignKey(ic => ic.IdCombo);

            modelBuilder.Entity<ItemCombo>()
                .HasOne(ic => ic.ConfiguracionProducto)
                .WithMany(cp => cp.ItemsCombo)
                .HasForeignKey(ic => ic.IdConfiguracionProducto);

            modelBuilder.Entity<ItemOrden>()
                .HasOne(io => io.Orden)
                .WithMany(o => o.ItemsOrden)
                .HasForeignKey(io => io.IdOrden);

            modelBuilder.Entity<ItemOrden>()
                .HasOne(io => io.ConfiguracionProducto)
                .WithMany(cp => cp.ItemsOrden)
                .HasForeignKey(io => io.IdConfiguracionProducto)
                .IsRequired(false);

            modelBuilder.Entity<ItemOrden>()
                .HasOne(io => io.Combo)
                .WithMany(c => c.ItemsOrden)
                .HasForeignKey(io => io.IdCombo)
                .IsRequired(false);

            modelBuilder.Entity<IngredienteReceta>()
                .HasOne(ir => ir.ConfiguracionProducto)
                .WithMany(cp => cp.IngredientesReceta)
                .HasForeignKey(ir => ir.IdConfiguracionProducto);

            modelBuilder.Entity<IngredienteReceta>()
                .HasOne(ir => ir.Ingrediente)
                .WithMany(i => i.IngredientesReceta)
                .HasForeignKey(ir => ir.IdIngrediente);

            modelBuilder.Entity<Notificacion>()
                .HasOne(n => n.Usuario)
                .WithMany()
                .HasForeignKey(n => n.IdUsuario);

            modelBuilder.Entity<TemporizadorLote>()
                .HasOne(tl => tl.ConfiguracionProducto)
                .WithMany(cp => cp.TemporizadoresLote)
                .HasForeignKey(tl => tl.IdConfiguracionProducto);
        }
    }
}
