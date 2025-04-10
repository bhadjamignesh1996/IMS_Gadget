USE [GadgetInventoryDB]
GO
/****** Object:  Table [dbo].[Gadgets]    Script Date: 09-04-2025 20:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gadgets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Brand] [nvarchar](100) NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Category] [nvarchar](100) NULL,
	[SecretInfo] [nvarchar](255) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09-04-2025 20:43:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Role] [nvarchar](20) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Gadgets] ON 

INSERT [dbo].[Gadgets] ([Id], [Name], [Brand], [Price], [Quantity], [Description], [Category], [SecretInfo], [CreatedAt], [UpdatedAt]) VALUES (1, N'Smartphone X1', N'TechBrand', CAST(499.99 AS Decimal(10, 2)), 50, N'A high-end smartphone with OLED display', N'Mobile', N'Confidential chipset specs', CAST(N'2025-04-09T07:43:30.490' AS DateTime), NULL)
INSERT [dbo].[Gadgets] ([Id], [Name], [Brand], [Price], [Quantity], [Description], [Category], [SecretInfo], [CreatedAt], [UpdatedAt]) VALUES (2, N'Wireless Earbuds', N'SoundX', CAST(99.99 AS Decimal(10, 2)), 100, N'Noise cancelling earbuds with long battery life', N'Accessories', N'Proprietary noise-canceling tech', CAST(N'2025-04-09T07:43:30.490' AS DateTime), NULL)
INSERT [dbo].[Gadgets] ([Id], [Name], [Brand], [Price], [Quantity], [Description], [Category], [SecretInfo], [CreatedAt], [UpdatedAt]) VALUES (3, N'Gaming Laptop Z', N'GameTech', CAST(1299.99 AS Decimal(10, 2)), 25, N'High performance gaming laptop with RTX graphics', N'Laptop', N'WTZwcVNaT04lNUNKeTVUWFo2VnNTVVNxV1IlNUQ2UyU1RU9ZaUxPWSU1QkhocXFmZlhaJTdGVnJfT2ZNS1lTJTVCUnFTNVdmaG5aJTdGV01LWSU1Q3AlM0Q4X3BxdWY3bDhnTUtZJTVDcVI3ZiU1QnRxUjUlNUJrJTVDJTVDJTNFa09ZJTVCSlo2bWZPWWlMJTVCblo2VnNXJTdEWjZ1WVlLXyU3Q1lwTkI=', CAST(N'2025-04-09T07:43:30.490' AS DateTime), CAST(N'2025-04-09T19:31:46.843' AS DateTime))
INSERT [dbo].[Gadgets] ([Id], [Name], [Brand], [Price], [Quantity], [Description], [Category], [SecretInfo], [CreatedAt], [UpdatedAt]) VALUES (4, N'Smartwatch Elite', N'TimePro', CAST(199.99 AS Decimal(10, 2)), 75, N'Fitness tracking smartwatch with AMOLED screen', N'Wearables', N'Heart rate sensor algorithm', CAST(N'2025-04-09T07:43:30.490' AS DateTime), NULL)
INSERT [dbo].[Gadgets] ([Id], [Name], [Brand], [Price], [Quantity], [Description], [Category], [SecretInfo], [CreatedAt], [UpdatedAt]) VALUES (5, N'Bluetooth Speaker Mini', N'BoomBox', CAST(49.99 AS Decimal(10, 2)), 150, N'Portable speaker with deep bass and long battery life', N'Accessories', N'Battery optimization firmware', CAST(N'2025-04-09T07:43:30.490' AS DateTime), NULL)
INSERT [dbo].[Gadgets] ([Id], [Name], [Brand], [Price], [Quantity], [Description], [Category], [SecretInfo], [CreatedAt], [UpdatedAt]) VALUES (6, N'Samsung A51', N'SAMSUNG', CAST(45000.00 AS Decimal(10, 2)), 25, N'Samsung Cellphone Important', N'CellPhone', N'WGZyeHpzbCUyNUhqcXF1bXRzag==', CAST(N'2025-04-09T18:55:56.020' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Gadgets] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Email], [PasswordHash], [FullName], [Role], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (1, N'admin01', N'admin01@example.com', N'RmdoJTI5Njc4OQ==', N'Admin One', N'Admin', CAST(N'2025-04-09T17:22:34.733' AS DateTime), NULL, 1)
INSERT [dbo].[Users] ([Id], [Username], [Email], [PasswordHash], [FullName], [Role], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (2, N'user01', N'user01@example.com', N'RmdoJTI5Njc4OQ==', N'User One', N'User', CAST(N'2025-04-09T17:22:34.733' AS DateTime), NULL, 1)
INSERT [dbo].[Users] ([Id], [Username], [Email], [PasswordHash], [FullName], [Role], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (3, N'user02', N'user02@example.com', N'RmdoJTI5Njc4OQ==', N'User Two', N'User', CAST(N'2025-04-09T17:22:34.733' AS DateTime), NULL, 1)
INSERT [dbo].[Users] ([Id], [Username], [Email], [PasswordHash], [FullName], [Role], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (4, N'manager01', N'manager01@example.com', N'RmdoJTI5Njc4OQ==', N'Manager One', N'Manager', CAST(N'2025-04-09T17:22:34.733' AS DateTime), NULL, 1)
INSERT [dbo].[Users] ([Id], [Username], [Email], [PasswordHash], [FullName], [Role], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (5, N'guest01', N'guest01@example.com', N'RmdoJTI5Njc4OQ==', N'Guest User', N'Guest', CAST(N'2025-04-09T17:22:34.733' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E49E9AB27E]    Script Date: 09-04-2025 20:43:32 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D1053489B7BF9A]    Script Date: 09-04-2025 20:43:32 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Gadgets] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('User') FOR [Role]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [IsActive]
GO
