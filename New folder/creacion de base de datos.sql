CREATE DATABASE ibzdb_test;
GO

USE ibzdb_test;
GO

CREATE TABLE departamento (
	iddepartamento INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	descripcion VARCHAR(100)
);

CREATE TABLE genero (
	idgenero INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	descripcion VARCHAR(100)
);

CREATE TABLE municipio (
	idmunicipio INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	iddepartamento INT,
	descripcion VARCHAR(100),
	CONSTRAINT fk_departamento FOREIGN KEY (iddepartamento) REFERENCES departamento(iddepartamento)
);

CREATE TABLE estado_civil (
	idestado INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	descripcion VARCHAR(100)
);

CREATE TABLE miembros (
	idmiembro INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	nombres VARCHAR(100),
	apellidos VARCHAR(100),
	fecha_nacimiento DATE,
	idgenero INT NOT NULL,
	idestado INT NOT NULL,
	telefono VARCHAR(20),
	correo VARCHAR(100),
	direccion TEXT,
	fecha_ingreso DATE,
	bautizado TINYINT,
	fecha_bautizo DATE,
	activo TINYINT,
	idmunicipio INT NOT NULL,
	iddepartamento INT NOT NULL,

	CONSTRAINT fk_genero FOREIGN KEY (idgenero) REFERENCES genero(idgenero),
	CONSTRAINT fk_idestado FOREIGN KEY (idestado) REFERENCES estado_civil(idestado),
	CONSTRAINT fk_municipio FOREIGN KEY (idmunicipio) REFERENCES municipio(idmunicipio),
	CONSTRAINT fk_departamento_miembro FOREIGN KEY (iddepartamento) REFERENCES departamento(iddepartamento)
);
