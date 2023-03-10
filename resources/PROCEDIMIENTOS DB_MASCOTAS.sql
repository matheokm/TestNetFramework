USE [DB_MASCOTAS]
GO
/****** Object:  StoredProcedure [dbo].[Mascota_Add]    Script Date: 25/02/2023 21:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mascota_Add]
@userId int,
@nombre varchar(50),
@edad int NULL,
@desc varchar(MAX) NULL
AS
INSERT INTO [dbo].[Mascotas] (idUsuario, nombre, edad, descripcion)
VALUES (@userId, @nombre, @edad, @desc)
SELECT 'REGISTRADO CON EXITO' Validacion
GO
/****** Object:  StoredProcedure [dbo].[Mascota_All]    Script Date: 25/02/2023 21:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mascota_All]
AS
SELECT * FROM [dbo].[Mascotas]
ORDER BY idMascota ASC 
GO
/****** Object:  StoredProcedure [dbo].[Mascota_Delete]    Script Date: 25/02/2023 21:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mascota_Delete]
@id int
AS
DELETE FROM [dbo].[Mascotas] 
WHERE idMascota= @id
SELECT 'ELIMINADO CON EXITO' Validacion
GO
/****** Object:  StoredProcedure [dbo].[Mascota_Update]    Script Date: 25/02/2023 21:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Mascota_Update]
@id int,
@nombre varchar(50),
@edad int,
@desc varchar(MAX)
AS
UPDATE [dbo].[Mascotas] 
SET
nombre = @nombre,
edad = @edad,
descripcion = @desc
WHERE idMascota = @id
SELECT 'ACTUALIZADO CON EXITO' Validacion
GO
