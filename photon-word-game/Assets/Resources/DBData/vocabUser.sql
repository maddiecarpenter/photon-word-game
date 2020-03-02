/*
 Navicat Premium Data Transfer

 Source Server         : a
 Source Server Type    : MySQL
 Source Server Version : 50720
 Source Host           : localhost:3306
 Source Schema         : vocab

 Target Server Type    : MySQL
 Target Server Version : 50720
 File Encoding         : 65001

 Date: 10/02/2020 21:52:40
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for vocabUser
-- ----------------------------
DROP TABLE IF EXISTS `vocabUser`;
CREATE TABLE `vocabUser` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` text NOT NULL,
  `score` int(255) DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=5307 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of vocabUser
-- ----------------------------
BEGIN;
INSERT INTO `vocabUser` VALUES (1, 'name1', 1);
INSERT INTO `vocabUser` VALUES (2, 'name2', 2);
INSERT INTO `vocabUser` VALUES (5306, 'a', 5);
COMMIT;

SET FOREIGN_KEY_CHECKS = 1;
