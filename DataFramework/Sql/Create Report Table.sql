CREATE TABLE [dbo].[Report](
	[pkID] [int] IDENTITY(1,1) NOT NULL,
	[ReportName] [nvarchar](60) NOT NULL,
	[ServerName] [nvarchar](60) NOT NULL,
	[ProcName]   [nvarchar](60) NOT NULL,
	CONSTRAINT [PK_Report] PRIMARY KEY(pkID) 
)