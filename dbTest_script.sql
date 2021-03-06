USE [dbTest]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 02.02.2021 15:35:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ID] [int] NOT NULL,
	[Name] [varchar](100) NULL,
	[BirthDate] [date] NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Address] [varchar](50) NULL,
	[SocialNumber] [varchar](50) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clients] ([ID], [Name], [BirthDate], [PhoneNumber], [Address], [SocialNumber]) VALUES (1, N'Тестовый клиент1', CAST(N'1991-03-08' AS Date), N'123', N'г. Баткен', N'12345678901234')
INSERT [dbo].[Clients] ([ID], [Name], [BirthDate], [PhoneNumber], [Address], [SocialNumber]) VALUES (2, N'Тестовый клиент2', CAST(N'1996-04-20' AS Date), N'456', N'г. Бишкек', N'98765432101234')
INSERT [dbo].[Clients] ([ID], [Name], [BirthDate], [PhoneNumber], [Address], [SocialNumber]) VALUES (3, N'Тестовый клиент3', CAST(N'1995-08-04' AS Date), N'789', N'г. Нарын', N'12345543211234')
INSERT [dbo].[Clients] ([ID], [Name], [BirthDate], [PhoneNumber], [Address], [SocialNumber]) VALUES (4, N'Тестовый клиент4', CAST(N'1989-02-25' AS Date), N'012', N'с. Комсомольское', N'12345671234567')
