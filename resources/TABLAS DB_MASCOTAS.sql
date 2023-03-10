USE [DB_MASCOTAS]
GO
/****** Object:  Table [dbo].[Mascotas]    Script Date: 25/02/2023 19:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mascotas](
	[idMascota] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[descripcion] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Mascotas] PRIMARY KEY CLUSTERED 
(
	[idMascota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 25/02/2023 19:58:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [int] NOT NULL,
	[nombreCompleto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [fk_mascotas_usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [fk_mascotas_usuarios]
GO
