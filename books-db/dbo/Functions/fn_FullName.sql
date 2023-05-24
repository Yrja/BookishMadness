CREATE FUNCTION [dbo].[fn_FullName]
(
	@name varchar(50),
	@surname varchar(50)
)
RETURNS varchar(100)
AS
BEGIN
	RETURN TRIM(@name) + ' ' + TRIM(@surname)
END
