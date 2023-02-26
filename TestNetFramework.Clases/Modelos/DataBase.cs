using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TestNetFramework.Clases.Modelos
{
    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=DataBase")
        {
        }

        public virtual DbSet<Mascotas> Mascotas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mascotas>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Mascotas>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.nombreCompleto)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Mascotas)
                .WithRequired(e => e.Usuarios)
                .WillCascadeOnDelete(false);
        }
    }
}
