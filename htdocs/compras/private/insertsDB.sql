USE compras;

INSERT INTO ARTICULOS (nombre_art, descripcion_art, precio) 
VALUES ('Lapiz 2H','lapiz 2H SM','0.99'),
('Lapiz 1H','lapiz 1H SM','0.99'),
('Cuaderno A4 anillas b/w','cuaderno anillas A4 black / white','3.20'),
('Libro mat. 1ESO','libro matematicas 1ºESO ','16.75'),
('Libro mat. 2ESO','libro matematicas 1ºESO ','18.75'),
('Libro mat. 3ESO','libro matematicas 1ºESO ','21.75'),
('Libro mat. 4ESO','libro matematicas 1ºESO ','30.75'),
('Libro len. 1ESO','libro lenguage castellana 1ºESO ','14.75'),
('Libro len. 2ESO','libro lenguage castellana 2ºESO ','16.75'),
('Libro len. 3ESO','libro lenguage castellana 3ºESO ','18.75'),
('Libro len. 4ESO','libro lenguage castellana 4ºESO ','20.75');

INSERT INTO CLIENTES (nombre_cli, apellidos_cli, direccion_cli, telefono_cli) 
VALUES ('Sofia','Castaño Rodriguez','Calle rio odiel, 34, 1ºa','654222111'),
('Juan','Pérez García','Calle de la Paz, 10, 2ºB','654333222'),
('Ana','Martínez López','Avenida de la Constitución, 20, 3ºC','654444333'),
('Carlos','Gómez Fernández','Plaza Mayor, 30, 4ºD','654555444'),
('María','Rodríguez Sánchez','Calle del Prado, 40, 5ºE','654666555'),
('Pedro','Ruiz González','Paseo de la Castellana, 50, 6ºF','654777666'),
('Isabel','Morales Romero','Calle de Alcalá, 60, 7ºG','654888777'),
('Javier','Torres Peña','Gran Vía, 70, 8ºH','654999888'),
('Carmen','Guerrero Navarro','Calle de Bailén, 80, 9ºI','655000999'),
('Luis','Ramos Méndez','Calle de Ferraz, 90, 10ºJ','655111000'),
('Teresa','Gutiérrez Mendoza','Calle de Serrano, 100, 11ºK','655222111');


INSERT INTO USUARIOS (nombre_usuario, id_cliente, pass) 
VALUES ('emi94', '0', '1234'),
('sofiaCR', '1', '1234'),
('juanPG', '2', '1234'),
('anaML', '3', '1234'),
('carlosGF', '4', '1234'),
('mariaRS', '5', '1234'),
('pedroRG', '6', '1234'),
('isabelMR', '7', '1234'),
('javierTP', '8', '1234'),
('carmenGN', '9', '1234'),
('luisRM', '10', '1234'),
('teresaGM', '11', '1234');


