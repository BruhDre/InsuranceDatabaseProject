CREATE VIEW view_ponude AS
SELECT idPonuda as 'ID',naziv as 'Agent',vrstaOsiguranja as 'Vrsta osiguranja',cenaMesecno as 'Cena €',limitPokrica as 'Limit pokrića', isnull(popust,0) as 'Popust'
FROM AGENT,PONUDA
WHERE AGENT.idAgent=PONUDA.idAgent AND statusPonuda='Aktivan'
go
