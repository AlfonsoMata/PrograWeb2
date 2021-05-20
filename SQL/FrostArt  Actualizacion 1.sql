/*
	Equipo 02
	Integrantes:
	1800628 José Arturo Rodríguez Cavazos
	1803321	Alfonso Mata de Anda
	1800719	Pablo Andrés Mariles Feregrino
	1838420 Rene Miramontes Hernandez


	Query #2
		Actualizacion de las tablas Usuario e Imagenes, cambiando el tipo de dato de la columna FotoPerfil e Imagen respectivamente 
		al tipo de dato VARCHAR(150) para de esa manera guardar la direccion de las imagenes las cuales seran cargadas a Firebase
		y se guardaran en esta base de datos como su URL.
					
					
		Fecha: 2021-05-19

*/


USE FrostArtDB;

ALTER TABLE Usuarios
ALTER COLUMN FotoPerfil VARCHAR(450);


ALTER TABLE Imagenes
ALTER COLUMN Imagen VARCHAR(450);
