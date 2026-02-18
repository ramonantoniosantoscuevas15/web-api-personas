requisitos para usar la api:
una version de angular/clic 20.3.0 o superior
una version de net.9.0.1 o superior
para la base de datos en PostgreSQL se necesita una version de pgadmin 4 9.6 o superior
para levantar el frontend solo es necesario el comando ng serve -o
la variable de entorno para conectarse a la base de datos:
en appsettings.json
en el archivo appsetting.Developer.json
"ConnectionStrings": {
  "PostgreSQLConnetion": "Server=127.0.0.1;Port=5432;Database=Web-api-db;User Id=postgres;Password=password"
},
como tambien la conexion con angular:
"origenesPermitos": "http://localhost:4200"
en la misma carpeta
