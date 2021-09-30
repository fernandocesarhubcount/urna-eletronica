USE [HubCount]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/09/2021 02:52:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Candidates]    Script Date: 29/09/2021 02:52:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCandidato] [int] NOT NULL,
	[NomeCompleto] [nvarchar](max) NOT NULL,
	[NomeVice] [nvarchar](max) NOT NULL,
	[DataRegistro] [datetime2](7) NOT NULL,
	[Legenda] [nvarchar](max) NOT NULL,
	[TotalVotos] [int] NOT NULL,
 CONSTRAINT [PK_Candidates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votes]    Script Date: 29/09/2021 02:52:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Datavoto] [datetime2](7) NOT NULL,
	[CandidateId] [int] NULL,
	[CodigoCandidato] [int] NULL,
 CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210929034628_INITIAL', N'5.0.10')
GO
SET IDENTITY_INSERT [dbo].[Candidates] ON 
GO
INSERT [dbo].[Candidates] ([Id], [CodigoCandidato], [NomeCompleto], [NomeVice], [DataRegistro], [Legenda], [TotalVotos]) VALUES (1, 30, N'Jefferson', N'pedro', CAST(N'2021-09-27T00:00:00.0000000' AS DateTime2), N'presidente com legenda', 0)
GO
INSERT [dbo].[Candidates] ([Id], [CodigoCandidato], [NomeCompleto], [NomeVice], [DataRegistro], [Legenda], [TotalVotos]) VALUES (2, 31, N'Pedro', N'pedro', CAST(N'2021-09-27T00:00:00.0000000' AS DateTime2), N'presidente com legenda', 0)
GO
SET IDENTITY_INSERT [dbo].[Candidates] OFF
GO
SET IDENTITY_INSERT [dbo].[Votes] ON 
GO
INSERT [dbo].[Votes] ([Id], [Datavoto], [CandidateId], [CodigoCandidato]) VALUES (1, CAST(N'2021-09-24T00:00:00.0000000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[Votes] ([Id], [Datavoto], [CandidateId], [CodigoCandidato]) VALUES (2, CAST(N'2021-09-24T00:00:00.0000000' AS DateTime2), 1, 30)
GO
INSERT [dbo].[Votes] ([Id], [Datavoto], [CandidateId], [CodigoCandidato]) VALUES (3, CAST(N'2021-09-24T00:00:00.0000000' AS DateTime2), 1, 30)
GO
INSERT [dbo].[Votes] ([Id], [Datavoto], [CandidateId], [CodigoCandidato]) VALUES (4, CAST(N'2021-09-24T00:00:00.0000000' AS DateTime2), 1, 30)
GO
INSERT [dbo].[Votes] ([Id], [Datavoto], [CandidateId], [CodigoCandidato]) VALUES (5, CAST(N'2021-09-24T00:00:00.0000000' AS DateTime2), 2, 31)
GO
INSERT [dbo].[Votes] ([Id], [Datavoto], [CandidateId], [CodigoCandidato]) VALUES (6, CAST(N'2021-09-24T00:00:00.0000000' AS DateTime2), 2, 31)
GO
SET IDENTITY_INSERT [dbo].[Votes] OFF
GO
ALTER TABLE [dbo].[Votes]  WITH CHECK ADD  CONSTRAINT [FK_Votes_Candidates_CandidateId] FOREIGN KEY([CandidateId])
REFERENCES [dbo].[Candidates] ([Id])
GO
ALTER TABLE [dbo].[Votes] CHECK CONSTRAINT [FK_Votes_Candidates_CandidateId]
GO
