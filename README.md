# TicketsAPI

API para el registro de tickets de soporte para la mesa de servicio

## Descargar proyecto

Clonar el repositorio

```sh
$ git clone https://github.com/criscantillo/TicketsAPI.git
$ cd TicketsAPI
```

## Modificar la cadena de conexión

Para establecer la comunicación con la base de datos, 
se debe modificar la cadena de conexión en el archivo appsettings.json

```json
"ConnectionStrings": {
    "DefaultConnection": "XXXXXXX"
  }
```


## Aplicar la Migración con Entity Framework

Abrir la consola de adminsitrador de paquetes

```sh
$ update-database
```

## GraphQl

Para acceder a esta vista, se ingresa a la ruta https://localhost:xxxx/graphql
