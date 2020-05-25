USE SuperRegistry;

INSERT INTO dbo.Affinity(Type) VALUES('Good guy');
INSERT INTO dbo.Superhero(AffinityID,Superhero.Name) VALUES(1,'Batman');

SELECT AffinityID,Type FROM Affinity;

SELECT Superhero.SuperheroID,Superhero.Name,Affinity.AffinityID,Affinity.Type 
FROM dbo.Superhero
INNER JOIN Affinity 
ON Superhero.AffinityID = Affinity.AffinityID
WHERE SuperheroID = 2;

DELETE FROM dbo.Superhero WHERE AffinityID = 2;

SELECT Max(Superhero.SuperheroID) FROM dbo.Superhero;
SELECT Min(Superhero.SuperheroID) FROM dbo.Superhero;

UPDATE dbo.Superhero 
SET AffinityID = '1',Name = 'Dare Devil Updated'
WHERE dbo.Superhero.SuperheroID = '7';

INSERT INTO dbo.Affinity(Type) VALUES('Midium-Well');