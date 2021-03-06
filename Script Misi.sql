USE [Misi]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[idEmpeado] [int] NOT NULL,
	[QueHizo] [char](100) NOT NULL,
	[Donde] [char](100) NOT NULL,
	[PorQue] [char](250) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[idMed] [int] NOT NULL,
	[idVen] [int] NOT NULL,
	[Cantidad] [numeric](10, 2) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Precio] [numeric](10, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [char](100) NOT NULL,
	[Ap] [char](100) NOT NULL,
	[Am] [char](100) NOT NULL,
	[Edad] [int] NOT NULL,
	[Sexo] [char](1) NOT NULL,
	[Telefono] [char](10) NOT NULL,
	[Direccion] [char](100) NOT NULL,
	[Estado] [char](100) NOT NULL,
	[Ciudad] [char](100) NOT NULL,
	[RFC] [char](13) NOT NULL,
	[Tipo] [int] NULL,
	[Foto] [text] NULL,
	[Contraseña] [char](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrega]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrega](
	[CodigoProv] [int] NOT NULL,
	[CodigoPed] [int] NOT NULL,
	[Medicamento] [char](100) NULL,
	[Cantidad] [int] NULL,
	[FechaEntrega] [datetime] NULL,
	[IDempleado] [int] NULL,
	[IDmed] [int] NULL,
	[Precio] [numeric](10, 2) NULL,
	[FechaCad] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[CodigoMed] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [char](100) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [numeric](10, 2) NOT NULL,
	[Estado] [int] NOT NULL,
	[FechaCad] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodigoMed] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProv] [int] NOT NULL,
	[CodigoEmp] [int] NOT NULL,
	[Medicamentos] [char](999) NOT NULL,
	[TotalMedicamentos] [int] NOT NULL,
	[MontoTotal] [numeric](10, 2) NOT NULL,
	[Fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [char](100) NOT NULL,
	[Direccion] [char](250) NOT NULL,
	[Telefono] [char](10) NOT NULL,
	[Email] [char](120) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[IdEmpleado] [int] NOT NULL,
	[MontoAcumulado] [numeric](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([Codigo], [idEmpeado], [QueHizo], [Donde], [PorQue], [FechaHora]) VALUES (2, 1, N'Recibió Pedido                                                                                      ', N'Almacen                                                                                             ', N'Reabastecimiento de medicamento                                                                                                                                                                                                                           ', CAST(N'2021-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Codigo], [idEmpeado], [QueHizo], [Donde], [PorQue], [FechaHora]) VALUES (3, 1, N'Recibió Pedido                                                                                      ', N'Almacen                                                                                             ', N'Reabastecimiento de medicamento                                                                                                                                                                                                                           ', CAST(N'2021-12-12T05:24:00.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Codigo], [idEmpeado], [QueHizo], [Donde], [PorQue], [FechaHora]) VALUES (4, 1, N'Recibió Pedido                                                                                      ', N'Almacen                                                                                             ', N'Reabastecimiento de medicamento                                                                                                                                                                                                                           ', CAST(N'2021-12-12T05:39:00.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Codigo], [idEmpeado], [QueHizo], [Donde], [PorQue], [FechaHora]) VALUES (5, 1, N'Borro un producto                                                                                   ', N'En la base de datos                                                                                 ', N'Motivo                                                                                                                                                                                                                                                    ', CAST(N'2021-12-12T20:49:12.883' AS DateTime))
INSERT [dbo].[Bitacora] ([Codigo], [idEmpeado], [QueHizo], [Donde], [PorQue], [FechaHora]) VALUES (6, 1, N'Dio de ALTA al Empleado: prueba1                                                                    ', N'Altas Empleados                                                                                     ', N'Motivo                                                                                                                                                                                                                                                    ', CAST(N'2021-12-12T20:52:11.577' AS DateTime))
INSERT [dbo].[Bitacora] ([Codigo], [idEmpeado], [QueHizo], [Donde], [PorQue], [FechaHora]) VALUES (7, 1, N'Cambio datos al Empleado: 2                                                                         ', N'Cambios Empleados                                                                                   ', N'Motivo                                                                                                                                                                                                                                                    ', CAST(N'2021-12-12T20:52:32.890' AS DateTime))
INSERT [dbo].[Bitacora] ([Codigo], [idEmpeado], [QueHizo], [Donde], [PorQue], [FechaHora]) VALUES (8, 1, N'Borro a un empleado                                                                                 ', N'En la base de datos                                                                                 ', N'Motivo                                                                                                                                                                                                                                                    ', CAST(N'2021-12-12T20:52:39.673' AS DateTime))
INSERT [dbo].[Bitacora] ([Codigo], [idEmpeado], [QueHizo], [Donde], [PorQue], [FechaHora]) VALUES (9, 1, N'Borro un proveedor                                                                                  ', N'En la base de datos                                                                                 ', N'Motivo                                                                                                                                                                                                                                                    ', CAST(N'2021-12-12T21:00:20.247' AS DateTime))
INSERT [dbo].[Bitacora] ([Codigo], [idEmpeado], [QueHizo], [Donde], [PorQue], [FechaHora]) VALUES (10, 1, N'Dio de ALTA al Empleado: prueba                                                                     ', N'Altas Empleados                                                                                     ', N'Motivo                                                                                                                                                                                                                                                    ', CAST(N'2021-12-13T14:44:18.043' AS DateTime))
INSERT [dbo].[Bitacora] ([Codigo], [idEmpeado], [QueHizo], [Donde], [PorQue], [FechaHora]) VALUES (11, 1, N'Cambio datos al Empleado: 3                                                                         ', N'Cambios Empleados                                                                                   ', N'Motivo                                                                                                                                                                                                                                                    ', CAST(N'2021-12-13T14:44:37.140' AS DateTime))
INSERT [dbo].[Bitacora] ([Codigo], [idEmpeado], [QueHizo], [Donde], [PorQue], [FechaHora]) VALUES (12, 1, N'Borro a un empleado                                                                                 ', N'En la base de datos                                                                                 ', N'Motivo                                                                                                                                                                                                                                                    ', CAST(N'2021-12-13T14:44:44.507' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 6, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-11' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1002, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (2, 1002, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(30.45 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1003, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (2, 1003, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(30.45 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1005, CAST(2.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(31.00 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (2, 1005, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(30.45 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1005, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1018, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1019, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1020, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1021, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1023, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1024, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (2, 1024, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(30.45 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1025, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1004, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (2, 1004, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(30.45 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1022, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (1, 1026, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[DetalleVenta] ([idMed], [idVen], [Cantidad], [Fecha], [Precio]) VALUES (2, 1026, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-13' AS Date), CAST(30.45 AS Numeric(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([Codigo], [Nombre], [Ap], [Am], [Edad], [Sexo], [Telefono], [Direccion], [Estado], [Ciudad], [RFC], [Tipo], [Foto], [Contraseña]) VALUES (1, N'prueba                                                                                              ', N'prueba                                                                                              ', N'prueba                                                                                              ', 30, N'M', N'8711416920', N'prueba                                                                                              ', N'prueba                                                                                              ', N'prueba                                                                                              ', N'prueba       ', 1, NULL, N'prueba123           ')
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
INSERT [dbo].[Entrega] ([CodigoProv], [CodigoPed], [Medicamento], [Cantidad], [FechaEntrega], [IDempleado], [IDmed], [Precio], [FechaCad]) VALUES (1, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Entrega] ([CodigoProv], [CodigoPed], [Medicamento], [Cantidad], [FechaEntrega], [IDempleado], [IDmed], [Precio], [FechaCad]) VALUES (1, 3, N'peptobismol                                                                                         ', 100, CAST(N'2021-12-12T05:39:00.000' AS DateTime), 1, NULL, CAST(30.45 AS Numeric(10, 2)), CAST(N'2024-01-20' AS Date))
INSERT [dbo].[Entrega] ([CodigoProv], [CodigoPed], [Medicamento], [Cantidad], [FechaEntrega], [IDempleado], [IDmed], [Precio], [FechaCad]) VALUES (1, 5, N'paracetamol                                                                                         ', 1, CAST(N'2021-12-12T05:24:00.000' AS DateTime), 1, 1, CAST(15.50 AS Numeric(10, 2)), CAST(N'2024-10-11' AS Date))
INSERT [dbo].[Entrega] ([CodigoProv], [CodigoPed], [Medicamento], [Cantidad], [FechaEntrega], [IDempleado], [IDmed], [Precio], [FechaCad]) VALUES (1, 6, N'paracetamol                                                                                         ', 1, CAST(N'2021-12-12T00:00:00.000' AS DateTime), 1, 1, CAST(15.50 AS Numeric(10, 2)), CAST(N'2024-10-11' AS Date))
INSERT [dbo].[Entrega] ([CodigoProv], [CodigoPed], [Medicamento], [Cantidad], [FechaEntrega], [IDempleado], [IDmed], [Precio], [FechaCad]) VALUES (1, 8, N'prueba                                                                                              ', 40, CAST(N'2021-12-13T14:42:00.000' AS DateTime), 1, NULL, CAST(12.00 AS Numeric(10, 2)), CAST(N'2025-10-23' AS Date))
INSERT [dbo].[Entrega] ([CodigoProv], [CodigoPed], [Medicamento], [Cantidad], [FechaEntrega], [IDempleado], [IDmed], [Precio], [FechaCad]) VALUES (1, 7, N'Medicasp                                                                                            ', 10, CAST(N'2021-12-13T01:28:00.000' AS DateTime), 1, NULL, CAST(50.00 AS Numeric(10, 2)), CAST(N'2025-10-05' AS Date))
INSERT [dbo].[Entrega] ([CodigoProv], [CodigoPed], [Medicamento], [Cantidad], [FechaEntrega], [IDempleado], [IDmed], [Precio], [FechaCad]) VALUES (1, 7, N'Clavipen                                                                                            ', 50, CAST(N'2021-12-13T01:30:00.000' AS DateTime), 1, NULL, CAST(25.00 AS Numeric(10, 2)), CAST(N'2025-12-05' AS Date))
INSERT [dbo].[Entrega] ([CodigoProv], [CodigoPed], [Medicamento], [Cantidad], [FechaEntrega], [IDempleado], [IDmed], [Precio], [FechaCad]) VALUES (1, 7, N'Portem                                                                                              ', 50, CAST(N'2021-12-13T01:30:00.000' AS DateTime), 1, NULL, CAST(25.00 AS Numeric(10, 2)), CAST(N'2025-12-05' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Inventario] ON 

INSERT [dbo].[Inventario] ([CodigoMed], [Nombre], [Cantidad], [Precio], [Estado], [FechaCad]) VALUES (1, N'Paracetamol                                                                                         ', 286, CAST(15.50 AS Numeric(10, 2)), 1, CAST(N'2030-12-20' AS Date))
INSERT [dbo].[Inventario] ([CodigoMed], [Nombre], [Cantidad], [Precio], [Estado], [FechaCad]) VALUES (2, N'peptobismol                                                                                         ', 94, CAST(30.45 AS Numeric(10, 2)), 1, CAST(N'2024-01-20' AS Date))
INSERT [dbo].[Inventario] ([CodigoMed], [Nombre], [Cantidad], [Precio], [Estado], [FechaCad]) VALUES (4, N'Medicasp                                                                                            ', 10, CAST(50.00 AS Numeric(10, 2)), 1, CAST(N'2025-10-05' AS Date))
INSERT [dbo].[Inventario] ([CodigoMed], [Nombre], [Cantidad], [Precio], [Estado], [FechaCad]) VALUES (5, N'Clavipen                                                                                            ', 50, CAST(25.00 AS Numeric(10, 2)), 1, CAST(N'2025-12-05' AS Date))
INSERT [dbo].[Inventario] ([CodigoMed], [Nombre], [Cantidad], [Precio], [Estado], [FechaCad]) VALUES (6, N'Portem                                                                                              ', 50, CAST(25.00 AS Numeric(10, 2)), 1, CAST(N'2025-12-05' AS Date))
INSERT [dbo].[Inventario] ([CodigoMed], [Nombre], [Cantidad], [Precio], [Estado], [FechaCad]) VALUES (7, N'prueba                                                                                              ', 40, CAST(12.00 AS Numeric(10, 2)), 1, CAST(N'2025-10-23' AS Date))
SET IDENTITY_INSERT [dbo].[Inventario] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([Codigo], [CodigoProv], [CodigoEmp], [Medicamentos], [TotalMedicamentos], [MontoTotal], [Fecha]) VALUES (1, 1, 1, N'1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ', 1, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Pedido] ([Codigo], [CodigoProv], [CodigoEmp], [Medicamentos], [TotalMedicamentos], [MontoTotal], [Fecha]) VALUES (2, 1, 1, N'1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ', 1, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-12T04:24:00.000' AS DateTime))
INSERT [dbo].[Pedido] ([Codigo], [CodigoProv], [CodigoEmp], [Medicamentos], [TotalMedicamentos], [MontoTotal], [Fecha]) VALUES (3, 1, 1, N'1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ', 1, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-12T04:26:00.000' AS DateTime))
INSERT [dbo].[Pedido] ([Codigo], [CodigoProv], [CodigoEmp], [Medicamentos], [TotalMedicamentos], [MontoTotal], [Fecha]) VALUES (5, 1, 1, N'1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ', 1, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-12T04:32:00.000' AS DateTime))
INSERT [dbo].[Pedido] ([Codigo], [CodigoProv], [CodigoEmp], [Medicamentos], [TotalMedicamentos], [MontoTotal], [Fecha]) VALUES (6, 1, 1, N'1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ', 1, CAST(1.00 AS Numeric(10, 2)), CAST(N'2021-12-12T04:40:00.000' AS DateTime))
INSERT [dbo].[Pedido] ([Codigo], [CodigoProv], [CodigoEmp], [Medicamentos], [TotalMedicamentos], [MontoTotal], [Fecha]) VALUES (7, 1, 1, N'1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ', 10, CAST(50.00 AS Numeric(10, 2)), CAST(N'2021-12-12T23:56:00.000' AS DateTime))
INSERT [dbo].[Pedido] ([Codigo], [CodigoProv], [CodigoEmp], [Medicamentos], [TotalMedicamentos], [MontoTotal], [Fecha]) VALUES (8, 1, 1, N'prueba                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 ', 1, CAST(14.00 AS Numeric(10, 2)), CAST(N'2021-12-13T14:40:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([Codigo], [Nombre], [Direccion], [Telefono], [Email]) VALUES (1, N'prueba1                                                                                             ', N'prueba1                                                                                                                                                                                                                                                   ', N'8723541232', N'prueba1@hotmail.com                                                                                                     ')
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Venta] ON 

INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (2, CAST(N'2021-12-11T03:06:19.000' AS DateTime), 1, CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (6, CAST(N'2021-12-11T03:14:00.000' AS DateTime), 1, CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1002, CAST(N'2021-12-13T00:14:12.000' AS DateTime), 1, CAST(45.95 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1003, CAST(N'2021-12-13T00:21:44.000' AS DateTime), 1, CAST(45.95 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1004, CAST(N'2021-12-13T00:23:32.000' AS DateTime), 1, CAST(45.95 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1005, CAST(N'2021-12-13T00:26:43.000' AS DateTime), 1, CAST(61.45 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1018, CAST(N'2021-12-13T00:55:50.000' AS DateTime), 1, CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1019, CAST(N'2021-12-13T00:57:39.000' AS DateTime), 1, CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1020, CAST(N'2021-12-13T01:00:26.000' AS DateTime), 1, CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1021, CAST(N'2021-12-13T01:01:08.000' AS DateTime), 1, CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1022, CAST(N'2021-12-13T01:01:59.000' AS DateTime), 1, CAST(45.95 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1023, CAST(N'2021-12-13T01:02:48.000' AS DateTime), 1, CAST(45.95 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1024, CAST(N'2021-12-13T01:06:40.000' AS DateTime), 1, CAST(45.95 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1025, CAST(N'2021-12-13T01:09:27.000' AS DateTime), 1, CAST(15.50 AS Numeric(10, 2)))
INSERT [dbo].[Venta] ([Codigo], [Fecha], [IdEmpleado], [MontoAcumulado]) VALUES (1026, CAST(N'2021-12-13T01:10:11.000' AS DateTime), 1, CAST(45.95 AS Numeric(10, 2)))
SET IDENTITY_INSERT [dbo].[Venta] OFF
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD FOREIGN KEY([idEmpeado])
REFERENCES [dbo].[Empleado] ([Codigo])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([idMed])
REFERENCES [dbo].[Inventario] ([CodigoMed])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([idVen])
REFERENCES [dbo].[Venta] ([Codigo])
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD FOREIGN KEY([CodigoPed])
REFERENCES [dbo].[Pedido] ([Codigo])
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD FOREIGN KEY([CodigoProv])
REFERENCES [dbo].[Proveedores] ([Codigo])
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD FOREIGN KEY([IDempleado])
REFERENCES [dbo].[Empleado] ([Codigo])
GO
ALTER TABLE [dbo].[Entrega]  WITH CHECK ADD FOREIGN KEY([IDmed])
REFERENCES [dbo].[Inventario] ([CodigoMed])
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([CodigoEmp])
REFERENCES [dbo].[Empleado] ([Codigo])
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([CodigoProv])
REFERENCES [dbo].[Proveedores] ([Codigo])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([Codigo])
GO
/****** Object:  StoredProcedure [dbo].[SP_Cambia_Producto_Inventario]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Cambia_Producto_Inventario]
(
    @Accion int,
	@idProd int,
	@Nombre char(100),
	@Cantidad int,
	@Precio numeric(10,2),
	@Estado int,
	@Fecha_Cad date

	
)
as
	begin
		begin try
			begin transaction 
		    declare @mensage varchar(50)
			declare @id int
			if(@Accion=1)
			begin
			set @id=(SELECT CodigoMed FROM Inventario WHERE CodigoMed=@idProd)
			if(@id is null)
			begin
				insert into Inventario values(@Nombre,@Cantidad,@Precio, @Estado, @Fecha_Cad)
				set @mensage= 'Dio de ALTA al Producto: '+@Nombre
			end
			
			else 
			begin
				print 'El ID que quieres dar de alta ya existe'
			end
			end
			else
			begin
			if(@Accion=2)
			begin
			set @id=(SELECT CodigoMed FROM Inventario WHERE CodigoMed=@idProd)
			if(@id is not null)
			begin
				update Inventario set Nombre= @Nombre, Cantidad=@Cantidad,Precio=@Precio, Estado= @Estado,FechaCad=@Fecha_Cad
		        where CodigoMed=@idProd
				set @mensage= 'Dio de Cambio al Producto: '+@Nombre
			end
			
			else 
			begin
				print 'Error en el cambio del producto'
			end
			end
			else
			begin
			set @mensage='Error de accion'
			end
			end
			commit transaction
		end try
		begin catch
			rollback transaction
		end catch
	end
GO
/****** Object:  StoredProcedure [dbo].[spACInventario]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spACInventario]
(
	@Codigo int,
    @Nombre	char(100),
	@Cantidad int,
	@Precio numeric(10,2),
	@Estado int,
	@FechaCad date,
	@Accion int,
	@Res int output
)
as
	begin
		begin try
			begin transaction 
				if (@Accion=1)
				begin
					insert into Inventario(Nombre,Cantidad,Precio,Estado,FechaCad)
					values (@Nombre,@Cantidad,@Precio,@Estado,@FechaCad)
					set @Res=1
				end
				else if (@Accion=2)
				begin
					update Inventario set Nombre=@Nombre,Cantidad=@Cantidad,Precio=@Precio,Estado=@Estado,FechaCad=@FechaCad
					set @Res=1
				end
			commit transaction
		end try
		begin catch
				set @res=2
			rollback transaction
		end catch
	end
GO
/****** Object:  StoredProcedure [dbo].[spACProv]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spACProv]
(
	@Codigo int,
    @Nombre	char(100),
	@Direccion char(250),
	@Tel char(10),
	@Email char(120),
	@Accion int,
	@Res int output
)
as
	begin
		begin try
			begin transaction 
				if (@Accion=1)
				begin
					insert into Proveedores (Nombre,Direccion,Telefono,Email)
					values (@Nombre,@Direccion,@Tel,@Email)
					set @Res=1
				end
				else if (@Accion=2)
				begin
					update Proveedores set Nombre=@Nombre,Direccion=@Direccion,Telefono=@Tel,Email=@Email where Codigo=@Codigo
					set @Res=1
				end
			commit transaction
		end try
		begin catch
				set @res=2
			rollback transaction
		end catch
	end
GO
/****** Object:  StoredProcedure [dbo].[spEmpIU]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spEmpIU]
(
	@idResponsable int,
	@codigo int,
	@Nombre char(100),
	@Ap char(100),
	@Am char(100),
	@Edad int,
	@sexo char(1),
	@Telefono char(10),
	@Direccion char(100),
	@Estado char(100),
	@Ciudad char(100),
	@RFC char(13),
	@motivo char(250),
	@tipo int,
	@foto text,
	@Contra char(20),
	@Opcion int,
	@Resul bit output
)
as
	begin
		begin try
			begin transaction 
			if(@Opcion=2)
			begin
				if EXISTS((select Codigo from Empleado where Codigo=@codigo))
				begin
					update Empleado set Nombre=@Nombre,Ap=@Ap,Am=@Am,Edad=@Edad,Sexo=@sexo,Telefono=@Telefono,Direccion=@Direccion,Estado=
					@Estado,Ciudad=@Ciudad,RFC=@RFC,Tipo=@tipo,Foto=@foto, Contraseña=@Contra where Codigo=@codigo
					insert into Bitacora values(@idResponsable,'Cambio datos al Empleado: '+ (select cast(@codigo as varchar(100))),'Cambios Empleados',@motivo,GETDATE())
				end
			end
			else if(@opcion=1)
				begin
					INSERT INTO Empleado VALUES(@Nombre,@Ap,@Am,@Edad,@sexo,@Telefono,@Direccion,@Estado,@Ciudad,@RFC,@tipo,@foto,@Contra)
					insert into Bitacora values(@idResponsable,'Dio de ALTA al Empleado: '+@Nombre,'Altas Empleados',@motivo,GETDATE())
				end
			
			commit transaction
		end try
		begin catch
			rollback transaction
		end catch
	end
GO
/****** Object:  StoredProcedure [dbo].[spLogueo]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spLogueo]
(
	@codigo int,
	@Nombre char(100) output,
	@tipo int output,
	@Contra char(20),
	@Status bit output
)
as
Begin
    Begin Try
	   Begin Transaction
	     set @Tipo=(select Tipo from Empleado where Codigo=@codigo and Contraseña=@Contra)
	     set @Nombre=(select Nombre from Empleado where Codigo=@codigo)
	     set @codigo=(select Tipo from Empleado where Codigo=@codigo and Contraseña=@Contra)
		 Declare @mensaje varchar(50)
		 if(@codigo is null)
		 begin
			print 'Nombre de usuario o contraseña incorectos'
			set @Status='false'
			set @mensaje='Usuario o contraseña incorectos'
			SET @Tipo=''
			set @codigo=''
			set @Nombre=''
		 end
		 else
		 begin
			
			set @Status='true'
			set @mensaje='Bienvenido '
		 end
		 print @mensaje
	   Commit Transaction
	End Try
	Begin Catch
	   Rollback Transaction
	End Catch
End
GO
/****** Object:  Trigger [dbo].[TR_Compra]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[TR_Compra]
on [dbo].[DetalleVenta] for insert
as
set nocount on
update Inventario set Inventario.Cantidad=(Inventario.Cantidad-inserted.Cantidad) 
from inserted inner join Inventario on Inventario.CodigoMed=inserted.idMed 
where Inventario.CodigoMed=inserted.idMed
GO
ALTER TABLE [dbo].[DetalleVenta] ENABLE TRIGGER [TR_Compra]
GO
/****** Object:  Trigger [dbo].[TrEntregaBitacora]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[TrEntregaBitacora] on [dbo].[Entrega]
for update
as
insert into Bitacora 
values((select IDempleado from inserted),'Recibió Pedido', 'Almacen', 'Reabastecimiento de medicamento',
(select FechaEntrega from inserted))
GO
ALTER TABLE [dbo].[Entrega] ENABLE TRIGGER [TrEntregaBitacora]
GO
/****** Object:  Trigger [dbo].[TrEntregaInventario]    Script Date: 14/12/2021 06:16:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[TrEntregaInventario] on [dbo].[Entrega]
after insert
as
declare @idmed int
set @idmed=(select IDmed from inserted)
if exists ((select CodigoMed from Inventario where CodigoMed=@idmed))
begin
	if((select FechaEntrega from inserted)is not null)	
	begin
		declare @cantidad int
		set @cantidad=((select Cantidad from Inventario)+(select Cantidad from inserted))
		update Inventario set Cantidad=@cantidad
	end
end
else
begin
	insert into Inventario (Nombre,Cantidad,Precio,Estado,FechaCad)
	values((select Medicamento from inserted),(select Cantidad from inserted),(select Precio from inserted),
	1,(select FechaCad from inserted))
end
GO
ALTER TABLE [dbo].[Entrega] ENABLE TRIGGER [TrEntregaInventario]
GO
