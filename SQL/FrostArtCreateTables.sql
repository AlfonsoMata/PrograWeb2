
/*
	Equipo 02
	Integrantes:
	1800628 José Arturo Rodríguez Cavazos
	1803321	Alfonso Mata de Anda
	1800719	Pablo Andrés Mariles Feregrino
	1838420 Rene Miramontes Hernandez


	Query #1
		Creacion de la base de datos
		Creacion de las tablas:
			Usuarios
			Temas
			Publicaciones
			Etiquetas
			PublicacionEtiquetas
			Likes
			Imagenes
			UsuarioDestacados
			Comentarios
			Favoritos
			UsuariosSeguidos
					
					
		Fecha: 2021-03-12

*/
IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'FrostArtDB')
BEGIN
	CREATE DATABASE FrostArtDB
END

GO
USE FrostArtDB


GO
IF OBJECT_ID('Usuarios', 'U') IS NULL
BEGIN
CREATE TABLE Usuarios (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(30) NOT NULL,
	Contra VARCHAR(30) NOT NULL,
	Email  VARCHAR(254) NOT NULL,
	Descripcion VARCHAR (280) NULL,
	FechaNacimiento DATE NULL,
	FotoPerfil VARBINARY(MAX) NULL,
)
END

GO
IF OBJECT_ID('Temas', 'U') IS NULL
BEGIN
CREATE TABLE Temas (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(30) NOT NULL

)
END

GO
IF OBJECT_ID('Publicaciones', 'U') IS NULL
BEGIN
CREATE TABLE Publicaciones (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUsuario INT NOT NULL,
	Titulo VARCHAR (60) NOT NULL,
	Descripcion VARCHAR (280) NULL,
	IdTema INT NOT NULL,
	Fecha DATETIME NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,

	CONSTRAINT FK_Publicaciones_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id),
	CONSTRAINT FK_Publicaciones_Temas FOREIGN KEY (IdTema) REFERENCES Temas(Id)
)
END

GO
IF OBJECT_ID('Etiquetas', 'U') IS NULL
BEGIN
CREATE TABLE Etiquetas (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(30) NOT NULL
)
END

GO
IF OBJECT_ID('PublicacionEtiquetas', 'U') IS NULL
BEGIN
CREATE TABLE PublicacionEtiquetas (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdPublicacion INT NOT NULL,
	IdEtiqueta INT NOT NULL,
	CONSTRAINT FK_PublicacionEtiquetas_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(Id),
	CONSTRAINT FK_PublicacionEtiquetas_Etiquetas FOREIGN KEY (IdEtiqueta) REFERENCES Etiquetas(Id)
)
END

GO
IF OBJECT_ID('Likes', 'U') IS NULL
BEGIN
CREATE TABLE Likes (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdPublicacion INT NOT NULL,
	IdUsuario INT NOT NULL,

	CONSTRAINT FK_Likes_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(Id),
	CONSTRAINT FK_Likes_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id)
)
END

GO
IF OBJECT_ID('Imagenes', 'U') IS NULL
BEGIN
CREATE TABLE Imagenes (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdPublicacion INT NOT NULL,
	Imagen VARBINARY(MAX) NULL,

	CONSTRAINT FK_Imagenes_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(Id)
)
END

GO
IF OBJECT_ID('UsuarioDestacados', 'U') IS NULL
BEGIN
CREATE TABLE UsuarioDestacados (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUsuario INT NOT NULL,
	IdPublicacion INT NOT NULL,
	IndiceOrden INT NOT NULL,

	CONSTRAINT FK_UsuarioDestacados_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id),
	CONSTRAINT FK_UsuarioDestacados_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(Id)
)
END

GO
IF OBJECT_ID('Comentarios', 'U') IS NULL
BEGIN
CREATE TABLE Comentarios (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUsuario INT NOT NULL,
	IdPublicacion INT NOT NULL,
	Texto VARCHAR (280) NOT NULL,
	Fecha DATETIME NOT NULL, 
	Activo BIT DEFAULT 1 NOT NULL

	CONSTRAINT FK_Comentarios_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id),
	CONSTRAINT FK_Comentarios_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(Id)
)
END

GO
IF OBJECT_ID('Favoritos', 'U') IS NULL
BEGIN
CREATE TABLE Favoritos (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUsuario INT NOT NULL,
	IdPublicacion INT NOT NULL,

	CONSTRAINT FK_Favoritos_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id),
	CONSTRAINT FK_Favoritos_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(Id)
)
END

GO
IF OBJECT_ID('UsuariosSeguidos', 'U') IS NULL
BEGIN
CREATE TABLE UsuariosSeguidos (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdUsuario INT NOT NULL,
	IdUsuarioSeguido INT NOT NULL,

	CONSTRAINT FK_UsuariosSeguidos_Usuarios1 FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id),
	CONSTRAINT FK_UsuariosSeguidos_Usuarios2 FOREIGN KEY (IdUsuarioSeguido) REFERENCES Usuarios(Id)
)
END