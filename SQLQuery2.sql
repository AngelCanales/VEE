	  USE [aspnet-VEE-2020];
GO
BACKUP DATABASE [aspnet-VEE-2020]
TO DISK = 'C:\Users\canales\source\repos\VEE\VEE\App_Data\aspnet-VEE-2020.Bak'
   WITH FORMAT,
      MEDIANAME = 'Z_SQLServerBackups',
      NAME = 'Full Backup of aspnet-VEE-2020';
GO