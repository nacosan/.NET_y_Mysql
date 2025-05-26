-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 26-05-2025 a las 17:43:42
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
-- Base de datos: `gesteventos`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compras`
--

CREATE TABLE `compras` (
  `CompraID` int(11) NOT NULL,
  `UsuarioID` int(11) NOT NULL,
  `EventoID` int(11) NOT NULL,
  `FechaCompra` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `compras`
--

INSERT INTO `compras` (`CompraID`, `UsuarioID`, `EventoID`, `FechaCompra`) VALUES
(1, 1, 1, '2025-05-01 12:30:00'),
(2, 1, 2, '2025-05-02 15:00:00'),
(3, 2, 1, '2025-05-03 10:00:00'),
(4, 3, 3, '2025-05-04 18:45:00'),
(5, 1, 2, '2025-05-12 20:55:57'),
(6, 1, 2, '2025-05-26 17:38:06');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `eventoid`
--

CREATE TABLE `eventoid` (
  `EventoID` int(11) NOT NULL,
  `NombreEvento` varchar(100) NOT NULL,
  `FechaEvento` date NOT NULL,
  `Precio` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `eventoid`
--

INSERT INTO `eventoid` (`EventoID`, `NombreEvento`, `FechaEvento`, `Precio`) VALUES
(1, 'Concierto Rock Madrid', '2025-06-15', 45.00),
(2, 'Festival Jazz Barcelona', '2025-07-20', 60.00),
(3, 'Pop Night Sevilla', '2025-08-10', 35.00);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `UsuarioID` int(11) NOT NULL,
  `NombreUsuario` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`UsuarioID`, `NombreUsuario`) VALUES
(3, 'carlossanchez'),
(1, 'juanperez'),
(2, 'mariagomez');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `compras`
--
ALTER TABLE `compras`
  ADD PRIMARY KEY (`CompraID`),
  ADD KEY `UsuarioID` (`UsuarioID`),
  ADD KEY `EventoID` (`EventoID`);

--
-- Indices de la tabla `eventoid`
--
ALTER TABLE `eventoid`
  ADD PRIMARY KEY (`EventoID`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`UsuarioID`),
  ADD UNIQUE KEY `NombreUsuario` (`NombreUsuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `compras`
--
ALTER TABLE `compras`
  MODIFY `CompraID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `eventoid`
--
ALTER TABLE `eventoid`
  MODIFY `EventoID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `UsuarioID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `compras`
--
ALTER TABLE `compras`
  ADD CONSTRAINT `compras_ibfk_1` FOREIGN KEY (`UsuarioID`) REFERENCES `usuarios` (`UsuarioID`),
  ADD CONSTRAINT `compras_ibfk_2` FOREIGN KEY (`EventoID`) REFERENCES `eventoid` (`EventoID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
