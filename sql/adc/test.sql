
show databases;

use dbo;
/*sdfasdfsag**/


DROP TABLE TAdministrativeArea;
DROP TABLE TAuthority;/***********************************/
DROP TABLE TCharge;/***********************************/
DROP TABLE TConfig;/***********************************/
DROP TABLE TConfigItem;/***********************************/
DROP TABLE TCultivation;/***********************************/
DROP TABLE TDataItem;/***********************************/
DROP TABLE TDataReport;
DROP TABLE TDevType;/***********************************/
DROP TABLE TDevice;
DROP TABLE TEquipment;/***********************************/
DROP TABLE TEstate;/***********************************/
DROP TABLE TExperimentalZone;
DROP TABLE TFarm;/*******人人人人人人人人人人人人**********/
DROP TABLE TFarmConfig;/***********************************/
DROP TABLE TFarmDevice;/***********************************/
DROP TABLE TFarmMember;/***********************************/
DROP TABLE TForest;/***********************************/
DROP TABLE TIncome;/***********************************/
DROP TABLE TOperation;/***********************************/
DROP TABLE TRole;/***********************************/
DROP TABLE TUser;/***********************************/

show tables;


select TExperimentalZone.City, TExperimentalZone.County, TDataReport.DataItem, TDataReport.Value 
	from TDevice, TDataReport, TExperimentalZone
where TDevice.IEEEAddress = TDataReport.DeviceID
and  TExperimentalZone.ZoneID = TDevice.ZoneID
limit 5;


select TDevice.ZoneID
	from TDevice, TExperimentalZone
where  TExperimentalZone.ZoneID = TDevice.ZoneID
limit 5;

select * from  TExperimentalZone;








