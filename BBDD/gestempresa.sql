-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 26-05-2025 a las 17:03:28
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `gestempresa`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `entradas`
--

CREATE TABLE `entradas` (
  `id` int(4) NOT NULL,
  `codigo` varchar(8) NOT NULL,
  `cantidad` int(3) NOT NULL,
  `fecha` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `entradas`
--

INSERT INTO `entradas` (`id`, `codigo`, `cantidad`, `fecha`) VALUES
(1, 'AAAA', 10, '2025-05-13 00:00:00'),
(2, 'CCCC', 10, '2025-05-13 20:56:25'),
(3, 'CCCC', 10, '2025-05-13 20:59:05'),
(4, 'CCCC', 10, '2025-05-14 18:54:21'),
(5, 'A001', 10, '2025-05-01 10:00:00'),
(6, 'A002', 20, '2025-05-02 11:00:00'),
(7, 'A003', 15, '2025-05-03 12:00:00'),
(8, 'A001', 5, '2025-05-04 13:00:00'),
(9, 'A004', 30, '2025-05-05 14:00:00'),
(10, 'A005', 25, '2025-05-06 15:00:00'),
(11, 'CCCC', 10, '2025-05-14 20:01:56'),
(12, 'CCCC', 10, '2025-05-14 20:32:38'),
(13, 'CCCC', 10, '2025-05-14 20:50:51'),
(14, 'CCCC', 10, '2025-05-14 20:53:04'),
(15, 'CCCC', 10, '2025-05-26 16:30:51'),
(16, 'AAAA', 3, '2025-05-26 16:40:52'),
(17, 'dddd', 5, '2025-05-26 16:51:39');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id` int(4) NOT NULL,
  `codigo` varchar(8) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `tipo` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id`, `codigo`, `nombre`, `tipo`) VALUES
(1, 'AAAA', 'chorizo', 'embutido'),
(2, 'BBBB', 'lomo', 'embutido'),
(3, 'BBBB', 'lomo', 'embutido'),
(4, 'CCCC', 'Jamón', 'Embutido');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `salidas`
--

CREATE TABLE `salidas` (
  `id` int(4) NOT NULL,
  `codigo` varchar(8) NOT NULL,
  `cantidad` int(3) NOT NULL,
  `fecha` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `salidas`
--

INSERT INTO `salidas` (`id`, `codigo`, `cantidad`, `fecha`) VALUES
(1, 'AAAA', 8, '2025-05-13 00:00:00'),
(2, 'A001', 8, '2025-05-07 10:00:00'),
(3, 'A002', 20, '2025-05-08 11:00:00'),
(4, 'A003', 5, '2025-05-09 12:00:00'),
(5, 'A005', 10, '2025-05-10 13:00:00');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `entradas`
--
ALTER TABLE `entradas`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `salidas`
--
ALTER TABLE `salidas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `entradas`
--
ALTER TABLE `entradas`
  MODIFY `id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `salidas`
--
ALTER TABLE `salidas`
  MODIFY `id` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
