USE [Registro_Tiendas]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 18-12-2021 9:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encargado]    Script Date: 18-12-2021 9:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encargado](
	[id_encargado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[telefono] [int] NOT NULL,
	[rut] [varchar](50) NOT NULL,
	[correo] [varchar](60) NULL,
	[contraseña] [varchar](25) NULL,
	[id_rol] [int] NULL,
 CONSTRAINT [PK_Encargado] PRIMARY KEY CLUSTERED 
(
	[id_encargado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 18-12-2021 9:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[id_marca] [int] IDENTITY(1,1) NOT NULL,
	[nombre_marca] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 18-12-2021 9:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre_producto] [varchar](50) NOT NULL,
	[codigo_producto] [varchar](50) NOT NULL,
	[precio_compra] [int] NOT NULL,
	[precio_venta] [int] NOT NULL,
	[descripcion_producto] [varchar](500) NULL,
	[id_marca] [int] NOT NULL,
	[id_tienda] [int] NOT NULL,
	[id_categoria] [int] NOT NULL,
	[fecha_recepcion] [date] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 18-12-2021 9:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[nombre_rol] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 18-12-2021 9:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tienda](
	[id_tienda] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[ubicacion] [varchar](150) NOT NULL,
	[telefono] [int] NOT NULL,
	[correo] [varchar](200) NOT NULL,
	[id_encargado] [int] NULL,
 CONSTRAINT [PK_Tienda] PRIMARY KEY CLUSTERED 
(
	[id_tienda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Encargado]  WITH CHECK ADD  CONSTRAINT [FK_Encargado_Rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Rol] ([id_rol])
GO
ALTER TABLE [dbo].[Encargado] CHECK CONSTRAINT [FK_Encargado_Rol]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categorias] FOREIGN KEY([id_categoria])
REFERENCES [dbo].[Categorias] ([id_categoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categorias]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Marca] FOREIGN KEY([id_marca])
REFERENCES [dbo].[Marca] ([id_marca])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Marca]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Tienda1] FOREIGN KEY([id_tienda])
REFERENCES [dbo].[Tienda] ([id_tienda])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Tienda1]
GO
ALTER TABLE [dbo].[Tienda]  WITH CHECK ADD  CONSTRAINT [FK_Tienda_Encargado] FOREIGN KEY([id_encargado])
REFERENCES [dbo].[Encargado] ([id_encargado])
GO
ALTER TABLE [dbo].[Tienda] CHECK CONSTRAINT [FK_Tienda_Encargado]
GO
