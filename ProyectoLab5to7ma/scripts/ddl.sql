CREATE DATABASE IF NOT EXISTS DB_JoacoEnvios;
USE DB_JoacoEnvios;



CREATE TABLE Cliente
(
    idCliente INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    dni VARCHAR(20) NOT NULL UNIQUE,
    telefono VARCHAR(30) NOT NULL,
    email VARCHAR(150) NOT NULL
);



CREATE TABLE Direccion
(
    idDireccion INT AUTO_INCREMENT PRIMARY KEY,
    calle VARCHAR(150) NOT NULL,
    direccionPostal VARCHAR(20) NOT NULL,
    localidad VARCHAR(100) NOT NULL
);



CREATE TABLE Paquete
(
    idPaquete INT AUTO_INCREMENT PRIMARY KEY,
    peso DECIMAL(10,2) NOT NULL,
    alto DECIMAL(10,2) NOT NULL,
    ancho DECIMAL(10,2) NOT NULL,
    largo DECIMAL(10,2) NOT NULL,

    CONSTRAINT chk_peso
        CHECK (peso > 0),

    CONSTRAINT chk_alto
        CHECK (alto > 0),

    CONSTRAINT chk_ancho
        CHECK (ancho > 0),

    CONSTRAINT chk_largo
        CHECK (largo > 0)
);



CREATE TABLE Envio
(
    idEnvio INT AUTO_INCREMENT PRIMARY KEY,
    idCliente INT NOT NULL,
    idPaquete INT NOT NULL,
    idOrigen INT NOT NULL,
    idDestino INT NOT NULL,
    distancia DECIMAL(10,2) NOT NULL,

    modalidad ENUM('ESTANDAR', 'EXPRESS', 'PRIORITARIO') NOT NULL,

    estado VARCHAR(50) NOT NULL,
    fechaCreacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT chk_distancia
        CHECK (distancia > 0),

    CONSTRAINT fk_envio_cliente
        FOREIGN KEY (idCliente)
        REFERENCES Cliente(idCliente),

    CONSTRAINT fk_envio_paquete
        FOREIGN KEY (idPaquete)
        REFERENCES Paquete(idPaquete),

    CONSTRAINT fk_envio_origen
        FOREIGN KEY (idOrigen)
        REFERENCES Direccion(idDireccion),

    CONSTRAINT fk_envio_destino
        FOREIGN KEY (idDestino)
        REFERENCES Direccion(idDireccion)
);



CREATE TABLE HistorialEstado
(
    idHistorial INT AUTO_INCREMENT PRIMARY KEY,
    idEnvio INT NOT NULL,
    estado VARCHAR(50) NOT NULL,
    fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_historial_envio
        FOREIGN KEY (idEnvio)
        REFERENCES Envio(idEnvio)
);