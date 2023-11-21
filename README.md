# README.md

## Descripción del Proyecto

El proyecto "MVC_FUT_NFL" es una aplicación basada en el patrón de diseño Modelo-Vista-Controlador. Su propósito es [proporcionar un servicio específico, resolver un problema, etc.].

## Tecnologías Utilizadas

- ASP.NET MVC 7.0
- EntityFramework para SQL Server

## Estructura del Proyecto

Describe la estructura principal del proyecto y la funcionalidad de cada componente importante, como modelos, vistas y controladores.

```plaintext
MVC_FUT_NFL/
|-- Controllers/
|-- Data/
|-- Models/
|-- Views/
|-- ...
|-- appsettings.json
|-- Program.cs
|-- ...
```

## Instalación

1. Clona el repositorio:

   ```bash
   git clone https://github.com/rinfasulasalle/MVC_FUT_NFL.git
   ```

2. Abre el proyecto en tu entorno de desarrollo preferido.

3. Realiza cualquier instalación de dependencias necesarias:

   ```bash
   dotnet restore
   ```

## Ejecución

Inicia la aplicación:

```bash
dotnet run
```

La aplicación estará disponible en `http://localhost:5000` (o el puerto que hayas configurado).

## Despliegue en Otra Máquina

1. Publica la aplicación:

   ```bash
   dotnet publish -c Release
   ```

2. Copia los archivos publicados a la máquina de destino.

3. Instala el entorno .NET en la máquina de destino si no está instalado.

4. Ejecuta la aplicación en la máquina de destino:

   ```bash
   dotnet MVC_FUT_NFL.dll
   ```

Asegúrate de ajustar los pasos según las necesidades y configuraciones específicas de tu proyecto. Este README proporciona solo un esquema básico y debería personalizarse según la complejidad y los requisitos particulares de tu aplicación.