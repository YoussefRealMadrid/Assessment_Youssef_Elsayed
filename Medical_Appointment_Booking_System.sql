create database Medical_Appointment_Booking_System
go
use Medical_Appointment_Booking_System
go


create table Users(
	UserId			int primary key identity(1,1),
	UserName		nvarchar(50) not null,
	UserPassword	nvarchar(100) not null,
	UserEmail		nvarchar(150) not null unique,
	UserRole		nvarchar(50) check(UserRole in ('Receptionist','Doctor'))
);
go

create table Patients(
	PatientId			int primary key identity(1,1),
	PatientName			nvarchar(50) not null,
	PatientPhone		nvarchar(30),
	DateOfBirth			date,
	PatientNotes		nvarchar(90) default 'No Notes'
);
go


create table Appointments(
	AppId				int primary key identity(1,1),
	DoctorId			int references Users(UserId),
	PatientId			int references Patients(PatientId),
	AppDateTime			datetime default GETDATE(),
	AppReason			nvarchar(100) not null,
	AppStatus			nvarchar(50) check(AppStatus in ('Waiting','Examined','Cancelled')),
	AppDay				nvarchar(30) check(AppDay in ('Saturday','Sunday','Monday','Tuesday','Wednesday','Thursday','Friday'))
);
go
drop table Appointments
go
insert into Users values
('Youssef Elsayed','Joo123','YEJ@gmail.com','Receptionist'),
('Hager Elsayed','Gory321','Gory@gmail.com','Doctor'),
('Hamza Khaled','Hamooz99111','7mzzzz@gmail.com','Receptionist'),
('Mohamed Elsayed','MoElsayed','MoElsayed@gmail.com','Doctor'),
('Sohaib Osama','Bob11111','ElBobb@gmail.com','Doctor')
go
select * from Users
go
select * from Patients
go

select * from Appointments
go

insert into Appointments values
(2,1,'10-5-2025','Bruh','Waiting','Sunday')
go