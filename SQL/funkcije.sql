CREATE FUNCTION fun_prikaz_ponuda(@id int)
RETURNS TABLE
AS RETURN
(SELECT * FROM view_ponude WHERE [ID] NOT IN (SELECT idPonuda from UGOVOR
		WHERE idKlijent=@id))
go

CREATE FUNCTION fun_filter_ponude(@vrsta nvarchar(20),@id int)
RETURNS TABLE
AS RETURN
(SELECT * FROM view_ponude WHERE [Vrsta osiguranja]=@vrsta AND [ID] NOT IN (SELECT idPonuda from UGOVOR
		WHERE idKlijent=@id))
go

CREATE FUNCTION fun_dogadjaji(@id int)
RETURNS TABLE
AS RETURN
(SELECT opis as 'Opis',odsteta as 'Odšteta' FROM DOGADJAJ WHERE idPonuda=@id AND statusDogadjaj='Aktivan')
go

CREATE FUNCTION fun_prikazi_ugovor(@id int)
RETURNS TABLE
AS RETURN
(SELECT idUgovor as 'ID',naziv as 'Agent',vrstaOsiguranja as 'Vrsta osiguranja',
ROUND(cenaMesecno-(popust*cenaMesecno/100),2) as 'Cena €',limitPokrica as 'Limit pokrića',datum as 'Datum',statusUgovora as 'Status'
FROM UGOVOR,AGENT,PONUDA WHERE idKlijent=@id AND UGOVOR.idPonuda=PONUDA.idPonuda AND 
PONUDA.idAgent=AGENT.idAgent)
go

CREATE FUNCTION fun_prikazi_ugovor_agentA(@id int)
RETURNS TABLE
AS RETURN
(SELECT idUgovor as 'ID',ime+' '+prezime as 'Klijent',vrstaOsiguranja as 'Vrsta osiguranja',
ROUND(cenaMesecno-(popust*cenaMesecno/100),2) as 'Cena €',limitPokrica as 'Limit pokrića',datum as 'Datum',statusUgovora as 'Status'
FROM UGOVOR,KLIJENT,PONUDA WHERE idAgent=@id AND UGOVOR.idPonuda=PONUDA.idPonuda AND 
UGOVOR.idKlijent=KLIJENT.idKlijent and statusUgovora='Aktivan')
go

CREATE FUNCTION fun_prikazi_ugovor_agentN(@id int)
RETURNS TABLE
AS RETURN
(SELECT idUgovor as 'ID',ime+' '+prezime as 'Klijent',vrstaOsiguranja as 'Vrsta osiguranja',
ROUND(cenaMesecno-(popust*cenaMesecno/100),2) as 'Cena €',limitPokrica as 'Limit pokrića',datum as 'Datum',statusUgovora as 'Status'
FROM UGOVOR,KLIJENT,PONUDA WHERE idAgent=@id AND UGOVOR.idPonuda=PONUDA.idPonuda AND 
UGOVOR.idKlijent=KLIJENT.idKlijent and statusUgovora='Neaktivan')
go

CREATE FUNCTION fun_prikaz_izvestaj(@id int)
RETURNS TABLE
AS RETURN
(SELECT naziv as 'Agent',vrstaOsiguranja as 'Vrsta osiguranja',opis as 'Opis',IZVESTAJ.datum as 'Datum',ukupnaOdsteta as 'Ukupna odšteta'
FROM IZVESTAJ,UGOVOR,DOGADJAJ,PONUDA,AGENT
WHERE IZVESTAJ.idUgovor=UGOVOR.idUgovor AND IZVESTAJ.idDogadjaj=DOGADJAJ.idDogadjaj AND
UGOVOR.idPonuda=PONUDA.idPonuda AND PONUDA.idAgent=AGENT.idAgent AND UGOVOR.idKlijent=@id)
go

CREATE FUNCTION fun_prikaz_izvestaj_agent(@id int)
RETURNS TABLE
AS RETURN
(SELECT ime+' '+prezime as 'Klijent',vrstaOsiguranja as 'Vrsta osiguranja',opis as 'Opis',IZVESTAJ.datum as 'Datum',ukupnaOdsteta as 'Ukupna odšteta'
FROM IZVESTAJ,UGOVOR,DOGADJAJ,PONUDA,KLIJENT
WHERE IZVESTAJ.idUgovor=UGOVOR.idUgovor AND IZVESTAJ.idDogadjaj=DOGADJAJ.idDogadjaj AND
UGOVOR.idPonuda=PONUDA.idPonuda AND UGOVOR.idKlijent=KLIJENT.idKlijent AND PONUDA.idAgent=@id)
go

CREATE FUNCTION fun_do_limita(@mesec datetime,@id int)
RETURNS int
AS BEGIN
DECLARE @broj int;
SELECT @broj=SUM(ukupnaOdsteta)
FROM IZVESTAJ
WHERE idUgovor=@id AND MONTH(datum)=MONTH(@mesec) AND YEAR(datum)=YEAR(@mesec);
RETURN @broj
END
go

CREATE FUNCTION fun_filter_klijenti(@karakteri nvarchar(30))
RETURNS TABLE
AS RETURN
(SELECT idKlijent,ime,prezime,jmbg,datumRodjenja,pol,adresa,mesto,mejl,telefon FROM KLIJENT 
WHERE ime like @karakteri+'%' OR prezime like @karakteri+'%')
go

CREATE FUNCTION fun_filter_agenti(@karakteri nvarchar(30))
RETURNS TABLE
AS RETURN
(SELECT idAgent,naziv,adresa,mejl,telefon FROM AGENT 
WHERE naziv like @karakteri+'%')
go
