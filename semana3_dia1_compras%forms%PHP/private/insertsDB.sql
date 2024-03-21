USE bdtutienda;

INSERT INTO ARTICULOS (nombre_art, descripcion_art, precio) 
VALUES 
('Sneaker1', 'Comfortable running sneaker in size 42', 59.99),
('Sneaker2', 'Stylish casual sneaker in size 38', 79.99),
('Sneaker3', 'Lightweight training sneaker in size 44', 69.99),
('Sneaker4', 'Durable hiking sneaker in size 40', 89.99),
('Sneaker5', 'Versatile cross-training sneaker in size 41', 75.99),
('Sneaker6', 'Breathable walking sneaker in size 39', 65.99),
('Sneaker7', 'Water-resistant trail sneaker in size 43', 85.99),
('Sneaker8', 'High-performance athletic sneaker in size 45', 95.99),
('Sneaker9', 'Classic leather sneaker in size 40', 80.99),
('Sneaker10', 'Slip-resistant work sneaker in size 42', 70.99),
('Sneaker11', 'Trendy fashion sneaker in size 38', 90.99),
('Sneaker12', 'Eco-friendly sustainable sneaker in size 41', 100.99),
('Sneaker13', 'Orthopedic comfort sneaker in size 39', 77.99),
('Sneaker14', 'Non-slip yoga sneaker in size 37', 67.99);   



INSERT INTO CLIENTES (nombre_cli, apellidos_cli, direccion_cli,telefono_cli) 
VALUES ('Emilio', 'Arevalo Zuñiga', 'Calle rio Segre, 2, 2b', '676543112');

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


INSERT INTO USUARIOS (id_cliente, user, pass) 
VALUES ('1', 'emi94', '1234'),
('2', 'sofiaCR', '1234'),
('3', 'juanPG', '1234'),
('4', 'anaML', '1234'),
('5', 'carlosGF', '1234'),
('6', 'mariaRS', '1234'),
('7', 'pedroRG', '1234'),
('8', 'isabelMR', '1234'),
('9', 'javierTP', '1234'),
('10', 'carmenGN', '1234'),
('11', 'luisRM', '1234'),
('12', 'teresaGM', '1234');

UPDATE ARTICULOS
SET codigo_art = CONCAT('COD', id_articulo);

ALTER TABLE ARTICULOS
ADD COLUMN imgpath varchar(1024);

UPDATE TABLE ARTICULOS 
SET imgpath = CONCAT('../img/',nombre_art, '.png');