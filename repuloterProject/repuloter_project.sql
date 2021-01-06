-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Nov 09. 00:21
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
-- Tábla szerkezet ehhez a táblához `repulogep`
--

CREATE TABLE `repulogep` (
  `repulogepid` int(10) NOT NULL,
  `tipus` varchar(12) COLLATE utf8_hungarian_ci NOT NULL,
  `nehezseg` varchar(12) COLLATE utf8_hungarian_ci NOT NULL,
  `uzemanyagallapot` int(3) NOT NULL,
  `ATerminal` tinyint(1) NOT NULL,
  `BTerminal` tinyint(1) NOT NULL,
  `honnan` varchar(40) COLLATE utf8_hungarian_ci NOT NULL,
  `érkezesido` date NOT NULL,
  `hova` varchar(40) COLLATE utf8_hungarian_ci NOT NULL,
  `indulasido` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `repuloter`
--

CREATE TABLE `repuloter` (
  `repulogepid` int(11) NOT NULL,
  `ugyfelid` int(11) NOT NULL,
  `repuloternev` varchar(40) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ugyfel`
--

CREATE TABLE `ugyfel` (
  `id` int(4) NOT NULL,
  `nev` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `kor` int(4) NOT NULL,
  `ATerminal` tinyint(1) NOT NULL,
  `BTerminal` tinyint(1) NOT NULL,
  `honnan` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `erkezesido` date NOT NULL,
  `hova` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `indulasido` date NOT NULL,
  `jegyar` int(10) NOT NULL,
  `kedvezmenyes` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `repulogep`
--
ALTER TABLE `repulogep`
  ADD PRIMARY KEY (`repulogepid`);

--
-- A tábla indexei `ugyfel`
--
ALTER TABLE `ugyfel`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `repulogep`
--
ALTER TABLE `repulogep`
  MODIFY `repulogepid` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `ugyfel`
--
ALTER TABLE `ugyfel`
  MODIFY `id` int(4) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
