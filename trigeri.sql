CREATE TRIGGER trig_arhiviranje_klijenta ON KLIJENT
AFTER DELETE
AS
INSERT INTO KLIJENT_ARHIVA(ime,prezime,jmbg,datumRodjenja,pol,adresa,mesto,mejl,telefon,sifra)
SELECT ime,prezime,jmbg,datumRodjenja,pol,adresa,mesto,mejl,telefon,sifra
FROM deleted
go

CREATE TRIGGER trig_arhiviranje_agenta ON AGENT
AFTER DELETE
AS
INSERT INTO AGENT_ARHIVA(naziv,adresa,mejl,telefon,sifra)
SELECT naziv,adresa,mejl,telefon,sifra
FROM deleted
go