/*
	Equipo 02
	Integrantes:
	1800628 Jos� Arturo Rodr�guez Cavazos
	1803321	Alfonso Mata de Anda
	1800719	Pablo Andr�s Mariles Feregrino
	1838420 Rene Miramontes Hernandez


	Query #3
		Actualizacion de la Tabla Temas a�adimos el campo "Imagen" en donde se guardara la direccion de la imagen principal del tema a mostrar
					
					
		Fecha: 2021-05-22

*/


USE FrostArtDB;

ALTER TABLE Temas
ADD  Imagen VARCHAR(450);