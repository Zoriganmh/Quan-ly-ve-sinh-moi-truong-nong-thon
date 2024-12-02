create database QuanLyVeSinhMoiTruongNongThon
go

use QuanLyVeSinhMoiTruongNongThon
go

create table Unit
(
	ID int identity(1,1) primary key,
	UnitName nvarchar(max)
)
go

create table Files
(
	ID int identity(1,1) primary key,
	FilesName nvarchar(max),
	Area nvarchar(200),
	Map nvarchar(max),
	Levels int,
	Addresss nvarchar(max),
	Dates datetime,
	MoreInfo nvarchar(max)
)
go

create table Objects
(
	ID nvarchar(128) primary key,
	ObName nvarchar(max),
	IDUnit int not null,
	IDFile int not null,
	QRCode nvarchar(max),
	BarCode nvarchar(max),

	foreign key(IDUnit) references Unit(ID),
	foreign key(IDFile) references Files(ID)
)
go

create table UserRole
(
	ID int identity(1,1) primary key,
	RoleName nvarchar(max)
)
go

create table Users
(
	ID int identity(1,1) primary key,
	DisplayName nvarchar(max),
	UserName nvarchar(100),
	Passwords nvarchar(max),
	Age int,
	Addresss nvarchar(max),
	Email nvarchar(200),
	Statuss nvarchar(200),
	Moreinfo nvarchar(max),
	IDRole int not null,

	foreign key(IDRole) references UserRole(ID)
)
go
insert into Users(DisplayName, UserName, Passwords, IDRole) values(N'Yasuo', N'Admin', N'ac9101d05fefe454418a03c3e9c3f0b5', 1)
go
insert into Users(DisplayName, UserName, Passwords, IDRole) values(N'Diana', N'Staff', N'a641b672e567876e64c244c7790d903f', 2)
go
-- password string to base64 -> string to md5

create table Input
(
	ID nvarchar(128) primary key,
	IDObject nvarchar(128) not null,
	IDFile int not null,

	foreign key(IDObject) references Objects(ID),
	foreign key(IDFile) references Files(ID)
)
go

create table Outputs
(
	ID nvarchar(128) primary key,
	IDObject nvarchar(128) not null,
	IDInput nvarchar(128) not null,
	IDFile int not null,
	Statuss nvarchar(max),

	foreign key(IDObject) references Objects(ID),
	foreign key(IDInput) references Input(ID),
	foreign key(IDFile) references Files(ID)
)
go
