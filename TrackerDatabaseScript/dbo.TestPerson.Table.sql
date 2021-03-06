USE [Tournaments]
GO
/****** Object:  Table [dbo].[TestPerson]    Script Date: 6/8/2020 1:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestPerson](
	[id] [int] NOT NULL,
	[firstNam] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[EmailAddress] [nvarchar](200) NOT NULL,
	[phoneNumber] [varchar](20) NULL,
	[NumberOfKids] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TestPerson] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TestPerson] ADD  CONSTRAINT [DF_TestPerson_NumberOfKids]  DEFAULT ((0)) FOR [NumberOfKids]
GO
ALTER TABLE [dbo].[TestPerson] ADD  CONSTRAINT [DF_TestPerson_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
