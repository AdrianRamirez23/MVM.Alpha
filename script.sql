USE [MVM.Alpha]
GO
/****** Object:  Table [dbo].[AuditoriaComunicaciones]    Script Date: 14/02/2021 7:38:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaComunicaciones](
	[DescripcionEvento] [varchar](100) NOT NULL,
	[FechaEvento] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comunicaciones]    Script Date: 14/02/2021 7:38:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comunicaciones](
	[IdComunicacion] [int] IDENTITY(1,1) NOT NULL,
	[Consecutivo] [varchar](10) NOT NULL,
	[CodTipoComunicacion] [varchar](2) NOT NULL,
	[UsuarioGestor] [varchar](15) NOT NULL,
	[Remitente] [varchar](200) NOT NULL,
	[Destinatario] [varchar](15) NOT NULL,
	[FechaRad] [date] NOT NULL,
 CONSTRAINT [PK_Comunicaciones] PRIMARY KEY CLUSTERED 
(
	[IdComunicacion] ASC,
	[Consecutivo] ASC,
	[UsuarioGestor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablaControlConsecutivos]    Script Date: 14/02/2021 7:38:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablaControlConsecutivos](
	[Prefijo] [varchar](2) NOT NULL,
	[TipoComunicacion] [varchar](7) NOT NULL,
	[IdComunicacion] [int] NULL,
	[Consecutivo] [varchar](10) NOT NULL,
 CONSTRAINT [PK_TablaControlConsecutivos_1] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 14/02/2021 7:38:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [varchar](15) NOT NULL,
	[Password] [varchar](10) NOT NULL,
	[NombreUsuario] [varchar](100) NOT NULL,
	[RolUsuario] [varchar](8) NOT NULL,
	[Area] [varchar](20) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios_1] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[RolUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha radicado una nueva comunicación', CAST(N'2021-02-14T09:47:48.350' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha radicado una nueva comunicación', CAST(N'2021-02-14T09:52:37.967' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha radicado una nueva comunicación', CAST(N'2021-02-14T09:53:15.700' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha radicado una nueva comunicación', CAST(N'2021-02-14T09:54:05.223' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha radicado una nueva comunicación', CAST(N'2021-02-14T09:54:44.133' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha radicado una nueva comunicación', CAST(N'2021-02-14T17:51:09.843' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha elimando una comunicación', CAST(N'2021-02-14T18:28:19.823' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha editado una comunicación', CAST(N'2021-02-14T18:35:41.797' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha editado una comunicación', CAST(N'2021-02-14T18:38:11.043' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha editado una comunicación', CAST(N'2021-02-14T18:53:40.500' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha editado una comunicación', CAST(N'2021-02-14T19:12:50.860' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha editado una comunicación', CAST(N'2021-02-14T18:39:10.753' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha editado una comunicación', CAST(N'2021-02-14T18:50:57.910' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha editado una comunicación', CAST(N'2021-02-14T18:53:28.383' AS DateTime))
INSERT [dbo].[AuditoriaComunicaciones] ([DescripcionEvento], [FechaEvento]) VALUES (N'Se ha editado una comunicación', CAST(N'2021-02-14T18:54:46.510' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Comunicaciones] ON 

INSERT [dbo].[Comunicaciones] ([IdComunicacion], [Consecutivo], [CodTipoComunicacion], [UsuarioGestor], [Remitente], [Destinatario], [FechaRad]) VALUES (1, N'CI00000000', N'CI', N'mcanaveral', N'aramirez', N'jgutierrez', CAST(N'2021-02-14' AS Date))
INSERT [dbo].[Comunicaciones] ([IdComunicacion], [Consecutivo], [CodTipoComunicacion], [UsuarioGestor], [Remitente], [Destinatario], [FechaRad]) VALUES (2, N'CE00000000', N'CE', N'mcanaveral', N'Uno A', N'aramirez', CAST(N'2021-02-14' AS Date))
INSERT [dbo].[Comunicaciones] ([IdComunicacion], [Consecutivo], [CodTipoComunicacion], [UsuarioGestor], [Remitente], [Destinatario], [FechaRad]) VALUES (3, N'CE00000001', N'CE', N'mcanaveral', N'Manpower', N'jgutierrez', CAST(N'2021-02-14' AS Date))
SET IDENTITY_INSERT [dbo].[Comunicaciones] OFF
GO
INSERT [dbo].[TablaControlConsecutivos] ([Prefijo], [TipoComunicacion], [IdComunicacion], [Consecutivo]) VALUES (N'CE', N'Externa', 2, N'CE00000000')
INSERT [dbo].[TablaControlConsecutivos] ([Prefijo], [TipoComunicacion], [IdComunicacion], [Consecutivo]) VALUES (N'CE', N'Externa', 3, N'CE00000001')
INSERT [dbo].[TablaControlConsecutivos] ([Prefijo], [TipoComunicacion], [IdComunicacion], [Consecutivo]) VALUES (N'CI', N'Interna', 1, N'CI00000000')
INSERT [dbo].[TablaControlConsecutivos] ([Prefijo], [TipoComunicacion], [IdComunicacion], [Consecutivo]) VALUES (N'CI', N'Interna', NULL, N'CI00000001')
INSERT [dbo].[TablaControlConsecutivos] ([Prefijo], [TipoComunicacion], [IdComunicacion], [Consecutivo]) VALUES (N'CI', N'Interna', NULL, N'CI00000002')
GO
INSERT [dbo].[Usuarios] ([IdUsuario], [Password], [NombreUsuario], [RolUsuario], [Area], [Estado]) VALUES (N'aramirez', N'Nicolas1*', N'Adrian Ramirez', N'admin', N'TI', 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [Password], [NombreUsuario], [RolUsuario], [Area], [Estado]) VALUES (N'jgutierrez', N'Humanos1*', N'Jessica Gutierrez', N'Consulto', N'DHO', 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [Password], [NombreUsuario], [RolUsuario], [Area], [Estado]) VALUES (N'mcanaveral', N'Gestor1*', N'Miguel Cañaveral', N'Gestor', N'Gestion Documental', 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [Password], [NombreUsuario], [RolUsuario], [Area], [Estado]) VALUES (N'nhiguita', N'Colombia1*', N'Natalia Higuita', N'Consulto', N'Contabilidad', 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [Password], [NombreUsuario], [RolUsuario], [Area], [Estado]) VALUES (N'ycifuentes', N'Comercial1', N'Yeison Cifuentes', N'Consulto', N'Comercial', 1)
GO
/****** Object:  Index [IX_Comunicaciones]    Script Date: 14/02/2021 7:38:01 p. m. ******/
ALTER TABLE [dbo].[Comunicaciones] ADD  CONSTRAINT [IX_Comunicaciones] UNIQUE NONCLUSTERED 
(
	[IdComunicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Comunicaciones_1]    Script Date: 14/02/2021 7:38:01 p. m. ******/
ALTER TABLE [dbo].[Comunicaciones] ADD  CONSTRAINT [IX_Comunicaciones_1] UNIQUE NONCLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuarios]    Script Date: 14/02/2021 7:38:01 p. m. ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [IX_Usuarios] UNIQUE NONCLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comunicaciones]  WITH CHECK ADD  CONSTRAINT [FK_Comunicaciones_TablaControlConsecutivos] FOREIGN KEY([Consecutivo])
REFERENCES [dbo].[TablaControlConsecutivos] ([Consecutivo])
GO
ALTER TABLE [dbo].[Comunicaciones] CHECK CONSTRAINT [FK_Comunicaciones_TablaControlConsecutivos]
GO
ALTER TABLE [dbo].[Comunicaciones]  WITH CHECK ADD  CONSTRAINT [FK_Comunicaciones_Usuarios] FOREIGN KEY([UsuarioGestor])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Comunicaciones] CHECK CONSTRAINT [FK_Comunicaciones_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[Comunicaciones_CRUD]    Script Date: 14/02/2021 7:38:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Comunicaciones_CRUD](
@opc int,
@IdCom int,
@Consec varchar(10),
@CodTipoConse varchar(2),
@TipoConse varchar(7),
@UserGestor varchar(15),
@Rem varchar(100),
@Destin varchar(15),
@FechIn date,
@FechFin date

)
AS

IF @opc=1 BEGIN

    IF NOT EXISTS (SELECT '' FROM TablaControlConsecutivos WHERE Prefijo=@CodTipoConse)BEGIN

	    INSERT INTO TablaControlConsecutivos
        SELECT @CodTipoConse, @TipoConse, NULL, @CodTipoConse+'00000000'

		DECLARE @PrimerCon varchar(10)=@CodTipoConse+'00000000'

		INSERT INTO Comunicaciones
		SELECT @PrimerCon, @CodTipoConse, @UserGestor, @Rem,@Destin, GETDATE()

		UPDATE TablaControlConsecutivos
		SET IdComunicacion=(SELECT IdComunicacion FROM Comunicaciones WHERE Consecutivo=@PrimerCon)
		WHERE Consecutivo=@PrimerCon
		


	END ELSE BEGIN

	     DECLARE @ConMax VARCHAR(10) = (SELECT  MAX(Consecutivo)  FROM TablaControlConsecutivos WHERE Prefijo=@CodTipoConse)
		 DECLARE @ConInt int=  CONVERT(INT,(SUBSTRING(@ConMax,3,8)))+1

		 INSERT INTO TablaControlConsecutivos
		 SELECT @CodTipoConse, @TipoConse, NULL, CASE WHEN @ConInt<10 THEN @CodTipoConse+'0000000'+CONVERT(varchar(1),@ConInt) 
		                                              WHEN @ConInt<100 THEN @CodTipoConse+'000000'+CONVERT(varchar(2),@ConInt) 
													  WHEN @ConInt<1000 THEN @CodTipoConse+'00000'+CONVERT(varchar(3),@ConInt) 
													  WHEN @ConInt<10000 THEN @CodTipoConse+'0000'+CONVERT(varchar(4),@ConInt) 
													  WHEN @ConInt<100000 THEN @CodTipoConse+'000'+CONVERT(varchar(5),@ConInt) 
													  WHEN @ConInt<1000000 THEN @CodTipoConse+'00'+CONVERT(varchar(6),@ConInt) 
													  WHEN @ConInt<10000000 THEN @CodTipoConse+'0'+CONVERT(varchar(7),@ConInt)
													  ELSE @CodTipoConse+CONVERT(varchar(8),@ConInt) END
        DECLARE @Con varchar(10)=(SELECT MAX(Consecutivo) FROM TablaControlConsecutivos WHERE Prefijo=@CodTipoConse) 

		INSERT INTO Comunicaciones
		SELECT @Con, @CodTipoConse, @UserGestor, @Rem, @Destin, GETDATE()

		UPDATE TablaControlConsecutivos
		SET IdComunicacion=(SELECT IdComunicacion FROM Comunicaciones WHERE Consecutivo=@Con)
		WHERE Consecutivo=@Con

	END

END

IF @opc=2 BEGIN

   SELECT * FROM Comunicaciones

END 

IF @opc=3 BEGIN

   SELECT * FROM Comunicaciones WHERE IdComunicacion=@IdCom

END 

IF @opc=4 BEGIN

   UPDATE Comunicaciones 
   SET UsuarioGestor=@UserGestor, Destinatario=@Destin, Remitente=@Rem 
   WHERE IdComunicacion=@IdCom

END 

IF @opc=5 BEGIN

	   DELETE Comunicaciones WHERE IdComunicacion=@IdCom
	   DELETE TablaControlConsecutivos WHERE IdComunicacion=@IdCom


END

IF @opc=6 BEGIN

	  SELECT * FROM Comunicaciones WHERE FechaRad BETWEEN @FechIn AND @FechFin

END


GO
/****** Object:  StoredProcedure [dbo].[Usuario_CRUD]    Script Date: 14/02/2021 7:38:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Usuario_CRUD](
@opc int,
@idUser varchar(15),
@Pass varchar(10),
@Nombre varchar(100),
@RolUsuario varchar(8),
@Area varchar(20),
@Estado bit

)
AS

IF @opc=1 BEGIN

    INSERT INTO Usuarios
	SELECT @idUser, @Pass, @Nombre, @RolUsuario, @Area, @Estado


END

IF @opc=2 BEGIN

   SELECT * FROM Usuarios

END 

IF @opc=3 BEGIN

   SELECT * FROM Usuarios WHERE IdUsuario=@idUser

END 

IF @opc=4 BEGIN

   UPDATE Usuarios 
   SET [Password]=@Pass, NombreUsuario=@Nombre, 
   RolUsuario=@RolUsuario, Area=@Area, Estado=@Estado
   WHERE IdUsuario=@idUser

END 

IF @opc=5 BEGIN

    IF NOT EXISTS (SELECT '' FROM Comunicaciones WHERE UsuarioGestor=@idUser OR Destinatario=@idUser)BEGIN

	   DELETE Usuarios WHERE IdUsuario=@idUser

	END


END

IF @opc=6 BEGIN

   SELECT * FROM Usuarios WHERE IdUsuario=@idUser AND [Password]=@Pass AND Estado=1

END
GO
/****** Object:  Trigger [dbo].[ActualizacionComunicacion]    Script Date: 14/02/2021 7:38:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[ActualizacionComunicacion]
on [dbo].[Comunicaciones] AFTER update

AS

  INSERT INTO AuditoriaComunicaciones
  SELECT 'Se ha editado una comunicación',GETDATE() 
GO
ALTER TABLE [dbo].[Comunicaciones] ENABLE TRIGGER [ActualizacionComunicacion]
GO
/****** Object:  Trigger [dbo].[EliminacionComunicacion]    Script Date: 14/02/2021 7:38:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[EliminacionComunicacion]
on [dbo].[Comunicaciones] AFTER Delete

AS

  INSERT INTO AuditoriaComunicaciones
  SELECT 'Se ha elimando una comunicación',GETDATE() 
GO
ALTER TABLE [dbo].[Comunicaciones] ENABLE TRIGGER [EliminacionComunicacion]
GO
/****** Object:  Trigger [dbo].[RegistroNuevaComunicacion]    Script Date: 14/02/2021 7:38:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[RegistroNuevaComunicacion]
on [dbo].[Comunicaciones] AFTER insert

AS

  INSERT INTO AuditoriaComunicaciones
  SELECT 'Se ha radicado una nueva comunicación',GETDATE() 
GO
ALTER TABLE [dbo].[Comunicaciones] ENABLE TRIGGER [RegistroNuevaComunicacion]
GO
