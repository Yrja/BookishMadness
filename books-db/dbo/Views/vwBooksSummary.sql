CREATE VIEW [dbo].[vwBooksSummary]
	AS
	WITH tbl AS(
		SELECT
			 books.Id BookId
			,Round(AVG(Cast(reactions.Reaction AS Float)), 4) AvgReaction
			,COUNT(reactions.Reaction) RectionsCount
			,SUM(reactions.Reaction) LikesQuantity
			,COUNT(reactions.Reaction) - SUM(reactions.Reaction) DislikesQuantity
		FROM dbo.Books AS books
		LEFT JOIN dbo.Reactions reactions ON reactions.BookId = books.Id --Why not BookId?
		GROUP BY books.Id)

	SELECT 
		 books.Id
		,books.Name
		,authors.Name + ' ' + authors.Surname AuthorFullName
		,tbl.AvgReaction
		,tbl.RectionsCount
		,LikesQuantity
		,DislikesQuantity
	FROM tbl
LEFT JOIN dbo.Books books ON tbl.BookId = books.Id
LEFT JOIN dbo.Authors authors ON books.AuthorId = authors.Id
