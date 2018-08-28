USE [GREXPO]
GO

/****** Object:  Index [Stand_PK]    Script Date: 27.08.2018 14:08:24 ******/
ALTER TABLE [dbo].[Stand] DROP CONSTRAINT [Stand_PK]
GO

ALTER TABLE [dbo].[PlanVisit] DROP CONSTRAINT [Stand_PlanVisit_FK1]
GO


ALTER TABLE [dbo].[Visit] DROP CONSTRAINT [Stand_Visit_FK1]
GO

ALTER TABLE [dbo].[StandStatusHistory] DROP CONSTRAINT [Stand_StandStatusHistory_FK1]
GO
/****** Object:  Index [Stand_PK]    Script Date: 27.08.2018 14:08:24 ******/
ALTER TABLE [dbo].[Stand] ADD  CONSTRAINT [Stand_PK] PRIMARY KEY CLUSTERED 
(
	[standId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PlanVisit]  WITH CHECK ADD  CONSTRAINT [Stand_PlanVisit_FK1] FOREIGN KEY([standId])
REFERENCES [dbo].[Stand] ([standId])
GO

ALTER TABLE [dbo].[StandStatusHistory]  WITH CHECK ADD  CONSTRAINT [Stand_StandStatusHistory_FK1] FOREIGN KEY([standId])
REFERENCES [dbo].[Stand] ([standId])
GO


ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [Stand_Visit_FK1] FOREIGN KEY([standId])
REFERENCES [dbo].[Stand] ([standId])
GO