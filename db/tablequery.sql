
CREATE DATABASE PITEDB
USE [PITEDB]
GO
/****** Object:  User [Luis]    Script Date: 16/03/2023 02:10:17 a. m. ******/
CREATE USER [Luis] FOR LOGIN [Luis] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Luis]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [Luis]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [Luis]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 16/03/2023 02:10:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[Precio] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
