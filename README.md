# README.md

## Descripci�n del Proyecto

El proyecto "MVC_FUT_NFL" es una aplicaci�n basada en el patr�n de dise�o Modelo-Vista-Controlador. Su prop�sito es [proporcionar un servicio espec�fico, resolver un problema, etc.].

## Tecnolog�as Utilizadas

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

## Instalaci�n

1. Clona el repositorio:

   ```bash
   git clone https://github.com/rinfasulasalle/MVC_FUT_NFL.git
   ```

2. Abre el proyecto en tu entorno de desarrollo preferido.

3. Realiza cualquier instalaci�n de dependencias necesarias:

   ```bash
   dotnet restore
   ```

## Ejecuci�n

Inicia la aplicaci�n:

```bash
dotnet run
```

La aplicaci�n estar� disponible en `http://localhost:5000` (o el puerto que hayas configurado).

## Despliegue en Otra M�quina

1. Publica la aplicaci�n:

   ```bash
   dotnet publish -c Release
   ```

2. Copia los archivos publicados a la m�quina de destino.

3. Instala el entorno .NET en la m�quina de destino si no est� instalado.

4. Ejecuta la aplicaci�n en la m�quina de destino:

   ```bash
   dotnet MVC_FUT_NFL.dll
   ```

Aseg�rate de ajustar los pasos seg�n las necesidades y configuraciones espec�ficas de tu proyecto. Este README proporciona solo un esquema b�sico y deber�a personalizarse seg�n la complejidad y los requisitos particulares de tu aplicaci�n.