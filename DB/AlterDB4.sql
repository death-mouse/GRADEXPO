USE [GREXPO]
GO

ALTER TABLE [dbo].[Visit] DROP CONSTRAINT [PlanVisit_Visit_FK1]
GO

ALTER TABLE [dbo].[PlanVisit] DROP CONSTRAINT [Vendor_PlanVisit_FK1]
GO

ALTER TABLE [dbo].[PlanVisit] DROP CONSTRAINT [Stand_PlanVisit_FK1]
GO

ALTER TABLE [dbo].[PlanVisit] DROP CONSTRAINT [Expo_PlanVisit_FK1]
GO

/****** Object:  Table [dbo].[PlanVisit]    Script Date: 27.08.2018 18:18:42 ******/
DROP TABLE [dbo].[PlanVisit]
GO

/****** Object:  Table [dbo].[PlanVisit]    Script Date: 27.08.2018 18:18:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlanVisit](
	[planVisitId] [int] identity NOT NULL,
	[planvisitDateTime] [datetime] NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[expoId] [int] NULL,
	[vendorId] [int] NULL,
	[standId] [int] NULL,
 CONSTRAINT [PlanVisit_PK] PRIMARY KEY CLUSTERED 
(
	[planVisitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[PlanVisit]  WITH CHECK ADD  CONSTRAINT [Expo_PlanVisit_FK1] FOREIGN KEY([expoId])
REFERENCES [dbo].[Expo] ([expoId])
GO

ALTER TABLE [dbo].[PlanVisit] CHECK CONSTRAINT [Expo_PlanVisit_FK1]
GO

ALTER TABLE [dbo].[PlanVisit]  WITH CHECK ADD  CONSTRAINT [Stand_PlanVisit_FK1] FOREIGN KEY([standId])
REFERENCES [dbo].[Stand] ([standId])
GO

ALTER TABLE [dbo].[PlanVisit] CHECK CONSTRAINT [Stand_PlanVisit_FK1]
GO

ALTER TABLE [dbo].[PlanVisit]  WITH CHECK ADD  CONSTRAINT [Vendor_PlanVisit_FK1] FOREIGN KEY([vendorId])
REFERENCES [dbo].[Vendor] ([vendorId])
GO

ALTER TABLE [dbo].[PlanVisit] CHECK CONSTRAINT [Vendor_PlanVisit_FK1]
GO




ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [PlanVisit_Visit_FK1] FOREIGN KEY([planVisitId])
REFERENCES [dbo].[PlanVisit] ([planVisitId])
GO

ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [PlanVisit_Visit_FK1]
GO

