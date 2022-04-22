create database Rubrica

create table Contatto(
Id int identity(1,1),
Nome varchar(30) not null,
Cognome varchar(30) not null

constraint PK_Contatto primary key (Id)
)

create table Indirizzo(
--Tipologia, via, citta, cap, provincia, nazione, id contatto
IdIndirizzo int identity(1,1),
Tipologia varchar(30) not null,
Via varchar(50) not null, 
Citta varchar(30) not null,
CAP int not null, 
Provincia varchar(30) not null,
Nazione varchar(30) not null,
IdContatto int not null,

constraint PK_Indirizzo primary key(IdIndirizzo),
Constraint FK_Contatto foreign key(IdContatto) references Contatto(Id)
)


