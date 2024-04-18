USE R22_Billeterie
GO

CREATE VIEW Spectacles.VW_SpectaclesRepresentationSpectateur
AS
	SELECT SS.SpectacleID, SS.Nom, SS.Debut, SS.Fin,
	(COUNT(DISTINCT SR.RepresentationID)) AS [NbRepresentation],
	(SUM(SB.NbBillet))  AS [NbBilletsVendus], SS.Prix
	FROM Spectacles.Spectacle SS
	INNER JOIN Spectacles.Representation SR
	ON SS.SpectacleID = SR.SpectacleID
	INNER JOIN Spectacles.Billet SB
	ON SR.RepresentationID = SB.RepresentationID
	GROUP BY SS.SpectacleID, SS.Nom, SS.Debut, SS.Fin, SS.Prix
GO

