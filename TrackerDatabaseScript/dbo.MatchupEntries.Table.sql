USE [Tournaments]
GO
/****** Object:  Table [dbo].[MatchupEntries]    Script Date: 6/8/2020 1:39:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchupEntries](
	[id] [int] NOT NULL,
	[MatchupID] [int] NOT NULL,
	[ParentMatchupID] [int] NOT NULL,
	[TeamCompetingID] [int] NOT NULL,
	[Score] [int] NOT NULL,
 CONSTRAINT [PK_MatchupEntries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MatchupEntries]  WITH CHECK ADD  CONSTRAINT [FK_MatchupEntries_Matchups] FOREIGN KEY([MatchupID])
REFERENCES [dbo].[Matchups] ([id])
GO
ALTER TABLE [dbo].[MatchupEntries] CHECK CONSTRAINT [FK_MatchupEntries_Matchups]
GO
ALTER TABLE [dbo].[MatchupEntries]  WITH CHECK ADD  CONSTRAINT [FK_MatchupEntries_Teams] FOREIGN KEY([TeamCompetingID])
REFERENCES [dbo].[Teams] ([id])
GO
ALTER TABLE [dbo].[MatchupEntries] CHECK CONSTRAINT [FK_MatchupEntries_Teams]
GO
