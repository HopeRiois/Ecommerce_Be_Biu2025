# DotNet 8

Esta es la web api para peticiones de la plataforma de ecommerce.

----- feature sprint4

#Commit Setup
Se crea los archivos del proyecto, se instala el nuget jtwBearer, se crea una clase para crypto, 
se crean los modelos base de usuario y producto, y se configura los puertos de despliegue.

#Connection db
Se instala Pomelo Entity framework para mysql con el fin de gestionar todo lo relacionado con la db. 
Se utiliza migrations para crear las tablas y relaciones de la base de datos, se genera una estructura
de MVC donde se crea un controller base que genera los metodos crud para cualquier entidad que sea 
definida en  la db y hereden dicha clase.
