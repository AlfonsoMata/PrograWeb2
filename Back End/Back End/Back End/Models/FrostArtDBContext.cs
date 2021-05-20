using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class FrostArtDBContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Etiquetas> Etiquetas { get; set; }
        public DbSet<Favoritos> Favoritos { get; set; }
        public DbSet<Imagenes> Imagenes { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Publicaciones> Publicaciones { get; set; }
        public DbSet<PublicacionEtiquetas> PublicacionEtiquetas { get; set; }
        public DbSet<Temas> Temas { get; set; }
        public DbSet<UsuarioDestacados> UsuarioDestacados { get; set; }
        public DbSet<UsuariosSeguidos> usuariosSeguidos { get; set; }

        public FrostArtDBContext() { }

        public FrostArtDBContext(DbContextOptions<FrostArtDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(EntityFrameworkQueryableExtensions =>
            {
                EntityFrameworkQueryableExtensions.HasKey(e => e.Id);
                EntityFrameworkQueryableExtensions.Property(e => e.Nombre).HasMaxLength(30).IsUnicode(false).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.Contra).HasMaxLength(30).IsUnicode(false).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.Email).HasMaxLength(254).IsUnicode(false).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.Descripcion).HasMaxLength(280).IsUnicode(false).IsRequired(false);
                EntityFrameworkQueryableExtensions.Property(e => e.FechaNacimiento).HasColumnType("datetime").IsRequired(false);
                EntityFrameworkQueryableExtensions.Property(e => e.FotoPerfil).HasMaxLength(150).IsRequired(false);



            });

            modelBuilder.Entity<Temas>(EntityFrameworkQueryableExtensions =>
            {
                EntityFrameworkQueryableExtensions.HasKey(e => e.Id);
                EntityFrameworkQueryableExtensions.Property(e => e.Nombre).HasMaxLength(30).IsUnicode(false).IsRequired();

              
            });

            modelBuilder.Entity<Publicaciones>(EntityFrameworkQueryableExtensions =>
            {
                EntityFrameworkQueryableExtensions.HasKey(e => e.Id);
                EntityFrameworkQueryableExtensions.Property(e => e.IdUsuario).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.Titulo).HasMaxLength(60).IsUnicode(false).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.Descripcion).HasMaxLength(280).IsUnicode(false).IsRequired(false);
                EntityFrameworkQueryableExtensions.Property(e => e.IdTema).IsRequired(true);
                EntityFrameworkQueryableExtensions.Property(e => e.Fecha).HasColumnType("datetime").IsRequired(false);
                EntityFrameworkQueryableExtensions.Property(e => e.Activo).HasColumnType("bit").IsRequired();

                EntityFrameworkQueryableExtensions.HasOne(e => e.Usuarios).WithMany(y => y.Publicaciones)
                    .HasConstraintName("FK_Publicaciones_Usuarios");

                EntityFrameworkQueryableExtensions.HasOne(e => e.Temas).WithMany(y => y.Publicaciones)
                    .HasConstraintName("FK_Publicaciones_Temas");
            });

            modelBuilder.Entity<Etiquetas>(EntityFrameworkQueryableExtensions =>
            {
                EntityFrameworkQueryableExtensions.HasKey(e => e.Id);
                EntityFrameworkQueryableExtensions.Property(e => e.Nombre).HasMaxLength(30).IsRequired();

            });

            modelBuilder.Entity<PublicacionEtiquetas>(EntityFrameworkQueryableExtensions =>
            {
                EntityFrameworkQueryableExtensions.HasKey(e => e.Id);
                EntityFrameworkQueryableExtensions.Property(e => e.IdPublicacion).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.IdEtiqueta).IsRequired();

                EntityFrameworkQueryableExtensions.HasOne(e => e.Publicaciones).WithMany(y => y.PublicacionEtiquetas)
                    .HasConstraintName("FK_PublicacionEtiquetas_Publicaciones");

                EntityFrameworkQueryableExtensions.HasOne(e => e.Etiquetas).WithMany(y => y.PublicacionEtiquetas)
                   .HasConstraintName("FK_PublicacionEtiquetas_Etiquetas");
            });

            modelBuilder.Entity<Likes>(EntityFrameworkQueryableExtensions =>
            {
                EntityFrameworkQueryableExtensions.HasKey(e => e.Id);
                EntityFrameworkQueryableExtensions.Property(e => e.IdPublicacion).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.IdUsuario).IsRequired();

                EntityFrameworkQueryableExtensions.HasOne(e => e.Publicaciones).WithMany(y => y.Likes)
                    .HasConstraintName("FK_Likes_Publicaciones");

                EntityFrameworkQueryableExtensions.HasOne(e => e.Usuarios).WithMany(y => y.Likes)
                   .HasConstraintName("FK_Likes_Usuarios");
            });

            modelBuilder.Entity<Imagenes>(EntityFrameworkQueryableExtensions =>
            {
                EntityFrameworkQueryableExtensions.HasKey(e => e.Id);
                EntityFrameworkQueryableExtensions.Property(e => e.IdPublicacion).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.Imagen).HasMaxLength(150).IsRequired(false);

                EntityFrameworkQueryableExtensions.HasOne(e => e.Publicaciones).WithMany(y => y.Imagenes)
                   .HasConstraintName("FK_Imagenes_Publicaciones");
            });

            modelBuilder.Entity<UsuarioDestacados>(EntityFrameworkQueryableExtensions =>
            {
                EntityFrameworkQueryableExtensions.HasKey(e => e.Id);
                EntityFrameworkQueryableExtensions.Property(e => e.IdUsuario).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.IdPublicacion).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.IndiceOrden).IsRequired();

                EntityFrameworkQueryableExtensions.HasOne(e => e.Usuarios).WithMany(y => y.UsuarioDestacado)
                    .HasConstraintName("FK_UsuarioDestacados_Usuarios");
                EntityFrameworkQueryableExtensions.HasOne(e => e.Publicaciones).WithMany(y => y.UsuarioDestacados)
                    .HasConstraintName("FK_UsuarioDestacados_Publicaciones");

            });

            modelBuilder.Entity<Comentarios>(EntityFrameworkQueryableExtensions =>
            {
                EntityFrameworkQueryableExtensions.HasKey(e => e.Id);
                EntityFrameworkQueryableExtensions.Property(e => e.IdUsuario).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.IdPublicacion).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.Texto).HasMaxLength(280).IsUnicode(false).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.Fecha).HasColumnType("datetime").IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.Activo).HasColumnType("bit").IsRequired();

                EntityFrameworkQueryableExtensions.HasOne(e => e.Publicaciones).WithMany(y => y.Comentarios)
                    .HasConstraintName("FK_Comentarios_Publicaciones");

                EntityFrameworkQueryableExtensions.HasOne(e => e.Usuarios).WithMany(y => y.Comentarios)
                   .HasConstraintName("FK_Comentarios_Usuarios");
            });

            modelBuilder.Entity<Favoritos>(EntityFrameworkQueryableExtensions =>
            {
                EntityFrameworkQueryableExtensions.HasKey(e => e.Id);
                EntityFrameworkQueryableExtensions.Property(e => e.IdPublicacion).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.IdUsuario).IsRequired();

                EntityFrameworkQueryableExtensions.HasOne(e => e.Publicaciones).WithMany(y => y.Favoritos)
                    .HasConstraintName("FK_Favoritos_Publicaciones");

                EntityFrameworkQueryableExtensions.HasOne(e => e.Usuarios).WithMany(y => y.Favoritos)
                   .HasConstraintName("FK_Favoritos_Usuarios");
            });

            modelBuilder.Entity<UsuariosSeguidos>(EntityFrameworkQueryableExtensions =>
            {
                EntityFrameworkQueryableExtensions.HasKey(e => e.Id);
                EntityFrameworkQueryableExtensions.Property(e => e.IdUsuarioSeguido).IsRequired();
                EntityFrameworkQueryableExtensions.Property(e => e.IdUsuario).IsRequired();

                EntityFrameworkQueryableExtensions.HasOne(e => e.Usuarios).WithMany(y => y.UsuariosSeguidos)
                    .HasConstraintName("FK_UsuariosSeguidos_Usuario1");

                
            });

        }

    }
}
