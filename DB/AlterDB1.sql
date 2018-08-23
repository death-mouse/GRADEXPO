USE GREXPO
GO
Alter table dbo.Expo add logoFileId int
Alter table dbo.Expo add expoAddress nvarchar(500)
Alter table dbo.Expo add expoCoords geography

go
Alter table [File] add fileType nvarchar(4)
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlanVisit]') AND type in (N'U'))
    DROP TABLE [dbo].[PlanVisit]
GO
CREATE TABLE [dbo].[PlanVisit] (
[planVisitId] int  NOT NULL  
, [planvisitDateTime] datetime  NOT NULL  
, [Comments] nvarchar(max)  NULL  
, [expoId] int  NULL  
, [vendorId] int  NULL  
, [standId] int  NULL  
)
GO

ALTER TABLE [dbo].[PlanVisit] ADD CONSTRAINT [PlanVisit_PK] PRIMARY KEY CLUSTERED (
[planVisitId]
)
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[planUserVisit]') AND type in (N'U'))
    DROP TABLE [dbo].[planUserVisit]
GO
CREATE TABLE [dbo].[planUserVisit] (
[planVisitId] int  NOT NULL  
, [userId] int  NOT NULL  
)
GO

ALTER TABLE [dbo].[planUserVisit] ADD CONSTRAINT [planUserVisit_PK] PRIMARY KEY CLUSTERED (
[planVisitId]
, [userId]
)
GO


Alter TABLE dbo.Visit add planVisitId int
GO

ALTER TABLE [dbo].[Visit] WITH CHECK ADD CONSTRAINT [PlanVisit_Visit_FK1] FOREIGN KEY (
[planVisitId]
)
REFERENCES [dbo].[PlanVisit] (
[planVisitId]
)
ALTER TABLE [dbo].[PlanVisit] WITH CHECK ADD CONSTRAINT [Expo_PlanVisit_FK1] FOREIGN KEY (
[expoId]
)
REFERENCES [dbo].[Expo] (
[expoId]
)
ALTER TABLE [dbo].[PlanVisit] WITH CHECK ADD CONSTRAINT [Stand_PlanVisit_FK1] FOREIGN KEY (
[standId]
, [expoId]
)
REFERENCES [dbo].[Stand] (
[standId]
, [expoId]
)
ALTER TABLE [dbo].[PlanVisit] WITH CHECK ADD CONSTRAINT [Vendor_PlanVisit_FK1] FOREIGN KEY (
[vendorId]
)
REFERENCES [dbo].[Vendor] (
[vendorId]
)
GO