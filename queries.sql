SELECT s.Id AS ShelterId, s.Name AS ShelterName, s.Capacity, a.City, a.Neighborhood
FROM Shelters AS s INNER JOIN Areas AS a ON s.AreaId = a.Id;
    

