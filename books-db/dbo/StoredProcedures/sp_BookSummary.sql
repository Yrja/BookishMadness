CREATE PROCEDURE [dbo].[sp_BookSummary]
	 @dateFrom datetime
	,@dateTo datetime
	,@bookId uniqueidentifier
AS
	WITH tbl AS(
		SELECT
			 books.Id BookId
			,Round(AVG(Cast(reactions.Reaction AS Float)), 4) AvgReaction
			,COUNT(reactions.Reaction) ReactionsCount
			,SUM(reactions.Reaction) LikesQuantity
			,COUNT(reactions.Reaction) - SUM(reactions.Reaction) DislikesQuantity
		FROM dbo.Books AS books
		LEFT JOIN 
			(SELECT * FROM dbo.Reactions
			 WHERE CreatedOn >= @dateFrom and CreatedOn <= @dateTo) reactions
		ON reactions.BookId = books.Id
		GROUP BY books.Id)

	SELECT 
		 books.Id
		,books.Name
		,dbo.fn_FullName(authors.Name, authors.Surname) AuthorFullName
		,tbl.AvgReaction
		,tbl.ReactionsCount
		,LikesQuantity
		,DislikesQuantity
	FROM tbl
	LEFT JOIN dbo.Books books ON tbl.BookId = books.Id
	LEFT JOIN dbo.Authors authors ON books.AuthorId = authors.Id
	WHERE BookId = @bookId
GO