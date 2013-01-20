/****** Object:  UserDefinedTableType [dbo].[tinyint_list_tbltype]    Script Date: 03/22/2012 19:29:22 ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'tinyint_list_tbltype' AND ss.name = N'dbo')
CREATE TYPE [dbo].[tinyint_list_tbltype] AS TABLE(
	[n] [tinyint] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[n] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO

/****** Object:  UserDefinedTableType [dbo].[smallint_list_tbltype]    Script Date: 03/22/2012 19:28:36 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'smallint_list_tbltype' AND ss.name = N'dbo')
CREATE TYPE [dbo].[smallint_list_tbltype] AS TABLE(
	[n] [smallint] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[n] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO

/****** Object:  UserDefinedTableType [dbo].[int_list_tbltype]    Script Date: 03/22/2012 19:22:05 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'int_list_tbltype' AND ss.name = N'dbo')
CREATE TYPE [dbo].[int_list_tbltype] AS TABLE(
	[n] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[n] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO

/****** Object:  UserDefinedTableType [dbo].[bigint_list_tbltype]    Script Date: 03/22/2012 19:27:16 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'bigint_list_tbltype' AND ss.name = N'dbo')
CREATE TYPE [dbo].[bigint_list_tbltype] AS TABLE(
	[n] [bigint] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[n] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
