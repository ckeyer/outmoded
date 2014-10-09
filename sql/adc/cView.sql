
CREATE VIEW dbo.VAvgValueByBatchOfDevice
AS
SELECT   CONVERT(varchar(13), BatchTime) AS Batch, DeviceID, DataItem, AVG(Value) AS AvgValue
FROM      dbo.TDataReport
GROUP BY CONVERT(varchar(13), BatchTime), DeviceID, DataItem
;


/****** Object:  View dbo.VAvgValueOfHour    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VAvgValueOfHour
AS
SELECT   dbo.TDevice.ZoneID, dbo.VAvgValueByBatchOfDevice.DataItem, dbo.VAvgValueByBatchOfDevice.AvgValue, 
                dbo.TDataItem.Unit, dbo.TDataItem.MaxValue, dbo.TDataItem.MinValue, 
                CAST(dbo.VAvgValueByBatchOfDevice.Batch + ':00:00' AS datetime) AS BatchTime
FROM      dbo.TDataItem INNER JOIN
                dbo.VAvgValueByBatchOfDevice ON dbo.TDataItem.DataItem = dbo.VAvgValueByBatchOfDevice.DataItem INNER JOIN
                dbo.TDevice ON dbo.VAvgValueByBatchOfDevice.DeviceID = dbo.TDevice.IEEEAddress
;


/****** Object:  View dbo.VLastBatchByDevice    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VLastBatchByDevice
AS
SELECT   DeviceID, DataItem, Value, BatchTime
FROM      dbo.TDataReport
WHERE   (BatchTime IN
                    (SELECT   MAX(BatchTime) AS Expr1
                     FROM      dbo.TDataReport AS TDataReport_1
                     GROUP BY DeviceID, DataItem))
;


/****** Object:  View dbo.VLastBatchByZone    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VLastBatchByZone
AS
SELECT   dbo.TDevice.ZoneID, dbo.VLastBatchByDevice.BatchTime, dbo.VLastBatchByDevice.DataItem, 
                AVG(dbo.VLastBatchByDevice.Value) AS AvgValue
FROM      dbo.VLastBatchByDevice INNER JOIN
                dbo.TDevice ON dbo.VLastBatchByDevice.DeviceID = dbo.TDevice.IEEEAddress
GROUP BY dbo.TDevice.ZoneID, dbo.VLastBatchByDevice.BatchTime, dbo.VLastBatchByDevice.DataItem
;


/****** Object:  View dbo.VAvgValueOfLastBatch    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VAvgValueOfLastBatch
AS
SELECT   dbo.VLastBatchByZone.ZoneID, dbo.TDataItem.DataItem, dbo.VLastBatchByZone.AvgValue, dbo.TDataItem.Unit, 
                dbo.TDataItem.MaxValue, dbo.TDataItem.MinValue, dbo.VLastBatchByZone.BatchTime
FROM      dbo.VLastBatchByZone INNER JOIN
                dbo.TDataItem ON dbo.VLastBatchByZone.DataItem = dbo.TDataItem.DataItem
;


/****** Object:  View dbo.VMaxValueOfDay    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VMaxValueOfDay
AS
SELECT   DeviceID, DataItem, MAX(Value) AS MaxValue, CONVERT(CHAR(8), BatchTime, 112) AS Date
FROM      dbo.TDataReport
GROUP BY CONVERT(CHAR(8), BatchTime, 112), DeviceID, DataItem
;


/****** Object:  View dbo.VMaxValueOfZone    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VMaxValueOfZone
AS
SELECT   dbo.TDevice.ZoneID, dbo.VMaxValueOfDay.DataItem, AVG(dbo.VMaxValueOfDay.MaxValue) AS Value, 
                CAST(dbo.VMaxValueOfDay.Date AS datetime) AS BatchTime, dbo.TDataItem.Unit, dbo.TDataItem.MaxValue, 
                dbo.TDataItem.MinValue
FROM      dbo.TDevice INNER JOIN
                dbo.VMaxValueOfDay ON dbo.TDevice.IEEEAddress = dbo.VMaxValueOfDay.DeviceID INNER JOIN
                dbo.TDataItem ON dbo.VMaxValueOfDay.DataItem = dbo.TDataItem.DataItem
GROUP BY dbo.TDevice.ZoneID, dbo.VMaxValueOfDay.DataItem, dbo.VMaxValueOfDay.Date, dbo.TDataItem.Unit, 
                dbo.TDataItem.MaxValue, dbo.TDataItem.MinValue
;


/****** Object:  View dbo.VMinValueOfDay    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VMinValueOfDay
AS
SELECT   DeviceID, DataItem, MIN(Value) AS MinValue, CONVERT(CHAR(8), BatchTime, 112) AS Date
FROM      dbo.TDataReport
GROUP BY CONVERT(CHAR(8), BatchTime, 112), DeviceID, DataItem
;


/****** Object:  View dbo.VMinValueOfZone    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VMinValueOfZone
AS
SELECT   dbo.TDevice.ZoneID, dbo.VMinValueOfDay.DataItem, AVG(dbo.VMinValueOfDay.MinValue) AS Value, 
                CAST(dbo.VMinValueOfDay.Date AS datetime) AS BatchTime, dbo.TDataItem.Unit, dbo.TDataItem.MaxValue, 
                dbo.TDataItem.MinValue
FROM      dbo.TDevice INNER JOIN
                dbo.VMinValueOfDay ON dbo.TDevice.IEEEAddress = dbo.VMinValueOfDay.DeviceID INNER JOIN
                dbo.TDataItem ON dbo.VMinValueOfDay.DataItem = dbo.TDataItem.DataItem
GROUP BY dbo.TDevice.ZoneID, dbo.VMinValueOfDay.DataItem, dbo.VMinValueOfDay.Date, dbo.TDataItem.Unit, 
                dbo.TDataItem.MaxValue, dbo.TDataItem.MinValue
;


/****** Object:  View dbo.VMinValueOfMonth    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VMinValueOfMonth
AS
SELECT   DeviceID, DataItem, MIN(Value) AS MinValue, CONVERT(CHAR(6), BatchTime, 112) AS Month
FROM      dbo.TDataReport
GROUP BY CONVERT(CHAR(6), BatchTime, 112), DeviceID, DataItem
;


/****** Object:  View dbo.VMinValueOfZoneM    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VMinValueOfZoneM
AS
SELECT   dbo.TDevice.ZoneID, dbo.VMinValueOfMonth.DataItem, AVG(dbo.VMinValueOfMonth.MinValue) AS Value, 
                CAST(dbo.VMinValueOfMonth.Month + '01' AS datetime) AS BatchTime, dbo.TDataItem.Unit, dbo.TDataItem.MaxValue, 
                dbo.TDataItem.MinValue
FROM      dbo.TDevice INNER JOIN
                dbo.VMinValueOfMonth ON dbo.TDevice.IEEEAddress = dbo.VMinValueOfMonth.DeviceID INNER JOIN
                dbo.TDataItem ON dbo.VMinValueOfMonth.DataItem = dbo.TDataItem.DataItem
GROUP BY dbo.TDevice.ZoneID, dbo.VMinValueOfMonth.DataItem, dbo.VMinValueOfMonth.Month, dbo.TDataItem.Unit, 
                dbo.TDataItem.MaxValue, dbo.TDataItem.MinValue
;


/****** Object:  View dbo.VMaxValueOfMonth    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VMaxValueOfMonth
AS
SELECT   DeviceID, DataItem, MAX(Value) AS MaxValue, CONVERT(CHAR(6), BatchTime, 112) AS Month
FROM      dbo.TDataReport
GROUP BY CONVERT(CHAR(6), BatchTime, 112), DeviceID, DataItem
;


/****** Object:  View dbo.VMaxValueOfZoneM    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VMaxValueOfZoneM
AS
SELECT   dbo.TDevice.ZoneID, dbo.VMaxValueOfMonth.DataItem, AVG(dbo.VMaxValueOfMonth.MaxValue) AS Value, 
                CAST(dbo.VMaxValueOfMonth.Month + '01' AS datetime) AS BatchTime, dbo.TDataItem.Unit, dbo.TDataItem.MaxValue, 
                dbo.TDataItem.MinValue
FROM      dbo.TDevice INNER JOIN
                dbo.VMaxValueOfMonth ON dbo.TDevice.IEEEAddress = dbo.VMaxValueOfMonth.DeviceID INNER JOIN
                dbo.TDataItem ON dbo.VMaxValueOfMonth.DataItem = dbo.TDataItem.DataItem
GROUP BY dbo.TDevice.ZoneID, dbo.VMaxValueOfMonth.DataItem, dbo.VMaxValueOfMonth.Month, dbo.TDataItem.Unit, 
                dbo.TDataItem.MaxValue, dbo.TDataItem.MinValue
;


/****** Object:  View dbo.VFarm    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VFarm
AS
SELECT   dbo.TFarm.ID, dbo.TFarm.FarmerName, dbo.TFarm.Sex, dbo.TFarm.EthnicGroup, dbo.TFarm.Education, 
                dbo.TFarm.LaborCount, dbo.TFarm.Address, dbo.TFarm.ZipCode, dbo.TExperimentalZone.City, 
                dbo.TExperimentalZone.County, dbo.TExperimentalZone.ZoneID, dbo.TExperimentalZone.Charge
FROM      dbo.TFarm LEFT OUTER JOIN
                dbo.TExperimentalZone ON dbo.TFarm.ZoneID = dbo.TExperimentalZone.ID
GROUP BY dbo.TFarm.ID, dbo.TFarm.FarmerName, dbo.TFarm.Sex, dbo.TFarm.EthnicGroup, dbo.TFarm.Education, 
                dbo.TFarm.LaborCount, dbo.TFarm.Address, dbo.TFarm.ZipCode, dbo.TExperimentalZone.City, 
                dbo.TExperimentalZone.County, dbo.TExperimentalZone.ZoneID, dbo.TExperimentalZone.Charge
;


/****** Object:  View dbo.VFarmConfig    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VFarmConfig
AS
SELECT   dbo.VFarm.ID, dbo.VFarm.FarmerName, dbo.VFarm.Sex, dbo.VFarm.EthnicGroup, dbo.VFarm.Education, 
                dbo.VFarm.LaborCount, dbo.VFarm.Address, dbo.VFarm.ZipCode, dbo.VFarm.City, dbo.VFarm.County, dbo.VFarm.ZoneID, 
                dbo.VFarm.Charge, dbo.TConfig.ID AS ConfigModeID, dbo.TConfig.ConfigMode, dbo.TConfig.DataReportCycle, 
                dbo.TConfig.DataAcquisitionCycle, dbo.TConfig.ShootingCycle, dbo.TConfig.ImageUploadCycle
FROM      dbo.TFarmConfig RIGHT OUTER JOIN
                dbo.TConfig ON dbo.TFarmConfig.ConfigID = dbo.TConfig.ID RIGHT OUTER JOIN
                dbo.VFarm ON dbo.TFarmConfig.FarmID = dbo.VFarm.ID
;


/****** Object:  View dbo.VFarmDevice    Script Date: 2014/2/21 14:00:42 ******/

CREATE VIEW dbo.VFarmDevice
AS
SELECT   dbo.TDevice.ID, dbo.TDevice.DeviceID, dbo.TDevice.Account, dbo.TDevice.PWD, dbo.TDevice.DevType, 
                dbo.TDevice.Manufacturers, dbo.TDevice.Model, dbo.TDevice.IP, dbo.TDevice.Port, dbo.TDevice.IEEEAddress, 
                dbo.TDevice.IEEEPort, dbo.TDevice.ZoneID, dbo.TDevice.InternalCode, dbo.TDevice.IsEnable, 
                dbo.TFarmDevice.FarmID, dbo.TFarm.FarmerName
FROM      dbo.TFarm INNER JOIN
                dbo.TFarmDevice ON dbo.TFarm.ID = dbo.TFarmDevice.FarmID RIGHT OUTER JOIN
                dbo.TDevice ON dbo.TFarmDevice.DeviceID = dbo.TDevice.ID

