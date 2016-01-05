USE [HomeMovieCollection];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[Actor] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Actor]([ActorId], [Description], [FirstName], [LastName], [UrlSlug])
SELECT 1, N' ', N'Robert', N'Downey Jr', N'robert-downey' UNION ALL
SELECT 2, N' ', N'Chris', N'Evans', N'chris-evans' UNION ALL
SELECT 4, N' ', N'Scarlett', N'Johannson', N'scar-jo' UNION ALL
SELECT 5, N' ', N'Samuel L', N'Jackson', N'sam-jackson' UNION ALL
SELECT 6, N' ', N'Oscar', N'Issac', N'oscar-issac' UNION ALL
SELECT 7, N' ', N'Tom', N'Cruise', N'tom-cruise'
COMMIT;
RAISERROR (N'[dbo].[Actor]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Actor] OFF;

SET IDENTITY_INSERT [dbo].[Genre] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Genre]([GenreId], [Name], [Description], [UrlSlug])
SELECT 1, N'Action', N' ', N'action' UNION ALL
SELECT 2, N'Adventure', N' dfdasdfafdfda', N'adventure' UNION ALL
SELECT 3, N'Drama', N' ', N'drama' UNION ALL
SELECT 5, N'Sci-Fi', N' ', N'sci-fi' UNION ALL
SELECT 6, N'Comedy', N' ', N'comedy' UNION ALL
SELECT 7, N'Horror', N' ', N'horror' UNION ALL
SELECT 11, N'Animated', NULL, N'animated'
COMMIT;
RAISERROR (N'[dbo].[Genre]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Genre] OFF;

SET IDENTITY_INSERT [dbo].[Movie] ON;

BEGIN TRANSACTION;
INSERT INTO [dbo].[Movie]([MovieId], [Title], [Summary], [Description], [Cover], [Format], [Region], [UrlSlug], [ReleaseDate], [RunTime], [AddedOn], [Modified], [GenreId], [Director], [Rating])
SELECT 1, N'The Avengers', N' ', N' ', N' ', N'Blu-Ray', N'All Regions', N'avengers', '20120915 00:00:00.000', 141, '20160102 00:00:00.000', NULL, 1, N'Josh Whedon', NULL UNION ALL
SELECT 2, N'Avengers: Age Of Ultron', N' ', N' ', N' ', N'Blu-Ray', N'All Regions', N'age-of-ultron', '20151024 00:00:00.000', 142, '20160102 00:00:00.000', NULL, 1, N'Josh Whedon', NULL UNION ALL
SELECT 4, N'Iron Man 2', N' ', N' ', N' ', N'Blu-Ray', N'All Regions', N'iron-man-2', '20100901 00:00:00.000', 130, '20160102 00:00:00.000', NULL, 1, N'Jon Favreau', NULL UNION ALL
SELECT 7, N'Ex Machina', N' ', N' ', N' ', N'Blu-Ray', N'All Regions', N'ex-machina', '20151015 00:00:00.000', 130, '20160102 00:00:00.000', NULL, 5, N'Alex Garland', NULL UNION ALL
SELECT 8, N'Tropic Thunder', N' ', N' ', N' ', N'Blu-Ray', N'All Regions', N'tropic-thunder', '20081122 00:00:00.000', 140, '20160102 00:00:00.000', NULL, 6, N'Ben Stiller', NULL UNION ALL
SELECT 10, N'Iron Man', NULL, NULL, NULL, N'Blu-Ray', N'All Regions', N'iron-man', '20080921 00:00:00.000', 130, '20160104 16:45:40.000', NULL, 1, N'Jon Favreu', 0 UNION ALL
SELECT 11, N'Iron Man 3', N' ', N'<p>Marvel''s "Iron Man 3" pits brash-but-brilliant industrialist Tony Stark/Iron Man against an enemy whose reach knows no bounds. When Stark finds his personal world destroyed at his enemy''s hands, he embarks on a harrowing quest to find those responsible. This journey, at every turn, will test his mettle. With his back against the wall, Stark is left to survive by his own devices, relying on his ingenuity and instincts to protect those closest to him. As he fights his way back, Stark discovers the answer to the question that has secretly haunted him: does the man make the suit or does the suit make the man?</p>', NULL, N'DVD', N'All Regions', N'iron-man-3', '20130915 00:00:00.000', 135, '20160102 00:00:00.000', '20160105 01:58:53.000', 1, N'Jon Favreau', 0
COMMIT;
RAISERROR (N'[dbo].[Movie]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Movie] OFF;

BEGIN TRANSACTION;
INSERT INTO [dbo].[MovieActorsMap]([Actor_id], [Movie_id])
SELECT 1, 1 UNION ALL
SELECT 2, 1 UNION ALL
SELECT 4, 1 UNION ALL
SELECT 5, 1 UNION ALL
SELECT 1, 2 UNION ALL
SELECT 2, 2 UNION ALL
SELECT 4, 2 UNION ALL
SELECT 5, 2 UNION ALL
SELECT 1, 11 UNION ALL
SELECT 1, 4 UNION ALL
SELECT 6, 7 UNION ALL
SELECT 7, 8 UNION ALL
SELECT 1, 8 UNION ALL
SELECT 1, 10
COMMIT;
RAISERROR (N'[dbo].[MovieActorsMap]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

