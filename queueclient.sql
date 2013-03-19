/*
Navicat MySQL Data Transfer

Source Server         : loacal
Source Server Version : 50146
Source Host           : localhost:3306
Source Database       : queueclient

Target Server Type    : MYSQL
Target Server Version : 50146
File Encoding         : 65001

Date: 2013-03-18 23:19:51
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `t_bank`
-- ----------------------------
DROP TABLE IF EXISTS `t_bank`;
CREATE TABLE `t_bank` (
  `Id` char(36) NOT NULL,
  `OrgNo` varchar(50) NOT NULL COMMENT '机构编号',
  `OrgName` varchar(50) NOT NULL COMMENT '机构名称',
  `OrgBH` varchar(64) NOT NULL COMMENT '机构编号',
  `ParentOrgBH` varchar(64) NOT NULL COMMENT '上级机构编号',
  `Description` varchar(100) DEFAULT NULL COMMENT '描述',
  `BankSort` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_bank
-- ----------------------------
INSERT INTO `t_bank` VALUES ('3718313B-6C9C-4642-A57E-552504D3A736', '530', '深圳分行', '000001000001', '000001', '', null);

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
-- Table structure for `t_bussinessrole`
-- ----------------------------
DROP TABLE IF EXISTS `t_bussinessrole`;
CREATE TABLE `t_bussinessrole` (
  `Id` char(36) NOT NULL,
  `Name` varchar(50) DEFAULT NULL COMMENT '业务角色名称',
  `Description` varchar(100) DEFAULT NULL COMMENT '描述',
  `OrgBH` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_bussinessrole
-- ----------------------------
INSERT INTO `t_bussinessrole` VALUES ('5d807131-39ff-4189-a8cf-1b10377fb264', '特色业务', '', '000001');
INSERT INTO `t_bussinessrole` VALUES ('5f2a69e9-a168-43ec-8c25-ff98508cad21', '个人业务', '', '000001');

-- ----------------------------
-- Table structure for `t_bussinessroleon`
-- ----------------------------
DROP TABLE IF EXISTS `t_bussinessroleon`;
CREATE TABLE `t_bussinessroleon` (
  `BussinessRoleID` char(36) DEFAULT NULL COMMENT '业务角色ID',
  `BussinessId` char(36) DEFAULT NULL COMMENT '业务类型',
  `PriorTimes` int(11) DEFAULT NULL COMMENT '主队列优先时间',
  `BackupPriorTimes` int(11) DEFAULT NULL COMMENT '备用队列优先时间'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_bussinessroleon
-- ----------------------------
INSERT INTO `t_bussinessroleon` VALUES ('5f2a69e9-a168-43ec-8c25-ff98508cad21', '31d0a213-015c-4d78-8f29-2c72a0df1e8d', null, null);
INSERT INTO `t_bussinessroleon` VALUES ('5f2a69e9-a168-43ec-8c25-ff98508cad21', '47e6ffe3-011a-4a9f-bf54-f2cb49b38e6e', null, null);
INSERT INTO `t_bussinessroleon` VALUES ('5d807131-39ff-4189-a8cf-1b10377fb264', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', null, null);

-- ----------------------------
-- Table structure for `t_employee`
-- ----------------------------
DROP TABLE IF EXISTS `t_employee`;
CREATE TABLE `t_employee` (
  `Id` char(36) NOT NULL COMMENT 'dd',
  `Name` varchar(50) DEFAULT NULL COMMENT '姓名',
  `EmployNo` varchar(50) DEFAULT NULL COMMENT '柜员编号',
  `EmployType` char(36) DEFAULT NULL COMMENT '外键，关联到表t_EmployType中',
  `HighRole` char(36) DEFAULT NULL COMMENT '默认不设置，以窗口角色为准	外键，关联到表t_BussinessRole中。表示高柜业务角色',
  `LowRole` char(36) DEFAULT NULL COMMENT '默认不设置，以窗口角色为准	外键，关联到表t_BussinessRole中。表示低柜业务角色',
  `Description` varchar(100) DEFAULT NULL COMMENT '描述',
  `OrgBH` varchar(64) DEFAULT NULL COMMENT '机构编号',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_employee
-- ----------------------------
INSERT INTO `t_employee` VALUES ('bda0adff-84ad-4713-856c-3deda606ccd0', '深圳朱长双', '530100', '196fe741-c442-4145-aaa8-4922498a46fd', '5f2a69e9-a168-43ec-8c25-ff98508cad21', '5f2a69e9-a168-43ec-8c25-ff98508cad21', '', '000001000001');

-- ----------------------------
-- Table structure for `t_employtype`
-- ----------------------------
DROP TABLE IF EXISTS `t_employtype`;
CREATE TABLE `t_employtype` (
  `Id` char(36) NOT NULL,
  `Name` varchar(50) DEFAULT NULL COMMENT '柜员类型名称，如普通柜员、高级柜员、个人业务顾问等',
  `Description` varchar(100) DEFAULT NULL COMMENT '描述',
  `OrgBH` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_employtype
-- ----------------------------
INSERT INTO `t_employtype` VALUES ('196fe741-c442-4145-aaa8-4922498a46fd', '类型1', '', '000001');
INSERT INTO `t_employtype` VALUES ('41b517d3-aefb-4752-b31a-d4880c7460c2', '类型2', '', '000001');
INSERT INTO `t_employtype` VALUES ('e2b0fc81-c953-4e9a-8a29-ba9648318b69', '深圳柜员', '深圳柜员', '000001000001');

-- ----------------------------
-- Table structure for `t_nearbyinfo`
-- ----------------------------
DROP TABLE IF EXISTS `t_nearbyinfo`;
CREATE TABLE `t_nearbyinfo` (
  `Id` char(36) NOT NULL,
  `OrgBH` varchar(64) NOT NULL COMMENT '所属机构',
  `NearbyIndex` int(11) NOT NULL COMMENT '网点编号(1-5)',
  `OrgNo` int(11) DEFAULT NULL COMMENT '网点编号',
  `BankName` varchar(50) DEFAULT NULL COMMENT '邻近网点名称',
  `BankAddr` varchar(50) DEFAULT NULL COMMENT '邻近网点地址',
  `BusInfo` varchar(50) DEFAULT NULL COMMENT '公交线路',
  `Flag` int(11) DEFAULT NULL COMMENT '启用标记，1为启用，0为禁用',
  `Description` varchar(100) DEFAULT NULL COMMENT '描述',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_nearbyinfo
-- ----------------------------

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
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_pagewin
-- ----------------------------
INSERT INTO `t_pagewin` VALUES ('77e194e1-c1cb-4a96-b040-71db2daba955', 'T', '400', '400', '000001000001');
INSERT INTO `t_pagewin` VALUES ('bfea6f60-8506-4ffc-b49b-3d6f9513ddca', 'Q2', '550', '400', '000001000001');

-- ----------------------------
-- Table structure for `t_qhandy`
-- ----------------------------
DROP TABLE IF EXISTS `t_qhandy`;
CREATE TABLE `t_qhandy` (
  `ID` char(36) NOT NULL,
  `OrgBH` varchar(64) DEFAULT NULL,
  `LABEL_IDX` int(1) NOT NULL,
  `LABEL_VISIBLE` bit(1) DEFAULT NULL,
  `LABEL_CAPTION` varchar(100) DEFAULT NULL,
  `LABEL_FONTCOLOR` int(11) DEFAULT NULL,
  `LABEL_FONTNAME` varchar(30) DEFAULT NULL,
  `LABEL_FONTUNDERLINE` bit(1) DEFAULT NULL,
  `LABEL_FONTITALIC` bit(1) DEFAULT NULL,
  `LABEL_FONTBOLD` bit(1) DEFAULT NULL,
  `LABEL_FONTSIZE` int(11) DEFAULT NULL,
  `LABEL_TOP` int(11) DEFAULT NULL,
  `LABEL_LEFT` int(11) DEFAULT NULL,
  `LABEL_JOBNO` varchar(50) DEFAULT NULL,
  `LABEL_JOBNAME` varchar(50) DEFAULT NULL,
  `LABEL_PRINTSTR` varchar(50) DEFAULT NULL,
  `LABEL_SHADE` bit(1) DEFAULT NULL,
  `TAG_VISIBLE` bit(1) DEFAULT NULL,
  `TAG_CAPTION` varchar(100) DEFAULT NULL,
  `TAG_FONTCOLOR` int(11) DEFAULT NULL,
  `TAG_FONTNAME` varchar(30) DEFAULT NULL,
  `TAG_FONTUNDERLINE` bit(1) DEFAULT NULL,
  `TAG_FONTITALIC` bit(1) DEFAULT NULL,
  `TAG_FONTBOLD` bit(1) DEFAULT NULL,
  `TAG_FONTSIZE` int(11) DEFAULT NULL,
  `TAG_TOPOFFSET` int(11) DEFAULT NULL,
  `TAG_LEFTOFFSET` int(11) DEFAULT NULL,
  `LABEL_TYPE` varchar(20) DEFAULT NULL,
  `ENLABEL_VISIBLE` bit(1) DEFAULT NULL,
  `ENLABEL_CAPTION` varchar(100) DEFAULT NULL,
  `ENLABEL_FONTCOLOR` int(11) DEFAULT NULL,
  `ENLABEL_FONTNAME` varchar(30) DEFAULT NULL,
  `ENLABEL_FONTITALIC` bit(1) DEFAULT NULL,
  `ENLABEL_FONTUNDERLINE` bit(1) DEFAULT NULL,
  `ENLABEL_FONTBOLD` bit(1) DEFAULT NULL,
  `ENLABEL_FONTSIZE` int(11) DEFAULT NULL,
  `SCREENTYPE` int(11) DEFAULT NULL,
  `ENLABEL_LEFTOFFSET` int(11) DEFAULT NULL,
  `ENLABEL_TOPOFFSET` int(11) DEFAULT NULL,
  `ButtomType` bit(1) NOT NULL,
  `windowOnID` varchar(50) DEFAULT NULL,
  `windowID` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_qhandy
-- ----------------------------
INSERT INTO `t_qhandy` VALUES ('052985d2-8cd3-48f3-9012-42074e2157cb', '000001000001', '13', '', '个人外汇', '0', '宋体', '\0', '\0', '\0', '12', '143', '57', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '个人外汇', '', '\0', '', 'TagT1', '1', '宋体', '\0', '\0', '\0', '9', '161', '171', '', '', 'EnT1', '2', '宋体', '\0', '\0', '', '12', '0', '57', '188', '\0', '', '77e194e1-c1cb-4a96-b040-71db2daba955');
INSERT INTO `t_qhandy` VALUES ('1913b60f-c8b2-48a0-ae13-f58ac9ae5d7c', '000001000001', '9', '', '窗口页', '0', '宋体', '\0', '\0', '\0', '12', '106', '294', '', '', '', '\0', '', 'TagText', '1', '宋体', '\0', '\0', '\0', '9', '126', '420', '', '', 'EnLabelText', '1', '宋体', '\0', '\0', '', '12', '-1', '295', '152', '', '77e194e1-c1cb-4a96-b040-71db2daba955', '');
INSERT INTO `t_qhandy` VALUES ('b83fb348-75af-4e80-9211-fef85c435820', '000001000001', '10', '', 'Text', '0', '宋体', '\0', '\0', '\0', '12', '228', '295', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '个人存取款和汇款', '', '\0', '', 'TagText', '0', '宋体', '\0', '\0', '\0', '9', '250', '417', '', '', 'EnLabelText', '0', '宋体', '\0', '\0', '', '12', '-1', '296', '286', '\0', '', '');
INSERT INTO `t_qhandy` VALUES ('bab2b3cd-da60-46d2-a383-e70e3e00d7c1', '000001000001', '14', '', 'Text', '0', '宋体', '\0', '\0', '\0', '12', '46', '141', '', '', '', '\0', '', 'TagText', '0', '宋体', '\0', '\0', '\0', '9', '67', '262', '', '', 'EnLabelText', '0', '宋体', '\0', '\0', '', '12', '0', '141', '93', '\0', '', 'bfea6f60-8506-4ffc-b49b-3d6f9513ddca');
INSERT INTO `t_qhandy` VALUES ('d0f54d88-731e-4210-8d85-6d33ea9c91b9', '000001000001', '12', '', 'Q2页', '2', '宋体', '\0', '\0', '\0', '12', '51', '54', '', '', '', '\0', '\0', 'TagText', '0', '宋体', '\0', '\0', '\0', '9', '51', '194', '', '\0', 'EnLabelText', '0', '宋体', '\0', '\0', '', '12', '0', '55', '96', '', 'bfea6f60-8506-4ffc-b49b-3d6f9513ddca', '77e194e1-c1cb-4a96-b040-71db2daba955');
INSERT INTO `t_qhandy` VALUES ('e9f7c466-f0ce-40a4-a899-890354980398', '000001000001', '15', '', 'Text', '0', '宋体', '\0', '\0', '\0', '12', '143', '145', '', '', '', '\0', '', 'TagText', '0', '宋体', '\0', '\0', '\0', '9', '159', '265', '', '', 'EnLabelText', '0', '宋体', '\0', '\0', '', '12', '0', '145', '178', '\0', '', 'bfea6f60-8506-4ffc-b49b-3d6f9513ddca');

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
  `Status` int(11) DEFAULT '0' COMMENT '0：取号,1:叫号、2：欢迎、3：结束、4上传完成。',
  `UpStatus` int(11) NOT NULL DEFAULT '-1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_queueinfo
-- ----------------------------
INSERT INTO `t_queueinfo` VALUES ('037eb126-e07f-4d5b-b3ce-df4f6cea5296', '530', '0007', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-15 23:07:07', '0', '0', '0', '2013-03-15 23:07:07', '2013-03-15 23:07:07', '2013-03-15 23:07:07', '', '', '', '', '0', '0', '0', '2', '6', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('06e8b472-3764-4752-9fd3-568aef366c2a', '530', '0001', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-10 18:13:10', '0', '0', '0', '2013-03-10 18:13:10', '2013-03-10 18:13:10', '2013-03-10 18:13:10', '', '', '', '', '0', '0', '0', '0', '0', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('081d7f8c-339a-4c16-b3cb-b19eeaf16fed', '530', '0005', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-15 23:07:03', '0', '0', '0', '2013-03-15 23:10:19', '2013-03-15 23:07:03', '2013-03-15 23:07:03', '1', '530100', '深圳朱长双', '', '0', '0', '0', '3', '4', '0', '', '1', '1');
INSERT INTO `t_queueinfo` VALUES ('082c94fe-c16c-425f-bd72-acdb41b6785b', '530', '0004', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-10 18:14:33', '0', '0', '0', '2013-03-10 18:14:33', '2013-03-10 18:14:33', '2013-03-10 18:14:33', '', '', '', '', '0', '0', '0', '0', '3', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('100dbf33-af1f-4b45-9ac1-c39edca22797', '530', '0003', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-16 23:25:36', '0', '0', '0', '2013-03-16 23:26:49', '2013-03-16 23:25:36', '2013-03-16 23:25:36', '1', '530100', '深圳朱长双', '', '0', '0', '0', '1', '2', '0', '', '1', '1');
INSERT INTO `t_queueinfo` VALUES ('12561d80-8c0d-4def-8e5b-3e1ec88e105c', '530', '0008', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-17 16:45:55', '0', '0', '0', '2013-03-17 16:45:55', '2013-03-17 16:45:55', '2013-03-17 16:45:55', '', '', '', '', '0', '0', '0', '6', '7', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('15921d52-cdc1-4764-8c3f-ccf660769d56', '530', '0001', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-14 21:53:45', '0', '0', '0', '2013-03-14 21:53:45', '2013-03-14 21:53:45', '2013-03-14 21:53:45', '', '', '', '', '0', '0', '0', '0', '0', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('1a252448-733b-47f0-8910-2b7bf2e4b8ef', '530', '0004', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-17 16:45:52', '0', '0', '0', '2013-03-17 18:37:19', '2013-03-17 18:37:32', '2013-03-17 18:37:35', '1', '530100', '深圳朱长双', '', '0', '6700', '3', '2', '3', '0', '', '3', '3');
INSERT INTO `t_queueinfo` VALUES ('1f01029f-30eb-4d75-ab73-b648be6cc633', '530', '0003', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-12 22:09:00', '0', '0', '0', '2013-03-12 22:43:22', '2013-03-12 22:09:00', '2013-03-12 22:09:00', '1', '530100', '深圳朱长双', '', '0', '0', '0', '1', '2', '0', '', '1', '1');
INSERT INTO `t_queueinfo` VALUES ('2405d156-58b4-43d0-bd93-5ea417da8b37', '530', '0006', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-15 23:07:06', '0', '0', '0', '2013-03-15 23:07:06', '2013-03-15 23:07:06', '2013-03-15 23:07:06', '', '', '', '', '0', '0', '0', '1', '5', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('2768d968-fa17-42df-b964-809def0380ae', '530', '0001', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-15 21:56:16', '0', '0', '0', '2013-03-15 21:58:49', '2013-03-15 21:56:16', '2013-03-15 21:56:16', '1', '530100', '深圳朱长双', '', '0', '0', '0', '0', '0', '0', '', '1', '1');
INSERT INTO `t_queueinfo` VALUES ('28d4dc9e-f636-4460-bc60-ac20013fbc5a', '530', '0010', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-17 16:45:58', '0', '0', '0', '2013-03-17 16:45:58', '2013-03-17 16:45:58', '2013-03-17 16:45:58', '', '', '', '', '0', '0', '0', '1', '9', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('3bfc1c1a-36d0-434a-9b40-08f19047fe6f', '530', '0009', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-15 23:07:09', '0', '0', '0', '2013-03-15 23:07:23', '2013-03-15 23:07:09', '2013-03-15 23:07:09', '1', '530100', '深圳朱长双', '', '0', '0', '0', '4', '8', '0', '', '1', '1');
INSERT INTO `t_queueinfo` VALUES ('3c43121c-07b6-4867-911b-91686a94d2fc', '530', '0005', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-17 16:45:53', '0', '0', '0', '2013-03-17 18:38:42', '2013-03-17 18:38:45', '2013-03-17 18:38:47', '1', '530100', '深圳朱长双', '', '0', '6772', '1', '3', '4', '0', '', '3', '3');
INSERT INTO `t_queueinfo` VALUES ('3d5031c9-a95b-403c-80a9-0d5ad652af47', '530', '0003', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-17 15:49:52', '0', '0', '0', '2013-03-17 15:49:52', '2013-03-17 15:49:52', '2013-03-17 15:49:52', '', '', '', '', '0', '0', '0', '0', '2', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('3d6a262c-1627-4491-8e5c-ce330713b3a6', '530', '0011', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-15 23:22:40', '0', '0', '0', '2013-03-15 23:22:40', '2013-03-15 23:22:40', '2013-03-15 23:22:40', '', '', '', '', '0', '0', '0', '6', '10', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('3e0907d0-b8d9-4c4b-9675-e6285b6afa49', '530', '0001', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-16 23:25:29', '0', '0', '0', '2013-03-16 23:25:29', '2013-03-16 23:25:29', '2013-03-16 23:25:29', '', '', '', '', '0', '0', '0', '0', '0', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('42686283-0f6d-4256-9302-17f42170c74f', '530', '0001', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-17 15:49:03', '0', '0', '0', '2013-03-17 16:54:22', '2013-03-17 16:54:42', '2013-03-17 16:54:49', '1', '530100', '深圳朱长双', '', '0', '3939', '6', '0', '0', '0', '', '3', '3');
INSERT INTO `t_queueinfo` VALUES ('479a5204-2697-4ab8-a3c0-1992e18ea638', '530', '0006', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-17 16:45:54', '0', '0', '0', '2013-03-17 18:38:51', '2013-03-17 18:38:52', '2013-03-17 18:39:04', '1', '530100', '深圳朱长双', '', '0', '6778', '11', '4', '5', '0', '', '3', '3');
INSERT INTO `t_queueinfo` VALUES ('63c99dd5-85b0-418c-a9da-288c22c53226', '530', '0011', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-17 16:45:59', '0', '0', '0', '2013-03-17 16:45:59', '2013-03-17 16:45:59', '2013-03-17 16:45:59', '', '', '', '', '0', '0', '0', '2', '10', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('79f967c9-5511-49fc-b03c-7b72987af3be', '530', '0001', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-12 22:08:32', '0', '0', '0', '2013-03-12 22:46:17', '2013-03-12 22:08:32', '2013-03-12 22:08:32', '1', '530100', '深圳朱长双', '', '0', '0', '0', '0', '0', '0', '', '1', '1');
INSERT INTO `t_queueinfo` VALUES ('84c1aa02-22c7-4dc8-9c0d-cd2a0ad944fa', '530', '0005', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-16 23:25:50', '0', '0', '0', '2013-03-16 23:26:46', '2013-03-16 23:25:50', '2013-03-16 23:25:50', '1', '530100', '深圳朱长双', '', '0', '0', '0', '2', '4', '0', '', '1', '1');
INSERT INTO `t_queueinfo` VALUES ('878554db-d333-4835-bedc-0230fff9891c', '530', '0013', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-15 23:23:07', '0', '0', '0', '2013-03-15 23:23:07', '2013-03-15 23:23:07', '2013-03-15 23:23:07', '', '', '', '', '0', '0', '0', '7', '12', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('8c49dac9-9b94-40f6-b48e-0785c23fd4e4', '530', '0002', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-17 15:49:49', '0', '0', '0', '2013-03-17 16:45:32', '2013-03-17 15:49:49', '2013-03-17 15:49:49', '1', '530100', '深圳朱长双', '', '0', '0', '0', '1', '1', '0', '', '1', '1');
INSERT INTO `t_queueinfo` VALUES ('94064a76-f709-43ff-96f8-748dad04d2a1', '530', '0002', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-15 21:56:24', '0', '0', '0', '2013-03-15 22:00:39', '2013-03-15 21:56:24', '2013-03-15 21:56:24', '1', '530100', '深圳朱长双', '', '0', '0', '0', '0', '1', '0', '', '1', '1');
INSERT INTO `t_queueinfo` VALUES ('95c29bdf-af28-4557-9ca4-fec7b933465d', '530', '0002', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-10 18:13:40', '0', '0', '0', '2013-03-10 18:13:40', '2013-03-10 18:13:40', '2013-03-10 18:13:40', '', '', '', '', '0', '0', '0', '1', '1', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('98769614-2ded-4fcc-ba8e-4004d20107d7', '530', '0004', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-15 23:07:01', '0', '0', '0', '2013-03-15 23:07:01', '2013-03-15 23:07:01', '2013-03-15 23:07:01', '', '', '', '', '0', '0', '0', '2', '3', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('9f1eb671-6b65-4cde-8401-0b19f180ac6a', '530', '0004', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-14 21:53:51', '0', '0', '0', '2013-03-14 21:53:51', '2013-03-14 21:53:51', '2013-03-14 21:53:51', '', '', '', '', '0', '0', '0', '1', '3', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('a010cf15-0973-4e25-8519-855989b6939f', '530', '0002', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-12 22:08:45', '0', '0', '0', '2013-03-12 22:50:35', '2013-03-12 22:08:45', '2013-03-12 22:08:45', '1', '530100', '深圳朱长双', '', '0', '0', '0', '0', '1', '0', '', '1', '1');
INSERT INTO `t_queueinfo` VALUES ('c4d13511-009c-4a4c-89ad-05ead6d6821b', '530', '0004', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-16 23:25:49', '0', '0', '0', '2013-03-16 23:25:49', '2013-03-16 23:25:49', '2013-03-16 23:25:49', '', '', '', '', '0', '0', '0', '1', '3', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('c67a0719-47e5-47dd-8bfe-7d6d4d948e5d', '530', '0009', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-17 16:45:56', '0', '0', '0', '2013-03-17 16:45:56', '2013-03-17 16:45:56', '2013-03-17 16:45:56', '', '', '', '', '0', '0', '0', '7', '8', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('cae166fc-29f2-436f-859a-0a7263f02591', '530', '0002', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-16 23:25:33', '0', '0', '0', '2013-03-16 23:25:33', '2013-03-16 23:25:33', '2013-03-16 23:25:33', '', '', '', '', '0', '0', '0', '0', '1', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('cb58bd5d-9e45-4b45-9c31-a13e380a8b75', '530', '0003', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-10 18:14:24', '0', '0', '0', '2013-03-10 18:14:24', '2013-03-10 18:14:24', '2013-03-10 18:14:24', '', '', '', '', '0', '0', '0', '2', '2', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('d75c4116-f67f-4cfc-91d9-8315bba0ed77', '530', '0002', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-14 21:53:49', '0', '0', '0', '2013-03-14 21:53:49', '2013-03-14 21:53:49', '2013-03-14 21:53:49', '', '', '', '', '0', '0', '0', '0', '1', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('e1a5ede8-2ee5-47a8-bfd5-a1e0eab4fc41', '530', '0012', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-17 16:46:00', '0', '0', '0', '2013-03-17 16:46:00', '2013-03-17 16:46:00', '2013-03-17 16:46:00', '', '', '', '', '0', '0', '0', '3', '11', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('e892e5be-9d50-4ccb-a8b0-a1cf3d2d2896', '530', '0003', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-14 21:53:51', '0', '0', '0', '2013-03-14 21:53:51', '2013-03-14 21:53:51', '2013-03-14 21:53:51', '', '', '', '', '0', '0', '0', '1', '2', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('ec6558b8-5e81-464a-82b3-58352e992ab1', '530', '0008', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-15 23:07:09', '0', '0', '0', '2013-03-15 23:07:09', '2013-03-15 23:07:09', '2013-03-15 23:07:09', '', '', '', '', '0', '0', '0', '3', '7', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('ef4d5bbe-aa0f-4bf3-b071-ebb55688aa56', '530', '0007', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-17 16:45:55', '0', '0', '0', '2013-03-17 16:45:55', '2013-03-17 16:45:55', '2013-03-17 16:45:55', '', '', '', '', '0', '0', '0', '5', '6', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('f57dfa59-8040-4ece-95e6-c786b2c1d8dd', '530', '0003', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-15 21:56:25', '0', '0', '0', '2013-03-15 21:57:30', '2013-03-15 21:56:25', '2013-03-15 21:56:25', '1', '530100', '深圳朱长双', '', '0', '0', '0', '1', '2', '0', '', '1', '1');
INSERT INTO `t_queueinfo` VALUES ('f77a1a45-b408-48a0-aec8-d0ae3a31ef3f', '530', '0012', 'b7c7318a-d86c-4165-a47a-0d0909e70932', '2013-03-15 23:22:43', '0', '0', '0', '2013-03-15 23:22:43', '2013-03-15 23:22:43', '2013-03-15 23:22:43', '', '', '', '', '0', '0', '0', '4', '11', '0', '', '0', '0');
INSERT INTO `t_queueinfo` VALUES ('fcdb03e5-3ceb-499a-a9b6-98801f3126cb', '530', '0010', 'f7929360-b26e-44f9-821b-a78b9c5aa6ca', '2013-03-15 23:10:27', '0', '0', '0', '2013-03-15 23:22:04', '2013-03-15 23:10:27', '2013-03-15 23:10:27', '1', '530100', '深圳朱长双', '', '0', '0', '0', '5', '9', '0', '', '1', '1');

-- ----------------------------
-- Table structure for `t_queueinfohistory`
-- ----------------------------
DROP TABLE IF EXISTS `t_queueinfohistory`;
CREATE TABLE `t_queueinfohistory` (
  `Id` char(36) NOT NULL DEFAULT '',
  `BankNo` varchar(20) DEFAULT NULL COMMENT '网点编号',
  `BillNo` varchar(50) DEFAULT NULL COMMENT '票号',
  `BussinessId` char(36) DEFAULT NULL COMMENT '业务ID',
  `PrillBillTime` datetime DEFAULT NULL COMMENT '打印时间',
  `TransferDestWin` varchar(36) DEFAULT NULL COMMENT '转移目标窗口',
  `DelayNum` int(11) DEFAULT NULL COMMENT '延后的人数',
  `DelayTime` int(11) DEFAULT NULL COMMENT '延后秒数',
  `CallTime` datetime DEFAULT NULL COMMENT '呼叫时间',
  `ProcessTime` datetime DEFAULT NULL COMMENT '办理时间',
  `FinishTime` datetime DEFAULT NULL COMMENT '完成时间',
  `WindowNo` char(36) DEFAULT NULL COMMENT '服务窗口号',
  `EmployNo` char(36) DEFAULT NULL COMMENT '柜员号',
  `EmployName` varchar(30) DEFAULT NULL COMMENT '柜员姓名',
  `CardNo` varchar(50) DEFAULT NULL COMMENT '取号的卡号',
  `Judge` int(11) DEFAULT NULL COMMENT '评价结果',
  `WaitInterval` int(11) DEFAULT NULL COMMENT '等待时长(秒)',
  `ProcessInterval` int(11) DEFAULT NULL COMMENT '办理时长(秒)',
  `WaitPeopleBusssiness` int(11) DEFAULT NULL COMMENT '取号时该业务的等待人数',
  `WaitPeopleBank` int(11) DEFAULT NULL COMMENT '取号时该网点的等待人数',
  `CustemClass` int(11) DEFAULT NULL COMMENT '客户级别',
  `Description` varchar(100) DEFAULT NULL COMMENT '描述',
  `Status` int(11) DEFAULT '0' COMMENT '0：取号,1:叫号、2：欢迎、3：结束、4上传完成。',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_queueinfohistory
-- ----------------------------

-- ----------------------------
-- Table structure for `t_shutdowntime`
-- ----------------------------
DROP TABLE IF EXISTS `t_shutdowntime`;
CREATE TABLE `t_shutdowntime` (
  `Id` char(36) NOT NULL,
  `MondayTime` varchar(10) DEFAULT NULL COMMENT '周一关机时间',
  `TuesdayTime` varchar(10) DEFAULT NULL COMMENT '周二关机时间',
  `WednesdayTime` varchar(10) DEFAULT NULL COMMENT '周三关机时间',
  `ThurdayTime` varchar(10) DEFAULT NULL COMMENT '周四关机时间',
  `FridayTime` varchar(10) DEFAULT NULL COMMENT '周五关机时间',
  `SaturdayTime` varchar(10) DEFAULT NULL COMMENT '周六关机时间',
  `SundayTime` varchar(10) DEFAULT NULL COMMENT '周日关机时间',
  `Description` varchar(100) DEFAULT NULL COMMENT '描述',
  `orgbh` char(36) NOT NULL COMMENT '所属机构',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_shutdowntime
-- ----------------------------

-- ----------------------------
-- Table structure for `t_smspeople`
-- ----------------------------
DROP TABLE IF EXISTS `t_smspeople`;
CREATE TABLE `t_smspeople` (
  `Id` char(36) NOT NULL,
  `Name` varchar(20) NOT NULL COMMENT '姓名',
  `MobileNO` varchar(50) NOT NULL COMMENT '手机号码',
  `SendMoney` int(11) NOT NULL COMMENT '发送金额',
  `Description` varchar(100) DEFAULT NULL COMMENT '描述',
  `orgbh` varchar(64) NOT NULL COMMENT '所属机构',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_smspeople
-- ----------------------------
INSERT INTO `t_smspeople` VALUES ('71ba8062-f6e2-4466-b82c-3b18c2c8794d', '小朱', '18688983916', '0', '一千万发送', '000001');

-- ----------------------------
-- Table structure for `t_syspara`
-- ----------------------------
DROP TABLE IF EXISTS `t_syspara`;
CREATE TABLE `t_syspara` (
  `Id` char(36) NOT NULL,
  `OrgBH` varchar(64) NOT NULL COMMENT '所属机构',
  `KeyStr` varchar(50) NOT NULL COMMENT '关键字',
  `ValueStr` varchar(50) DEFAULT NULL COMMENT '值',
  `Description` varchar(100) DEFAULT NULL COMMENT '描述',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_syspara
-- ----------------------------

-- ----------------------------
-- Table structure for `t_vipcardkey`
-- ----------------------------
DROP TABLE IF EXISTS `t_vipcardkey`;
CREATE TABLE `t_vipcardkey` (
  `ID` char(36) NOT NULL,
  `VIPCardKey` varchar(18) DEFAULT NULL COMMENT 'VIP卡识别码',
  `VipCardType` char(36) DEFAULT NULL COMMENT 'VIP卡类型',
  `Description` varchar(100) DEFAULT NULL COMMENT '描述',
  `orgbh` varchar(64) DEFAULT NULL COMMENT '所属机构',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_vipcardkey
-- ----------------------------
INSERT INTO `t_vipcardkey` VALUES ('58c99326-29d2-4d44-8684-d080920f755c', '46358', '1430b2ce-5e80-4785-8abd-34c88c099eb3', '', '000001');
INSERT INTO `t_vipcardkey` VALUES ('9dcd78f2-95d4-4621-8087-bc52e8da94ab', '34567', 'bcf97a6d-404b-4421-931f-537a8534fcad', '', '000001');
INSERT INTO `t_vipcardkey` VALUES ('f0a86bdb-ec5e-47f8-ba15-c2c5c3045dda', '4567', '1430b2ce-5e80-4785-8abd-34c88c099eb3', '', '000001000001');

-- ----------------------------
-- Table structure for `t_vipcardtype`
-- ----------------------------
DROP TABLE IF EXISTS `t_vipcardtype`;
CREATE TABLE `t_vipcardtype` (
  `id` char(36) NOT NULL,
  `name` varchar(20) NOT NULL COMMENT '名称',
  `FirstTime` int(11) NOT NULL COMMENT '优先时间',
  `Description` varchar(200) DEFAULT NULL COMMENT '描述',
  `orgBH` varchar(64) NOT NULL COMMENT '所属机构',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_vipcardtype
-- ----------------------------
INSERT INTO `t_vipcardtype` VALUES ('1430b2ce-5e80-4785-8abd-34c88c099eb3', '金卡', '0', '', '000001');
INSERT INTO `t_vipcardtype` VALUES ('bcf97a6d-404b-4421-931f-537a8534fcad', '银卡', '0', '描述', '000001');

-- ----------------------------
-- Table structure for `t_window`
-- ----------------------------
DROP TABLE IF EXISTS `t_window`;
CREATE TABLE `t_window` (
  `Id` char(36) NOT NULL,
  `Name` varchar(50) DEFAULT NULL COMMENT '窗口名称',
  `Role` char(36) DEFAULT NULL COMMENT '业务角色',
  `SoundDev` int(11) DEFAULT NULL COMMENT '声音设备',
  `Description` varchar(100) DEFAULT NULL COMMENT '描述',
  `OrgBH` varchar(64) DEFAULT NULL COMMENT '机构',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_window
-- ----------------------------
INSERT INTO `t_window` VALUES ('3e8a42f2-3098-4805-ae46-7081338d5dfa', '1', '5f2a69e9-a168-43ec-8c25-ff98508cad21', null, '', '000001000001');

-- ----------------------------
-- Table structure for `t_windowlogininfo`
-- ----------------------------
DROP TABLE IF EXISTS `t_windowlogininfo`;
CREATE TABLE `t_windowlogininfo` (
  `ID` char(36) NOT NULL,
  `LoginTime` datetime NOT NULL,
  `WindowNo` varchar(50) NOT NULL,
  `EmployNo` varchar(50) NOT NULL,
  `EmployName` varchar(50) NOT NULL,
  `Status` int(11) NOT NULL,
  `AlertTime` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_windowlogininfo
-- ----------------------------
INSERT INTO `t_windowlogininfo` VALUES ('07408222-b50c-4839-b6d8-125ece7b35b0', '2013-03-16 10:46:11', '1', '530100', '深圳朱长双', '1', '2013-03-16 23:26:44');
INSERT INTO `t_windowlogininfo` VALUES ('098df96d-a316-44d8-974f-b2be521daac5', '2013-03-13 23:21:46', '1', '530100', '深圳朱长双', '0', '2013-03-13 23:21:46');
INSERT INTO `t_windowlogininfo` VALUES ('0bc80884-dc3b-4f8e-b7ff-3969442b2b95', '2013-03-15 21:57:26', '1', '530100', '深圳朱长双', '0', '2013-03-15 21:57:26');
INSERT INTO `t_windowlogininfo` VALUES ('0dd55f30-be13-4586-8429-7f5e12c11d9e', '2013-03-16 13:07:13', '1', '530100', '深圳朱长双', '0', '2013-03-16 13:07:13');
INSERT INTO `t_windowlogininfo` VALUES ('1688dcc2-0abc-4947-8e34-1ba38b9f1757', '2013-03-13 22:43:30', '1', '530100', '深圳朱长双', '1', '2013-03-13 23:10:56');
INSERT INTO `t_windowlogininfo` VALUES ('28b511bc-f40e-4d9b-a67c-22c7faa6b86c', '2013-03-12 22:11:06', '1', '530100', '深圳朱长双', '0', '2013-03-12 23:21:12');
INSERT INTO `t_windowlogininfo` VALUES ('2d202c09-4e06-48e8-8fde-3bdb94c8e0f7', '2013-03-17 16:54:14', '1', '530100', '深圳朱长双', '1', '2013-03-17 18:37:16');
INSERT INTO `t_windowlogininfo` VALUES ('37a1bb26-efe3-485b-acc6-d914a43a0c5f', '2013-03-06 22:46:13', '1', '530100', '深圳朱长双', '0', '2013-03-06 22:46:16');
INSERT INTO `t_windowlogininfo` VALUES ('3a80486d-6dab-4e2e-8d35-8ed5c9abfcda', '2013-03-06 22:45:43', '1', '530100', '深圳朱长双', '1', '2013-03-06 22:45:50');
INSERT INTO `t_windowlogininfo` VALUES ('3b3b0b1d-8c83-4e86-8a24-3049c9f86ba9', '2013-03-16 23:26:44', '1', '530100', '深圳朱长双', '0', '2013-03-16 23:26:44');
INSERT INTO `t_windowlogininfo` VALUES ('3c4f6acb-ae01-48a6-b673-f215ff76d5aa', '2013-03-15 23:10:16', '1', '530100', '深圳朱长双', '0', '2013-03-15 23:10:16');
INSERT INTO `t_windowlogininfo` VALUES ('3f89e0fe-f871-46f3-9a32-d4293e1d891a', '2013-03-15 22:02:42', '1', '530100', '深圳朱长双', '0', '2013-03-15 22:02:42');
INSERT INTO `t_windowlogininfo` VALUES ('44d19c3e-85f4-40e2-9489-6451771b4e38', '2013-03-15 21:54:49', '1', '530100', '深圳朱长双', '1', '2013-03-15 22:02:42');
INSERT INTO `t_windowlogininfo` VALUES ('4c9dccb0-a9d6-49b7-a8f3-d3193a95afaf', '2013-03-13 23:11:04', '1', '530100', '深圳朱长双', '0', '2013-03-13 23:11:04');
INSERT INTO `t_windowlogininfo` VALUES ('5b4e676f-5c36-4da8-a193-4c134a9a336a', '2013-03-16 18:30:18', '1', '530100', '深圳朱长双', '0', '2013-03-16 18:30:18');
INSERT INTO `t_windowlogininfo` VALUES ('6492ef0c-c8e8-45ce-be9c-7541b84c2285', '2013-03-17 14:43:51', '1', '530100', '深圳朱长双', '1', '2013-03-17 16:54:14');
INSERT INTO `t_windowlogininfo` VALUES ('66dfd2f2-f12d-478c-90d7-ea221b9b8516', '2013-03-15 21:59:54', '1', '530100', '深圳朱长双', '0', '2013-03-15 21:59:54');
INSERT INTO `t_windowlogininfo` VALUES ('7354d788-e439-4672-b1c6-9e2ee9453a6c', '2013-03-16 13:05:42', '1', '530100', '深圳朱长双', '0', '2013-03-16 13:05:42');
INSERT INTO `t_windowlogininfo` VALUES ('7989ff88-153f-4597-a4b4-86b2d0c5fc47', '2013-03-10 22:33:05', '1', '530100', '深圳朱长双', '1', '2013-03-10 22:41:26');
INSERT INTO `t_windowlogininfo` VALUES ('8d3bddc4-cd08-4f00-903f-79f1343ccd11', '2013-03-10 22:39:12', '1', '530100', '深圳朱长双', '0', '2013-03-10 22:39:12');
INSERT INTO `t_windowlogininfo` VALUES ('9a24979c-dc8e-445a-b728-e8b908836e40', '2013-03-17 18:38:38', '1', '530100', '深圳朱长双', '0', '2013-03-17 18:38:38');
INSERT INTO `t_windowlogininfo` VALUES ('a5e22e91-3bd8-4d30-88d8-bfc763db7f5c', '2013-03-13 23:11:21', '1', '530100', '深圳朱长双', '0', '2013-03-13 23:11:21');
INSERT INTO `t_windowlogininfo` VALUES ('a82dbf87-9b21-4c04-b847-42fbaa595b3e', '2013-03-16 13:09:06', '1', '530100', '深圳朱长双', '0', '2013-03-16 13:09:06');
INSERT INTO `t_windowlogininfo` VALUES ('b946f1e7-926f-4185-b75d-53256a2f10f3', '2013-03-12 22:50:26', '1', '530100', '深圳朱长双', '0', '2013-03-12 22:50:26');
INSERT INTO `t_windowlogininfo` VALUES ('bfbc9fe8-f525-4ed3-9b68-10dba0b4269c', '2013-03-03 22:22:47', '1', '530100', '深圳朱长双', '0', '2013-03-03 22:22:47');
INSERT INTO `t_windowlogininfo` VALUES ('c6c06c72-d249-43a6-9777-26c247bd0b7c', '2013-03-12 22:46:07', '1', '530100', '深圳朱长双', '0', '2013-03-12 22:46:07');
INSERT INTO `t_windowlogininfo` VALUES ('c9ef6241-c825-4f40-9d8b-35e5fc2b4438', '2013-03-15 21:56:40', '1', '530100', '深圳朱长双', '1', '2013-03-15 23:22:03');
INSERT INTO `t_windowlogininfo` VALUES ('ce07f4ad-82cd-44ff-bdc6-584999516817', '2013-03-15 23:06:52', '1', '530100', '深圳朱长双', '0', '2013-03-15 23:06:52');
INSERT INTO `t_windowlogininfo` VALUES ('ce52ba49-9955-42d1-9360-e608993ba712', '2013-03-12 22:53:09', '1', '530100', '深圳朱长双', '0', '2013-03-12 22:53:09');
INSERT INTO `t_windowlogininfo` VALUES ('d0f148d5-cc57-40f9-bf44-a8e83bce41d4', '2013-03-16 09:22:07', '1', '530100', '深圳朱长双', '1', '2013-03-16 18:30:18');
INSERT INTO `t_windowlogininfo` VALUES ('d1bac0de-36e5-424a-8da9-25cc55bfbd20', '2013-03-16 10:52:25', '1', '530100', '深圳朱长双', '0', '2013-03-16 10:52:25');
INSERT INTO `t_windowlogininfo` VALUES ('d6609c1b-2224-4c59-b288-34e09627ecd3', '2013-03-03 20:42:14', '1', '530100', '深圳朱长双', '1', '2013-03-03 20:49:46');
INSERT INTO `t_windowlogininfo` VALUES ('f07ef89d-b42b-4990-ac43-cac4206398d9', '2013-03-15 21:58:45', '1', '530100', '深圳朱长双', '0', '2013-03-15 21:58:45');
INSERT INTO `t_windowlogininfo` VALUES ('f1d8b630-a036-421d-a93b-5807764a457a', '2013-03-15 23:22:03', '1', '530100', '深圳朱长双', '0', '2013-03-15 23:22:03');
INSERT INTO `t_windowlogininfo` VALUES ('f6d926e8-3978-4fd6-9f15-e35701df4f8e', '2013-03-17 18:37:16', '1', '530100', '深圳朱长双', '1', '2013-03-17 18:38:38');
INSERT INTO `t_windowlogininfo` VALUES ('f81e61bf-af1f-4334-ac39-5e523c1f770c', '2013-03-12 22:40:26', '1', '530100', '深圳朱长双', '0', '2013-03-12 22:40:26');
INSERT INTO `t_windowlogininfo` VALUES ('f9cc8347-432d-491c-9270-a7784a1e8305', '2013-03-10 22:41:26', '1', '530100', '深圳朱长双', '0', '2013-03-10 22:41:26');
INSERT INTO `t_windowlogininfo` VALUES ('fb9f8a4c-a081-46ff-8077-7af8c7f78067', '2013-03-13 23:10:22', '1', '530100', '深圳朱长双', '1', '2013-03-13 23:21:46');
