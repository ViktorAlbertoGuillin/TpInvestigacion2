-- Crear la base de datos
CREATE DATABASE TpInvestigacion;
GO

-- Usar la base de datos
USE TpInvestigacion;
GO

-- Crear la tabla Bloque
CREATE TABLE Bloque (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Datos VARCHAR(255),
    Hash VARCHAR(255),
    Hash_anterior VARCHAR(255),
    Tiempo Date,
    Integro BIT
);

select * from Bloque

drop database TpInvestigacion

/*USE TpInvestigacion;

INSERT INTO Bloque (Datos, Hash, Hash_anterior, Tiempo, Integro)
VALUES
    ('Datos 1', 'Hash1', 'Hash_anterior1', '2023-05-30 09:00:00', 1),
    ('Datos 2', 'Hash2', 'Hash_anterior2', '2023-05-30 10:30:00', 0),
    ('Datos 3', 'Hash3', 'Hash_anterior3', '2023-05-30 13:15:00', 1),
    ('Datos 4', 'Hash4', 'Hash_anterior4', '2023-05-30 16:45:00', 1),
    ('Datos 5', 'Hash5', 'Hash_anterior5', '2023-05-30 19:20:00', 0),
    ('Datos 6', 'Hash6', 'Hash_anterior6', '2023-05-31 08:10:00', 1),
    ('Datos 7', 'Hash7', 'Hash_anterior7', '2023-05-31 11:30:00', 0),
    ('Datos 8', 'Hash8', 'Hash_anterior8', '2023-05-31 14:45:00', 1),
    ('Datos 9', 'Hash9', 'Hash_anterior9', '2023-05-31 17:20:00', 1),
    ('Datos 10', 'Hash10', 'Hash_anterior10', '2023-05-31 20:00:00', 0); */