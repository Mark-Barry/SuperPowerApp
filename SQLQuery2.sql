USE SuperRegistry;

INSERT INTO dbo.Affinity(Type) VALUES('Good guy');
INSERT INTO dbo.Superhero(AffinityID,Superhero.Name) VALUES(1,'Batman');

SELECT AffinityID,Type FROM Affinity;

SELECT Superhero.SuperheroID,Superhero.Name,Affinity.Type 
FROM dbo.Superhero
INNER JOIN Affinity 
ON Superhero.AffinityID = Affinity.AffinityID
WHERE SuperheroID = 2;

DELETE FROM dbo.Superhero WHERE AffinityID = 2;

SELECT Max(Superhero.SuperheroID) FROM dbo.Superhero;