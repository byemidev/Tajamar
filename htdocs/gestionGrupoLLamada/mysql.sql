CREATE DATABASE gruposLlamadas;

USE gruposLlamadas;

CREATE TABLE grupos (
    id_grupo INT(10),
    nombre_grupo VARCHAR(255),
    CONSTRAINT pk_grupos PRIMARY KEY (id_grupo)
);

CREATE TABLE numeros (
    id_numero INT(10),
    nombre VARCHAR(100),
    descripcion VARCHAR(255),
    id_grupo INT(10),
    CONSTRAINT pk_numeros PRIMARY KEY (id_numero),
    CONSTRAINT fk_numeros FOREIGN KEY (id_grupo) REFERENCES grupos (id_grupo);
);

INSERT INTO grupos (id_grupo, nombre_grupo) VALUES (91, 'Madrid');
INSERT INTO grupos (id_grupo, nombre_grupo) VALUES (93, 'Barcelona');
INSERT INTO grupos (id_grupo, nombre_grupo) VALUES (93, 'Barcelona');
INSERT INTO grupos (id_grupo, nombre_grupo) VALUES (96, 'Valencia');
