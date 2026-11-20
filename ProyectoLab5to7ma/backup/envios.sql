-- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
--
-- Host: localhost    Database: db_joacoenvios
-- ------------------------------------------------------
-- Server version	8.0.46

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `idCliente` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `dni` varchar(20) NOT NULL,
  `telefono` varchar(30) NOT NULL,
  `email` varchar(150) NOT NULL,
  PRIMARY KEY (`idCliente`),
  UNIQUE KEY `dni` (`dni`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (2,'Juan','Perez','40123456','1123456789','juan@gmail.com');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `direccion`
--

DROP TABLE IF EXISTS `direccion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `direccion` (
  `idDireccion` int NOT NULL AUTO_INCREMENT,
  `calle` varchar(150) NOT NULL,
  `direccionPostal` varchar(20) NOT NULL,
  `localidad` varchar(100) NOT NULL,
  PRIMARY KEY (`idDireccion`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `direccion`
--

LOCK TABLES `direccion` WRITE;
/*!40000 ALTER TABLE `direccion` DISABLE KEYS */;
INSERT INTO `direccion` VALUES (1,'Av. Rivadavia 1500','C1033','CABA'),(2,'Av. Rivadavia 1500','1704','Ramos Mejia');
/*!40000 ALTER TABLE `direccion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `envio`
--

DROP TABLE IF EXISTS `envio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `envio` (
  `idEnvio` int NOT NULL AUTO_INCREMENT,
  `idCliente` int NOT NULL,
  `idPaquete` int NOT NULL,
  `idOrigen` int NOT NULL,
  `idDestino` int NOT NULL,
  `distancia` decimal(10,2) NOT NULL,
  `modalidad` enum('ESTANDAR','EXPRESS','PRIORITARIO') NOT NULL,
  `estado` varchar(50) NOT NULL,
  `fechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idEnvio`),
  KEY `fk_envio_cliente` (`idCliente`),
  KEY `fk_envio_paquete` (`idPaquete`),
  KEY `fk_envio_origen` (`idOrigen`),
  KEY `fk_envio_destino` (`idDestino`),
  CONSTRAINT `fk_envio_cliente` FOREIGN KEY (`idCliente`) REFERENCES `cliente` (`idCliente`),
  CONSTRAINT `fk_envio_destino` FOREIGN KEY (`idDestino`) REFERENCES `direccion` (`idDireccion`),
  CONSTRAINT `fk_envio_origen` FOREIGN KEY (`idOrigen`) REFERENCES `direccion` (`idDireccion`),
  CONSTRAINT `fk_envio_paquete` FOREIGN KEY (`idPaquete`) REFERENCES `paquete` (`idPaquete`),
  CONSTRAINT `envio_chk_1` CHECK ((`distancia` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `envio`
--

LOCK TABLES `envio` WRITE;
/*!40000 ALTER TABLE `envio` DISABLE KEYS */;
INSERT INTO `envio` VALUES (1,2,1,1,2,30.00,'EXPRESS','CANCELADO','2026-11-18 22:31:23'),(2,2,2,1,2,25.00,'EXPRESS','CANCELADO','2026-11-19 22:42:45'),(3,2,3,1,2,30.00,'EXPRESS','ENTREGADO','2026-11-19 23:06:22'),(4,2,4,1,2,15.00,'ESTANDAR','CANCELADO','2026-11-19 23:33:29'),(5,2,5,1,2,30.00,'EXPRESS','ENTREGADO','2026-11-19 23:52:42'),(6,2,6,1,2,10.00,'ESTANDAR','CANCELADO','2026-11-19 23:57:42'),(7,2,7,1,2,10.00,'ESTANDAR','PENDIENTE','2026-11-20 00:16:12'),(8,2,8,1,2,30.00,'EXPRESS','ENTREGADO','2026-11-20 00:16:42'),(9,2,9,1,2,10.00,'ESTANDAR','CANCELADO','2026-11-20 00:20:15'),(10,2,10,1,2,30.00,'EXPRESS','ENTREGADO','2026-11-20 00:40:36');
/*!40000 ALTER TABLE `envio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `historialestado`
--

DROP TABLE IF EXISTS `historialestado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `historialestado` (
  `idHistorial` int NOT NULL AUTO_INCREMENT,
  `idEnvio` int NOT NULL,
  `estado` varchar(50) NOT NULL,
  `fecha` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idHistorial`),
  KEY `fk_historial_envio` (`idEnvio`),
  CONSTRAINT `fk_historial_envio` FOREIGN KEY (`idEnvio`) REFERENCES `envio` (`idEnvio`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historialestado`
--

LOCK TABLES `historialestado` WRITE;
/*!40000 ALTER TABLE `historialestado` DISABLE KEYS */;
INSERT INTO `historialestado` VALUES (1,1,'PENDIENTE','2026-11-18 22:31:23'),(2,1,'CANCELADO','2026-11-19 22:27:06'),(3,2,'PENDIENTE','2026-11-19 22:42:45'),(4,2,'CANCELADO','2026-11-19 22:44:47'),(5,3,'PENDIENTE','2026-11-19 23:06:22'),(6,3,'DESPACHADO','2026-11-19 23:07:09'),(7,3,'ENTREGADO','2026-11-19 23:07:36'),(8,4,'PENDIENTE','2026-11-19 23:33:29'),(9,4,'CANCELADO','2026-11-19 23:34:49'),(10,5,'PENDIENTE','2026-11-19 23:52:42'),(11,5,'DESPACHADO','2026-11-19 23:56:08'),(12,5,'ENTREGADO','2026-11-19 23:56:39'),(13,6,'PENDIENTE','2026-11-19 23:57:42'),(14,6,'CANCELADO','2026-11-19 23:58:17'),(15,7,'PENDIENTE','2026-11-20 00:16:12'),(16,8,'PENDIENTE','2026-11-20 00:16:42'),(17,8,'DESPACHADO','2026-11-20 00:18:28'),(18,8,'ENTREGADO','2026-11-20 00:18:51'),(19,9,'PENDIENTE','2026-11-20 00:20:15'),(20,9,'CANCELADO','2026-11-20 00:20:44'),(21,10,'PENDIENTE','2026-11-20 00:40:36'),(22,10,'DESPACHADO','2026-11-20 00:42:09'),(23,10,'ENTREGADO','2026-11-20 00:42:28');
/*!40000 ALTER TABLE `historialestado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paquete`
--

DROP TABLE IF EXISTS `paquete`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paquete` (
  `idPaquete` int NOT NULL AUTO_INCREMENT,
  `peso` decimal(10,2) NOT NULL,
  `alto` decimal(10,2) NOT NULL,
  `ancho` decimal(10,2) NOT NULL,
  `largo` decimal(10,2) NOT NULL,
  PRIMARY KEY (`idPaquete`),
  CONSTRAINT `paquete_chk_1` CHECK ((`peso` > 0)),
  CONSTRAINT `paquete_chk_2` CHECK ((`alto` > 0)),
  CONSTRAINT `paquete_chk_3` CHECK ((`ancho` > 0)),
  CONSTRAINT `paquete_chk_4` CHECK ((`largo` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paquete`
--

LOCK TABLES `paquete` WRITE;
/*!40000 ALTER TABLE `paquete` DISABLE KEYS */;
INSERT INTO `paquete` VALUES (1,6.00,20.00,15.00,30.00),(2,6.00,10.00,10.00,20.00),(3,6.00,10.00,10.00,10.00),(4,5.00,10.00,10.00,10.00),(5,6.00,10.00,10.00,10.00),(6,3.00,10.00,10.00,10.00),(7,3.00,10.00,10.00,10.00),(8,6.00,10.00,10.00,10.00),(9,3.00,10.00,10.00,10.00),(10,6.00,10.00,10.00,10.00);
/*!40000 ALTER TABLE `paquete` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-20  1:05:07
