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

Crud base de los modelos de db vistos desde swagger
![image](https://github.com/user-attachments/assets/ff3900b1-8033-4b21-8d6b-b91b539f48d4)
![image](https://github.com/user-attachments/assets/71e8d017-ca5c-4586-a297-e334cdbd7b40)

Prueba de obtener todos los usuarios
![image](https://github.com/user-attachments/assets/5c192d3f-58fb-4bb9-a08d-73c4aeada95a)

Obtener un producto por id
![image](https://github.com/user-attachments/assets/aac87d23-6518-402d-90a6-095c86d80bc3)

Crear un nuevo rol
![image](https://github.com/user-attachments/assets/eb343b32-c1ed-4ccd-ab9c-752693abe8c4)

Actualizar una categoria
![image](https://github.com/user-attachments/assets/0a4d9e84-375d-4ed9-8c9e-c54f87e57918)

Eliminar el rol de prueba
![image](https://github.com/user-attachments/assets/c8c0e9ea-b3a2-410b-806d-80a033ca4f8e)

#Merge feature/sprint4 to master

-----

----- feature sprint5

#Commit Order, Sales and Security
Se crea los modelos para el manejo de ordenes de compra y ventas, se finaliza la implementación
de seguridad a través de jwt y con comprobaciones de roles para los usuarios. Se generan métodos
que faltaban para el sistema de gestión de usuarios de la plataforma, productos entre otros.

Métodos agregados a api
![image](https://github.com/user-attachments/assets/9ae3bf28-ac83-4343-90c5-85c6087ecbc4)

Generacion de token con jwt para el inicio de sesión en la plataforma
![image](https://github.com/user-attachments/assets/be3e74af-9ed9-4252-a73f-2afa55e7a1d8)

Configuración del swagger para permitir registrar la autorización del bearer token
![image](https://github.com/user-attachments/assets/2c9d08da-ba41-40c4-b7f1-9465e7812d40)

Obtener la orden de compra para el usuario logeado
![image](https://github.com/user-attachments/assets/75bb7311-61f0-4e00-8459-378761edac3d)

Obtener las ventas realizadas con la plataforma
![image](https://github.com/user-attachments/assets/1b2ec8c6-82a4-4a01-9864-64221e978f56)

#Merge feature/sprint5 to master

-----

----- feature sprint5

#Commit Get products no auth 
Se genera un nuevo endpoint para obtener los productos sin necesidad de usar token de autenticación
este endpoint será utilizado por el chatbot de OpenAi


-----
