USE [Tournaments]
GO
/****** Object:  Table [dbo].[TournamentEntries]    Script Date: 6/8/2020 1:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TournamentEntries](
	[id] [int] NOT NULL,
	[TournamentId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_TournamentEntries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TournamentEntries]  WITH CHECK ADD  CONSTRAINT [FK_TournamentEntries_Teams] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([id])
GO
ALTER TABLE [dbo].[TournamentEntries] CHECK CONSTRAINT [FK_TournamentEntries_Teams]
GO
ALTER TABLE [dbo].[TournamentEntries]  WITH CHECK ADD  CONSTRAINT [FK_TournamentEntries_Tournaments] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournaments] ([id])
GO
ALTER TABLE [dbo].[TournamentEntries] CHECK CONSTRAINT [FK_TournamentEntries_Tournaments]
GO
