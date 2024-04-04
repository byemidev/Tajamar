CREATE DATABASE CARRITO;
USE CARRITO;

CREATE TABLE PRODUCTS(
    idprod int(5) PRIMARY KEY AUTO_INCREMENT,
    nomprod varchar(100),
    precio float(5,2)
);