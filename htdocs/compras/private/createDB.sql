CREATE DATABASE bdbiblioteca; 

USE bdbiblioteca; 

CREATE TABLE CLIENTES (
    idcliente int(10) NOT NULL AUTO_INCREMENT, 
    nombrecliente varchar(50) NOT NULL UNIQUE, 
    apellidoscliente varchar(50), 
    dircliente varchar(100),
    telcliente varchar(15), 
    CONSTRAINT CLIENTES_PK PRIMARY KEY (idcliente)
);

CREATE TABLE LIBROS (
    idlibro int(10) NOT NULL AUTO_INCREMENT, 
    nombrelibro varchar(50) NOT NULL UNIQUE,
    autor varchar(150) NOT NULL UNIQUE,
    codlibro varchar(50),
    apendice varchar(100),
    disponible boolean NOT NULL DEFAULT 1,
    CONSTRAINT ARTICULOS_PK PRIMARY KEY (idlibro)
);

CREATE TABLE PRESTAMOS (
    idprestamo int(10) NOT NULL AUTO_INCREMENT,
    idcliente int(10)NOT NULL,
    idlibro int(10) NOT NULL,
    fecha_prestamo varchar(20) NOT NULL,
    fecha_devolucion varchar(20),
    disponible boolean,
    CONSTRAINT PRESTAMOS_PK PRIMARY KEY (idprestamo), 
    CONSTRAINT P_CLIENTES_FK FOREIGN KEY (idcliente) REFERENCES CLIENTES(idcliente) ON DELETE SET NULL, 
    CONSTRAINT P_LIBROS_FK FOREIGN KEY (idlibro) REFERENCES LIBROS(idlibro)
);

CREATE TABLE USUARIOS (
    idusuario int(10) NOT NULL AUTO_INCREMENT,
    idcliente int(10) NOT NULL,
    user varchar(50) NOT NULL,
    pass varchar(50) NOT NULL,
    CONSTRAINT USUARIOS_PK PRIMARY KEY (idusuario),
    CONSTRAINT USUARIOS_FK FOREIGN KEY (idcliente) REFERENCES CLIENTES(idcliente) ON DELETE CASCADE
);
