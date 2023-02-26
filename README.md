# TicketsAPI

API para el registro de tickets de soporte para la mesa de servicio

## Descargar proyecto

Clonar el repositorio

```sh
$ git clone https://github.com/criscantillo/TicketsAPI.git
$ cd TicketsAPI
```

## Modificar la cadena de conexi�n

Para establecer la comunicaci�n con la base de datos, 
se debe modificar la cadena de conexi�n en el archivo appsettings.json

```json
"ConnectionStrings": {
    "DefaultConnection": "XXXXXXX"
  }
```


## Aplicar la Migraci�n con Entity Framework

Abrir la consola de adminsitrador de paquetes

```sh
$ update-database
```

