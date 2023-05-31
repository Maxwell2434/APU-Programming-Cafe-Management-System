DROP TABLE Users

CREATE TABLE [dbo].[Users] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Role]     NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (1, N'Student1', N'abcdef', N'Student')
INSERT INTO [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (2, N'Student2', N'studentpass', N'Student')
INSERT INTO [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (3, N'admin2', N'12345', N'Administrator')
INSERT INTO [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (4, N'admin3', N'password123', N'Administrator')
SET IDENTITY_INSERT [dbo].[Users] OFF