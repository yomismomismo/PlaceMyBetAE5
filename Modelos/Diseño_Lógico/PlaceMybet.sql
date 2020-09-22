-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 22-09-2020 a las 18:08:22
-- Versión del servidor: 10.4.11-MariaDB
-- Versión de PHP: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `placemybet`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `apuesta`
--

CREATE TABLE `apuesta` (
  `ID` int(11) NOT NULL,
  `DineroApostado` int(11) NOT NULL,
  `TipoApuesta` varchar(20) NOT NULL,
  `Cuota` double NOT NULL,
  `Fecha` date NOT NULL,
  `ID_Mercado` int(11) NOT NULL,
  `Email_Usuario` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `apuesta`
--

INSERT INTO `apuesta` (`ID`, `DineroApostado`, `TipoApuesta`, `Cuota`, `Fecha`, `ID_Mercado`, `Email_Usuario`) VALUES
(2, 15, 'Over', 1.43, '2020-09-22', 1, 'yomismomismo@yomismo.cat');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuenta_banco`
--

CREATE TABLE `cuenta_banco` (
  `ID` int(11) NOT NULL,
  `Nombre_Banco` varchar(100) NOT NULL,
  `Tarjeta_Credito` bigint(16) NOT NULL,
  `Saldo_Actual` int(11) NOT NULL,
  `Email_Usuario` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cuenta_banco`
--

INSERT INTO `cuenta_banco` (`ID`, `Nombre_Banco`, `Tarjeta_Credito`, `Saldo_Actual`, `Email_Usuario`) VALUES
(4, 'Bankmismo', 4521479658521475, 200, 'yomismomismo@yomismo.cat');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `evento`
--

CREATE TABLE `evento` (
  `ID` int(11) NOT NULL,
  `Equipo_Local` varchar(100) NOT NULL,
  `Equipo_Visitante` varchar(100) NOT NULL,
  `Fecha` date NOT NULL,
  `Goles` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `evento`
--

INSERT INTO `evento` (`ID`, `Equipo_Local`, `Equipo_Visitante`, `Fecha`, `Goles`) VALUES
(1, 'Valencia', 'Espanyol', '2020-09-16', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mercado`
--

CREATE TABLE `mercado` (
  `ID` int(11) NOT NULL,
  `OverUnder` double NOT NULL,
  `CuotaOver` double NOT NULL,
  `CuotaUnder` double NOT NULL,
  `DineroOver` double NOT NULL,
  `DineroUnder` double NOT NULL,
  `ID_Evento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `mercado`
--

INSERT INTO `mercado` (`ID`, `OverUnder`, `CuotaOver`, `CuotaUnder`, `DineroOver`, `DineroUnder`, `ID_Evento`) VALUES
(1, 1.5, 1.43, 2.85, 100, 50, 1),
(2, 2.5, 1.9, 1.9, 100, 100, 1),
(3, 3.5, 2.85, 1.43, 50, 100, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `Email` varchar(100) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Edad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`Email`, `Nombre`, `Apellido`, `Edad`) VALUES
('yomismomismo@yomismo.cat', 'Yomismo', 'Mismo', 21);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `apuesta`
--
ALTER TABLE `apuesta`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK_ID_Mercado` (`ID_Mercado`),
  ADD KEY `FK_Email_Usuario` (`Email_Usuario`);

--
-- Indices de la tabla `cuenta_banco`
--
ALTER TABLE `cuenta_banco`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `FK_Email_Usuario` (`Email_Usuario`) USING BTREE;

--
-- Indices de la tabla `evento`
--
ALTER TABLE `evento`
  ADD PRIMARY KEY (`ID`);

--
-- Indices de la tabla `mercado`
--
ALTER TABLE `mercado`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK_ID_evento` (`ID_Evento`) USING BTREE;

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Email`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `apuesta`
--
ALTER TABLE `apuesta`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `cuenta_banco`
--
ALTER TABLE `cuenta_banco`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `evento`
--
ALTER TABLE `evento`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `mercado`
--
ALTER TABLE `mercado`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `apuesta`
--
ALTER TABLE `apuesta`
  ADD CONSTRAINT `apuesta_ibfk_1` FOREIGN KEY (`ID_Mercado`) REFERENCES `mercado` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `apuesta_ibfk_2` FOREIGN KEY (`Email_Usuario`) REFERENCES `usuario` (`Email`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `cuenta_banco`
--
ALTER TABLE `cuenta_banco`
  ADD CONSTRAINT `cuenta_banco_ibfk_1` FOREIGN KEY (`Email_Usuario`) REFERENCES `usuario` (`Email`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `mercado`
--
ALTER TABLE `mercado`
  ADD CONSTRAINT `mercado_ibfk_1` FOREIGN KEY (`ID_Evento`) REFERENCES `evento` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
