-- Making sure I am using my Performance database
USE Performance;
-- Testing if dbo.LookNumber procedure exists, and if it does we drop it.
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.LookNumber'))
    DROP PROCEDURE dbo.LookNumber;
GO
-- Creating dbo.LookNumber
CREATE PROCEDURE dbo.LookNumber
AS-- We are searching how many times the number 4711 is in our database here.
	SELECT * FROM dbo.Random WHERE Random.RandomNumber = 4711;
GO
-- Same thing here but with dbo.Frequency.
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.Frequency'))
    DROP PROCEDURE dbo.Frequency;
GO

CREATE PROCEDURE dbo.Frequency
AS-- Here we get all the numbers in the list, but sorted and grouped in the desired way.
	SELECT RandomNumber, COUNT(RandomNumber) AS Frequency FROM Random
	GROUP BY RandomNumber
	ORDER BY COUNT(RandomNumber) DESC;
GO
-- Here I am testing if our RandomNumber is an index, and if it is we drop it.
IF EXISTS (SELECT * FROM sys.indexes WHERE name = ('index_number'))
	DROP INDEX index_number ON Random;
GO
-- Here we are creating said index.
CREATE INDEX index_number
	ON Random (RandomNumber);
GO
-- Running the procedures.
dbo.LookNumber;
GO
dbo.Frequency;