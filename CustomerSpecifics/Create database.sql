USE [master]
/****** Note! Make sure SQLCMDMODE is on for queries before running this script ******/

:setvar DbName "M2M.DataCenter"
:setvar DbPath "D:\M2M Solutions\SQL"
:setvar AssemblyPath "D:\M2M Solutions\SQL"

GO
/****** Object:  Database  [$(DbName)]    Script Date: 01/26/2011 11:47:17 ******/
CREATE DATABASE [$(DbName)] ON  PRIMARY 
( NAME = N'$(DbName)', FILENAME = N'$(DbPath)\$(DbName).mdf' , SIZE = 13312KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'$(DbName)_log', FILENAME = N'$(DbPath)\$(DbName)_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'$(DbName)', @new_cmptlevel=120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [$(DbName)].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [$(DbName)] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [$(DbName)] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [$(DbName)] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [$(DbName)] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [$(DbName)] SET ARITHABORT OFF 
GO
ALTER DATABASE [$(DbName)] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [$(DbName)] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [$(DbName)] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [$(DbName)] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [$(DbName)] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [$(DbName)] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [$(DbName)] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [$(DbName)] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [$(DbName)] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [$(DbName)] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [$(DbName)] SET  ENABLE_BROKER 
GO
ALTER DATABASE [$(DbName)] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [$(DbName)] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [$(DbName)] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [$(DbName)] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [$(DbName)] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [$(DbName)] SET  READ_WRITE 
GO
ALTER DATABASE [$(DbName)] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [$(DbName)] SET  MULTI_USER 
GO
ALTER DATABASE [$(DbName)] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [$(DbName)] SET DB_CHAINING OFF
GO

USE [$(DbName)]
GO
/****** Object:  UserDefinedFunction [dbo].[MaxDateValue]    Script Date: 12/17/2009 15:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[MaxDateValue]
(
	@value1 datetime,
	@value2 datetime
)
RETURNS datetime
AS
BEGIN
	DECLARE @Result datetime
	SET @value1 =ISNULL(@value1,getDate())
	SET @value2 =ISNULL(@value2,getDate())
	IF @value1 >= @value2
		SET @Result = @value1
	ELSE
		SET @Result = @value2
RETURN @Result
END
GO

CREATE FUNCTION [dbo].[MinDateValue]
(
	@value1 datetime,
	@value2 datetime
)
RETURNS datetime
AS
BEGIN
	DECLARE @Result datetime	
	SET @value1 = ISNULL(@value1,getDate())
	SET @value2 = ISNULL(@value2,getDate())
    IF @value1 <= @value2
		SET @Result = @value1
	ELSE
	SET @Result = @value2

RETURN @Result      
END
GO

sp_configure "clr enabled", 1
GO

RECONFIGURE
GO

IF NOT EXISTS (SELECT * FROM sys.assemblies WHERE [name] = 'Telerik_Web_UI_RecurrenceEngine')
	CREATE ASSEMBLY Telerik_Web_UI_RecurrenceEngine
	FROM '$(AssemblyPath)\Telerik.Web.UI.RecurrenceEngine.dll'
GO

IF NOT EXISTS (SELECT * FROM sys.assemblies WHERE [name] = 'ExpandRecurrence_SP')
	CREATE ASSEMBLY ExpandRecurrence_SP
	FROM '$(AssemblyPath)\ExpandRecurrence_UDF.dll'
GO

CREATE FUNCTION ExpandRecurrence
    (@recurrenceRule nvarchar(max), @rangeStart datetime, @rangeEnd datetime)
	RETURNS TABLE (StartDate datetime, EndDate datetime)
    AS EXTERNAL NAME ExpandRecurrence_SP.UserDefinedFunctions.ExpandRecurrence;
GO


 