-- ======================================
-- CREAR BASE DE DATOS SOLO SI NO EXISTE
-- ======================================
IF DB_ID('BibliotecaDB') IS NULL
BEGIN
    CREATE DATABASE BibliotecaDB;
END
GO

USE BibliotecaDB;
GO

-- ======================================
-- TABLAS PRINCIPALES
-- ======================================

CREATE TABLE Autores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Nacionalidad NVARCHAR(100)
);

CREATE TABLE Temas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Tema NVARCHAR(100) NOT NULL
);

CREATE TABLE Editoriales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Editorial NVARCHAR(100) NOT NULL
);

CREATE TABLE Paises (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Pais NVARCHAR(100) NOT NULL
);

CREATE TABLE Tipos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Tipo NVARCHAR(100) NOT NULL
);

CREATE TABLE Libros (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Editorial INT FOREIGN KEY REFERENCES Editoriales(Id),
    Pais INT FOREIGN KEY REFERENCES Paises(Id),
    Tipo INT FOREIGN KEY REFERENCES Tipos(Id),
    Isbn NVARCHAR(20) UNIQUE,
    Titulo NVARCHAR(200) NOT NULL,
    Edicion NVARCHAR(50),
    Fecha_Lanzamiento DATE
);

CREATE TABLE Libros_Autores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Libro INT FOREIGN KEY REFERENCES Libros(Id),
    Autor INT FOREIGN KEY REFERENCES Autores(Id)
);

CREATE TABLE Libros_Temas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Libro INT FOREIGN KEY REFERENCES Libros(Id),
    Tema INT FOREIGN KEY REFERENCES Temas(Id)
);

CREATE TABLE Existencias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Libro INT FOREIGN KEY REFERENCES Libros(Id),
    Codigo_Ejemplar NVARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Estados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Estado NVARCHAR(100) NOT NULL
);

CREATE TABLE Estados_Existencias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Existencia INT FOREIGN KEY REFERENCES Existencias(Id),
    Estado INT FOREIGN KEY REFERENCES Estados(Id),
    Fecha_Cambio DATETIME DEFAULT GETDATE()
);

CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Documento NVARCHAR(50) UNIQUE,
    Telefono NVARCHAR(20),
    Direccion NVARCHAR(200),
    Fecha_Nacimiento DATE,
    Correo NVARCHAR(150) UNIQUE,
    Contraseña NVARCHAR(255) NOT NULL -- HASH de la clave
);

CREATE TABLE Tipos_Prestamos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100)
);

CREATE TABLE Prestamos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usuario INT FOREIGN KEY REFERENCES Usuarios(Id),
    Tipo_Prestamo INT FOREIGN KEY REFERENCES Tipos_Prestamos(Id),
    Existencia INT FOREIGN KEY REFERENCES Existencias(Id),
    Fecha_Prestamo DATE NOT NULL,
    Fecha_Devolucion DATE,
    Fecha_Entrega_Real DATE
);

CREATE TABLE Sanciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usuario INT FOREIGN KEY REFERENCES Usuarios(Id),
    Descripcion NVARCHAR(MAX),
    Fecha_Inicio DATE,
    Fecha_Fin DATE
);

-- ======================================
-- TABLA DE AUDITORÍAS
-- ======================================

CREATE TABLE Auditorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Tabla NVARCHAR(50) NOT NULL,
    Operacion NVARCHAR(10) NOT NULL,
    UsuarioBD NVARCHAR(100) DEFAULT SUSER_SNAME(),
    Fecha DATETIME DEFAULT GETDATE(),
    Datos_Antiguos NVARCHAR(MAX),
    Datos_Nuevos NVARCHAR(MAX)
);


/*
-- ======================================
-- TRIGGERS DE AUDITORÍA
-- ======================================

-- USUARIOS
CREATE TRIGGER trg_usuarios_insert
ON Usuarios
AFTER INSERT
AS	
BEGIN
    INSERT INTO Auditorias (Tabla, Operacion, Datos_Nuevos)
    SELECT 'Usuarios', 'INSERT',
           'Id=' + CAST(i.Id AS NVARCHAR) + ', Correo=' + ISNULL(i.Correo,'')
    FROM inserted i;
END
GO

CREATE TRIGGER trg_usuarios_update
ON Usuarios
AFTER UPDATE
AS
BEGIN
    INSERT INTO Auditorias (Tabla, Operacion, Datos_Antiguos, Datos_Nuevos)
    SELECT 'Usuarios', 'UPDATE',
           'Id=' + CAST(d.Id AS NVARCHAR) + ', Correo=' + ISNULL(d.Correo,''),
           'Id=' + CAST(i.Id AS NVARCHAR) + ', Correo=' + ISNULL(i.Correo,'')
    FROM deleted d
    INNER JOIN inserted i ON d.Id = i.Id;
END
GO

CREATE TRIGGER trg_usuarios_delete
ON Usuarios
AFTER DELETE
AS
BEGIN
    INSERT INTO Auditorias (Tabla, Operacion, Datos_Antiguos)
    SELECT 'Usuarios', 'DELETE',
           'Id=' + CAST(d.Id AS NVARCHAR) + ', Correo=' + ISNULL(d.Correo,'')
    FROM deleted d;
END
GO

-- LIBROS
CREATE TRIGGER trg_libros_insert
ON Libros
AFTER INSERT
AS
BEGIN
    INSERT INTO Auditorias (Tabla, Operacion, Datos_Nuevos)
    SELECT 'Libros', 'INSERT',
           'Id=' + CAST(i.Id AS NVARCHAR) + ', Titulo=' + ISNULL(i.Titulo,'')
    FROM inserted i;
END
GO

-- PRESTAMOS
CREATE TRIGGER trg_prestamos_insert
ON Prestamos
AFTER INSERT
AS
BEGIN
    INSERT INTO Auditorias (Tabla, Operacion, Datos_Nuevos)
    SELECT 'Prestamos', 'INSERT',
           'Id=' + CAST(i.Id AS NVARCHAR) +
           ', Usuario=' + CAST(i.Usuario AS NVARCHAR) +
           ', Existencia=' + CAST(i.Existencia AS NVARCHAR)
    FROM inserted i;
END
GO
*/