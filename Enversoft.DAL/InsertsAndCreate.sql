CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NULL,
	[Surname] [nvarchar](40) NULL,
	[Mobile] [nvarchar](11) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2023/07/15 03:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NULL,
	[Surname] [nvarchar](40) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Role] [varchar](300) NOT NULL,
	[AccessCode] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 2023/07/15 03:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](300) NULL,
	[Description] [nvarchar](40) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logistics]    Script Date: 2023/07/15 03:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logistics](
	[LogisticsId] [int] IDENTITY(1,1) NOT NULL,
	[VehicleDescription] [nvarchar](300) NOT NULL,
	[VehicleNumberPlate] [varchar](15) NOT NULL,
	[FromString] [varchar](20) NOT NULL,
	[WarehouseFromId] [int] NULL,
	[SupplierFromId] [int] NULL,
	[SupplierCost] [decimal](10, 3) NULL,
	[WarehouseDeliveryId] [int] NOT NULL,
	[WarehouseDispatchDate] [datetime] NULL,
	[DateDelivered] [datetime] NULL,
	[DueDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[LogisticsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2023/07/15 03:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[EmployeeId] [int] NULL,
	[DateFulfilled] [datetime2](7) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[OrderReference] [uniqueidentifier] NOT NULL,
	[VAT] [decimal](18, 2) NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[WarehouseId] [int] NULL,
	[DeliveryAddress] [nvarchar](500) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 2023/07/15 03:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[QuantityReserved] [int] NULL,
	[QuantityPacked] [int] NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockItem]    Script Date: 2023/07/15 03:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockItem](
	[StockItemId] [int] IDENTITY(1,1) NOT NULL,
	[StockItemType] [varchar](100) NOT NULL,
	[WarehouseId] [int] NULL,
	[SupplierId] [int] NULL,
	[LogisticsId] [int] NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 2023/07/15 03:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[Telephone] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierLocation]    Script Date: 2023/07/15 03:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierLocation](
	[SupplierLocationId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierLocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 2023/07/15 03:32:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[WarehouseId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[WarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [Name], [Surname], [Mobile]) VALUES (3, N'Mlando', N'Sikhosana Khoza', N'1111111111')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([ItemId], [ImageName], [Description], [Price], [IsDeleted]) VALUES (1, N'117ac3cc-caf5-4ec3-884c-8405c9d28f69.jpg', N'Apple', CAST(100.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[Item] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderId], [CustomerId], [EmployeeId], [DateFulfilled], [DateCreated], [OrderReference], [VAT], [Subtotal], [GrandTotal], [WarehouseId], [DeliveryAddress], [Latitude], [Longitude]) VALUES (3, 3, NULL, NULL, CAST(N'2023-07-13T20:31:59.0000000' AS DateTime2), N'4794643c-682f-49b3-9f2c-813ca3e8b61c', CAST(0.15 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(575.00 AS Decimal(18, 2)), NULL, N'31 Kenneth Kaunda Road, Athlone, Durban, 4051', -29.8024564, 31.0313645)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItem] ON 

INSERT [dbo].[OrderItem] ([OrderItemId], [OrderId], [ItemId], [Quantity], [Price], [QuantityReserved], [QuantityPacked]) VALUES (3, 3, 1, 5, CAST(100.00 AS Decimal(18, 2)), 0, 0)
SET IDENTITY_INSERT [dbo].[OrderItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (1, 234, N'Eskom Holdings Limited', N'086 0037566')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (2, 939, N'Focus Rooms (Pty) Ltd', N'0820776910')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (3, 34, N'GSM Electro', N'0128110069')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (4, 1264, N'Jody and Herman Investments CC', N'0118864227')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (5, 5667, N'Johan Le Roux Ingenieurswerke', N'0233423390')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (6, 667, N'L. J. Ross t/a Petite Cafe''', N'0117868101')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (7, 45, N'L.A Auto Center  CC t/a LA Body Works', N'0219488412')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (8, 1351, N'LG Tow-In CC', N'0828044026')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (9, 1352, N'LM Greyling t/aThe Electric Advertiser', N'0119545972')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (10, 1437, N'M.H Cloete Enterprises (Pty) Ltd  t/a  Rola Motors', N'0218418300')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (11, 67, N'M.M Hydraulics CC', N'011425 6578')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (12, 1980, N'Phulo Human Capital (Pty) Ltd', N'0114755934')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (13, 345, N'Picaro 115 CC t/a H2O CT Services', N'0216745710')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (14, 2279, N'Safetygrip CC', N'0117086660')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (15, 876, N'Safic (Pty) Ltd', N'0114064000')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (16, 2549, N'The Financial Planning Institute Of Southern Africa', N'0861000374')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (17, 935, N'The Fitment Zone  CC', N'0118234181')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (18, 2693, N'Turnweld Engineering CC', N'0115468790')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (19, 6, N'Tutuka Motor Holdings Pty Ltd t/a Tutuka Motor Lab', N'0117044324')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (20, 134, N'WP Exhaust Brake & Clutch t/a In Focus Fleet Services', N'0219055028')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (21, 3277, N'WP Sekuriteit', N'0233421732')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (22, 53, N'Brietta Trading (Pty) Ltd', N'0115526000')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (23, 392, N'C.N. Braam t/a CNB Electrical Services', N'0832835399')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (24, 625, N'Creative Crew (Pty) Ltd', N'0120040218')
INSERT [dbo].[Supplier] ([SupplierId], [Code], [Name], [Telephone]) VALUES (25, 389, N'Moo Cow Industry', N'0999999999')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Customer__6FAE07824D3A9B73]    Script Date: 2023/07/15 03:32:19 ******/
ALTER TABLE [dbo].[Customer] ADD UNIQUE NONCLUSTERED 
(
	[Mobile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderItem] ADD  DEFAULT ((0)) FOR [QuantityReserved]
GO
ALTER TABLE [dbo].[OrderItem] ADD  DEFAULT ((0)) FOR [QuantityPacked]
GO
ALTER TABLE [dbo].[Logistics]  WITH CHECK ADD FOREIGN KEY([SupplierFromId])
REFERENCES [dbo].[Supplier] ([SupplierId])
GO
ALTER TABLE [dbo].[Logistics]  WITH CHECK ADD FOREIGN KEY([WarehouseFromId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
GO
ALTER TABLE [dbo].[Logistics]  WITH CHECK ADD FOREIGN KEY([WarehouseDeliveryId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Orders_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Orders_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Items_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItems_Items_ItemId]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItems_Orders_OrderId]
GO
ALTER TABLE [dbo].[StockItem]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
GO
ALTER TABLE [dbo].[StockItem]  WITH CHECK ADD FOREIGN KEY([LogisticsId])
REFERENCES [dbo].[Logistics] ([LogisticsId])
GO
ALTER TABLE [dbo].[StockItem]  WITH CHECK ADD FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
GO
ALTER TABLE [dbo].[StockItem]  WITH CHECK ADD FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
GO
ALTER TABLE [dbo].[StockItem]  WITH CHECK ADD FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([WarehouseId])
GO
ALTER TABLE [dbo].[SupplierLocation]  WITH CHECK ADD FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
GO
