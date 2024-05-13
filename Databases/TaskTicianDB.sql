CREATE DATABASE  IF NOT EXISTS `tm_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `tm_db`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: tm_db
-- ------------------------------------------------------
-- Server version	8.0.35

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
-- Table structure for table `dailytask_tbl`
--

DROP TABLE IF EXISTS `dailytask_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dailytask_tbl` (
  `DTID` int NOT NULL AUTO_INCREMENT,
  `DTName` varchar(100) NOT NULL,
  `UID` int NOT NULL,
  `UN` varchar(100) NOT NULL,
  `DateCompleted` date DEFAULT NULL,
  PRIMARY KEY (`DTID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dailytask_tbl`
--

LOCK TABLES `dailytask_tbl` WRITE;
/*!40000 ALTER TABLE `dailytask_tbl` DISABLE KEYS */;
/*!40000 ALTER TABLE `dailytask_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `group_tbl`
--

DROP TABLE IF EXISTS `group_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `group_tbl` (
  `GID` int NOT NULL AUTO_INCREMENT,
  `GroupName` varchar(200) NOT NULL,
  `OwnerID` int NOT NULL,
  `GroupMembers` varchar(300) NOT NULL,
  `DateCreated` date NOT NULL,
  `ID_GroupName` varchar(150) NOT NULL,
  `TotalTask` int DEFAULT NULL,
  `CompletedTask` int DEFAULT NULL,
  `Progress` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`GID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group_tbl`
--

LOCK TABLES `group_tbl` WRITE;
/*!40000 ALTER TABLE `group_tbl` DISABLE KEYS */;
INSERT INTO `group_tbl` VALUES (1,'testGroup1',1,'2','2024-05-13','ZaitestGroup1',4,3,75);
/*!40000 ALTER TABLE `group_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personaltask_tbl`
--

DROP TABLE IF EXISTS `personaltask_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personaltask_tbl` (
  `TID` int NOT NULL AUTO_INCREMENT,
  `TaskName` varchar(3000) NOT NULL,
  `TaskCategory` varchar(100) DEFAULT NULL,
  `TaskDeadline` date DEFAULT NULL,
  `TaskStatus` varchar(20) NOT NULL,
  `UID` int NOT NULL,
  `UN` varchar(60) NOT NULL,
  `TaskInfo` varchar(1000) DEFAULT NULL,
  UNIQUE KEY `TID` (`TID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personaltask_tbl`
--

LOCK TABLES `personaltask_tbl` WRITE;
/*!40000 ALTER TABLE `personaltask_tbl` DISABLE KEYS */;
INSERT INTO `personaltask_tbl` VALUES (1,'Task 1','School','2024-05-14','Completed',1,'Zai','Task1');
/*!40000 ALTER TABLE `personaltask_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_tbl`
--

DROP TABLE IF EXISTS `user_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_tbl` (
  `UID` int NOT NULL AUTO_INCREMENT,
  `UN` varchar(100) NOT NULL,
  `PW` varchar(100) NOT NULL,
  `ImageData` longblob,
  `FirstName` varchar(50) NOT NULL,
  `MiddleName` varchar(60) NOT NULL,
  `LastName` varchar(60) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Quote` varchar(300) DEFAULT NULL,
  `Friends` varchar(300) NOT NULL,
  `TotalTask` int DEFAULT NULL,
  `CompletedTask` int DEFAULT NULL,
  `FailedTask` int DEFAULT NULL,
  UNIQUE KEY `UID` (`UID`),
  UNIQUE KEY `UN` (`UN`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_tbl`
--

LOCK TABLES `user_tbl` WRITE;
/*!40000 ALTER TABLE `user_tbl` DISABLE KEYS */;
INSERT INTO `user_tbl` VALUES (1,'Zai','zai',_binary '�PNG\r\n\Z\n\0\0\0\rIHDR\0\0\0\0\0\0\0\0\0�x\��\0\0\0sRGB\0�\�\�\0\0\0gAMA\0\0���a\0\0\0	pHYs\0\0\�\0\0\�(J�\0\0\0tEXtSoftware\0www.inkscape.org�\�<\Z\0\0/3IDATx^\�\���U�\��t�3ҍ$�\0D�J\�1pgEt1\����WP\�\n��H3*D�@h�\n�\�&(9gh`\��4T[4ouթ:\�\�\���\���\�j�\�\��\�\�\�o\�>\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"���,��\�d���.\�d#\�b����\�����\�\��y�\�DDDԡ\�\�d\�@��ɧ\�@9\\��\�\�<��\�*�\��v��-����/�-�M�m�����;\��\�\�1Uۼ2I�I{\�G�\�I2]n����\�A�\\Δcd�\�!>��,(DDDE\�y���\�/�~\�����8\�E~�\�7B~����,���#DDD�ȧ�א�\��x�R�7��\�S߷?\�׾\�}\��\�u4�\��4�.r��S\��X�{��ke��딍e��\�xY_��c\�\nyF� 4�+\�5��|\\֓qBDD��\�r�w\�����3\�\�>[\�6��\�y	U\�\�	z��~�<-ы��>K\�s|5\�bBDD\��w[��S�R��\�E��1\�c\�0\�R|\�Q�� �\�3�9��V����\�\�先�\Z�g\��{|\�\�S�/H�\���\�p�\��?�\�\"���x\�Y/E��DO\�@��X;Uv&u)\�\���0_�\�u�\�5O ��#^\�oH������f���\r�EߧX\�.\�Ci|\��\���\�>���h��K��\�~@�\'V�4�\n\�g���ī���^\�;\��r��%z��^�\0�Q��R*�\�\���\�\�\�B{�\�\�+\"��U\�[\�)~\�E�\�7ee!\"J��������\�2�@�����&#DDŶ�x9^\�\�=\��\�(ޝrQ!\"*&�\����I�\�`x/A��5�\�\�\�\�:�@{�w\�l\�T��\Z��\��l��%z\�\�^޶\�W0O��z\�<\�\�J|��\�_\�o\�	Q\����~ҹA�\'%\0\�u�x!-\� ����|^\�\�I@o\�-�r`~!\"\Zu\�ŗ�\�%ѓ�f�O�F`��\\�w�7K�$�\�n�y+DDC\�Y�~\���%ѓ\n��\��\�\"\Z4/\�\�K��\'\0e�U~sϖ\�D4��\�\"��4\0\�2]\�\"��\�\�eF�	I�D \'�,\�͹�\"�(_/\�Y\�^g<zr\0P�\'\��v�2_\"J\\�?/=\0�\�\�\�}�%kC��D��\0`\�\�\�BD	�~\�G\��\��&K\n�O�{\��{%�%��y@��\0�\r\�*r�D�\�\0Њd5!�7Q�\�\��\"�H<+�*����\Z\�fr�D��\0\�\�dk!���x1�\�\0:��-.Dԣ�N��~A���E��u���O�\0���D]�O�\0�\�g\�#Dԁ�\��\�|6`1!�6��x�\�\�\0�\�g(7\"\ZEc\�\����/��x9a�0^��\�V�?H�\�\0%�L�2)\r3�\���D�P\0P�\'e!������D�D\0P�S�	�DAޯ�V�~q\0 �\�\�:\"z)o���D�0\0�\�L\�_\�f��nA��D�$\0�\�\�\�L��\�r�D�\0P�d\r!���\�q�~!\0�&O\�G�(u�ǈ~	\0�f\�d��\�5r�D>\0\�Ņ���4m \�-+:\�\0�t�l\"Dŷ��;�\�@\0�\�Ӳ�\��*\��\r\0��@��hD\�\�%}ϔ\�\0߯eQ!j|��\�׶F2\0�u\�\�녨�m*It\0\0F\�Ay�5��#L��\��)^H��1y�\�$:`\0\�\�\�\�)B\�\�<;�h�R\0@\��@\�	Q\�[@Β\��\0t޹��u-/Uy�D$\0�{�$���\�$7It \0�\�Vy�u��\��@\0@\�\�-k	Q\�����Ht\���\�&\�\�O\�\�r�\�-އ\�]���#��\�`� ^Ym ���?��]�7�o�3���3���o\\ ���\�\�6�򰰑���\����f\�r�\�.�\�k�����o�6��|T�\"?\�\�h@7<)\�Ѩ\�UfJt�\�\�O\�W\�wdO\�XJ�\�\�\�\�\�\�1�R٫�3\�?g\�\"D#\�3\�?\�$�t�([�//\�ڂ��|YΑG%�O�v�s�i#j�/HtP�\�O��_\�o]k��\�U\��(\�Kt����\r;?!E0�\�4��,.��\�(\'\�ݗ�H DCv�D\�\n\�\n\�}OF\Z/\�Z>;\�9GȽ\�\�@+�\nQث\�0�`8�����߾|_n\'~C��D�=0_��\��oIt�\0C�\\��\����\'zv�׀�`(�\�\�\��D��c$:P����\�YS�7�Y�/�=F�`|\��&��|\0�I<:@�\�\r�q�O����z7J�������\��\0\�\�\��>�\\�e{Mo�K��p.Ta^R5: �~^H\����TVȩ\�B^������\",с\0��H\��He���$��\�|I����ot\0\0\�~\�G��gJ��Ɗ�\��\�\\$	\�\�m⥘�c\0u�Y������\�8\��w�\�>.	�\'?\�;ȭ��\�\�&�(\�fK_��*\�7_>\�Ӿ�.����\�I	\�D��\�F�N�e�\�-\'\'Kt��N��\�(�\�֐%z�Q�;\�}B\�O}�Kt\�>^ar-�[Y\�\�E]����{^H�斏\�@\�|!�w�|�PAM�=��\�_�\��\�j�Z\�:��)\�\�fYF���[\�U=��G��~\�집6A|6�E�p�0a�ፓ�%z\0Q�{\��\����\��G�c\r�8K\�\n50_\���8\�\�o\09]G\�n)a%A|O��M�\�C��\�ł>ԩ|l\�#�N<:Q��\ZԎ\��t��j~\����yR\�?$:��_k>,Ԁ�ޑ\�\�<YZ����f�@�c��5g��yH��y��\'~�\"O�r\�ѱ���Մz\�\�r�Dr{Z��Q�fR���\�\�FYL���S\�\�$z@���v~�5)\��O�c�����B]ʧ~��\�\"�ڇ��y��$:v��/A�.��D\0r�D�\�GM\�_MN�\�Fn�\�`\�ןM:\�\�X&\nQ	y�i�\Z\�\�\�9\�F�yG&o\�\��\�\�t�W�J\�\�	�,\�1���U�ژ7��V�;y�HX{�Jm��<y}��\�\�Bmha\r\��-~\�J\�\�{G�\�G^>s\��W:H�;y.�\�OY��M��u\�Ş�\�=¤��|_x�l��>J�c9yπ�	��7�\'TDw,r��pڌ�\�c{�D\�>r�\��\�	�\��¤���L��G\��\���J�;���_\ZJ\�̳��;9y�\'��P-�A\�	�\��B\�h/�\�@\�t���u�	2Y֐u\�\�\�L�����\����\��\����\�六.�\�w9\�!4�\�\��\�y\�\�k���\�\��5\�\�\�r�� \�m�D��p���U���\�����\�7	��%Ż\�E�=��k�\�dSТ\��\�C>�Ww�\��X�\�>Eΐݿ\�\�\�W߆/�o�o��\';{�\�\��E>~C\��\"h@�D\�\�a\�\�\�}ʙ�Γ��/&s�x��\�>m߶+\�[�.a��ᵩ<#\�}�|�H�:Ȼ(Ewr\�Yh�&ɧ\�lyJ���Oʯ\��z�\Z�]%��\�\�B\�߉�\��	���\�r�d\\�\�c��\�)�\�^K\�\�gAג�[@�qBt!\�\�\�~�\�\�x�I�D�YF~\�\�K?w_O/\�u0Η\�>C>�\0Z��\�V�\�\�s�p\Z�\�<\���\�\�	|Mቄ�\�\"B/^�w�\�+\�\�\�O�\�\�\�!\�ǟn}�Z\�(S\�˃F�S\��c�eS��6��Ǉ��V�\�Gw��$����\�\�\�<��)f�?�$5�i�\�\�\�=o^+U\�\�=/�\�@>�^\�%/����Zt\�`p>k\�7M��\�\�\�\\$U̇��Dw\0�G^-�奍�POɗ�5�O�{v|�+�ʐ�%�_��\��\�\�\�w[u�^\�\�IM�\�\�.r�D�	FΓH��zmW\rx(�.E�	r�k㚒�y\�j��|�[jju�D��\�\�S��JM%\�}�|�\r~ʍ��!р�\�_��e`���/cc�\���\0_M\�5\�\�Y/�_�T�0f@\��+�\�rɟW��;�\�~@\�]#iO�\�\�&\�Wu�sh��R<y\�; EE>ߖ\�y��>§�\��\�\0O����\�-\�}�|�@V���\�I4@\���\����F=��h�\�s$�\'~A�C��#�c�\�\�#\����\�\���\r\�F�Ǝ\��\�\r%s��&\Z;rz���a�u\�Ѡ�ω�9_�\�%�\�\�E�<)3s�H4v\�\�u �\�=�T��|��e%c�\�\�\�X\��\�Ӭ;O./OJ4n\�s�\�$\Zr:P2\�:��q4f4\�o$뜔�%\Z3rz��\�\�β��\�o�\�OY\\\�W>/>\�=�\�u6n�h\�\�\�s��\�2��\r\09��d\��\�l\�<�B��dkg�Ƌ��#��\�*\��ɶӟ���l�h�(�\'S�!��\�\�t�Ƌ|�@\�ۤ�yYN/\�p\�\�7|�ZG�h�(\����dʗ�FcEN\�K#�\n�/�n0r:K2�&�D4V\�q�x\�L�+\�X�\�AҨ�\�5\�uYO�\�\�Y\�^�\�\r��u��^\�\�\�\�դy\rno\�\�P\�t�dɳ���WO\�tu�/%\Z\'r�\�\�c�\�\�-\�\rDN���fɐ\�V�eb\�8��/�,\�Ҫa\�\r��\�\'��-\'�Jt㐓�!͐W��2\�Qo\�4^2\�3s\���_{{z\�KF7y�U2\��\�W��k/卐��!���\'m$�r�\��!\�\�����d\�ksD\�C^]�\��.�\�\� �\���SW�`N\�JcYi��K4>\�u��5�k\�.\�\rA^7HW�4I\�h|��0YZJο�7J4>䵛t%\�\�5\�������+\�؀~�Z��\�{I46\�奮}US\���D7\0y=$�I\�}N��s����w\�|X��!/�\�\�\�|\��S�\�\�\�\�Rrk	\��c���\�׺�\�q\�ؐד2Y:\�K�#����I���U\�H\�\��)Ѹ�\�\�ґ��\'$�G�\��\��h\\�P���B�q!/�F/)mo�D� r����w�\�\�?F\�\�ΪRj{J4.\�\���\0�J\������o���\�R\�U~\�~\\�q!�G��{\\�TX�!�J��\�E4&�U�H��X�1!�/J[�%%�I� �m�\�X�\�Եk�;�W\�Ƅ\�\�d\�y�\�\�@nJ����&ј��\��5\�\�W���m���Q\�u���ܾ\'%���:\�hL�H�\Z\�e�Ď�hL\�\������$��\�o+)1�q�\���\�)�m%\Z�[[F��Ɏ~(r��G㤴V\�\��	-[+Ii��<��	���M�\'<*\�En>eXb\'H4�]�/%�#�ƃ\��\Z>�K���[��\���V�\�$\Z\�.3\��LJ\�C��y����\\��\��\"����T�[�\��R\�\�K4\�\�\�Z\�ߥF?�],���x\�\�h<@���j[WZ\�R����4we�~�+q�Wt\�~RZ�H4\��v��^�u���\���\�t\�-\�c��6�h,\�\�V�\��~r�&c��\�)\�X�N\�\\Jj��UY�<�c��$�\�\�l)�S$\Z\�i\'Ji�V�� ��ɐ�F��� %\�\�,��^�\�KHI$\�X�ߐ�<��\'\�zm!%\�\�*�Z[6\\\�b|eV�gda4������ъQ=\�|�\�t�Ϙ���5f��zy_�A�\��������\�\�k>�����DcA~\�*}\�X(�^�\�t�)�\�t۞RR\�H4\�7誀�\Z�[iOb�\��\�3��>)\�8�����\�\�F��\0u\�HJi�<)\�8�n{\\&H)m\"\�8P�-\����\�/#?/�\�3@�ěU4M��\�м���\�\�\�]$\�_F~^J����h@���C\�\����bY`�i\�\�X\�_F~�KI1�M\�	\�%��Ɓ��\���dv\�*0���áRJLVEyr\�RJS%\Z개̎�궻�\�V�\�ͤ��.|4\���f�%��\�P\�ח%\Z\�k%\��\�}Nf�c��\�ீJ\�\��\�Ӥ�V�h�\�4�\�\��%\�\�\�\�\�I)\�*\�8�^�YJi�x��h\�\�J�\�X�.A\�_B~�I)y\'+�_FS���\���=%c�\�5/�\�\��J\�m�h�\r��.�h�\�$\�{\�?@}~\"�\��1\0M�a)��$\Z\��\�{߀?@}���\�!�h�)RJGI4\�\�\�¶��+\�	\��\�\04\���xC]�Y;�~e��>~XJ\�%\Z\�%ͩ��Dc@��\��곣��\0�\�n�R��Dc@�/}\��\�\�RJOH4�)�R\�Z�1����?�\�g=)��\�~�i\�\�\n���AX�rkH	-+\�\��f)��$���\�U\�wÀ?@}\� %\�7*\�\��fu)�U%���\�߄\� +W\�F@\�Kt������J�,\�\�G<��\���L�b`�b#)!���\�=\����?@}��\�B�\�4\�fRBKIt�Q�YW�x;\�\��D�\�^	m#\�\��Ɨו���ۏ:\�\�\0T�7\0@{�\0%����\0\�\�W\0@{�\0J0\�+\0&֍I�@{1	%�5	�\�\0\�\�e�@{q J0\�2@�\�U\�B@�It�Q�Y�p\�JY\n\�_UD�h�WK	�-\�\�G�6��O��\��n?\�4㥄6�\����6b;ຽKJ�+V\�t�H)m\'\�P�Y\�7\�P����<i%\Z\��H)\�&\�P�c�\�\���\�-�t�Dc\0�\�<)�}%\Z\�p��\�5\�P�YA!� \������\�W%\Z\��1\�{\�?@}��R:D�1\0M1EJɧ��1�\��T\�D)�\�%\Z\��J)�&\�P�u�o\����/�\�%V�1\0MQ\�e�\�b�ƀ:,#}c\�\��\0��MJiAyA�q\0���, �t�D\�@~O\��՟%�K\�\�\�A��R�!\�8�^�QJi>\�\�t���\��H���:��!�;C�1\0�v���\0\�\�x�\�%�K�\�\�RJ_�h@� ���Dc@>\'�{�D	u���\��\�M��>)\�P��ev+J��P��H)y�\�L�\��ɒ&\0.\�8P�\�dv��G%��\�\�\�RR\�\�2\Z\�+�JI�+\�8�\�\�\�\���u�D�y�����D\�\0z\�RR\\X�p헩�e\�\�ˁ�R��W\�8�^�ܔRZZ�1�^R��Z����&\��\�\�e^)�-%\Z\�\�\��y�5&W\�\�RR��h@��6�\����5ޯ�a�I�!������	M�q))oY��y��A;L���]%%�j�2\�\�X�n�1���\�u��y�ߠ� P��D���\�\�%\Z\�-\�HI-!\�P�md\�<�Y��C\�Nip{J4�[JZE\��!�^\�\�B2\���6����\�\�/�%\�u4�Ӽ��bRR_�h,\�\�,2>Uի�ә\�d�\�tڏ��� \�X�߿ːM�\�%�\�\�\�A���\�J��\0����\��Y�h,\�\�s��\0԰\�]b�֗��\�7I4�Sn�y��\�I�^\�ɰ\�O����Hiyo\�h,@�\�+�\�e\��\�G�\�\�\�)-\�l}D��\0\�\�c��Kfݵ����ϗm�;�X�N��\�k�K\��h7Ϥ/-�\0DcA~�J�\�>&\�C~;Ji-/\�e�N�:)-�j@<�\�k7i�ĳ£�\�N�;^��\0\�r��\�\���=,�ˈ��D?�= 㤴VB��ӿ\�G�\�|\�-��1!��dĭ+\�E~[K���r��ؿJ4䷖��+$��\�\�8)1?��DcF\�I�,%v�DcBn�ʨci\�:=$�J�*ј��*q}���\�K4&\�6���\�\�\�@n\�I�y\�?$\ZЪ�ˈ\'R���$\Zr�_�<ؖ�\�AnӤ\�v�hL@�J�,��3$\Zr���-�z\�S\�\�?���!��nh^��\"�\�\��\��&J\�z��O}|\�\�\"\�־*\�?�\�\��=R�z�0!#\�\�7J���K���\�w�\\KZ��\�$\�a���ʗ�\��*Ѹ��_����t�D�(r���=l�\\#Ѹ���YJ\\��M$\Zr�kY\�j}J]\0��Յ\�\�\�S�kJ\�y9\�hl\�˗{N�����q\�\�I%^N�\�>+\�؀9}JJnQ\�\���t\��9�wJt�\�\'�\�<��,�\��;[J��\�\�$\Z�[�\�SW��D7y\�,c�\�/\���]:6��Ky\��`\�\�\�t-_c}�D7y�WJ\�µј�w�\�HJ\�{�G\�C^W�_��چ�D79M��\�h|�W\�\�]�\�.|�B4>\�\�+>z\�I\� 䵁d\�X�Ƈ�|G2��D\�C^?��\�W�\�!\'o-�!_\��k�ƈz�J\�J�~/\���_{�\Z\�\���\�\�!\'\�dȳf�$\�8����>\'z�DcD^��\\�MW\��s\�\�k\�6�Ɖ�f\�dɒ7-�Ɖ�.�\�\\�\�֞�\�\"\'Ϧ\�\�\�\�\���5\�\�(*K\�h�\�ɯ��I��*DэEN��<S~A�C4V\�q�4\�\�s��\�`4V\�t�4�	r�D79�{\�L�-~��Ɗ���-yc��wK4V\��7�W\Z��Gdm�z\\,�/�:g\���\��K\�$��\�\�tY�\�ecit\�Ht\�\�N��\�KG\�Eyn\��\�\�>�9%�o!\�T=�X\�/\��\�WK4f�×yf�\�\�\�br�DcF>����\��%\Zrj䤔6\�/!ј\�|\�?�d\�H�ƌ��E�\�g\r�x\��Hա�b \��\�\��fY\�o\�|\��L�ƍ|�\�~qy[M.��\�ɒ�=��.�\�;=���y\�\�\�$\Z;��\�\�%�ȶ�hPȩ�\�T-��xBY4v�\��i���\�%\Z;r\�N�\��\r�5Qe�--�n9\Z?z\�,�Y\�̽Z�h�\�\�W\��g�\�(\�\0�O���2���WOHt�{���\�{�d�\�\�\�q�x��m$\�I4P\�\�\�*��8Xk\n��Ο%\�\�>���D���s\�\�%U_�h�\�\�KBO�\Z�U�\�\�g\�}��{V�\�x��E��U\�\�c;]^�\�\�أ#�oKMy	\�\�\�ho{�i\'�\���\�\���:)�.\\�\�.\Z8r��\n��<7`\�J���\'\�]$\�\�C�a�\�\�㳈kH\�>/\�\��Ͻ\�˵5�L/�\�/>߇>%�fBT�$�Ht� ��$}��\�\�x\��|Ζ\�>����!��j��\��eP\��N^\��\�7\�\�_��*z�<&\��|2�\�6�V��\��\���?�>�\�\�\�K\�*\���|�\��\�\�@>~R�\�\���������$��j\�\'A�-ɺ�D+y�7_\n\�O\�gg��i\�!\�\�kZO\�\�[X�}\�\�\�W5�I�\�\'\�׷���?�j�*��\�A>�N��k���\�Fl,����	��\�\�U\�Z\�D�����\�q�\�8��ey%/&I\�çy\�-.^^�7�q\�L�\�\\�wYL\�/\�}�|�&x-!��Dwr��\�4x\�phO����\��\�r�|L�\Z<\r݇\�i/���i�\�%�����\��\�\�yU��\�0�LfJt�6�oۥ�\r�\�}��IC�~a\�_=~&4G\�F�IQ��\'�l\�\�\��=�fr��&���\�}\�I�7=�\�T9@6\�6j���J\�\�;\�2\�u���\Z��\�c��t7�.O$\�@�l�/3�w\�^l\�[���\���~�\�\�韽��U\Z]+\�\�\��\�\�s\�\��K�\�y\�\�r\�cg��suYG|\�O\�\�?��\�\��\n�Z��y\"�w͌~\'�\�nB\�\�8�\�@\�t��}1Ւ���@�\�\��=�a\�䯒\�DN�>\�\�e\�gV�?F�;����\��\�Kt�\"\'�\�͢�2\�_\��\�ɫ:�,4�\�)E�\�i�\�Q��\�\�O$:摓/\�\�Vh�r�\�\�E^\�\�P��\�Ͼ\'���\�(��\�\��\�\�\�\��u\0��O�{߃\�G^�\�ć�6\�k��\"\���~,L�R�-~!��m\�\�\r\�jc��ɬ\�\�\�\�\���׶�\�G\�1��&�u�m�I��9K���Jɋ�\\,ѱ���\�\�\�\���C�;��I&Q���>\�\�ͻ\�R:Z�\0��]�_Q[_\�\�\�En�|��\�8��Dr�5\��&�^aW�:y�,�\�\�r���V�\���xW:�&������\���\�\�=\�2z`��\�\n\��7�*\�Y\�\�e�zDV\�a\�\��Y� \�w�x�Z�n��x��\�D~>��P��� \���\�M��y}w\�<\�˯5�5�$z�P�����&u*�Jy��a�n��\�Ў�\�C=��\�$!jg+\�t��9\�\�X��\�]�ΐ\�C=������\� ,C�_\n{�4</{�D \�\�-X�&;\�HZX�G�cu�\\�)�g�\�,\���\\\'�Q+��W���)\�\�\�\�,-TP+ɝ=���\'m�l\0v\�P��\�\�Jt�>�\�\�@�&y@���K> DQ���~��\�\�ay�P�m,�э�N�\�\�y5�\�It��N�\�B	\�R��\�F������P�-*G\�L��\�\�k�l-�(�Ȇ���\�\�C\��#_\�\�\�ܗ�F\�\�\�׈J\�^\�*^�\\,oʛW��\��k%:P7�6|\\(q�H�\�\�\�\�\�.�+o\Zv�D�9`�	U\�g%:\0�~^R�-Be\�I�L�\�P� TQIt \0�|J�t\�P��|�ߓ�~/\�\�\nt�P�}E�������\�\�Ƌ�k$z�9}C�\�%сDnO&e��\�\�\���_\�=f@��u��\� �`�J\�Q��P��\��x�^\�!z�������!�Y\�\�(�P|Y�?��\�@\��}_\��D�0>�S\�\�$:`�\��\�?��ȼB\�ɫ5\�$g\�3\���px\�Ѡ��\\t\�\0�𛁓d{�\�4j�	\��Χ��\�>Z᥿��\�?%:���xP~$;\�RBq\�\�\�\�4�f,\�}	�\��h\�}N�	\r�5~�\"^_�\�\�\n�)s�w�,ϋN\�W�Znoa\�\0t�Oo�V�0\�;e!\�\�\���.	;t���f��B4\�|\�\�\�CF\�n\�ɟ\��z�\�m)-\�\����C���\no�\�-~\��\�Q�Q��p�1z\�6��x\"�/�\�JV�^N0�(�ʶ\�OZ��\�{(\�-\��n�\�m��my�؇$:\��^�i\�;\�B�U^�\��>-?�/\�\�e%YQ|=}?�_\�?�\�\�w�\�]śg��c\���u2/�h\"?Go$Dm\�O�,7\n\0\�s��Y�:�?=\�(\�\0\�\�Ĉ:\�$�J�\0\�=W\�2BԵ�3%: \0��k\�|\�,5�1r�D&\0�s�\'5/�E\ri�l\�\� \0��ד�\"D�\��D,\0`��z\�BԸ|\��}�\0��{@�2&Qc{�\\\'\�\0h���\�2?*�\��d\0���JJ\��*\�Wx\��\�\0\��s)Q�}P\�H\0�ϓ��Q�-�Kt�\0�\���x+�4M�K%:\�\0}}���Z\'J׼\�ﴢ\0j6M&\nQ\�v�\�%�%\0��x�\�G���\� �\�\0jp��I��\�\��(\�/\0dv�,,DU��<#\�/	\0d2S��W	)\�#0C�_\0\��\�q~�#�9ZHN�\�\0Jv�,*D4�v��$�%��<*�����\�\n2]�_(\0(�?[Y��\�\�\�yN�_.\0h�\�ŋ��\"\ZE\��\0P�\�d!�6\�	�\�\��\�@��$L�#\�P\�\�\0h�;e{!�\�\�\0\0M��~�\�\�\0\0�\�O�\�\"\�Q^K��\0�ɟ�\"j@�R\�o��@;\�$>�HD\rk�x݀�%�\���xV���c���y\�s$�E�V�\'o\"*(\�)p�D�\�\007�\��g\�^�B[D�$��\�~\�` O(�&K%h}�X�_x\0��d]!��y�����\���p��(ye�>\�ѓ�:<!�r\�\�	DTQ�ċ�\�0P\�\�\�|�\"�8\�w�DO\0r�@\�\"DD�\�B��\�I@ٮ_\Z\���D\�\'?I\\\'ѓ��x�pO�G���\�O~#ൿ�\'\0\�v�x!��BD\�r\�\�O\"\��3z�\�,����a\�~\"jK�\�~r�DO:\0z\�o\�������\��x�DOB\0�\�{\�#\\\�OD]\�s��\�\�=)\�,\�\���q�\�\'��\��F�k�GOR\0\�˗\�r95�w\�Y\�UƢ\'.\0#\�\�<)�Qc[Y�ʃ=�\�\�\�\�W\"�bZP|	\�_$zr�A|)\�\"BDTt�7a\�! \�\��\�\�\���>�\�r�\�\'ѓ P/\��\rYI��\�\���I\�g��\�Ȫ�Ӿg��w���ʖ/d�g��,�,�\�\�a~\"�9ZG��$zJ�Lo�\�w�DDC\��\�w�\�\�)��X���1\�cwGam~\"�\�\'P\��\�%z\�z\�/�g��\�]H�����f\0M>Q�BC>\�z��{\�\�	\Zh7k>\�>(>�����O �k\�P\�~h��œS=��\����\Z\�\�\�Ӳ^g\�a��ԁ�<!�Nߗ�r\�Q���?�y�5�`9b\�\�\�\�e�es\�S>Q\�\��!�\���\�e���)~3\�\��^�oQ!\"�\�\Z\'�?\�\�\�<�����)�\�\�m��\�o����\�7\�\��h�\�%zaA����T�\��1�c\�ǔ���\����xb�O�\�$\���7��V�.�\'\�y\�\�	BDDԱ��`u��\�ɉr��Ơ�|�^!?\�\��}\�7d������1yR�?����w�\���\�sw�xb\�1\�9^�\��\�\�#DDD\�\�\�\�&�����[��\�����i\�\�űt�g\�{�e���R�<��\�DDD\�\�O�~���l+\�q/�O�Zߗ�\�o\�_9\�\"I��\�	���o�\��m�m�����6���6o#�\�\�\'x\"\"�\�͒�����ק\�mU�Y\�P��{ �Y��\�\��\��g��<��%\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"��\�\���q\�\�c3;\0\0\0\0IEND�B`�','Zairus','Villasis','Bermillo','notZairus@gmail.com','bkldksadms,','^,2',1,1,0),(2,'test1','test1',_binary '�PNG\r\n\Z\n\0\0\0\rIHDR\0\0\0\0\0\0\0\0\0�x\��\0\0\0sRGB\0�\�\�\0\0\0gAMA\0\0���a\0\0\0	pHYs\0\01\0\01���\0\0\0tEXtSoftware\0www.inkscape.org�\�<\Z\0\0)�IDATx^\�\�yܧs���{0c0���%d\�ѩ���o�hA��I��N\�)��S���D��\�CJ��9Id�\�\"�2c\�0\���\�{d\�3���{�.\���^�\�\��\�=�|\�\����\�w�>�O��U�\�X	c;\�C1�\�i�!~�\��;܈�\�^<5���s��\��{� .#.+.3.;�\��M���\�\�]\�!�\�033�~Zo�n�N\�y�\Z�\�~����\�#n\���\�\�\��bf���\��X�\��p�7~�\�0\r\�g�\�6��M��\�0�a>���U��\�;��>�3p-�\"{\�\���#>�\0\�\"�fx=\�E���Yǋ\�\�\�h��x�ٓ�Z/\�W�\�\"^lm��affֲ\�\�\�8g\">�~\���\'�\�-�6\���+33t�a\'�����\'U\�d\\��#���٬\�I!���3\�\��l��\��\"⫃8?#\�\'X\Zff֐B���܌��=Y�|3�G��x8ffVP19MLX\�<�\�\�@�!��ᓈs\�̬f\�;�xGg\�ߏ\��^\Z\�}��b\�aff,�\�=���j�)�`)��Y��dc,�\��\�=uJ�L\'�\�+\�\�\�:\���(~�8�+{��:%^\\�X\� \�u03�g\�ǰ-\�\�\�^�d VGt\�3�a\�\�\��\�9���\Z:�h�I�\\��\�l��X�ų�U��#RbJi33\�U|\\z~�\�T*E|Ek���Yc[1\�S\�,�R\�\Z1\�@LRefֈ\� N\�Y��F�inD�8\'���\�J�U\�C� (5ݣ8\�-`fE�	\�N\�\��g:.��afV�\�\�^�\�����	�މ8�\�\�*[|�S�މ\��L\���\r1��K�Y��a|�\�� �/I��b��%`fֵbU�\�a�+I\�Cg\���03\�X��n<�<�\��IRg\�2\�1��K�Y[�\�w\�\�w�R�\���n8V\�43kY1m\��\�/U\�+�,3�ag�\�eq\�Q�`#���@�hwԀ�\r�X�7\�y\0ك��z�U5�K�ـ�ǭ\�L$\�S\�ͱ#\�\���.A�\�!�c\r������1\����<�8Q0&�2�6\Z1{_�K�=HH*[�(��`֠��Dd\n��\�x̬\�⻿Xf4{�\�lq~�\�0�����?\r\�\�4/\�\�(\�P`3�y\�Fd�$e��\�`f5l!ę�/\";�%i^^@�/�̬&\�	=FvPK\�P܍� \�\�*\�8/!;�%i8\�1\�\\\�R\�fV�vŃ\�^Ij�Xl�Y���b�Nv�JR;\\�af]j\�l^\�*I\��8v��u�8\�?\�\�\�JI\�87`̬ͽ�\�/�J\�¦0�64\n�p\�td�$uS\�p,\\\\Ȭ���k�t�T%W\�50���Dv�IRM\�{af\�h1\�\�5\��%Iup<A\�l�\r\�\�T�8Ap=�\�\0\���,;�$���A|�ifIq\�l�\�\�<��J�m�\�(�^-�_!;h$�$Wcy�5�Mp/�E�J�\06�Yc�U��!;@$�d\�\�`�5��-d�$5Iw��M̊o%܀\�@��&�+��\�\�\��\�\0Ij��̊k<\�/I���v�Y1}\03�\�\�%I��U�Y��%|cy\�\�N.I\�ߩ�\�P�\�g���\�-I\Z\���ڴ\\�_�F\�Z\�l�f�ﵸ\�Y�4t\�Z0�l1�\�c\�\����\�{�¬rm�\�\�����\�o�Ye\�\�!�\�J�Z\�Yl���/b\�jvG�$�^,$�̺\�\���;�$�}br��a\��Bv��$uƋ8fk�;�$��\�S\�#a\���\�W��\�30k[�CvǓ$u\�\�0ky\'\"�\�I��\�8��,\��KR}|\nf#.�W\�\�`��\��w�\r�O �cI��-F�!\�J�;�$�b�\0\'�!��\�O�\�/f��Z\�lw8��$�c:v�Y�m\rW����\�*�o�Y�6\�dwIR�M\�&0�\�\�x\�F�T�Ǳ&\�z�\�]\�\�(���܁%a\rn�Dv�$�\�\�X\��F\�\\dwIR�~�x.��\�\�>��X\�\�\Zԁ\�\���f�I\�\�k@[!&�\�\���\�\�\�\�\nn=<�\� Ij�\�\�\0V`+\�~d;^��{���\�\�d;\\��W\\�\"n�t&�-I\�\�N�С\�v�$I��\�bV\�b��\�\�\\I��+þVÖF�Б\�XI�\'�/�Q�\�2d;T�����b5\�\�v�$ICu��1�c�%I\Z�xN\�V\�\�F\�\�\�@I��\���`�\�.d;N����\�`˵�%I\��mX�\�َ�$�\���U�\�\�Id;I��V{\n���\�|�\n\��$�]���t�c�\�I�\�\�(X\�ӑ\�I�\�m6�u�E\��?IR�݁�a\���%IU�MX\�\��$�[v�������/IR�<�`m\�\"d^��n�ֆލl�K�T�����-IRU\�\�\�\�\�Z\�w�mhI��\�Xz;^B��%I��=a#(&W���+IRU=�%a\�\�K\�6�$IU\�A\�,\�W~\�F�$�\�f\�-�!�\0nB�A%I��[1\Z6\�>�lCJ\Z�x\�Gނ_ \�P��5g�\�9��Y�[�N�n��\�$\r\�ѰA��C�%\�\�\\��76\�X���1��I�S��MI��,V�\r\�ϐm@I}\�;�pބ���]\�e�\�\�px�4x?�ͣ��m8Is�\�\'��\�*V\�\�vd\�QҜ��%��]\�6����\�\�\�ǣjm�8���\��M�\'&}\n\���.�?�91\�\�\�J�\n\�:g�Ej��\�z\��\�\�K\�ƒ�*\��ˡn\�b(�q�\�&5\�d�XP�\�F������bDL\�[?Av��:F1L\�1\�\�\�\�\��(�q�\�,5M\�r�\Z\�\�6�\�$1�.>2_�6_�\���\'\�jt� \�0R�<�۔�\�Cȶ�\�$%~\�7�bR�;�m�).òhZqT\�X�m�)b>��ѸE�A���q�휹�\�\�\�\�ȶ�\�\�G��y\�@�1�\�=��\�^n8\\PM\'�.�\��IdB*\�\�\�6g[c�m&�\�hD�\�	dA*Y���zX^	�\"�m\'�\�\�(�\���\r �,\�\�_6\�\�\�?�mC�dǠ\��3\�n�T�8ߥ�Y�:U�p���&�\\\�\��j�\�\�;���>�D�M�R�\"[\Z��W�Ċxo�\r�7�E\�\�$q\"l����\�K%��-v�����g\�X*\�gQTK�w�j\��n]�mc�D\�}\n\���j�\��Z\�9ȶ�T�Ϡ�b\��ݘ\�H�4� f��\�67!\�\�Ri�¢�}�Bv�\�\�]�����0ٶ�J�\�u1��\�y\���\�[��m{�41\�ԶÐ\�0�4߃u��\��4@-��>��\�FI%�W\�K�:S\�)\�\'�j�;0j\�^\�n�T�=a�-�S\���T�\�Q�~�\�\�H%�֝�B�O��\\�Z�)�\"�d:ցu�Xca�}#�d3Ԧ\�#�RIbzk\�n_B�o��\�DX�h%\�;�\�FH��;\���[L�� �}$�\"�SWD\�;\�\r�J\��\��}$�\�8T���\�1dW^*\�D\�rhN�Ő\�?#\�WR)E<\�V�}�]q�$\�U��\�+�$�~\�ٕ�J�7,\0�V�q�}&�\�רd\"�\�RI❦U3�W��\�u\Z�++�\�~\�zq�O\�C�\�R��JCq�Ave�R�vG \�wR)b\��EP�AvE�RLA�еj�2MC��RT\�\�\�]I�߁գX�9ۇR)*s2\�\�x	ٕ�J�X=\�\n\�>�JϹk�\�}\��JqF�\�Q쫿\"ۗR)b\�ݮ\�Bv\�R�W�F�/�R\�\Z1f\�\�\��J�j��\�\�\n�}�\�S�ۣk��\�JI��VϮ@�O�R���C�n�\��gG\"ۧR)��+˒�\��J�\"��ճ5�\�W�$]Y \�RdWF*\�o`�\�e�U��\�і�\'بtq&�ջ� ۷R)f`it,\�\�Vl�w\�\�[�$]�\�ZdWB*\�S\�\�[kI�B\�$d�X*ŕ\�H1�v&�+!�\�g�2���\�>�J\',\�W�m\�CȮ�T����\�1\���T��\��⣆\�K%\�VFoG�����m-\�4�\�5�\��\�i\�G�\�~�J1K�m}\0\��Jr��\�@����쇶�SdT*\�����}-�\�\�hKb\n�?*�\�hXYM@����\�st<W��8)*��Riv��\�\�\���T����\�}\��J�ZXY��l_K��\�[^���1�$q&\���\ZG�	\�FK\�\��Js�\�\�1\�\�Ri\�Aˊ���?\"�\�2X�]�l�K�9-\�rdD*\�ٰ2�>�}.�&ֿhIc1\r\��Js\"�̾�l�K����\�\��J�QX�}\�>�J�F\��]�T���\�\�\0d�\\*QK>\����J\�X��\�>�JtF\�R��\�¥m+3�V�\�s��V���f#X�m�l�K�\�\�\�\�\�.T*պ�2\�\0\�>�Ju\n�\��]�T�5ae��e�\\*\��bX-\�\�VӬ\n+�X\�)\�\�R�^��r;!�@�d��\�l5d�\\*\�vr\'!�0�d����_���ǐ�\nمI%�Ŭ\�ހl�K%�g�a2��J��\�ތl�K%��xNt\"� �tNTnN��Z�\�d\"�n<�\�vD�ϥ\��A�md\"�n/X��\�>�Jwݭ\�.D*݇ae�1d�\\*],\�7�\�\"&\�.D*\�\�`e�yd�\\*\�\�s��m�\��&��\�\�F�ϥ&\�v��,5�\�`e�Kd�\\j��0`�!�\�R\�\0+���\�s�	����\�?KM�$��F�\�\�\�d\�a�͏i\���\�\��\�jed�Zj�)�猀�J��&�7XYm�l_KM�:�md�Ij��	\�\�\�C\���\�$��ߎA���&�oXY��l_KMr4�\�<d�Ij�Kaeu5�}-5\�w\�o7#�OR�<�!-�i�.Nn���}-5I�Ü\�\�\0\�\�օ�\�F\���\�4�B8�\��)\�\���\�DCZ>\�*ݡ\���\�D�A��E�\�R�&@9}\�>��h+�\�pd�,5\�m�2�\�>��\�`�)�>e�,5\�K�\�\�\�\�ǝ\����*�\�\�\�E\�~Yj*\��~�/\�\�\�\�\�\�\�~Yj��@�Z�d�Vj�\�?G1,\�Yd�,5\�$��ճ1xپ��*��9Z\�/JM�6X=\�\Z\�>��nI\�nd�$5]\�!o�\�4d�Tj�\r1�ݑ��\�t�aX���nG�O��\����_�\�ӳ�^\�l_J\�\�� fw\n�_�\�\��=X���})��\�$\�\��\�~I\�\�h,�G\�0پ�4כ\Z\�ʖ\�\�X=��}(\�eW`vΕ-\�[L��.�i�+\�q\�����ͱ\�ɓ\�~Iҫ\��v\�\�;I�z��\�2��I�K�^u!�\��پ�����5�y��@Ҽ��\�`\�l\r\�>\����9-g��\�X5;\�>�\�׬\�\0�\��I�6�êU��\�>�\�\�6\�٧\�$\r,\�iZ�:پ��\�=������\��\�kê�\����;=G������!�\Z�\�>�ԿO�\��~ i���m�1KCw\\3[\Z��0\�Ѱ\�4?nA�o$\�\�\�\�Y\�|֝>�l�H\Z\�y\��Y�H\Z�IX\�\�V\�S\�����]�Y�e�(ip\�E�u��#\��\�2�\\\�\���\� Xg�m�\�I���\�\�\���g*ք��U1\�>�4x7�\�^?�4|�\�|��g�_�l\�K\Z�;\���^?�42\'\�\�\�\�ȶ����=�������Ii����ئN�#�\�#p(�\�bS�>�5ź~\�/�\����\�\�/X6���\�)I��4z�\��I��^\�Zd\�V\�\�\�\'�=\�����ֺV���d\�T\�\�MCό^?�\�z�t�\�\�(|ٶ�\�\Z�\�\�3�\�$�Ǚ�w�6\�bŶʶ��։\�~�\�Hi�u@�œ�9ȶ��֚�\��^?�\�^W\��/�.D�\�$�ެ�\0�\��I\��[,{�e\�(g\�JR{\�:	\�a�R\�=�\�\��6\�=ȶ����5�^?�\�9�\�\�hj�Ȥ\�5�SK\�u*Ƣ)\�m�2<Y\�YS��\�}�4\�\�(�Mp;�m �sf-\�r�R5Ĉ�XNxJk4���I\�p\\hC���4`g�\�v��\�J\�x�鹹\�$U\�\�umM\\�\�I\�\�s]�H���Ա[�\�&I\��\�z�����j\�\nu\��\�n��\�=?\��I\�C\�D;\Z\�m�\�}�6I\�z�@R�\�:S��m�\�6I\��\��\�^?�T-�^�״�\�?�M��齃5\�8�GI\�w,\�\�?�\�.I\�u<��N����\0x�K�\�.I\��	�\�\���e5\�9?a��\�@�\�\�\���#V\�\Z�:\�\�TM\�g\�Ju\r\�\�\�\�6Iݵ5z6\��I\�0\r%�8� ����g��\�\���/��\���>\�Dv[%u\��\�Y\0�R5\�r������3R5ě��1�Ǒ���\�y;�\�v\�Td�]R\�<�\�ݎ\�$uF�ͽ.J\�\r�\�6�\��bvW!�%I\�w6ESZ�(uO�<;F��\�.hj1G�\�ȶ���9�;\�/Ij�\��,��K�O�:\'f\�݇����ֺk�\�,\��\0\�6�\�Z�av�!�%I�1;�\�\�6�#�m(�5\�mg\�f�$id\�DL�3\�\�\��m�\�C�M%�̬Y\0_iid�$ixbX\���=ن\r�шmx�m,ix���,�_�4x1�ƻ\�;�\���\�\'�iJ�\�%\r\�d�\�6d�,i`7\�]���}Ŷ���� \��v3��d�,�\�bW\�}\����b2�l�H\�_��\�\������\�<��\��Z���$iN\'�O�#�eI/�\�j\�\�f3X����cv��\�;I/��9�\�f�_��.�\�=kê]L��mLG�/��\�\n}Z\�/KMS�ƻ\�5a�j��i\���\�T�A�\�[��g\�{�\�`�n%|S�\�k�I��\��c(S���&��0ba��`e�,N��\�n@���\�?I%�\��cE�x�he/\�E^|��\�����~�4��$�(\�\�1��\�׼V�\��i�B�\�\�?I%�1\���X�֚ݦ�\��D*\�\�践��\'��\�\���w��S�t1گ\�b\�2O�Q�FL�\�\\�\�_���!<�\�>$\�Y�\0��\�zd�Y�����Xf�)�G?���\��\��Md�Y���H�\�0NoA,\�ݷ���*\�d�Y��\���u\�\�F҂�,�ZXuw \�\���T��\r0ke\�#\�Q\�\�sR\�qq,bb�\����U\�\�\�h����4\��\�\0\�M|��\�A\�p\�\��u\�\�:Q������TE�\�ՠ����\�WXf�,�v!\�\�it1^:��*\�c\�	\�we+�6��P\��A\'�d\"U�3�i�ͪ\�N��\�*U�:t1[P���]�\�M\�\�aV�6\��\�\�R7=�!πz���%f�t�~�j����\�w�n�C\�d&uC܉�Y�[W!�K\�p,�܎\�.L\��S�աo�\�\�,u\�x�\���d(u\�\�p?�[1!\��ݧ�N�I���ɩ\�g��~\��\��\�-u\�\�0쾄\�B�v��P}���\�}\\j��1\�vCv�R;�c`VB\�\Zd�u��b��aC��\�J�\�Pę\�f%\�T݆\�>/�ËX#\�&d.�\�\�Xf%�\ZEvߗZ\��q� �p���\�_aVr�j\��Ȏ��>�c��Zi_�5![S\'l��Ļ�\�H���5�s�R+LELHՒb\��\�H#5ìI�\�]Ȏ	i�.F\�:\n\��F\�9l�&�)�#;6��8-k}dD\Z�#a\�\�& ;6��xZ\�=\���47 �J5krq�\�1\"\rǟ\��\�IC�L�f\�\��FĤ-ٱ\"\rUL\�\��G�Ǥ�:	f�j�\";V��\�\Z-/�LA����17���ZL� �cF\Z�I��\�R�Ж�Qi�����\�@dǌ4X\�m�\�J��\�3\�[�x\'�cG\Z��Ψ���\�\�f\�{\";v��\�\Z#^�o��P\�q\�lލB�͎!i^.A\�;\��\�e[�\��\�\��\�%\�!i{\�\�1�\Z��\�?\�٘\��űkddǒ���U�AG�5�+!e\\\�\�lh�\�X�2�\�|\��0�+!\�\��m\\�Y�\�\\�!;������,\�#�\�H�}\nf6�GvLI�\�ȼ%\�\�~�\�\�H��sEV��\r��Ldǖ�\���Cve�W�f6�b�lvlI�\�oLEv����\��sz`\�\�3X]\�Ȯ�4]�c�\�b��\��\�A\�r\�\n�\�L�\�\���cL\�\�k�x\�?�]15ۮ0���Ndǘ�-�V\��\�j�Gv\�\�\\�(\�8�\�ȋ�f ;\�\�\\ǡ\�/!��j�Kaf�\�\Zdǚ�)�s\�@%�ٕT3}fֺ& ;\�\�LW�2�\�J��ւ���\r�kj��Q�\��\���]Q5\�=0�\�+>�\�S�<�\�\r���+�f9f\��.@v̩Y��ʵ<P����O\";\�\�,�G%�-�+�\�\�f\���\r\�1�\�\�\�s�^dWZ\��\��\�Z_|\�\�2\�Ͷ*ۂx\�W�~3k_Bv\�|���o��Gv\�U���\�\�׷�{*߱�|\�!��\�n�\���Y���cOe�\�\�P�\�Ev#T�\�`f\�+\�ʎ=�\�,ԦM�\��m5�Y�Zٱ��m�Z\��f���byh3k_�\�ʀ\�r%j\�\�n�\�t̬��\�1�2\�\�>�k>܅\��<\�\�\�\�%ȎA�\�v\�:�\�U�\�!�f�\�tdǠʳj[|_�wd7Le�̬�9\�J3\�sg<�\�:�h�\�af\�/\�ʎA�\�ԾE\�g7P刓>ͬ��\�1�r<�q(�\�\�H�\�0���5�cP\�8Ŵ8�FvCU��`f\�o}dǠ\�ϕK��<q�lK�\�\�_\�	��*\���\����k,̬�-�\�T��\���NDv�U1񓙵������B�-�\�\�n�\�+\�&7�\�3ý�\�XT}\�h�8_�\�b\�ƫ���\�:W,�����	(�\���\r�zzfֹ�$�,aa4�#�m\�\�?`f�\�1dǢ\�\�ChLq\��\�6�\�\'^\0l*�c��wc\ZՁ\�6�$IM�/\Z\���\��$�t7��C�ߎl�H�T���\�]�l\�H�T���\�!\�@�$�f\ZV�\�\�\�6�$I��%�\�-��!\�P�$�\�A,\�\�%I�{l�b(\�\r\�6�$Iuw=b1\'Kz\\\�J�T�xn\�6�bhD��$I��s`�*�E�%I��X2}e\� :\Z\�F�$�n��\r�p#�\r)IR]����\r��0\��$�\�^�ưat\n��*IR\�9\�\�ZE�a%I���06���sH�\�b&����3�mdI��\���8b�lCK�T��\���.d[���x�\r]�l�K�\�m\�\�\�Ԋxن�$�[�r�6�;��/IR7\�H�]`\�td;A��N�*�C-�;�\�I�:e\"b\�:\�`�`:�\"IR�=�X�ƺ\�d;E��v�8�K͇+�\�I�\�\�W\�b+\�	d;H��V�\�\�1,\�*\�;�\�$I�Z-��[�:َ�$�UN�U�q�\�\��$i�nAC�\n�&!\�q�$\r\�SXV\�vCL˘\�@I��j&v�ՠ��\�DI��곰���َ�$i�b����\Z�\�F�C%I\ZȽX\ZV\�b�\�g�\�XI���b\��q�\"۹�$�\�\0X��lK�47\��/�q=�-I\�+�\�hXA-��!\�\�$݃\�a�.b6�l\�K��\�I�\r+�-�<�;�$�y�ckXz�.X�\���\Z\�q\�\���\�8ְF\�dwIR�΂5�\�q�;�$�\\Wc��-�[�\�A$I噈%`ֳ\ZAvG�$�\�!�\n�\�m�I\�\�0����y`b�8�>�+� �\�H�\�k*��Y�\�d�dv�$\�\�4l�\�\�(I�7;\�lн/ �CI��\�E\��!�?f\"�cI��+��=f\�\�\�\�\�\\��j�\'�\�l\��\�N&I���aֲ�GvG�$U\�ga\��& �\�I��\�d����h)�_\�\�|��΋\�\�O��\�GHR�œ�0\�X\��HR�\�8�`\��v�3JR\�M\�^0\�Z;!\�\��֋7^���\�m�g�\�Q%I�����Ye\�O\"�\�J�F\�i�f�k<�\�+I\Z���\�*\�j��\�,I\Z�۱*\�*\��\n\�Y�4xW`q�զp�;�$i`gc4\�j\�\�\�\���4x�y,\�j\�>x\�]����\�g_�\�[�8�;�$��\�)ļ*fŵ��\�/IMvցY�-�\�\0�\�D\�bY�_�8ف IM��\���Qŉ.\�\";($�dqb�`\�\�6\�\�\�I*\��x#\�\Z\�R�ف\"I%������Q���\�\ZI���\�\'\�}�f��b\�\�\�\0��:��=`f�܊\�@��:�k�\�\�\"8\�%Iup:��\r��\�\�	d�$UQL{�;\�l�\�\�q\�lv�IR�\\��af-*F	\�\�\�\�#;\�$��\�)F2y��Y�Z� (�J\�@Ljffmn,NE��\�FI\�x���=\�Ϭ\�m�����\�N�aW�Y�Z!;@%�.@��lf\�]�W\�\��*I��8\�	3�X\�\�\\d�$\rW|\��-�p��U�x��0�Y��\�Nl3�I�#F\n��젖�y��X�/F�Y\r\�@v�KR\�&\�c��ռ\�8\Z\�\";\�%)L�p6?���=IP\�\�\�$�ڷ\n̬\�\�m\�$5K|E��YCZ\0��\�$d\n�\��\n?\�7kh1�\�\�p��\�\�p<��Y\�:�\�\0�Ie��\�̬O\�\�O\�<$\�S\�{\�\�\�\��8\0�!{0�Twc?�=��\r��? Nr\�a�^ba�	Xff\�.N����=\�H���p,��Yˊ�x!2ك��\�x1o�03k[���a2|\�7��+~O\"{p�\�O\�?�\�̺\�8Ĭ�G�`%�5F|\�\���U�5�?&\"{�4<E�\���~3�t1\�xw\\�\��L\�\�\\�]1\nff�jc���<{��4�\�i�\�3�ڷ�ã\����{��~,\�efV\\c�.\\���=JMr#b\�ͅ`fֈ\�F�a�!M\��T�I��\�6��Yc���c�\��OT��o_�)\�}3���\�,�� {�\�\�A\�\']k\�\�\�(�n��0\��TU17��\�.\�kf6\�\�\"\�B\�Ш\"�=\�J\��\"\�\�\���?f\�43��4Õ�\�\�X\�O��`I��YZ\n�n\�b�ɀ:%^x^���\�1�ff].�C\�����5{\���+�ݍ���E��iffl~l�8��d\�\�@\�F�Տ�Ob+33�Y\�\�H\\G�?S�s�\��\�\�\n*\�\�m���x\"asž�=N���]��Y��\�Z\���\�\�ܞLX�xy�OE�G\'����\�*^l�\�qb\��\�\�D\��4.E���y1崙�٠�Y\�\�\�\'��	3�=\�{b�܌\�\�J��Q033kY��z\��qr�	�Ȳ\'&�^l\��(?�ڍ��1\�\�\�u\�̬k����9��\�ӂxa\��\��<&\"\�\�\�\���}��rn}33�|�1t�p�v��� &+���}q��;7\�\��<b\�(�\����\�̬\�b��\r�>�m_�\��f\"{򬲸\�q\�\�6\�m�\��\�p\���7���Y?\�̆+ ^(l��\�?�\��uĲ\�\"�2�����\�\��S�L\�\�O\��޿�\'�o\\F\\\�o�#�V�\��\�q�\�\�1\�\��cz�J\�\���\�\��ٗ�N\0\0\0\0IEND�B`�','Test','No','1','t1',NULL,'^,1',0,0,0);
/*!40000 ALTER TABLE `user_tbl` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-13 21:37:37
CREATE DATABASE  IF NOT EXISTS `tm_teams_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `tm_teams_db`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: tm_teams_db
-- ------------------------------------------------------
-- Server version	8.0.35

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
-- Table structure for table `zaitestgroup1_chat`
--

DROP TABLE IF EXISTS `zaitestgroup1_chat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zaitestgroup1_chat` (
  `MID` int NOT NULL AUTO_INCREMENT,
  `Message` varchar(1000) NOT NULL,
  `Sender` int NOT NULL,
  `MessageDate` datetime NOT NULL,
  PRIMARY KEY (`MID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zaitestgroup1_chat`
--

LOCK TABLES `zaitestgroup1_chat` WRITE;
/*!40000 ALTER TABLE `zaitestgroup1_chat` DISABLE KEYS */;
INSERT INTO `zaitestgroup1_chat` VALUES (1,'Zai completed a Task!',1,'2024-05-13 21:02:21'),(2,'Wow galing',2,'2024-05-13 21:03:22'),(3,'sana all',2,'2024-05-13 21:03:30'),(4,'my idol!',2,'2024-05-13 21:03:34'),(5,'Zai created a new Task!',1,'2024-05-13 21:10:31'),(6,'Zai completed a Task!',1,'2024-05-13 21:14:37'),(7,'Zai created a new Task!',1,'2024-05-13 21:14:51'),(8,'Zai completed a Task!',1,'2024-05-13 21:15:55'),(9,'Zai created a new Task!',1,'2024-05-13 21:16:17');
/*!40000 ALTER TABLE `zaitestgroup1_chat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zaitestgroup1_task`
--

DROP TABLE IF EXISTS `zaitestgroup1_task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zaitestgroup1_task` (
  `TTID` int NOT NULL AUTO_INCREMENT,
  `TaskName` varchar(150) NOT NULL,
  `TaskInfo` varchar(600) DEFAULT NULL,
  `Assigned` varchar(100) NOT NULL,
  `TaskStatus` varchar(50) NOT NULL,
  `TaskDeadline` date DEFAULT NULL,
  PRIMARY KEY (`TTID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zaitestgroup1_task`
--

LOCK TABLES `zaitestgroup1_task` WRITE;
/*!40000 ALTER TABLE `zaitestgroup1_task` DISABLE KEYS */;
INSERT INTO `zaitestgroup1_task` VALUES (1,'asdad','sadsadsa','2,1','Completed','2024-05-30'),(2,'sadsa','sadsad','2,1','Completed','2024-06-19'),(3,'new task','sd','2,1','Completed','2024-07-17'),(4,'tast4','sd','2,1','Pending','2024-06-20');
/*!40000 ALTER TABLE `zaitestgroup1_task` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-13 21:37:37
