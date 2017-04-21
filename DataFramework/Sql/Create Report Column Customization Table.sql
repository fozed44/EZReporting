USE [EZReporting]
GO

/****** Object:  Table [dbo].[ReportOutputColumnCustomization]    Script Date: 4/21/2017 12:26:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReportOutputColumnCustomization](
	[pkID] [int] IDENTITY(1,1) NOT NULL,
	[fkUser] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[Flags] [int] NOT NULL,
	[DisplayName] [nvarchar](60) NULL,
	[fkColumn] [int] NOT NULL,
	[DisplayType] [nvarchar](60) NULL,
 CONSTRAINT [PK_ReportOutputColumnCustomization] PRIMARY KEY CLUSTERED 
(
	[pkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ReportOutputColumnCustomization]  WITH CHECK ADD  CONSTRAINT [FK_ReportOutputColumnCustomization_ReportOutputColumn] FOREIGN KEY([fkColumn])
REFERENCES [dbo].[ReportOutputColumn] ([pkID])
GO

ALTER TABLE [dbo].[ReportOutputColumnCustomization] CHECK CONSTRAINT [FK_ReportOutputColumnCustomization_ReportOutputColumn]
GO

