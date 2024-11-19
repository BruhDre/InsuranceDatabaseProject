CREATE DATABASE OSIGURANJE COLLATE Serbian_Latin_100_CI_AI
GO
use OSIGURANJE

create table KLIJENT (
idKlijent int identity(1,1),
ime nvarchar(20) not null,
prezime nvarchar(20) not null,
jmbg varchar(13) not null,
datumRodjenja datetime not null,
pol nvarchar(1),
adresa nvarchar(40),
mesto nvarchar(20),
mejl nvarchar(30) not null,
telefon nvarchar(15) not null,
sifra nvarchar(70) not null,
constraint PK_KLIJENT primary key (idKlijent)
)
go

create table AGENT (
idAgent int identity(1,1),
naziv nvarchar(20) not null,
adresa nvarchar(40) not null,
mejl nvarchar(30) not null,
telefon nvarchar(15) not null,
sifra nvarchar(70) not null,
constraint PK_AGENT primary key (idAgent)
)
go

create table PONUDA (
idPonuda int identity(1,1),
idAgent int not null,
vrstaOsiguranja nvarchar(20) not null,
cenaMesecno float not null,
limitPokrica float,
popust int,
statusPonuda nvarchar(15) not null,
constraint PK_PONUDA primary key (idPonuda)
)
go

create nonclustered index Relationship_1_FK on PONUDA (idAgent ASC)
go

create table DOGADJAJ (
idDogadjaj int identity(1,1),
idPonuda int not null,
opis nvarchar(60) not null,
odsteta float not null,
statusDogadjaj nvarchar(15) not null,
constraint PK_DOGADJAJ primary key (idDogadjaj)
)
go

create nonclustered index Relationship_2_FK on DOGADJAJ (idPonuda ASC)
go

create table UGOVOR (
idUgovor int identity(1,1),
idKlijent int not null,
idPonuda int not null,
datum datetime not null,
statusUgovora nvarchar(15) not null,
constraint PK_UGOVOR primary key (idUgovor)
)
go

create nonclustered index Relationship_3_FK on UGOVOR (idKlijent ASC)
go

create nonclustered index Relationship_4_FK on UGOVOR (idPonuda ASC)
go

create table IZVESTAJ (
idIzvestaj int identity(1,1),
idUgovor int not null,
idDogadjaj int not null,
datum datetime not null,
ukupnaOdsteta float not null,
constraint PK_IZVESTAJ primary key (idIzvestaj)
)
go

create nonclustered index Relationship_5_FK on IZVESTAJ (idUgovor ASC)
go

create nonclustered index Relationship_6_FK on IZVESTAJ (idDogadjaj ASC)
go

create table ADMIN (
idAdmin int identity(1,1),
ime nvarchar(20) not null,
mejl nvarchar(30) not null,
sifra nvarchar(70) not null,
constraint PK_ADMIN primary key (idAdmin)
)
go

alter table PONUDA
   add constraint FK_PONUDA_RELATIONS_AGENT foreign key (idAgent)
      references AGENT (idAgent)
   ON DELETE CASCADE
go

alter table DOGADJAJ
   add constraint FK_DOGADJAJ_RELATIONS_PONUDA foreign key (idPonuda)
      references PONUDA (idPonuda)
   ON DELETE CASCADE
go

alter table UGOVOR
   add constraint FK_UGOVOR_RELATIONS_KLIJENT foreign key (idKlijent)
      references KLIJENT (idKlijent)
   ON DELETE CASCADE
go

alter table UGOVOR
   add constraint FK_UGOVOR_RELATIONS_PONUDA foreign key (idPonuda)
      references PONUDA (idPonuda)
   ON DELETE CASCADE
go

create table KLIJENT_ARHIVA (
idKlijent int identity(1,1),
ime nvarchar(20) not null,
prezime nvarchar(20) not null,
jmbg varchar(13) not null,
datumRodjenja datetime not null,
pol nvarchar(1),
adresa nvarchar(40),
mesto nvarchar(20),
mejl nvarchar(30) not null,
telefon nvarchar(15) not null,
sifra nvarchar(70) not null,
constraint PK_KLIJENT_ARHIVA primary key (idKlijent)
)
go

create table AGENT_ARHIVA (
idAgent int identity(1,1),
naziv nvarchar(20) not null,
adresa nvarchar(40) not null,
mejl nvarchar(30) not null,
telefon nvarchar(15) not null,
sifra nvarchar(70) not null,
constraint PK_AGENT_ARHIVA primary key (idAgent)
)
go