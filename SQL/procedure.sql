CREATE PROCEDURE sp_sklopi_ugovor @idK int,@idP int
AS
INSERT INTO UGOVOR(idKlijent,idPonuda,datum,statusUgovora)
VALUES(@idK,@idP,GETDATE(),'Aktivan')
go

CREATE PROCEDURE sp_novi_izvestaj(@idU int,@idD int) AS
BEGIN
DECLARE @pom int
DECLARE @pom2 int
BEGIN TRAN
SELECT @pom=limitPokrica-dbo.fun_do_limita(GETDATE(),@idU)
FROM PONUDA,UGOVOR
WHERE UGOVOR.idPonuda=PONUDA.idPonuda and idUgovor=@idU;
SELECT @pom2=odsteta
FROM DOGADJAJ
WHERE idDogadjaj=@idD;
IF @pom<=0
BEGIN
	ROLLBACK
	print('Neuspešno');
END
ELSE
BEGIN
	IF @pom<@pom2
	BEGIN
		INSERT INTO IZVESTAJ(idUgovor,idDogadjaj,datum,ukupnaOdsteta)
		VALUES(@idU,@idD,GETDATE(),@pom);
		commit
		print('Uspešno');
	END
	ELSE
	BEGIN
		INSERT INTO IZVESTAJ(idUgovor,idDogadjaj,datum,ukupnaOdsteta)
		VALUES(@idU,@idD,GETDATE(),@pom2);
		commit
		print('Uspešno');
	END
END
END
go

CREATE PROCEDURE sp_brisanje_klijenta(@idK int) AS
BEGIN
DECLARE @pom INT
BEGIN TRAN
SELECT @pom=COUNT(idUgovor)
FROM UGOVOR
WHERE idKlijent=@idk and statusUgovora='Aktivan';
IF @pom>0
BEGIN
	ROLLBACK
	print('Neuspešno');
END
ELSE
BEGIN
	DELETE FROM KLIJENT
	WHERE idKlijent=@idk;
	commit
	print('Uspešno');
END
END
go

CREATE PROCEDURE sp_brisanje_agenta(@ida int) AS
BEGIN
DECLARE @pom INT
BEGIN TRAN
SELECT @pom=COUNT(idPonuda)
FROM PONUDA
WHERE idAgent=@ida and statusPonuda='Aktivan';
IF @pom>0
BEGIN
	ROLLBACK
	print('Neuspešno');
END
ELSE
BEGIN
	DELETE FROM AGENT
	WHERE idAgent=@ida;
	commit
	print('Uspešno');
END
END
go

CREATE PROCEDURE sp_brisanje_ponude(@idp int) AS
BEGIN
DECLARE @pom INT
BEGIN TRAN
SELECT @pom=COUNT(idUgovor)
FROM UGOVOR
WHERE idPonuda=@idp and statusUgovora='Aktivan';
IF @pom>0
BEGIN
	ROLLBACK
	print('Neuspešno');
END
ELSE
BEGIN
	DELETE FROM PONUDA
	WHERE idPonuda=@idp;
	commit
	print('Uspešno');
END
END
go
