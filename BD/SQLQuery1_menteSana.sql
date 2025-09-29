Create database DBMenteSana
use DBMenteSana

CREATE TABLE Rol (
id_rol INT PRIMARY KEY IDENTITY,
nombre VARCHAR(30) NOT NULL
)

INSERT INTO Rol (nombre) VALUES
('Estudiante'),
('Psicologo'),
('Admin_Bienestar')

CREATE TABLE Persona (
id_persona VARCHAR(20) PRIMARY KEY,
nombres VARCHAR(60) NOT NULL,
apellidos VARCHAR(60) NOT NULL,
correo_institucional VARCHAR(120) NOT NULL UNIQUE,
contraseña VARCHAR(15) NOT NULL,
id_rol INT NOT NULL,
FOREIGN KEY (id_rol) REFERENCES Rol(id_rol)
)

insert into Persona (id_persona, nombres, apellidos, correo_institucional, contraseña, id_rol) values
('1034919583', 'Laura', 'Mejia', 'laura.mejia583@pascualbravo.edu.co', 'laura123', 1)

-- ESTADO_EMOCIONAL (texto viene del back)

CREATE TABLE Estado_Emocional (
id_estado INT IDENTITY PRIMARY KEY,
id_persona VARCHAR(20) NOT NULL, -- FK a Persona
nombre_estado VARCHAR(30) NOT NULL, -- viene del back (p.ej. 'Triste')
fecha_hora DATETIME NOT NULL DEFAULT SYSDATETIME(),
nota VARCHAR(2000) NULL,
FOREIGN KEY (id_persona) REFERENCES Persona(id_persona)
)

-- CITA (estudiante con psicólogo)
CREATE TABLE Cita (
id_cita INT IDENTITY PRIMARY KEY,
id_estudiante VARCHAR(20) NOT NULL,
id_psicologo VARCHAR(20) NOT NULL,
fecha DATE NOT NULL,
hora TIME NOT NULL,
FOREIGN KEY (id_estudiante) REFERENCES Persona(id_persona),
FOREIGN KEY (id_psicologo) REFERENCES Persona(id_persona)
)

-- RECOMENDACION (generada a partir de un estado)
CREATE TABLE Recomendacion (
id_recomendacion INT IDENTITY PRIMARY KEY,
id_estado INT NOT NULL,
contenido VARCHAR(3000) NOT NULL,
fecha_generada DATETIME NOT NULL DEFAULT SYSDATETIME(),


FOREIGN KEY (id_estado) REFERENCES Estado_Emocional(id_estado)
)

-- ALERTA (por estado crítico)
CREATE TABLE Alerta (
id_alerta INT IDENTITY PRIMARY KEY,
id_estado INT NOT NULL,
tipo VARCHAR(20) NOT NULL, -- se envía desde el back (p.ej. 'Critica')
fecha DATETIME NOT NULL DEFAULT SYSDATETIME(),
FOREIGN KEY (id_estado) REFERENCES Estado_Emocional(id_estado)
)

-- REPORTE (hecho por psicólogo; opcionalmente ligado a estudiante)
CREATE TABLE Reporte (
id_reporte INT IDENTITY PRIMARY KEY,
id_psicologo VARCHAR(20) NOT NULL,
tipo VARCHAR(20) NOT NULL, -- 'General' | 'Individual' (desde back)
fecha_generacion DATETIME NOT NULL DEFAULT SYSDATETIME(),
id_estudiante VARCHAR(20) NOT NULL,
FOREIGN KEY (id_psicologo) REFERENCES Persona(id_persona),
FOREIGN KEY (id_estudiante) REFERENCES Persona(id_persona)
);
go

-------- Procedimientos de almacenado ---------

Create procedure insertar_Persona (
@id_persona VARCHAR(20),
@nombres varchar(60),
@apellidos varchar(60),
@correo_institucional VARCHAR(120),
@contraseña VARCHAR(15),
@id_rol INT)
as
begin
 Insert into Persona values(@id_persona, @nombres, @apellidos, @correo_institucional, @contraseña, @id_rol)
end
go

--------------
Create procedure actualizar_Persona (
@id_persona VARCHAR(20),
@nombres varchar(60),
@apellidos varchar(60),
@correo_institucional VARCHAR(120),
@contraseña VARCHAR(15),
@id_rol INT)
as
begin
	update Persona set nombres = @nombres, apellidos = @apellidos, correo_institucional = @correo_institucional,  
	contraseña = @contraseña, id_rol = @id_rol where id_persona = @id_persona
end
go

------------
Create procedure eliminar_persona (
@id_persona varchar(20))
as
begin
 Delete Persona where id_persona = @id_persona
end
go

------------
Create procedure consulta_persona (
@id_persona varchar(20))
as
begin
 Select * from Persona where id_persona = @id_persona
end
go

---------
Create procedure listar_persona 
as
begin
 Select * from Persona 
end
go

---------
Create procedure listar_rol
as
begin
 Select * from Rol
end
Select SCOPE_IDENTITY()