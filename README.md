# AspireProjectUniversity

**AspireProjectUniversity** es una arquitectura de ejemplo que demuestra el uso de microservicios modernos, un API Gateway centralizado y un sistema de observabilidad multicanal basado en **.NET Aspire**.  
El proyecto está diseñado para ser fácilmente escalable, mantener una alta separación de responsabilidades y facilitar la trazabilidad completa de todas las operaciones dentro del ecosistema.

## 🧩 Arquitectura General

La solución se basa en los siguientes componentes:

- **Microservices**: Tres microservicios independientes que manejan funcionalidades específicas.
- **API Gateway**: Un único punto de entrada para todas las peticiones externas, que enruta a los microservicios correspondientes.
- **Frontend Web**: Aplicación web que consume servicios a través del API Gateway.
- **App Mobile**: Aplicación móvil que consume los mismos servicios a través del API Gateway.
- **Aspire Observabilidad Multicanal**: Plataforma de monitoreo, observabilidad y trazabilidad de todos los componentes del sistema.

## 📦 Tecnologías Utilizadas

- **.NET Aspire** para monitoreo y telemetría.
- **.NET 8/9** (dependiendo del servicio) para el desarrollo de microservicios.
- **Dapr** (opcional) para comunicación entre servicios (futuro).
- **YARP** para la implementación del API Gateway.
- **Blazor** para el Frontend Web.
- **.NET MAUI** para la App Mobile.

## 🚀 Objetivos del Proyecto

- **Microservicios desacoplados**: Cada servicio maneja una responsabilidad única.
- **Gateway centralizado**: Control de entrada/salida seguro y eficiente.
- **Observabilidad total**: Métricas, logs y trazas distribuidas a través de Aspire.
- **Multicanal**: El mismo backend sirve tanto a aplicaciones web como móviles.
- **Escalabilidad**: Pensado para adaptarse a nuevos microservicios o canales de consumo.

## 🛠️ Cómo ejecutar el proyecto

### Prerrequisitos

- .NET SDK 8.0 o superior
- Docker (opcional para infraestructura de observabilidad)
- Visual Studio 2022 / Rider / VS Code

### Pasos básicos

1. Clona el repositorio:
   ```bash
   git clone https://github.com/AlejoTorresLeon/AspireProjectUniversity.git
   cd AspireProjectUniversity
