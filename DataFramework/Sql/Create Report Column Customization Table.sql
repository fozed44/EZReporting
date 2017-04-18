CREATE TABLE [dbo].[ReportOutputColumnCustomization](
	[pkID] [int] IDENTITY(1,1) NOT NULL,
	[fkReport]   [int] NOT NULL,
	[fkUser]	 [int] NOT NULL,
	[ColumnName] [nvarchar](60) NOT NULL,
	[Position] [int] NOT NULL,
	[Flags] [int] NOT NULL,
	CONSTRAINT [PK_ReportOutputColumnCustomization] PRIMARY KEY(pkID),
	FOREIGN KEY (fkReport) REFERENCES Report(pkID)
)