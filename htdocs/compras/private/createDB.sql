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
    id_cliente int(10),
    id_articulo int(10) NOT NULL,
    cantidad varchar(100),
    fechacompra varchar(50),
    CONSTRAINT COMPRAS_PK PRIMARY KEY (id_compra), 
    CONSTRAINT C_CLIENTES_FK FOREIGN KEY (id_cliente) REFERENCES CLIENTES(id_cliente) ON DELETE SET NULL, 
    CONSTRAINT C_ARTICULOS_FK FOREIGN KEY (id_articulo) REFERENCES ARTICULOS(id_articulo)
);

CREATE TABLE USUARIOS (
    id_usuario int(10) NOT NULL AUTO_INCREMENT,
    id_cliente int(10) NOT NULL,
    user varchar(50) NOT NULL,
    pass varchar(50) NOT NULL,
    CONSTRAINT USUARIOS_PK PRIMARY KEY (id_usuario),
    CONSTRAINT USUARIOS_FK FOREIGN KEY (id_cliente) REFERENCES CLIENTES(id_cliente) ON DELETE CASCADE
);
