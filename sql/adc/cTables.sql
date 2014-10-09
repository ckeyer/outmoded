use dbo;

CREATE TABLE dbo.TAdministrativeArea(
	ID int AUTO_INCREMENT NOT NULL,
	City varchar(10) NOT NULL,
	County varchar(10) NULL,
	CONSTRAINT PK_TAdministrativeArea PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TAuthority)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TAuthority(
	ID int AUTO_INCREMENT NOT NULL,
	OperName varchar(50) NOT NULL,
	RoleName varchar(50) NOT NULL,
	IsEnable boolean NOT NULL,
	CONSTRAINT PK_TAuthority_1 PRIMARY KEY (ID) 
);
/****** Object:  Table dbo.TCharge)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TCharge(
	ID int AUTO_INCREMENT NOT NULL,
	ExperimentalZoneID int NOT NULL,
	UserID int NOT NULL,
	CONSTRAINT PK_TCharge PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TConfig)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TConfig(
	ID int AUTO_INCREMENT NOT NULL,
	ConfigMode varchar(50) NULL,
	DataReportCycle int NULL,
	DataAcquisitionCycle int NULL,
	ShootingCycle int NULL,
	ImageUploadCycle int NULL,
	CONSTRAINT PK_TConfig PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TConfigItem)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TConfigItem(
	ConfigItem varchar(50) NOT NULL,
	Unit varchar(10) NULL,
	DefaultValue int NULL,
	CONSTRAINT PK_TConfigItem PRIMARY KEY (ConfigItem) 
);
/****** Object:  Table dbo.TCultivation)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TCultivation(
	ID int AUTO_INCREMENT NOT NULL,
	Species varchar(50) NULL,
	Quantity decimal(18, 2) NULL,
	Covers decimal(18, 2) NULL,
	AssessPrice decimal(18, 2) NULL,
	FarmID int NULL,
	CONSTRAINT PK_TCultivation PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TDataItem)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TDataItem(
	ID int AUTO_INCREMENT NOT NULL,
	DataItem varchar(50) NOT NULL,
	ItemCode nchar(10) NULL,
	Unit varchar(10) NULL,
	Max_Value float NULL,
	Min_Value float NULL,
	CONSTRAINT PK_TDataItem_1 PRIMARY KEY (ID)
);

/****** Object:  Table dbo.TDataReport)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TDataReport(
	ID int AUTO_INCREMENT NOT NULL,
	DeviceID varchar(50) NULL,
	DataItem varchar(50) NULL,
	Value decimal(9, 2) NULL,
	ReportTime datetime NULL,
	ReportUserID varchar(50) NULL,
	BatchTime datetime NULL,
	CONSTRAINT PK_TDataReport PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TDevice)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TDevice(
	ID int AUTO_INCREMENT NOT NULL,
	DeviceID varchar(50) NULL,
	Account varchar(50) NULL,
	PWD varchar(50) NULL,
	DevType varchar(50) NULL,
	Manufacturers varchar(50) NULL,
	Model varchar(50) NULL,
	IP varchar(15) NULL,
	Port varchar(5) NULL,
	IEEEAddress varchar(64) NULL,
	IEEEPort varchar(5) NULL,
	ZoneID int NULL,
	InternalCode varchar(50) NULL,
	IsEnable boolean NULL,
	CONSTRAINT PK_TDevice PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TDevType)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TDevType(
	DevType varchar(50) NOT NULL,
	CONSTRAINT PK_TDevType PRIMARY KEY (DevType) 
);
/****** Object:  Table dbo.TEquipment)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TEquipment(
	ID int AUTO_INCREMENT NOT NULL,
	EquipmentName varchar(50) NULL,
	Quantity int NULL,
	PurchasePrice decimal(18, 2) NULL,
	GetYear smallint NULL,
	AssessPrice decimal(18, 2) NULL,
	FarmID int NULL,
	CONSTRAINT PK_TEquipment PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TEstate)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TEstate(
	ID int AUTO_INCREMENT NOT NULL,
	FarmID int NULL,
	PropertyNature varchar(50) NULL,
	Address varchar(100) NULL,
	GFA decimal(18, 2) NULL,
	GetYear smallint NULL,
	PurchasePrice decimal(18, 2) NULL,
	AssessPrice decimal(18, 2) NULL,
	CONSTRAINT PK_TEstate PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TExperimentalZone)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TExperimentalZone(
	ID int AUTO_INCREMENT NOT NULL,
	ZoneID varchar(50) NOT NULL,
	City varchar(50) NULL,
	County varchar(50) NULL,
	Charge varchar(50) NULL,
	CONSTRAINT PK_TExperimentalZone PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TFarm)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TFarm(
	ID int AUTO_INCREMENT NOT NULL,
	FarmerName varchar(20) NULL,
	Sex varchar(1) NULL,
	EthnicGroup varchar(10) NULL,
	Education varchar(10) NULL,
	LaborCount smallint NULL,
	Address varchar(100) NULL,
	ZipCode varchar(6) NULL,
	ZoneID int NULL,
	CONSTRAINT PK_TFarm PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TFarmConfig)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TFarmConfig(
	ID int AUTO_INCREMENT NOT NULL,
	FarmID int NULL,
	ConfigID int NULL,
	CONSTRAINT PK_TFarmConfig PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TFarmDevice)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TFarmDevice(
	FarmID int NOT NULL,
	DeviceID int NOT NULL,
	CONSTRAINT PK_TFarmDevice PRIMARY KEY (FarmID,DeviceID) 
);
/****** Object:  Table dbo.TFarmMember)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TFarmMember(
	ID int AUTO_INCREMENT NOT NULL,
	MemberName varchar(20) NULL,
	Relationship varchar(20) NULL,
	IDNumber varchar(20) NULL,
	Education varchar(20) NULL,
	Profession varchar(20) NULL,
	Sex varchar(2) NULL,
	ContactNumber varchar(20) NULL,
	FarmID int NULL,
	CONSTRAINT PK_TFarmMember PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TForest)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TForest(
	ID int AUTO_INCREMENT NOT NULL,
	FarmID int NULL,
	ForestIDNumber varchar(20) NULL,
	MainVarieties varchar(50) NULL,
	Covers decimal(18, 2) NULL,
	StockVolume decimal(18, 2) NULL,
	AssessPrice decimal(18, 2) NULL,
	CONSTRAINT PK_TForest PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TIncome)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TIncome(
	ID int AUTO_INCREMENT NOT NULL,
	IncomeType varchar(50) NULL,
	Sources varchar(50) NULL,
	Annualncome decimal(18, 2) NULL,
	FarmID int NULL,
	CONSTRAINT PK_TIncome PRIMARY KEY (ID)
);
/****** Object:  Table dbo.TOperation)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TOperation(
	OperName varchar(50) NOT NULL,
	CONSTRAINT PK_TOperation_1 PRIMARY KEY (OperName) 
);
/****** Object:  Table dbo.TRole)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TRole(
	RoleName varchar(10) NOT NULL,
	CONSTRAINT PK_TRole_1 PRIMARY KEY (RoleName) 
);
/****** Object:  Table dbo.TUser)    Script Date: 2014/2/21 14:00:42 ******/

CREATE TABLE dbo.TUser(
	ID int AUTO_INCREMENT NOT NULL,
	UserId varchar(50) NOT NULL,
	UserPwd varchar(32) NOT NULL,
	UserName varchar(20) NULL,
	City varchar(10) NULL,
	County varchar(10) NULL,
	Department varchar(50) NULL,
	Telephone varchar(20) NULL,
	MobilePhone varchar(14) NULL,
	Email varchar(60) NULL,
	Role varchar(20) NULL,
	LastLoginTime datetime NULL,
	LastLoginIP varchar(15) NULL,
	IsDisable boolean NULL,
	IsDelete boolean NULL,
	ErrorCount int NULL,
	CONSTRAINT PK_TUser PRIMARY KEY (ID)
)
;
