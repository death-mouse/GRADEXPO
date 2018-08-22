USE [GREXPO]
GO
/****** Object:  Table [dbo].[Expo]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Expo](
	[expoId] [int] IDENTITY(1,1) NOT NULL,
	[expoName] [varchar](100) NULL,
	[startDate] [datetime] NOT NULL,
	[endDate] [datetime] NOT NULL,
	[description] [varchar](255) NULL,
 CONSTRAINT [Expo_PK] PRIMARY KEY CLUSTERED 
(
	[expoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExpoFiles]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpoFiles](
	[expoId] [int] NOT NULL,
	[fileId] [int] NOT NULL,
 CONSTRAINT [ExpoFiles_PK] PRIMARY KEY CLUSTERED 
(
	[expoId] ASC,
	[fileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[File]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[File](
	[fileId] [int] IDENTITY(1,1) NOT NULL,
	[content] [nvarchar](max) NULL,
	[filename] [varchar](100) NULL,
	[authorId] [int] NULL,
	[dateTime] [datetime] NULL,
 CONSTRAINT [File_PK] PRIMARY KEY CLUSTERED 
(
	[fileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[productId] [int] IDENTITY(1,1) NOT NULL,
	[projectId] [int] NOT NULL,
	[productName] [char](10) NOT NULL,
	[description] [varchar](100) NULL,
 CONSTRAINT [Product_PK] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductFiles]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductFiles](
	[productId] [int] NOT NULL,
	[fileId] [int] NOT NULL,
 CONSTRAINT [ProductFiles_PK] PRIMARY KEY CLUSTERED 
(
	[productId] ASC,
	[fileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSample]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSample](
	[productId] [int] NOT NULL,
	[sampleId] [int] NOT NULL,
 CONSTRAINT [ProductSample_PK] PRIMARY KEY CLUSTERED 
(
	[sampleId] ASC,
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[projectId] [int] IDENTITY(1,1) NOT NULL,
	[projectName] [varchar](100) NOT NULL,
	[projectLogoFileId] [int] NULL,
	[description] [varchar](100) NULL,
 CONSTRAINT [Project_PK] PRIMARY KEY CLUSTERED 
(
	[projectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sample]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sample](
	[sampleId] [int] IDENTITY(1,1) NOT NULL,
	[visitId] [int] NULL,
	[vendorId] [int] NULL,
	[description] [varchar](100) NULL,
	[expoId] [int] NULL,
 CONSTRAINT [Sample_PK] PRIMARY KEY CLUSTERED 
(
	[sampleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SampleFiles]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SampleFiles](
	[fileId] [int] NOT NULL,
	[sampleId] [int] NOT NULL,
 CONSTRAINT [SampleFiles_PK] PRIMARY KEY CLUSTERED 
(
	[fileId] ASC,
	[sampleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stand]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stand](
	[expoId] [int] NOT NULL,
	[vendorId] [int] NOT NULL,
	[standId] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](100) NULL,
	[hall] [varchar](50) NULL,
	[statusId] [int] NULL,
 CONSTRAINT [Stand_PK] PRIMARY KEY CLUSTERED 
(
	[standId] ASC,
	[expoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StandStatus]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StandStatus](
	[statusId] [int] NOT NULL,
	[statusName] [varchar](50) NOT NULL,
 CONSTRAINT [StandStatus_PK] PRIMARY KEY CLUSTERED 
(
	[statusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StandStatusHistory]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StandStatusHistory](
	[standId] [int] NOT NULL,
	[expoId] [int] NOT NULL,
	[datetime] [datetime] NOT NULL,
	[statusId] [int] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [StandStatusHistory_PK] PRIMARY KEY CLUSTERED 
(
	[standId] ASC,
	[expoId] ASC,
	[datetime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[role] [int] NULL,
	[login] [varchar](100) NULL,
	[userName] [varchar](100) NULL,
	[phone] [varchar](100) NULL,
	[email] [varchar](100) NULL,
 CONSTRAINT [User_PK] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserVisits]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserVisits](
	[userId] [int] NOT NULL,
	[visitId] [int] NOT NULL,
 CONSTRAINT [UserVisits_PK] PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[visitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendor](
	[vendorId] [int] IDENTITY(1,1) NOT NULL,
	[vendorName] [varchar](100) NOT NULL,
	[vendAccount] [char](10) NULL,
	[description] [varchar](100) NULL,
 CONSTRAINT [Vendor_PK] PRIMARY KEY CLUSTERED 
(
	[vendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorContacts]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorContacts](
	[contactId] [int] IDENTITY(1,1) NOT NULL,
	[contactPosition] [varchar](100) NULL,
	[contactPerson] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[phone] [varchar](100) NULL,
	[im] [varchar](100) NULL,
	[description] [varchar](100) NULL,
	[vendorId] [int] NULL,
 CONSTRAINT [VendorContacts_PK] PRIMARY KEY CLUSTERED 
(
	[contactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Visit]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Visit](
	[visitId] [int] IDENTITY(1,1) NOT NULL,
	[standId] [int] NULL,
	[visitDateTime] [datetime] NOT NULL,
	[visitType] [int] NOT NULL,
	[authorId] [int] NULL,
	[vendorId] [int] NULL,
	[standPhotoFileId] [int] NULL,
	[visitCardFileId] [int] NULL,
	[expoId] [int] NULL,
	[visitSummary] [varchar](max) NULL,
	[comment] [varchar](max) NULL,
 CONSTRAINT [Visit_PK] PRIMARY KEY CLUSTERED 
(
	[visitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VisitFiles]    Script Date: 22.08.2018 22:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitFiles](
	[fileId] [int] NOT NULL,
	[visitId] [int] NOT NULL,
 CONSTRAINT [VisitFiles_PK] PRIMARY KEY CLUSTERED 
(
	[fileId] ASC,
	[visitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ExpoFiles]  WITH CHECK ADD  CONSTRAINT [Expo_ExpoFiles_FK1] FOREIGN KEY([expoId])
REFERENCES [dbo].[Expo] ([expoId])
GO
ALTER TABLE [dbo].[ExpoFiles] CHECK CONSTRAINT [Expo_ExpoFiles_FK1]
GO
ALTER TABLE [dbo].[ExpoFiles]  WITH CHECK ADD  CONSTRAINT [File_ExpoFiles_FK1] FOREIGN KEY([fileId])
REFERENCES [dbo].[File] ([fileId])
GO
ALTER TABLE [dbo].[ExpoFiles] CHECK CONSTRAINT [File_ExpoFiles_FK1]
GO
ALTER TABLE [dbo].[File]  WITH CHECK ADD  CONSTRAINT [User_File_FK1] FOREIGN KEY([authorId])
REFERENCES [dbo].[User] ([userId])
GO
ALTER TABLE [dbo].[File] CHECK CONSTRAINT [User_File_FK1]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [Project_Product_FK1] FOREIGN KEY([projectId])
REFERENCES [dbo].[Project] ([projectId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [Project_Product_FK1]
GO
ALTER TABLE [dbo].[ProductFiles]  WITH CHECK ADD  CONSTRAINT [File_ProductFiles_FK1] FOREIGN KEY([fileId])
REFERENCES [dbo].[File] ([fileId])
GO
ALTER TABLE [dbo].[ProductFiles] CHECK CONSTRAINT [File_ProductFiles_FK1]
GO
ALTER TABLE [dbo].[ProductFiles]  WITH CHECK ADD  CONSTRAINT [Product_ProductFiles_FK1] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([productId])
GO
ALTER TABLE [dbo].[ProductFiles] CHECK CONSTRAINT [Product_ProductFiles_FK1]
GO
ALTER TABLE [dbo].[ProductSample]  WITH CHECK ADD  CONSTRAINT [Product_ProductSample_FK1] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([productId])
GO
ALTER TABLE [dbo].[ProductSample] CHECK CONSTRAINT [Product_ProductSample_FK1]
GO
ALTER TABLE [dbo].[ProductSample]  WITH CHECK ADD  CONSTRAINT [Sample_ProductSample_FK1] FOREIGN KEY([sampleId])
REFERENCES [dbo].[Sample] ([sampleId])
GO
ALTER TABLE [dbo].[ProductSample] CHECK CONSTRAINT [Sample_ProductSample_FK1]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [File_Project_FK1] FOREIGN KEY([projectLogoFileId])
REFERENCES [dbo].[File] ([fileId])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [File_Project_FK1]
GO
ALTER TABLE [dbo].[Sample]  WITH CHECK ADD  CONSTRAINT [Expo_Sample_FK1] FOREIGN KEY([expoId])
REFERENCES [dbo].[Expo] ([expoId])
GO
ALTER TABLE [dbo].[Sample] CHECK CONSTRAINT [Expo_Sample_FK1]
GO
ALTER TABLE [dbo].[Sample]  WITH CHECK ADD  CONSTRAINT [Vendor_Sample_FK1] FOREIGN KEY([vendorId])
REFERENCES [dbo].[Vendor] ([vendorId])
GO
ALTER TABLE [dbo].[Sample] CHECK CONSTRAINT [Vendor_Sample_FK1]
GO
ALTER TABLE [dbo].[Sample]  WITH CHECK ADD  CONSTRAINT [Visit_Sample_FK1] FOREIGN KEY([visitId])
REFERENCES [dbo].[Visit] ([visitId])
GO
ALTER TABLE [dbo].[Sample] CHECK CONSTRAINT [Visit_Sample_FK1]
GO
ALTER TABLE [dbo].[SampleFiles]  WITH CHECK ADD  CONSTRAINT [File_SampleFiles_FK1] FOREIGN KEY([fileId])
REFERENCES [dbo].[File] ([fileId])
GO
ALTER TABLE [dbo].[SampleFiles] CHECK CONSTRAINT [File_SampleFiles_FK1]
GO
ALTER TABLE [dbo].[SampleFiles]  WITH CHECK ADD  CONSTRAINT [Sample_SampleFiles_FK1] FOREIGN KEY([sampleId])
REFERENCES [dbo].[Sample] ([sampleId])
GO
ALTER TABLE [dbo].[SampleFiles] CHECK CONSTRAINT [Sample_SampleFiles_FK1]
GO
ALTER TABLE [dbo].[Stand]  WITH CHECK ADD  CONSTRAINT [Expo_Stand_FK1] FOREIGN KEY([expoId])
REFERENCES [dbo].[Expo] ([expoId])
GO
ALTER TABLE [dbo].[Stand] CHECK CONSTRAINT [Expo_Stand_FK1]
GO
ALTER TABLE [dbo].[Stand]  WITH CHECK ADD  CONSTRAINT [StandStatus_Stand_FK1] FOREIGN KEY([statusId])
REFERENCES [dbo].[StandStatus] ([statusId])
GO
ALTER TABLE [dbo].[Stand] CHECK CONSTRAINT [StandStatus_Stand_FK1]
GO
ALTER TABLE [dbo].[Stand]  WITH CHECK ADD  CONSTRAINT [Vendor_Stand_FK1] FOREIGN KEY([vendorId])
REFERENCES [dbo].[Vendor] ([vendorId])
GO
ALTER TABLE [dbo].[Stand] CHECK CONSTRAINT [Vendor_Stand_FK1]
GO
ALTER TABLE [dbo].[StandStatusHistory]  WITH CHECK ADD  CONSTRAINT [Stand_StandStatusHistory_FK1] FOREIGN KEY([standId], [expoId])
REFERENCES [dbo].[Stand] ([standId], [expoId])
GO
ALTER TABLE [dbo].[StandStatusHistory] CHECK CONSTRAINT [Stand_StandStatusHistory_FK1]
GO
ALTER TABLE [dbo].[StandStatusHistory]  WITH CHECK ADD  CONSTRAINT [StandStatus_StandStatusHistory_FK1] FOREIGN KEY([statusId])
REFERENCES [dbo].[StandStatus] ([statusId])
GO
ALTER TABLE [dbo].[StandStatusHistory] CHECK CONSTRAINT [StandStatus_StandStatusHistory_FK1]
GO
ALTER TABLE [dbo].[StandStatusHistory]  WITH CHECK ADD  CONSTRAINT [User_StandStatusHistory_FK1] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([userId])
GO
ALTER TABLE [dbo].[StandStatusHistory] CHECK CONSTRAINT [User_StandStatusHistory_FK1]
GO
ALTER TABLE [dbo].[UserVisits]  WITH CHECK ADD  CONSTRAINT [User_UserVisits_FK1] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([userId])
GO
ALTER TABLE [dbo].[UserVisits] CHECK CONSTRAINT [User_UserVisits_FK1]
GO
ALTER TABLE [dbo].[UserVisits]  WITH CHECK ADD  CONSTRAINT [Visit_UserVisits_FK1] FOREIGN KEY([visitId])
REFERENCES [dbo].[Visit] ([visitId])
GO
ALTER TABLE [dbo].[UserVisits] CHECK CONSTRAINT [Visit_UserVisits_FK1]
GO
ALTER TABLE [dbo].[VendorContacts]  WITH CHECK ADD  CONSTRAINT [Vendor_VendorContacts_FK1] FOREIGN KEY([vendorId])
REFERENCES [dbo].[Vendor] ([vendorId])
GO
ALTER TABLE [dbo].[VendorContacts] CHECK CONSTRAINT [Vendor_VendorContacts_FK1]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [Expo_Visit_FK1] FOREIGN KEY([expoId])
REFERENCES [dbo].[Expo] ([expoId])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [Expo_Visit_FK1]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [File_Visit_FK1] FOREIGN KEY([standPhotoFileId])
REFERENCES [dbo].[File] ([fileId])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [File_Visit_FK1]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [File_Visit_FK2] FOREIGN KEY([visitCardFileId])
REFERENCES [dbo].[File] ([fileId])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [File_Visit_FK2]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [Stand_Visit_FK1] FOREIGN KEY([standId], [expoId])
REFERENCES [dbo].[Stand] ([standId], [expoId])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [Stand_Visit_FK1]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [User_Visit_FK1] FOREIGN KEY([authorId])
REFERENCES [dbo].[User] ([userId])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [User_Visit_FK1]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [Vendor_Visit_FK1] FOREIGN KEY([vendorId])
REFERENCES [dbo].[Vendor] ([vendorId])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [Vendor_Visit_FK1]
GO
ALTER TABLE [dbo].[VisitFiles]  WITH CHECK ADD  CONSTRAINT [File_VisitFiles_FK1] FOREIGN KEY([fileId])
REFERENCES [dbo].[File] ([fileId])
GO
ALTER TABLE [dbo].[VisitFiles] CHECK CONSTRAINT [File_VisitFiles_FK1]
GO
ALTER TABLE [dbo].[VisitFiles]  WITH CHECK ADD  CONSTRAINT [Visit_VisitFiles_FK1] FOREIGN KEY([visitId])
REFERENCES [dbo].[Visit] ([visitId])
GO
ALTER TABLE [dbo].[VisitFiles] CHECK CONSTRAINT [Visit_VisitFiles_FK1]
GO
