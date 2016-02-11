CREATE TABLE [dbo].[Player]
(
	[RecordGUID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [RecordCreation] DATETIME NOT NULL DEFAULT (getdate()), 
    [Name] VARCHAR(20) NOT NULL DEFAULT (''), 
    [Password] VARCHAR(MAX) NOT NULL DEFAULT (''), 
    [Position_x] FLOAT NOT NULL DEFAULT 0, 
    [Position_y] FLOAT NOT NULL DEFAULT 0, 
    [Postition_z] FLOAT NOT NULL DEFAULT 0, 
    [Rotation_x] FLOAT NOT NULL DEFAULT 0, 
    [Rotation_y] FLOAT NOT NULL DEFAULT 0, 
    [Rotation_z] FLOAT NOT NULL DEFAULT 0
)
