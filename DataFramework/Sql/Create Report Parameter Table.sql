﻿CREATE TABLE [dbo].[ReportParameter](
	[pkID] [int] IDENTITY(1,1) NOT NULL,
	[fkReport]   [int] NOT NULL,
	[ColumnName] [nvarchar](60) NOT NULL,
	[DisplayName][nvarchar](60) NOT NULL,
	[Flags] [int] NOT NULL,
	CONSTRAINT [PK_ReportParameter] PRIMARY KEY(pkID),
	FOREIGN KEY (fkReport) REFERENCES Report(pkID)
)