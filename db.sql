CREATE DATABASE  IF NOT EXISTS `lastcall` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `lastcall`;
-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: lastcall
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `foodoffers`
--

DROP TABLE IF EXISTS `foodoffers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `foodoffers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `offerdate` datetime DEFAULT NULL,
  `offerstarttime` datetime DEFAULT NULL,
  `offerendtime` datetime DEFAULT NULL,
  `offername` varchar(255) DEFAULT NULL,
  `offerdescription` varchar(255) DEFAULT NULL,
  `supplierid` int(11) DEFAULT NULL,
  `qtyavailable` int(11) DEFAULT NULL,
  `foodtypeid` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_foodtype_idx` (`foodtypeid`),
  KEY `fk_supplier_offer` (`supplierid`),
  CONSTRAINT `fk_foodtype_offer` FOREIGN KEY (`foodtypeid`) REFERENCES `foodtypes` (`id`),
  CONSTRAINT `fk_supplier_offer` FOREIGN KEY (`supplierid`) REFERENCES `suppliers` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Current food offers';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `foodoffers`
--

LOCK TABLES `foodoffers` WRITE;
/*!40000 ALTER TABLE `foodoffers` DISABLE KEYS */;
/*!40000 ALTER TABLE `foodoffers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `foodpreferences`
--

DROP TABLE IF EXISTS `foodpreferences`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `foodpreferences` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `subscriberid` int(11) NOT NULL,
  `preferenceid` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `ix_subscriberid` (`subscriberid`),
  KEY `fk_foodtype` (`preferenceid`),
  CONSTRAINT `fk_foodtype` FOREIGN KEY (`preferenceid`) REFERENCES `foodtypes` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `foodpreferences`
--

LOCK TABLES `foodpreferences` WRITE;
/*!40000 ALTER TABLE `foodpreferences` DISABLE KEYS */;
INSERT INTO `foodpreferences` VALUES (1,1,1),(2,1,2),(3,1,7);
/*!40000 ALTER TABLE `foodpreferences` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `foodtypes`
--

DROP TABLE IF EXISTS `foodtypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `foodtypes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `foodtype` varchar(45) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `foodtypes`
--

LOCK TABLES `foodtypes` WRITE;
/*!40000 ALTER TABLE `foodtypes` DISABLE KEYS */;
INSERT INTO `foodtypes` VALUES (1,'Vegetarian'),(2,'Pizza'),(3,'Burgers'),(4,'Sandwiches'),(5,'Fish'),(6,'Salads'),(7,'Thai'),(8,'Indian'),(9,'Italian'),(10,'Pasta and noodles');
/*!40000 ALTER TABLE `foodtypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subscribers`
--

DROP TABLE IF EXISTS `subscribers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `subscribers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(45) DEFAULT '',
  `friendlyname` varchar(45) DEFAULT '',
  `phone` varchar(45) DEFAULT '',
  `deliveryaddress` varchar(255) DEFAULT '',
  `emailoffers` tinyint(4) DEFAULT '0',
  `textoffers` tinyint(4) DEFAULT '0',
  `onmailinglist` tinyint(4) DEFAULT '0',
  `password` varchar(45) DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subscribers`
--

LOCK TABLES `subscribers` WRITE;
/*!40000 ALTER TABLE `subscribers` DISABLE KEYS */;
INSERT INTO `subscribers` VALUES (1,'adrianjking@gmail.com','Adrian','','',1,1,0,''),(2,'chloeking313@gmail.com','Chloe','','',0,0,0,'');
/*!40000 ALTER TABLE `subscribers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `suppliers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `phone` varchar(45) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `logo` blob,
  `url` varchar(255) DEFAULT NULL,
  `mapurl` varchar(255) DEFAULT NULL,
  `contactperson` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-11-11 17:43:16
