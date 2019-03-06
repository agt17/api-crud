CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UUID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](100) NOT NULL,
	[CardId] [varchar](15) NOT NULL,
	[DateBorn] [datetime] NOT NULL,
	[DateRegistry] [datetime] NOT NULL,
	[Age] [int] NOT NULL,
  CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED(
	[Id] ASC
  )
)
