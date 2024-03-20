CREATE DATABASE compras; 

USE compras; 

CREATE TABLE CLIENTES (
    id_cliente int(10) NOT NULL AUTO_INCREMENT, 
    nombre_cli varchar(50) NOT NULL UNIQUE, 
    apellidos_cli varchar(50), 
    direccion_cli varchar(100),
    telefono_cli varchar(15), 
    CONSTRAINT CLIENTES_PK PRIMARY KEY (id_cliente)
);

CREATE TABLE ARTICULOS(
    id_articulo int(10) NOT NULL AUTO_INCREMENT, 
    nombre_art varchar(50) NOT NULL UNIQUE,
    codigo_art varchar(50),
    descripcion_art varchar(50),
    precio float(5,2),
    CONSTRAINT ARTICULOS_PK PRIMARY KEY (id_articulo)
);

CREATE TABLE COMPRAS (
    id_compra int(10) NOT NULL AUTO_INCREMENT,
    id_cliente int(10) NOT NULL,
    id_articulo int(10) NOT NULL,
    cantidad varchar(100),
    fechacompra varchar(50),
    CONSTRAINT COMPRAS_PK PRIMARY KEY (id_compra), 
    CONSTRAINT CLIENTES_FK FOREIGN KEY (id_cliente) REFERENCES CLIENTES(id_cliente) ON DELETE CASCADE, //resolver el on delete cascade
    CONSTRAINT ARTICULOS_FK FOREIGN KEY (id_articulo) REFERENCES ARTICULOS(id_articulo)
);

CREATE TABLE USUARIOS (
    nombre_usuario varchar(50),
    id_cliente varchar(50),
    pass varchar(15), 
    CONSTRAINT USUARIOS_PK PRIMARY KEY (nombre_usuario, id_cliente), 
    CONSTRAINT USUARIOS_FK FOREIGN KEY (id_cliente) REFERENCES CLIENTES(id_cliente) 
);
