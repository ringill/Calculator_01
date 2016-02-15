CREATE TABLE [dbo].[Records]
(
	[Id] INT NOT NULL PRIMARY KEY identity(0,1), 
    [When] NVARCHAR(50) COLLATE Cyrillic_General_100_CI_AS NOT NULL default '', 
    [What] NVARCHAR(MAX) COLLATE Cyrillic_General_100_CI_AS NOT NULL default ''
)
