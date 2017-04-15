SELECT SUM(t.sumQ*p.Price) 
FROM 
(SELECT p.PaperID, q.sumQ, MAX(p.Quantity) AS Qua
FROM (SELECT SUM(f.Quantity)AS sumQ, f.PaperID
FROM dbo.Fotos AS f
WHERE f.OrderID = 4
GROUP BY f.PaperID) AS q
JOIN dbo.Prices AS p ON q.PaperID = p.PaperID
WHERE q.sumQ>p.Quantity
GROUP BY p.PaperID, q.sumQ) AS T
JOIN dbo.Prices AS p ON p.PaperID = t.PaperID AND p.Quantity = t.Qua



GROUP BY p.PaperID, f.OrderID, p.Quantity
HAVING p.Quantity<=SUM(f.Quantity) AND MAX(p.Quantity)=p.Quantity





SELECT SUM(f.Quantity)AS sumQ, f.PaperID
FROM dbo.Fotos AS f
WHERE f.OrderID = 4
GROUP BY f.PaperID