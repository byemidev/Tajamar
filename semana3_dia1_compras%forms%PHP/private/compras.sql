-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 21-03-2024 a las 14:37:03
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `compras`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `articulos`
--

CREATE TABLE `articulos` (
  `id_articulo` int(10) NOT NULL,
  `nombre_art` varchar(50) NOT NULL,
  `codigo_art` varchar(50) DEFAULT NULL,
  `descripcion_art` varchar(50) DEFAULT NULL,
  `precio` float(5,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `articulos`
--

INSERT INTO `articulos` (`id_articulo`, `nombre_art`, `codigo_art`, `descripcion_art`, `precio`) VALUES
(1, 'Lapiz 2H', NULL, 'lapiz 2H SM', 0.99),
(2, 'Lapiz 1H', NULL, 'lapiz 1H SM', 0.99),
(3, 'Cuaderno A4 anillas b/w', NULL, 'cuaderno anillas A4 black / white', 3.20),
(4, 'Libro mat. 1ESO', NULL, 'libro matematicas 1ºESO ', 16.75),
(5, 'Libro mat. 2ESO', NULL, 'libro matematicas 1ºESO ', 18.75),
(6, 'Libro mat. 3ESO', NULL, 'libro matematicas 1ºESO ', 21.75),
(7, 'Libro mat. 4ESO', NULL, 'libro matematicas 1ºESO ', 30.75),
(8, 'Libro len. 1ESO', NULL, 'libro lenguage castellana 1ºESO ', 14.75),
(9, 'Libro len. 2ESO', NULL, 'libro lenguage castellana 2ºESO ', 16.75),
(10, 'Libro len. 3ESO', NULL, 'libro lenguage castellana 3ºESO ', 18.75),
(11, 'Libro len. 4ESO', NULL, 'libro lenguage castellana 4ºESO ', 20.75);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `id_cliente` int(10) NOT NULL,
  `nombre_cli` varchar(50) NOT NULL,
  `apellidos_cli` varchar(50) DEFAULT NULL,
  `direccion_cli` varchar(100) DEFAULT NULL,
  `telefono_cli` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`id_cliente`, `nombre_cli`, `apellidos_cli`, `direccion_cli`, `telefono_cli`) VALUES
(0, 'Emilio', 'Arevalo Zuñiga', 'Calle rio Segre, 2, 2b', '676543112'),
(1, 'Sofia', 'Castaño Rodriguez', 'Calle rio odiel, 34, 1ºa', '654222111'),
(2, 'Juan', 'Pérez García', 'Calle de la Paz, 10, 2ºB', '654333222'),
(3, 'Ana', 'Martínez López', 'Avenida de la Constitución, 20, 3ºC', '654444333'),
(4, 'Carlos', 'Gómez Fernández', 'Plaza Mayor, 30, 4ºD', '654555444'),
(5, 'María', 'Rodríguez Sánchez', 'Calle del Prado, 40, 5ºE', '654666555'),
(6, 'Pedro', 'Ruiz González', 'Paseo de la Castellana, 50, 6ºF', '654777666'),
(7, 'Isabel', 'Morales Romero', 'Calle de Alcalá, 60, 7ºG', '654888777'),
(8, 'Javier', 'Torres Peña', 'Gran Vía, 70, 8ºH', '654999888'),
(9, 'Carmen', 'Guerrero Navarro', 'Calle de Bailén, 80, 9ºI', '655000999'),
(10, 'Luis', 'Ramos Méndez', 'Calle de Ferraz, 90, 10ºJ', '655111000'),
(11, 'Teresa', 'Gutiérrez Mendoza', 'Calle de Serrano, 100, 11ºK', '655222111');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compras`
--

CREATE TABLE `compras` (
  `id_compra` int(10) NOT NULL,
  `id_cliente` int(10) DEFAULT NULL,
  `id_articulo` int(10) NOT NULL,
  `cantidad` varchar(100) DEFAULT NULL,
  `fechacompra` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id_usuario` int(10) NOT NULL,
  `id_cliente` int(10) NOT NULL,
  `user` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id_usuario`, `id_cliente`, `user`, `pass`) VALUES
(25, 0, 'emi94', '1234'),
(26, 1, 'sofiaCR', '1234'),
(27, 2, 'juanPG', '1234'),
(28, 3, 'anaML', '1234'),
(29, 4, 'carlosGF', '1234'),
(30, 5, 'mariaRS', '1234'),
(31, 6, 'pedroRG', '1234'),
(32, 7, 'isabelMR', '1234'),
(33, 8, 'javierTP', '1234'),
(34, 9, 'carmenGN', '1234'),
(35, 10, 'luisRM', '1234'),
(36, 11, 'teresaGM', '1234');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `articulos`
--
ALTER TABLE `articulos`
  ADD PRIMARY KEY (`id_articulo`),
  ADD UNIQUE KEY `nombre_art` (`nombre_art`);

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`id_cliente`),
  ADD UNIQUE KEY `nombre_cli` (`nombre_cli`);

--
-- Indices de la tabla `compras`
--
ALTER TABLE `compras`
  ADD PRIMARY KEY (`id_compra`),
  ADD KEY `C_CLIENTES_FK` (`id_cliente`),
  ADD KEY `C_ARTICULOS_FK` (`id_articulo`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id_usuario`),
  ADD KEY `USUARIOS_FK` (`id_cliente`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `articulos`
--
ALTER TABLE `articulos`
  MODIFY `id_articulo` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `clientes`
--
ALTER TABLE `clientes`
  MODIFY `id_cliente` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `compras`
--
ALTER TABLE `compras`
  MODIFY `id_compra` int(10) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id_usuario` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `compras`
--
ALTER TABLE `compras`
  ADD CONSTRAINT `C_ARTICULOS_FK` FOREIGN KEY (`id_articulo`) REFERENCES `articulos` (`id_articulo`),
  ADD CONSTRAINT `C_CLIENTES_FK` FOREIGN KEY (`id_cliente`) REFERENCES `clientes` (`id_cliente`) ON DELETE SET NULL;

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `USUARIOS_FK` FOREIGN KEY (`id_cliente`) REFERENCES `clientes` (`id_cliente`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
