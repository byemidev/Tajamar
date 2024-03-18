CREATE DATABASE compras; 

USE compras; 

CREATE TABLE CLIENTES (
    id_compras int(10) NOT NULL AUTO_INCREMENT, 
    nombre_cli varchar(50), 
    apellidos_cli varchar(50), 
    direccion_cli varchar(100),
    telefono_cli varchar(15), 
    CONSTRAINT CLIENTES_PK PRIMARY KEY (id_compras)
);

CREATE TABLE ARTICULOS(
    id_articulos int(10) NOT NULL AUTO_INCREMENT, 
    nombre_art varchar(50),
    codigo_art varchar(50),
    descripcion_art varchar(50),
    precio float(50),
    CONSTRAINT ARTICULOS_PK PRIMARY KEY (id_articulos)
);

CREATE TABLE COMPRAS (
    id_compras int(10) NOT NULL AUTO_INCREMENT,
    nombre_art varchar(50),
    cantidad_art varchar(100),
    fechacompra_art varchar(50),
    CONSTRAINT COMPRAS_PK PRIMARY KEY (id_compras)
);

