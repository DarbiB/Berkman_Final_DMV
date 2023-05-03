USE [master]
GO
/****** Object:  Database [DMV]    Script Date: 5/2/2023 10:37:15 PM ******/
CREATE DATABASE [DMV]
 
GO

USE [DMV]
GO

CREATE TABLE [dbo].[Drivers](
	[DriverId] [varchar](8) NOT NULL,
	[DriverFirstName] [varchar](50) NOT NULL,
	[DriverLastName] [varchar](50) NOT NULL,
	[DriverSSN] [varchar](11) NOT NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[DriverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DriversInfractions]    Script Date: 5/2/2023 10:37:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DriversInfractions](
	[InfractionId] [varchar](8) NOT NULL,
	[DriverId] [varchar](8) NOT NULL,
	[PersonnelId] [varchar](8) NOT NULL,
	[VehicleId] [varchar](8) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_DriversInfractions] PRIMARY KEY CLUSTERED 
(
	[InfractionId] ASC,
	[DriverId] ASC,
	[PersonnelId] ASC,
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Infractions]    Script Date: 5/2/2023 10:37:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Infractions](
	[InfractionId] [varchar](8) NOT NULL,
	[InfractionType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Infractions] PRIMARY KEY CLUSTERED 
(
	[InfractionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 5/2/2023 10:37:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personnel](
	[PersonnelId] [varchar](8) NOT NULL,
	[PersonnelFirstName] [varchar](50) NOT NULL,
	[PersonnelLastName] [varchar](50) NOT NULL,
	[PersonnelTitle] [varchar](50) NOT NULL,
	[PersonnelUsername] [varchar](50) NOT NULL,
	[PersonnelPassword] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Personnel] PRIMARY KEY CLUSTERED 
(
	[PersonnelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 5/2/2023 10:37:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleId] [varchar](8) NOT NULL,
	[DriverId] [varchar](8) NOT NULL,
	[VehiclePlate] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D001', N'Luna', N'Patel', N'111-11-1111')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D002', N'Hector', N'Gomez', N'222-22-2222')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D003', N'Maya', N'Chen', N'333-33-3333')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D004', N'Alexander', N'Cooper', N'444-44-4444')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D005', N'Isla', N'Fischer', N'555-55-5555')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D006', N'Jacoby', N'Davis', N'666-66-6666')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D007', N'Olivia', N'Nguyen', N'777-77-7777')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D008', N'Mason', N'Singh', N'888-88-8888')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D009', N'Amelia', N'Carter', N'999-99-9999')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D010', N'Kai', N'Williams', N'101-10-1010')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D011', N'Jesse', N'Schultz', N'882-47-1489')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D012', N'Amanda', N'Jones', N'898-33-3333')
GO
INSERT [dbo].[Drivers] ([DriverId], [DriverFirstName], [DriverLastName], [DriverSSN]) VALUES (N'D013', N'Norman', N'Dons', N'323-32-3232')
GO
INSERT [dbo].[DriversInfractions] ([InfractionId], [DriverId], [PersonnelId], [VehicleId], [Date]) VALUES (N'I001', N'D001', N'P006', N'V001', CAST(N'2022-07-06' AS Date))
GO
INSERT [dbo].[DriversInfractions] ([InfractionId], [DriverId], [PersonnelId], [VehicleId], [Date]) VALUES (N'I001', N'D002', N'P008', N'V002', CAST(N'2022-05-08' AS Date))
GO
INSERT [dbo].[DriversInfractions] ([InfractionId], [DriverId], [PersonnelId], [VehicleId], [Date]) VALUES (N'I002', N'D002', N'P007', N'V002', CAST(N'2021-09-18' AS Date))
GO
INSERT [dbo].[DriversInfractions] ([InfractionId], [DriverId], [PersonnelId], [VehicleId], [Date]) VALUES (N'I003', N'D003', N'P008', N'V003', CAST(N'2023-04-26' AS Date))
GO
INSERT [dbo].[DriversInfractions] ([InfractionId], [DriverId], [PersonnelId], [VehicleId], [Date]) VALUES (N'I004', N'D004', N'P009', N'V004', CAST(N'2023-05-01' AS Date))
GO
INSERT [dbo].[DriversInfractions] ([InfractionId], [DriverId], [PersonnelId], [VehicleId], [Date]) VALUES (N'I005', N'D005', N'P010', N'V005', CAST(N'2021-01-08' AS Date))
GO
INSERT [dbo].[DriversInfractions] ([InfractionId], [DriverId], [PersonnelId], [VehicleId], [Date]) VALUES (N'I006', N'D006', N'P006', N'V006', CAST(N'2020-08-07' AS Date))
GO
INSERT [dbo].[DriversInfractions] ([InfractionId], [DriverId], [PersonnelId], [VehicleId], [Date]) VALUES (N'I007', N'D007', N'P007', N'V007', CAST(N'2023-02-16' AS Date))
GO
INSERT [dbo].[DriversInfractions] ([InfractionId], [DriverId], [PersonnelId], [VehicleId], [Date]) VALUES (N'I008', N'D008', N'P008', N'V008', CAST(N'2020-10-17' AS Date))
GO
INSERT [dbo].[DriversInfractions] ([InfractionId], [DriverId], [PersonnelId], [VehicleId], [Date]) VALUES (N'I009', N'D009', N'P009', N'V009', CAST(N'2021-01-10' AS Date))
GO
INSERT [dbo].[DriversInfractions] ([InfractionId], [DriverId], [PersonnelId], [VehicleId], [Date]) VALUES (N'I010', N'D010', N'P010', N'V010', CAST(N'2019-10-15' AS Date))
GO
INSERT [dbo].[Infractions] ([InfractionId], [InfractionType]) VALUES (N'I001', N'Speeding')
GO
INSERT [dbo].[Infractions] ([InfractionId], [InfractionType]) VALUES (N'I002', N'Running Red Light or Stop Sign')
GO
INSERT [dbo].[Infractions] ([InfractionId], [InfractionType]) VALUES (N'I003', N'Reckless Driving')
GO
INSERT [dbo].[Infractions] ([InfractionId], [InfractionType]) VALUES (N'I004', N'Failure to Yield')
GO
INSERT [dbo].[Infractions] ([InfractionId], [InfractionType]) VALUES (N'I005', N'Improper Lane Usage')
GO
INSERT [dbo].[Infractions] ([InfractionId], [InfractionType]) VALUES (N'I006', N'Driving Under the Influence')
GO
INSERT [dbo].[Infractions] ([InfractionId], [InfractionType]) VALUES (N'I007', N'Driving with Suspended or Revoked License')
GO
INSERT [dbo].[Infractions] ([InfractionId], [InfractionType]) VALUES (N'I008', N'Failure to Wear Seatbelt')
GO
INSERT [dbo].[Infractions] ([InfractionId], [InfractionType]) VALUES (N'I009', N'Distracted Driving')
GO
INSERT [dbo].[Infractions] ([InfractionId], [InfractionType]) VALUES (N'I010', N'Illegal U-Turn')
GO
INSERT [dbo].[Personnel] ([PersonnelId], [PersonnelFirstName], [PersonnelLastName], [PersonnelTitle], [PersonnelUsername], [PersonnelPassword]) VALUES (N'P001', N'Blake', N'Hernandez', N'DMV', N'bhernandez', N'bhernandez')
GO
INSERT [dbo].[Personnel] ([PersonnelId], [PersonnelFirstName], [PersonnelLastName], [PersonnelTitle], [PersonnelUsername], [PersonnelPassword]) VALUES (N'P002', N'Nora', N'Kim', N'DMV', N'nkim', N'nkim')
GO
INSERT [dbo].[Personnel] ([PersonnelId], [PersonnelFirstName], [PersonnelLastName], [PersonnelTitle], [PersonnelUsername], [PersonnelPassword]) VALUES (N'P003', N'Lucas', N'Patel', N'DMV', N'lpatel', N'lpatel')
GO
INSERT [dbo].[Personnel] ([PersonnelId], [PersonnelFirstName], [PersonnelLastName], [PersonnelTitle], [PersonnelUsername], [PersonnelPassword]) VALUES (N'P004', N'Ava', N'Stewart', N'DMV', N'astewart', N'astewart')
GO
INSERT [dbo].[Personnel] ([PersonnelId], [PersonnelFirstName], [PersonnelLastName], [PersonnelTitle], [PersonnelUsername], [PersonnelPassword]) VALUES (N'P005', N'Jaxon', N'Lee', N'DMV', N'jlee', N'jlee')
GO
INSERT [dbo].[Personnel] ([PersonnelId], [PersonnelFirstName], [PersonnelLastName], [PersonnelTitle], [PersonnelUsername], [PersonnelPassword]) VALUES (N'P006', N'Eva', N'Davis', N'Law Enforcement', N'edavis', N'edavis')
GO
INSERT [dbo].[Personnel] ([PersonnelId], [PersonnelFirstName], [PersonnelLastName], [PersonnelTitle], [PersonnelUsername], [PersonnelPassword]) VALUES (N'P007', N'Miles', N'Rivera', N'Law Enforcement', N'mrivera', N'mrivera')
GO
INSERT [dbo].[Personnel] ([PersonnelId], [PersonnelFirstName], [PersonnelLastName], [PersonnelTitle], [PersonnelUsername], [PersonnelPassword]) VALUES (N'P008', N'Harper', N'Wong', N'Law Enforcement', N'hwong', N'hwong')
GO
INSERT [dbo].[Personnel] ([PersonnelId], [PersonnelFirstName], [PersonnelLastName], [PersonnelTitle], [PersonnelUsername], [PersonnelPassword]) VALUES (N'P009', N'Logan', N'Mitchell', N'Law Enforcement', N'lmitchell', N'lmitchell')
GO
INSERT [dbo].[Personnel] ([PersonnelId], [PersonnelFirstName], [PersonnelLastName], [PersonnelTitle], [PersonnelUsername], [PersonnelPassword]) VALUES (N'P010', N'Zoey', N'Anderson', N'Law Enforcement', N'zanderson', N'zanderson')
GO
INSERT [dbo].[Vehicles] ([VehicleId], [DriverId], [VehiclePlate]) VALUES (N'V001', N'D001', N'123456')
GO
INSERT [dbo].[Vehicles] ([VehicleId], [DriverId], [VehiclePlate]) VALUES (N'V002', N'D002', N'234567')
GO
INSERT [dbo].[Vehicles] ([VehicleId], [DriverId], [VehiclePlate]) VALUES (N'V003', N'D003', N'345678')
GO
INSERT [dbo].[Vehicles] ([VehicleId], [DriverId], [VehiclePlate]) VALUES (N'V004', N'D004', N'456789')
GO
INSERT [dbo].[Vehicles] ([VehicleId], [DriverId], [VehiclePlate]) VALUES (N'V005', N'D005', N'567890')
GO
INSERT [dbo].[Vehicles] ([VehicleId], [DriverId], [VehiclePlate]) VALUES (N'V006', N'D006', N'678901')
GO
INSERT [dbo].[Vehicles] ([VehicleId], [DriverId], [VehiclePlate]) VALUES (N'V007', N'D007', N'789101')
GO
INSERT [dbo].[Vehicles] ([VehicleId], [DriverId], [VehiclePlate]) VALUES (N'V008', N'D008', N'891011')
GO
INSERT [dbo].[Vehicles] ([VehicleId], [DriverId], [VehiclePlate]) VALUES (N'V009', N'D009', N'910111')
GO
INSERT [dbo].[Vehicles] ([VehicleId], [DriverId], [VehiclePlate]) VALUES (N'V010', N'D010', N'101112')
GO
ALTER TABLE [dbo].[DriversInfractions]  WITH CHECK ADD  CONSTRAINT [FK_DriversInfractions_Drivers] FOREIGN KEY([DriverId])
REFERENCES [dbo].[Drivers] ([DriverId])
GO
ALTER TABLE [dbo].[DriversInfractions] CHECK CONSTRAINT [FK_DriversInfractions_Drivers]
GO
ALTER TABLE [dbo].[DriversInfractions]  WITH CHECK ADD  CONSTRAINT [FK_DriversInfractions_Infractions] FOREIGN KEY([InfractionId])
REFERENCES [dbo].[Infractions] ([InfractionId])
GO
ALTER TABLE [dbo].[DriversInfractions] CHECK CONSTRAINT [FK_DriversInfractions_Infractions]
GO
ALTER TABLE [dbo].[DriversInfractions]  WITH CHECK ADD  CONSTRAINT [FK_DriversInfractions_Personnel] FOREIGN KEY([PersonnelId])
REFERENCES [dbo].[Personnel] ([PersonnelId])
GO
ALTER TABLE [dbo].[DriversInfractions] CHECK CONSTRAINT [FK_DriversInfractions_Personnel]
GO
ALTER TABLE [dbo].[DriversInfractions]  WITH CHECK ADD  CONSTRAINT [FK_DriversInfractions_Vehicles] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([VehicleId])
GO
ALTER TABLE [dbo].[DriversInfractions] CHECK CONSTRAINT [FK_DriversInfractions_Vehicles]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Drivers] FOREIGN KEY([DriverId])
REFERENCES [dbo].[Drivers] ([DriverId])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Drivers]
GO
ALTER TABLE [dbo].[Drivers]  WITH CHECK ADD  CONSTRAINT [CK_Drivers] CHECK  (([DriverId] like 'D%'))
GO
ALTER TABLE [dbo].[Drivers] CHECK CONSTRAINT [CK_Drivers]
GO
ALTER TABLE [dbo].[Drivers]  WITH CHECK ADD  CONSTRAINT [CK_Drivers_1] CHECK  (([DriverSSN] like '[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Drivers] CHECK CONSTRAINT [CK_Drivers_1]
GO
ALTER TABLE [dbo].[DriversInfractions]  WITH CHECK ADD  CONSTRAINT [CK_DriversInfractions] CHECK  (([DriverId] like 'D%'))
GO
ALTER TABLE [dbo].[DriversInfractions] CHECK CONSTRAINT [CK_DriversInfractions]
GO
ALTER TABLE [dbo].[DriversInfractions]  WITH CHECK ADD  CONSTRAINT [CK_DriversInfractions_1] CHECK  (([PersonnelId] like 'P%'))
GO
ALTER TABLE [dbo].[DriversInfractions] CHECK CONSTRAINT [CK_DriversInfractions_1]
GO
ALTER TABLE [dbo].[DriversInfractions]  WITH CHECK ADD  CONSTRAINT [CK_DriversInfractions_2] CHECK  (([VehicleId] like 'V%'))
GO
ALTER TABLE [dbo].[DriversInfractions] CHECK CONSTRAINT [CK_DriversInfractions_2]
GO
ALTER TABLE [dbo].[DriversInfractions]  WITH CHECK ADD  CONSTRAINT [CK_DriversInfractions_3] CHECK  (([InfractionId] like 'I%'))
GO
ALTER TABLE [dbo].[DriversInfractions] CHECK CONSTRAINT [CK_DriversInfractions_3]
GO
ALTER TABLE [dbo].[Infractions]  WITH CHECK ADD  CONSTRAINT [CK_Infractions] CHECK  (([InfractionID] like 'I%'))
GO
ALTER TABLE [dbo].[Infractions] CHECK CONSTRAINT [CK_Infractions]
GO
ALTER TABLE [dbo].[Personnel]  WITH CHECK ADD  CONSTRAINT [CK_Personnel] CHECK  (([PersonnelId] like 'P%'))
GO
ALTER TABLE [dbo].[Personnel] CHECK CONSTRAINT [CK_Personnel]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [CK_Vehicles] CHECK  (([VehicleId] like 'V%'))
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [CK_Vehicles]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [CK_Vehicles_1] CHECK  (([DriverId] like 'D%'))
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [CK_Vehicles_1]
GO
USE [master]
GO
ALTER DATABASE [DMV] SET  READ_WRITE 
GO
