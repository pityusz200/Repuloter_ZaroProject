-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2021. Jan 06. 10:35
-- Kiszolgáló verziója: 10.4.11-MariaDB
-- PHP verzió: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `repuloter_project`
--
CREATE DATABASE IF NOT EXISTS `repuloter_project` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `repuloter_project`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `jarat`
--

CREATE TABLE `jarat` (
  `jaratszam` int(11) NOT NULL,
  `honnan` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `hova` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `indulasido` date NOT NULL,
  `erkezesido` date NOT NULL,
  `terminal` tinyint(1) NOT NULL,
  `rgepkod` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `jarat`:
--   `jaratszam`
--       `utazas` -> `jaratszamAz`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kedvezmenyek`
--

CREATE TABLE `kedvezmenyek` (
  `kedvAz` int(11) NOT NULL,
  `kedvNeve` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `kedvMerteke` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `kedvezmenyek`:
--   `kedvAz`
--       `utas` -> `kedvAz`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `meret`
--

CREATE TABLE `meret` (
  `meretAz` int(11) NOT NULL,
  `meretek` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `meret`:
--   `meretAz`
--       `repulogep` -> `meretAz`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `repgeptars`
--

CREATE TABLE `repgeptars` (
  `rgepTarsAz` int(11) NOT NULL,
  `repTarsNeve` varchar(50) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `repgeptars`:
--   `rgepTarsAz`
--       `repulogep` -> `rgepTarsAz`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `repulogep`
--

CREATE TABLE `repulogep` (
  `rgepkod` int(11) NOT NULL,
  `tipus` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `meretAz` int(11) NOT NULL,
  `rgepTarsAz` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `repulogep`:
--   `rgepkod`
--       `jarat` -> `rgepkod`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `utas`
--

CREATE TABLE `utas` (
  `utasAz` int(11) NOT NULL,
  `nev` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `szulido` date NOT NULL,
  `szemAzon` int(11) NOT NULL,
  `kedvAz` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `utas`:
--   `utasAz`
--       `utazas` -> `utasAz`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `utazas`
--

CREATE TABLE `utazas` (
  `utazasAz` int(11) NOT NULL,
  `jaratszamAz` int(11) NOT NULL,
  `utasAz` int(11) NOT NULL,
  `osztaly` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  `jegyar` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- TÁBLA KAPCSOLATAI `utazas`:
--

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `jarat`
--
ALTER TABLE `jarat`
  ADD PRIMARY KEY (`jaratszam`),
  ADD KEY `rgepkod` (`rgepkod`);

--
-- A tábla indexei `kedvezmenyek`
--
ALTER TABLE `kedvezmenyek`
  ADD PRIMARY KEY (`kedvAz`);

--
-- A tábla indexei `meret`
--
ALTER TABLE `meret`
  ADD PRIMARY KEY (`meretAz`);

--
-- A tábla indexei `repgeptars`
--
ALTER TABLE `repgeptars`
  ADD PRIMARY KEY (`rgepTarsAz`);

--
-- A tábla indexei `repulogep`
--
ALTER TABLE `repulogep`
  ADD PRIMARY KEY (`rgepkod`),
  ADD KEY `rgepTarsAz` (`rgepTarsAz`),
  ADD KEY `meretAz` (`meretAz`);

--
-- A tábla indexei `utas`
--
ALTER TABLE `utas`
  ADD PRIMARY KEY (`utasAz`),
  ADD KEY `kedvAz` (`kedvAz`);

--
-- A tábla indexei `utazas`
--
ALTER TABLE `utazas`
  ADD PRIMARY KEY (`utazasAz`),
  ADD KEY `jaratszam` (`jaratszamAz`),
  ADD KEY `utasAz` (`utasAz`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `jarat`
--
ALTER TABLE `jarat`
  MODIFY `jaratszam` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `kedvezmenyek`
--
ALTER TABLE `kedvezmenyek`
  MODIFY `kedvAz` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `meret`
--
ALTER TABLE `meret`
  MODIFY `meretAz` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `repgeptars`
--
ALTER TABLE `repgeptars`
  MODIFY `rgepTarsAz` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `repulogep`
--
ALTER TABLE `repulogep`
  MODIFY `rgepkod` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `utas`
--
ALTER TABLE `utas`
  MODIFY `utasAz` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `utazas`
--
ALTER TABLE `utazas`
  MODIFY `utazasAz` int(11) NOT NULL AUTO_INCREMENT;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `jarat`
--
ALTER TABLE `jarat`
  ADD CONSTRAINT `jarat_ibfk_1` FOREIGN KEY (`jaratszam`) REFERENCES `utazas` (`jaratszamAz`);

--
-- Megkötések a táblához `kedvezmenyek`
--
ALTER TABLE `kedvezmenyek`
  ADD CONSTRAINT `kedvezmenyek_ibfk_1` FOREIGN KEY (`kedvAz`) REFERENCES `utas` (`kedvAz`);

--
-- Megkötések a táblához `meret`
--
ALTER TABLE `meret`
  ADD CONSTRAINT `meret_ibfk_1` FOREIGN KEY (`meretAz`) REFERENCES `repulogep` (`meretAz`);

--
-- Megkötések a táblához `repgeptars`
--
ALTER TABLE `repgeptars`
  ADD CONSTRAINT `repgeptars_ibfk_1` FOREIGN KEY (`rgepTarsAz`) REFERENCES `repulogep` (`rgepTarsAz`);

--
-- Megkötések a táblához `repulogep`
--
ALTER TABLE `repulogep`
  ADD CONSTRAINT `repulogep_ibfk_1` FOREIGN KEY (`rgepkod`) REFERENCES `jarat` (`rgepkod`);

--
-- Megkötések a táblához `utas`
--
ALTER TABLE `utas`
  ADD CONSTRAINT `utas_ibfk_1` FOREIGN KEY (`utasAz`) REFERENCES `utazas` (`utasAz`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
