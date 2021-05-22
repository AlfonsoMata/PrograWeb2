/*
	Equipo 02
	Integrantes:
	1800628 José Arturo Rodríguez Cavazos
	1803321	Alfonso Mata de Anda
	1800719	Pablo Andrés Mariles Feregrino
	1838420 Rene Miramontes Hernandez


	Query #3
		Actualizacion de la Tabla Temas añadimos el campo "Imagen" en donde se guardara la direccion de la imagen principal del tema a mostrar
					
					
		Fecha: 2021-05-22

*/


USE FrostArtDB;

ALTER TABLE Temas
ADD  Imagen VARCHAR(450);