# Centro Médico — Capa de datos central (`centromedico_database`)

Capa de datos compartida por los otros dos componentes del ecosistema **Centro Médico**:

| Repositorio | Rol |
| --- | --- |
| [`centromedico_database`](https://github.com/KevinJ0/centromedico_database) | Este repositorio: modelo de datos central (EF Core) |
| [`centromedico_doctor`](https://github.com/KevinJ0/centromedico_doctor) | API de administración + panel (ASP.NET Core + Angular) |
| [`centromedico_cliente`](https://github.com/KevinJ0/centromedico_cliente) | Portal público para pacientes + API (ASP.NET Core + Angular) |

## ¿Qué contiene?

Modelo de dominio completo de un centro médico, implementado con **Entity Framework Core (Database First)** sobre SQL Server:

- **Médicos y consultorios**: perfil profesional, exequatur, colegiatura, horario de atención por semana.
- **Pacientes**: registro completo, incluyendo pacientes menores con datos del tutor.
- **Citas**: programación con agenda por slots, estado (programada/confirmada/cancelada/completada), cobro y cobertura de seguro.
- **Seguros y coberturas**: cálculo de porciento cubierto, diferencia a pagar y descuentos.
- **Turnos**: generación automática con código de verificación único por cita.
- **Laboratorio**: análisis, pruebas y resultados.
- **Finanzas**: arqueo de caja diario por consultorio.
- **Autenticación y usuarios**: ASP.NET Identity (`MyIdentityUser`), roles Doctor / Secretary / Patient.

## Stack

- .NET 5 (`net5.0`) — class library
- Entity Framework Core 5.0.11 + SQL Server Provider
- ASP.NET Identity EF Core

## Estructura

```
├── Context/
│   └── MyDbContext.cs        # Fluent API: mapeo, relaciones e índices
├── DbModels/                 # 31 entidades del dominio
│   ├── medicos, pacientes, citas, turnos, cod_verificacion
│   ├── seguros, cobertura_medicos, cobertura_analisis
│   ├── analisis, pruebas, resultados, balance_caja
│   └── MyIdentityUser (ASP.NET Identity)
└── Centromedico.Database.csproj
```

## Configuración

Este repositorio es una librería de clases; las cadenas de conexión y credenciales viven en las **APIs consumidoras** (`centromedico_doctor`, `centromedico_cliente`). Las APIs referencian esta librería como proyecto externo (`../CentromedicoDatabase/Centromedico.Database.csproj`) y la migran/la usan como su `DbContext` único — así todo el ecosistema comparte un solo modelo de datos.