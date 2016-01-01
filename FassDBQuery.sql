--Query buat FASSProject
create database FassDB
on primary
( Name=FassDB_data,
	Filename='E:\DATABASE\FassDBPrimary.mdf',
	Filegrowth=1,
	Maxsize=10,
	size=3
), 
(
	Name=FassDB_Second,
	Filename='E:\DATABASE\FassDBSecond.ndf',
	Filegrowth=1,
	Maxsize=10,
	size=3
)
log on
(
	Name=FassDB_log,
	Filename='E:\DATABASE\FassDB_log.ldf',
	Filegrowth=10%,
	Maxsize=3,
	size=2
)
create table Employees
(
	EmployeeID varchar(10) primary key,
	Katasandi varchar(10)
)
insert into Employees values('Admin','qwerty313');
create table Desa
(
	DesaID varchar(10) primary key,
	NamaDesa varchar(15),
	MesjidDesa varchar(30),
	Alamat varchar(50),
	deleted bit default 0,
	CreatedDate datetime,
	CreatedBy varchar(10),
	UpdatedDate datetime,
	UpdatedBy varchar(10)
)
--alter table Desa
--add deleted bit default 0
--update Desa set deleted = 0
--insert into Desa values('DS1','Bintaro Jaya','Baituzzaki Mustofa', 'Jln. Nusajaya No. 100 Pondok Karya');
create table Festival
(
	FestivalID varchar(10) primary key,
	NamaFestival varchar(60),
	SistemFestival varchar(15),
	[Description] varchar(50), 
	deleted bit default 0,
	CreatedDate datetime,
	CreatedBy varchar(10),
	UpdatedDate datetime,
	UpdatedBy varchar(10)
)
--alter table Festival
--add deleted bit default 0
--update Festival set deleted = 0
create table FestivalDetail
(
	FestivalID varchar(10) foreign key (FestivalID) references Festival,
	PoinID int,
	PoinPenilaian varchar(50)
	primary key(FestivalID,PoinID), 
	deleted bit default 0,
	CreatedDate datetime,
	CreatedBy varchar(10),
	UpdatedDate datetime,
	UpdatedBy varchar(10)
)
--alter table Festival
--alter column NamaFestival varchar(60)

create table Peserta
(
	PesertaID uniqueidentifier primary key,
	NamaPeserta varchar(50),
	Usia varchar(5),
	Gender varchar(10),
	DesaID varchar(10) foreign key (DesaID) references Desa,
	Kelompok varchar(30), 
	FestivalID varchar(10) foreign key (FestivalID) references Festival,
	deleted bit default 0,
	CreatedDate datetime,
	CreatedBy varchar(10),
	UpdatedDate datetime,
	UpdatedBy varchar(10)
	)
create table [Events]
(
	EventID uniqueidentifier primary key,
	EventDate datetime,
	Closed bit default 0, 
	EventName varchar(20)
)
create table EventDetail
(
	EventID uniqueidentifier foreign key (EventId) references Events,
	PesertaID uniqueidentifier foreign key (PesertaID) references Peserta,
	FestivalID varchar(10),
	PoinID int,
	Skor float default 0
	foreign key (FestivalID, PoinID) references FestivalDetail
	primary key(EventID, PesertaID, FestivalID, PoinID)
)
--alter table FestivalDetail
--add constraint PK__Festival__EAF4A761B80FF6FC primary key (FestivalID, PoinID)
--create table EventChild
--(
--	EventID uniqueidentifier foreign key (EventId) references Events,
--	PesertaID uniqueidentifier foreign key (PesertaID) references Peserta,
--	FestivalID varchar(10) foreign key (FestivalID) references Festival 
--	primary key(EventID, PesertaID, FestivalID)
--)
--alter table Peserta  
--add constraint pk_PesertaID_Peserta primary key (PesertaID)
--alter table Peserta  
--add  deleted bit default 0

--alter table FestivalDetail
--add deleted bit default 0

--update FestivalDetail set deleted=0

--alter table Events
--add EventName varchar(20)

--alter table EventDetail
--add constraint df_Skor_EveDet  default 0 for Skor
use FassDB
Select distinct EventID,a.PesertaID,NamaPeserta, Usia,b.DesaID, NamaDesa, a.FestivalID, Sum(Skor) TotalScore  from EventDetail a 
            join Peserta b on a.PesertaID=b.PesertaID
			join Desa c on c.DesaID=b.DesaID
			 where EventID='8CA83E1C-DA04-421D-87F2-1D3D8DC5E8A4'
			
			group by a.PesertaID, EventID, NamaPeserta,Usia, b.DesaID,NamaDesa, a.FestivalID
			order by TotalScore desc, NamaPeserta asc
Select distinct EventID,b.DesaID, NamaDesa, Sum(Skor) TotalScore  from EventDetail a 
            join Peserta b on a.PesertaID=b.PesertaID
			join Desa c on c.DesaID=b.DesaID
			 where EventID='8CA83E1C-DA04-421D-87F2-1D3D8DC5E8A4' and not Exists(Select DesaID from Desa where DesaID=.DesaID)
			
			group by EventID, b.DesaID,NamaDesa
			order by TotalScore desc, NamaPeserta asc


Select EventID,a.PesertaID,a.FestivalID,a.PoinID, PoinPenilaian, Skor  from EventDetail a 
            join FestivalDetail b on a.FestivalID=b.FestivalID and a.PoinID=b.PoinID where a.PesertaID='88700E3C-E66B-4A86-9F4F-34F914C393B7'

Select DesaID, NamaDesa from Desa  where DesaID not in (Select distinct b.DesaID from EventDetail a
join Peserta b on a.PesertaID=b.PesertaID   where EventID='8CA83E1C-DA04-421D-87F2-1D3D8DC5E8A4')