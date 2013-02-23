/*
Navicat MySQL Data Transfer

Source Server         : localRoot
Source Server Version : 50146
Source Host           : localhost:3306
Source Database       : queueclient

Target Server Type    : MYSQL
Target Server Version : 50146
File Encoding         : 65001

Date: 2013-02-22 18:22:50
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `t_bussiness`
-- ----------------------------
DROP TABLE IF EXISTS `t_bussiness`;
CREATE TABLE `t_bussiness` (
  `Id` char(36) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `EnglishName` varchar(50) DEFAULT NULL,
  `TypeName` varchar(50) DEFAULT NULL,
  `WaitTime1` int(11) DEFAULT NULL,
  `PriorTime1` int(11) DEFAULT NULL,
  `WaitTime2` int(11) DEFAULT NULL,
  `PriorTime2` int(11) DEFAULT NULL,
  `WaitTime3` int(11) DEFAULT NULL,
  `PriorTime3` int(11) DEFAULT NULL,
  `TicketMethod` int(11) DEFAULT NULL,
  `MondayFlag` bit(1) DEFAULT NULL,
  `MondayTime` varchar(50) DEFAULT NULL,
  `TuesdayFlag` bit(1) DEFAULT NULL,
  `TuesdayTime` varchar(50) DEFAULT NULL,
  `WednesdayFlag` bit(1) DEFAULT NULL,
  `WednesdayTime` varchar(50) DEFAULT NULL,
  `ThurdayFlag` bit(1) DEFAULT NULL,
  `ThurdayTime` varchar(50) DEFAULT NULL,
  `FridayFlag` bit(1) DEFAULT NULL,
  `FridayTime` varchar(50) DEFAULT NULL,
  `SaturdayFlag` bit(1) DEFAULT NULL,
  `SaturdayTime` varchar(50) DEFAULT NULL,
  `SundayFlag` bit(1) DEFAULT NULL,
  `SundayTime` varchar(50) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `OrgBH` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_bussiness
-- ----------------------------
INSERT INTO `t_bussiness` VALUES ('31d0a213-015c-4d78-8f29-2c72a0df1e8d', '公司现金', '', 'M5', '1', '1', '2', '2', '3', '3', '1', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '', '000001');
INSERT INTO `t_bussiness` VALUES ('47e6ffe3-011a-4a9f-bf54-f2cb49b38e6e', '工积金业务', '', 'M2', '1', '1', '2', '2', '3', '4', '1', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '', '000001');
INSERT INTO `t_bussiness` VALUES ('b3753eed-de30-4857-9b92-9ac750acb5f8', '理财业务', 'Lc', 'M3', '1', '1', '2', '2', '3', '3', '1', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '', '000001');
INSERT INTO `t_bussiness` VALUES ('b7c7318a-d86c-4165-a47a-0d0909e70932', '个人外汇', 'wh', 'M4', '1', '1', '2', '2', '3', '4', '1', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '\0', '', '', '000001');
INSERT INTO `t_bussiness` VALUES ('f7929360-b26e-44f9-821b-a78b9c5aa6ca', '个人存取款和汇款', '123', 'M1', '1', '1', '2', '2', '3', '3', '2', '', '01000200;04000500;;', '', '06000100;00000100;;', '', '06000700;08000830;;', '', '08300900;09000930;;', '', '09301000;10301100;;', '', '11301200;12301300;;', '\0', '13001330;14001500;;', '描述', '000001');

-- ----------------------------
-- Table structure for `t_queueinfo`
-- ----------------------------
DROP TABLE IF EXISTS `t_queueinfo`;
CREATE TABLE `t_queueinfo` (
  `Id` char(36) NOT NULL DEFAULT '',
  `BankNo` varchar(20) DEFAULT NULL,
  `BillNo` varchar(50) DEFAULT NULL,
  `BussinessId` char(36) DEFAULT NULL,
  `PrillBillTime` datetime DEFAULT NULL,
  `TransferDestWin` int(11) DEFAULT NULL,
  `DelayNum` int(11) DEFAULT NULL,
  `DelayTime` int(11) DEFAULT NULL,
  `CallTime` datetime DEFAULT NULL,
  `ProcessTime` datetime DEFAULT NULL,
  `FinishTime` datetime DEFAULT NULL,
  `WindowNo` char(36) DEFAULT NULL,
  `EmployNo` char(36) DEFAULT NULL,
  `EmployName` varchar(30) DEFAULT NULL,
  `CardNo` varchar(50) DEFAULT NULL,
  `Judge` int(11) DEFAULT NULL,
  `WaitInterval` int(11) DEFAULT NULL,
  `ProcessInterval` int(11) DEFAULT NULL,
  `WaitPeopleBusssiness` int(11) DEFAULT NULL,
  `WaitPeopleBank` int(11) DEFAULT NULL,
  `CustemClass` int(11) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Staus` int(11) DEFAULT '0' COMMENT '0：取号,1:叫号、2：欢迎、3：结束、4上传完成。',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_queueinfo
-- ----------------------------
