USE [SCAPEDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[documentId] [varchar](500) NOT NULL UNIQUE,
	[firstName] [varchar](500) NOT NULL,
	[lastName] [varchar](500) NOT NULL,
	[email] [varchar](500) NULL,
	[sex] [char] NULL,
	[dateBirth] [datetime]  NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkPlace](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](1000) NOT NULL,
	[address] [varchar](1000) NULL,
	[latitudePosition] [varchar](500) NULL,
	[longitudePosition] [varchar](500) NULL,
	[faceListId] [varchar](500) NULL,
 CONSTRAINT [PK_WorkPlace] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_WorkPlace](
	[idEmployee] [int]  NOT NULL,
	[idWorkPlace] [int]  NOT NULL,
	[startJobDate] [datetime] NULL,
	[endJobDate] [datetime] NULL,
	[schedule] [varchar](500) NULL,
	
 CONSTRAINT [PK_EmployeeWorkPlace] PRIMARY KEY CLUSTERED 
(
	[idEmployee], [idWorkPlace] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[type] [char] NOT NULL,
	[idEmployee] [int] NOT NULL,

 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[image] [varbinary](max) NULL,
	[persistenceFaceId] [varchar](500) NULL,
	[idEmployee] [int] NOT NULL,

 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([id], [documentId], [firstName], [lastName], [email],[sex],[dateBirth]) VALUES (1, 1234, 'Juan', 'Molina', 'juan@gmail.com', 'M', '20120618 10:34:09 AM')
INSERT [dbo].[Employee] ([id], [documentId], [firstName], [lastName], [email],[sex],[dateBirth]) VALUES (2, 12345, 'Pedro', 'Sanchez', 'pedro@gmail.com', 'M', '20120618 10:34:09 AM')

SET IDENTITY_INSERT [dbo].[Employee] OFF

ALTER TABLE [dbo].[Employee_WorkPlace]  WITH NOCHECK ADD  CONSTRAINT [FK_EmployeeWorkPlace] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Employee_WorkPlace] CHECK CONSTRAINT [FK_EmployeeWorkPlace]
GO
ALTER TABLE [dbo].[Employee_WorkPlace]  WITH NOCHECK ADD  CONSTRAINT [FK_WorkPlace] FOREIGN KEY([idWorkPlace])
REFERENCES [dbo].[WorkPlace] ([id])
GO
ALTER TABLE [dbo].[Employee_WorkPlace] CHECK CONSTRAINT [FK_WorkPlace]
GO
ALTER TABLE [dbo].[Attendance]  WITH NOCHECK ADD  CONSTRAINT [FK_Employee] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Employee]

ALTER TABLE [dbo].[Image]  WITH NOCHECK ADD  CONSTRAINT [FK_EmployeeImage] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_EmployeeImage]