CREATE DATABASE Tienda;

-- Crear la tabla de Usuarios
CREATE TABLE Usuarios (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    Correo NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Nombre NVARCHAR(255) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);

-- Crear la tabla de Compras
CREATE TABLE Compras (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    UsuarioId INT NOT NULL,
    FechaCompra DATETIME DEFAULT GETDATE(),
    Monto DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_Compras_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

CREATE PROCEDURE ObtenerPromedioGastoUsuario 
@UsuarioId  INT
AS
BEGIN
   

-- Calcular el promedio de gasto del usuario
SELECT
    u.Nombre AS Usuario,
    AVG(c.Monto) AS PromedioGasto
FROM
    Compras c
    INNER JOIN Usuarios u ON c.UsuarioId = u.Id
WHERE
    c.UsuarioId = @UsuarioId
GROUP BY
    u.Nombre;

END;