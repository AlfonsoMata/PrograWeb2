# FrostArt
 ## Integrantes 
 * **1800628 José Arturo Rodríguez Cavazos**
 * **1803321 Alfonso Mata de Anda**
 * **1800719 Pablo Andrés Mariles Feregrino**
 * **1838420 Rene Miramontes Hernandez**
 
 ## Descripción

_Frost Art es una página web destinada a artistas, donde podrán publicar imágenes de sus piezas de arte ya sean físicas o digitales con el objetivo de compartir y dar a conocer sus obras con otros artistas o personas interesadas en el arte._

## Carpetas
* **Back End** *Aqui se encuentra el proyecto de Visual Studio*
* **images and icons** *Aqui se encuentran imagenes e iconos para su uso en la pagina web*
* **SQL** *Aqui se encuentran los scripts de SQL SERVER para la creacion de la base de datos*
	
## Instrucciones de Instalación
* Descargar el contenido de la carpeta **SQL** y ejecutar los scripts en SQL SERVER.
* El primer archivo a ejecutar es "FrostArtCreateTables.sql".
* El segundo archivo a ejecutar es "FrostArt  Actualizacion 1.sql".
* El tercer archivo a ejecutar es "FrostArt  Actualizacion 2.sql".
* El cuarto archivo a ejecutar es "FrostArt Actualizacion 3 Insert Temas.sql".
* Descargar el contenido de la carpeta **Back End** y ejecutar en archivo "Back End.sln" (es necesario tener Visual Studio instalado).
* Dentro de la carpeta descargada **Back End** entrar a la carpeta "Back End", despues a la siguiente carpeta "Back End" y abrir el archivo "appsettings.Development.json", y cambiar dentro del mismo la siguiente linea de codigo **"SqlConnection": "Server=AORUS-B460M;Database=FrostArtDB;Trusted_Connection=True;"**, cambiar el valor del dato "Server" por el nombre del servidor de tu SQL SERVER.
* Hacer lo mismo con el archivo **appsettings.json**.
* **Dirigirse al github del FrontEnd de la pagina y seguir las instrucciones https://github.com/AlfonsoMata/frost_art_app_interface**
