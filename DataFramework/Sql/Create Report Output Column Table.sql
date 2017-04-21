USE [EZReporting]
GO

/****** Object:  Table [dbo].[ReportOutputColumn]    Script Date: 4/21/2017 12:22:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReportOutputColumn](
	[pkID] [int] IDENTITY(1,1) NOT NULL,
	[fkReport] [int] NOT NULL,
	[ColumnName] [nvarchar](60) NOT NULL,
	[Flags] [int] NOT NULL,
	[DBType] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_ReportOutputColumn] PRIMARY KEY CLUSTERED 
(
	[pkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ReportOutputColumn]  WITH CHECK ADD FOREIGN KEY([fkReport])
REFERENCES [dbo].[Report] ([pkID])
GO

