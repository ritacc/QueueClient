/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50091
Source Host           : localhost:3306
Source Database       : queueclient

Target Server Type    : MYSQL
Target Server Version : 50091
File Encoding         : 65001

Date: 2013-02-27 00:42:44
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `t_bussiness`
-- ----------------------------
DROP TABLE IF EXISTS `t_bussiness`;
CREATE TABLE `t_bussiness` (
  `Id` char(36) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `EnglishName` varchar(50) default NULL,
  `TypeName` varchar(50) default NULL,
  `WaitTime1` int(11) default NULL,
  `PriorTime1` int(11) default NULL,
  `WaitTime2` int(11) default NULL,
  `PriorTime2` int(11) default NULL,
  `WaitTime3` int(11) default NULL,
  `PriorTime3` int(11) default NULL,
  `TicketMethod` int(11) default NULL,
  `MondayFlag` bit(1) default NULL,
  `MondayTime` varchar(50) default NULL,
  `TuesdayFlag` bit(1) default NULL,
  `TuesdayTime` varchar(50) default NULL,
  `WednesdayFlag` bit(1) default NULL,
  `WednesdayTime` varchar(50) default NULL,
  `ThurdayFlag` bit(1) default NULL,
  `ThurdayTime` varchar(50) default NULL,
  `FridayFlag` bit(1) default NULL,
  `FridayTime` varchar(50) default NULL,
  `SaturdayFlag` bit(1) default NULL,
  `SaturdayTime` varchar(50) default NULL,
  `SundayFlag` bit(1) default NULL,
  `SundayTime` varchar(50) default NULL,
  `Description` varchar(100) default NULL,
  `OrgBH` varchar(64) default NULL,
  PRIMARY KEY  (`Id`)
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
-- Table structure for `t_pagewin`
-- ----------------------------
DROP TABLE IF EXISTS `t_pagewin`;
CREATE TABLE `t_pagewin` (
  `Id` char(36) NOT NULL,
  `Name` varchar(20) NOT NULL,
  `Width` int(11) NOT NULL,
  `Height` int(11) NOT NULL,
  `orgBH` varchar(64) NOT NULL,
  PRIMARY KEY  (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of t_pagewin
-- ----------------------------
INSERT INTO `t_pagewin` VALUES ('45165397-aace-49a8-aa02-c7c3ea349035', '页窗口1', '400', '400', '000001');

-- ----------------------------
-- Table structure for `t_qhandy`
-- ----------------------------
DROP TABLE IF EXISTS `t_qhandy`;
CREATE TABLE `t_qhandy` (
  `ID` char(36) NOT NULL,
  `OrgBH` varchar(64) default NULL,
  `LABEL_IDX` int(1) NOT NULL,
  `LABEL_VISIBLE` bit(1) default NULL,
  `LABEL_CAPTION` varchar(100) default NULL,
  `LABEL_FONTCOLOR` int(11) default NULL,
  `LABEL_FONTNAME` varchar(30) default NULL,
  `LABEL_FONTUNDERLINE` bit(1) default NULL,
  `LABEL_FONTITALIC` bit(1) default NULL,
  `LABEL_FONTBOLD` bit(1) default NULL,
  `LABEL_FONTSIZE` int(11) default NULL,
  `LABEL_TOP` int(11) default NULL,
  `LABEL_LEFT` int(11) default NULL,
  `LABEL_JOBNO` varchar(50) default NULL,
  `LABEL_JOBNAME` varchar(50) default NULL,
  `LABEL_PRINTSTR` varchar(50) default NULL,
  `LABEL_SHADE` bit(1) default NULL,
  `TAG_VISIBLE` bit(1) default NULL,
  `TAG_CAPTION` varchar(100) default NULL,
  `TAG_FONTCOLOR` int(11) default NULL,
  `TAG_FONTNAME` varchar(30) default NULL,
  `TAG_FONTUNDERLINE` bit(1) default NULL,
  `TAG_FONTITALIC` bit(1) default NULL,
  `TAG_FONTBOLD` bit(1) default NULL,
  `TAG_FONTSIZE` int(11) default NULL,
  `TAG_TOPOFFSET` int(11) default NULL,
  `TAG_LEFTOFFSET` int(11) default NULL,
  `LABEL_TYPE` varchar(20) default NULL,
  `ENLABEL_VISIBLE` bit(1) default NULL,
  `ENLABEL_CAPTION` varchar(100) default NULL,
  `ENLABEL_FONTCOLOR` int(11) default NULL,
  `ENLABEL_FONTNAME` varchar(30) default NULL,
  `ENLABEL_FONTITALIC` bit(1) default NULL,
  `ENLABEL_FONTUNDERLINE` bit(1) default NULL,
  `ENLABEL_FONTBOLD` bit(1) default NULL,
  `ENLABEL_FONTSIZE` int(11) default NULL,
  `SCREENTYPE` int(11) default NULL,
  `ENLABEL_LEFTOFFSET` int(11) default NULL,
  `ENLABEL_TOPOFFSET` int(11) default NULL,
  `ButtomType` bit(1) NOT NULL,
  `windowOnID` varchar(50) default NULL,
  `windowID` varchar(50) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of t_qhandy
-- ----------------------------
INSERT INTO `t_qhandy` VALUES ('37b5a532-4176-41da-b684-480a9910d278', '000001', '1', '', 'Text', '0', '宋体', '', '', '', '12', '51', '84', '', '', '', '', '', 'TagText', '0', '宋体', '', '', '', '9', '51', '224', '', '', 'EnLabelText', '0', '宋体', '', '', '', '12', '0', '84', '100', '', '', '45165397-aace-49a8-aa02-c7c3ea349035');
INSERT INTO `t_qhandy` VALUES ('ba2c8df1-a53e-4da8-ba54-f88e7134d8f7', '000001', '2', '', 'Text', '0', '宋体', '', '', '', '12', '213', '198', '', '', '', '', '', 'TagText', '0', '宋体', '', '', '', '9', '213', '338', '', '', 'EnLabelText', '0', '宋体', '', '', '', '12', '-1', '198', '248', '', '45165397-aace-49a8-aa02-c7c3ea349035', '');

-- ----------------------------
-- Table structure for `t_queueinfo`
-- ----------------------------
DROP TABLE IF EXISTS `t_queueinfo`;
CREATE TABLE `t_queueinfo` (
  `Id` char(36) NOT NULL default '',
  `BankNo` varchar(20) default NULL COMMENT '网点编号',
  `BillNo` varchar(50) default NULL COMMENT '票号',
  `BussinessId` char(36) default NULL COMMENT '业务ID',
  `PrillBillTime` datetime default NULL COMMENT '打印时间',
  `TransferDestWin` varchar(36) default NULL COMMENT '转移目标窗口',
  `DelayNum` int(11) default NULL COMMENT '延后的人数',
  `DelayTime` int(11) default NULL COMMENT '延后秒数',
  `CallTime` datetime default NULL COMMENT '呼叫时间',
  `ProcessTime` datetime default NULL COMMENT '办理时间',
  `FinishTime` datetime default NULL COMMENT '完成时间',
  `WindowNo` char(36) default NULL COMMENT '服务窗口号',
  `EmployNo` char(36) default NULL COMMENT '柜员号',
  `EmployName` varchar(30) default NULL COMMENT '柜员姓名',
  `CardNo` varchar(50) default NULL COMMENT '取号的卡号',
  `Judge` int(11) default NULL COMMENT '评价结果',
  `WaitInterval` int(11) default NULL COMMENT '等待时长(秒)',
  `ProcessInterval` int(11) default NULL COMMENT '办理时长(秒)',
  `WaitPeopleBusssiness` int(11) default NULL COMMENT '取号时该业务的等待人数',
  `WaitPeopleBank` int(11) default NULL COMMENT '取号时该网点的等待人数',
  `CustemClass` int(11) default NULL COMMENT '客户级别',
  `Description` varchar(100) default NULL COMMENT '描述',
  `Status` int(11) default '0' COMMENT '0：取号,1:叫号、2：欢迎、3：结束、4上传完成。',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_queueinfo
-- ----------------------------
INSERT INTO `t_queueinfo` VALUES ('1620fea4-a541-4462-887d-527c4309e3d8', '5300', '0001', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-02-24 09:49:48', '', '0', '0', '2013-02-24 10:23:52', '2013-02-24 09:49:48', '2013-02-24 09:49:48', '', '', '', '', '0', '0', '0', '0', '0', '0', '', '1');
INSERT INTO `t_queueinfo` VALUES ('851649c8-7c11-4fe9-8f5c-046d274e6b5a', '5300', '0003', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-02-24 09:49:54', '', '0', '0', '2013-02-24 10:17:40', '2013-02-24 09:49:54', '2013-02-24 09:49:54', '', '', '', '', '0', '0', '0', '0', '0', '0', '', '1');
INSERT INTO `t_queueinfo` VALUES ('fe5783ae-7d56-41d6-87e5-7df760287e77', '5300', '0002', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-02-24 09:49:50', '', '0', '0', '2013-02-24 10:01:53', '2013-02-24 09:49:50', '2013-02-24 09:49:50', '', '', '', '', '0', '0', '0', '0', '0', '0', '', '1');

-- ----------------------------
-- Table structure for `t_queueinfohistory`
-- ----------------------------
DROP TABLE IF EXISTS `t_queueinfohistory`;
CREATE TABLE `t_queueinfohistory` (
  `Id` char(36) NOT NULL default '',
  `BankNo` varchar(20) default NULL COMMENT '网点编号',
  `BillNo` varchar(50) default NULL COMMENT '票号',
  `BussinessId` char(36) default NULL COMMENT '业务ID',
  `PrillBillTime` datetime default NULL COMMENT '打印时间',
  `TransferDestWin` varchar(36) default NULL COMMENT '转移目标窗口',
  `DelayNum` int(11) default NULL COMMENT '延后的人数',
  `DelayTime` int(11) default NULL COMMENT '延后秒数',
  `CallTime` datetime default NULL COMMENT '呼叫时间',
  `ProcessTime` datetime default NULL COMMENT '办理时间',
  `FinishTime` datetime default NULL COMMENT '完成时间',
  `WindowNo` char(36) default NULL COMMENT '服务窗口号',
  `EmployNo` char(36) default NULL COMMENT '柜员号',
  `EmployName` varchar(30) default NULL COMMENT '柜员姓名',
  `CardNo` varchar(50) default NULL COMMENT '取号的卡号',
  `Judge` int(11) default NULL COMMENT '评价结果',
  `WaitInterval` int(11) default NULL COMMENT '等待时长(秒)',
  `ProcessInterval` int(11) default NULL COMMENT '办理时长(秒)',
  `WaitPeopleBusssiness` int(11) default NULL COMMENT '取号时该业务的等待人数',
  `WaitPeopleBank` int(11) default NULL COMMENT '取号时该网点的等待人数',
  `CustemClass` int(11) default NULL COMMENT '客户级别',
  `Description` varchar(100) default NULL COMMENT '描述',
  `Status` int(11) default '0' COMMENT '0：取号,1:叫号、2：欢迎、3：结束、4上传完成。',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_queueinfohistory
-- ----------------------------
