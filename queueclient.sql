/*
Navicat MySQL Data Transfer

Source Server         : localRoot
Source Server Version : 50146
Source Host           : localhost:3306
Source Database       : queueclient

Target Server Type    : MYSQL
Target Server Version : 50146
File Encoding         : 65001

Date: 2013-03-01 16:01:17
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
INSERT INTO `t_bussinessrole` VALUES ('5d807131-39ff-4189-a8cf-1b10377fb264', '特色业务', '', '000001000001');
INSERT INTO `t_bussinessrole` VALUES ('5f2a69e9-a168-43ec-8c25-ff98508cad21', '个人业务', '', '000001000001');

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
INSERT INTO `t_employee` VALUES ('bda0adff-84ad-4713-856c-3deda606ccd0', '深圳朱长双', '5301881', '196fe741-c442-4145-aaa8-4922498a46fd', '5f2a69e9-a168-43ec-8c25-ff98508cad21', '5f2a69e9-a168-43ec-8c25-ff98508cad21', '', '000001000001');

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
INSERT INTO `t_nearbyinfo` VALUES ('020d3eed-4841-4a41-af92-42083a737843', '000001000001', '0', null, '白云支行', '', '', null, '');
INSERT INTO `t_nearbyinfo` VALUES ('18127660-7717-4dbf-b781-65bb76408a2d', '000001000001', '0', null, '黄贝领支行', '', '', null, '');
INSERT INTO `t_nearbyinfo` VALUES ('229afd26-3ee1-43e0-b9e3-9bb448c1d783', '000001000001', '0', null, '花都支行', '', '', null, '');
INSERT INTO `t_nearbyinfo` VALUES ('757f34ec-caae-499d-b6f8-c5cb872661a0', '000001000001', '0', null, '罗湖分行', '', '', null, '');
INSERT INTO `t_nearbyinfo` VALUES ('e2a4c670-9ae3-4bc8-947f-51e997584a26', '000001000001', '0', null, '蛇口支行', '', '', null, '');

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
INSERT INTO `t_pagewin` VALUES ('135b20b0-25ae-4935-8fdd-66c47f1c2abc', '页窗口1', '0', '0', '000001000001');
INSERT INTO `t_pagewin` VALUES ('535c261f-f67f-4fc7-aaf5-cafdcd7f1582', '公积金', '0', '0', '000001000001');

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
INSERT INTO `t_qhandy` VALUES ('364a0fc7-3fb6-4a6f-b0a6-227e5a86ad5f', '000001000001', '0', null, 'Text', null, '宋体', null, null, null, null, null, null, '', '', '', null, null, 'TagText', null, '宋体', null, null, null, null, null, null, '', null, 'EnLabelText', null, '宋体', null, null, null, null, null, null, null, '\0', '', '');
INSERT INTO `t_qhandy` VALUES ('80a84859-b503-45c5-a428-3a35789a161b', '000001000001', '0', null, '公积金', null, '舒体', null, null, null, null, null, null, '', '', '', null, null, 'TagText', null, '宋体', null, null, null, null, null, null, '', null, 'EnLabelText', null, '宋体', null, null, null, null, null, null, null, '\0', '', '');
INSERT INTO `t_qhandy` VALUES ('c55a41c3-5e80-4e7c-8edf-50b77dfc4cc0', '000001000001', '0', null, 'Text', null, '宋体', null, null, null, null, null, null, '', '', '', null, null, 'TagText', null, '宋体', null, null, null, null, null, null, '', null, 'EnLabelText', null, '宋体', null, null, null, null, null, null, null, '\0', '', '535c261f-f67f-4fc7-aaf5-cafdcd7f1582');
INSERT INTO `t_qhandy` VALUES ('d73949b7-387f-4ee1-ae7a-2713f4387892', '000001000001', '0', null, 'Text', null, '宋体', null, null, null, null, null, null, '', '', '', null, null, 'TagText', null, '宋体', null, null, null, null, null, null, '', null, 'EnLabelText', null, '宋体', null, null, null, null, null, null, null, '\0', '', '135b20b0-25ae-4935-8fdd-66c47f1c2abc');

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
INSERT INTO `t_shutdowntime` VALUES ('30050A21-8FDC-4269-82F2-9AB6DCAF6877', '1330', '1500', '2000', '2000', '2000', '', '', '', '000001000001');

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
INSERT INTO `t_syspara` VALUES ('155BF9FA-C7B9-40AF-A359-0235FB821F31', '000001000001', 'backgroundsound', '2', '');
INSERT INTO `t_syspara` VALUES ('2F65AD5E-65BE-4CB4-B028-8599B06E3CCA', '000001000001', 'contickettime', '6', '');
INSERT INTO `t_syspara` VALUES ('5D2E07A4-9012-4E56-82FF-44DBC39E722F', '000001000001', 'thirdsound', '2', '');
INSERT INTO `t_syspara` VALUES ('7B101643-084F-4053-B0BA-AFD0A132877E', '000001000001', 'calllimittime', '6', '');
INSERT INTO `t_syspara` VALUES ('85EE404C-E40C-4AF6-B1B2-E0CFF743A75E', '000001000001', 'cartickettime', '6', '');
INSERT INTO `t_syspara` VALUES ('8A116137-8410-4185-8650-38C87FB2E906', '000001000001', 'secondsound', '2', '');
INSERT INTO `t_syspara` VALUES ('8EC914C1-E39B-40D2-9C2B-333302D17148', '000001000001', 'callvolumn', '6', '');
INSERT INTO `t_syspara` VALUES ('91C0BCF7-6182-425B-85FD-E73FD29DC758', '000001000001', 'mainwindowinfo', '欢迎光临1', '');
INSERT INTO `t_syspara` VALUES ('97094BFE-5F90-4EE5-B3DB-0CAD36167E83', '000001000001', 'backgroundvolumn', '6', '');
INSERT INTO `t_syspara` VALUES ('A6CED3BC-747B-4FBF-B02D-84B290BCD917', '000001000001', 'curshowtime', '1', '');
INSERT INTO `t_syspara` VALUES ('B14730EE-5D40-4B93-B2EE-03038AC258EF', '000001000001', 'windowinfo', '欢迎光临1', '');
INSERT INTO `t_syspara` VALUES ('BFB17C84-E93B-4064-A8D6-E6987C7A7B94', '000001000001', 'firstsound', '2', '');
INSERT INTO `t_syspara` VALUES ('C723A58C-1A06-4F55-9B82-6D6465F42ED7', '000001000001', 'popswiptime', '15', '');

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
INSERT INTO `t_vipcardtype` VALUES ('bcf97a6d-404b-4421-931f-537a8534fcad', '银卡', '0', '', '000001');

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
INSERT INTO `t_window` VALUES ('3e8a42f2-3098-4805-ae46-7081338d5dfa', '深圳分行01', '5f2a69e9-a168-43ec-8c25-ff98508cad21', null, '', '000001000001');

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