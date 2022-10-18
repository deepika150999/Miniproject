create database FlightTicket
use FlightTicket
create table Register(
Sno int identity(1,1) primary key,
Name varchar(100),
EmailId varchar(50) ,
Password varchar(16),
Confirm_Password varchar(16));

select*from Register

insert into Register values('Preethi','PreethiSatheesh@gmail.com','Preethi2805','Preethi2805');
drop table LoginPage
create table LoginPage(
EmailId varchar(50),
Password varchar(16),
Confirm_Password varchar(16),
Sno int identity(1,1) FOREIGN KEY REFERENCES Register(Sno)
);

insert into LoginPage values('Arunkumaresan@1203','Arun1203','Arun1203',1)
select* from LoginPage
drop table Flights
create table Flights(
FlightNumber int primary key,
ArravingPoint varchar(50),
DateOfArrving date ,
DeparturePoint varchar(50),
DateOfDeparture date ,
Timing time ,);
alter table Flights add TicketCost money
select * from Flights
insert into Flights(FlightNumber,ArravingPoint,DateOfArrving,DeparturePoint,DateOfDeparture,Timing,TicketCost)VALUES(34567,'Bangalore',GETDATE(),'SriLanka',GETDATE(),CURRENT_TIMESTAMP,22000)
insert into Flights(FlightNumber,ArravingPoint,DateOfArrving,DeparturePoint,DateOfDeparture,Timing,TicketCost)VALUES(56778,'Chennai',GETDATE(),'Trichy',GETDATE(),CURRENT_TIMESTAMP,3500)
insert into Flights(FlightNumber,ArravingPoint,DateOfArrving,DeparturePoint,DateOfDeparture,Timing,TicketCost)VALUES(345690,'Chennai',GETDATE(),'Coimbatore',GETDATE(),CURRENT_TIMESTAMP,5500)
insert into Flights(FlightNumber,ArravingPoint,DateOfArrving,DeparturePoint,DateOfDeparture,Timing,TicketCost)VALUES(34587,'Bangalore',GETDATE(),'New Delhi',GETDATE(),CURRENT_TIMESTAMP,15000)
insert into Flights(FlightNumber,ArravingPoint,DateOfArrving,DeparturePoint,DateOfDeparture,Timing,TicketCost)VALUES(34587,'Bangalore',GETDATE(),'Jaipur',GETDATE(),CURRENT_TIMESTAMP,25000)
insert into Flights(FlightNumber,ArravingPoint,DateOfArrving,DeparturePoint,DateOfDeparture,Timing,TicketCost)VALUES(679876,'Chennai',GETDATE(),'SriLanka',GETDATE(),CURRENT_TIMESTAMP,28000)
insert into Flights(FlightNumber,ArravingPoint,DateOfArrving,DeparturePoint,DateOfDeparture,Timing,TicketCost)VALUES(654909,'Chennai',GETDATE(),'Madurai',GETDATE(),CURRENT_TIMESTAMP,2500)

 DELETE FROM Flights WHERE ArravingPoint='Bangalore';
  SELECT * FROM FLIGHTS
  create table book(
  BookingId int primary key,
  FlightNumber int foreign key references flights(FlightNumber),
  DateofBooking datetime,
  ClassType varchar(15),
  NumberOfPassengers int)

  alter table book
  alter column BookingId int identity(2345,1) primary key


create table Classes(ClassId int primary key,
Economy_clsId int ,
Businesscls_id int )
create table EconomyClass(
Economy_clsId int primary key,
ClassId int FOREIGN KEY REFERENCES Classes(ClassId)
)
create table BusinessClass(
Business_clsId int primary key,
ClassId int FOREIGN KEY REFERENCES Classes(ClassId)
)

create table passengers(
PId int identity(1,1) primary key,
BookingId int foreign key references book(BookingId), 
PassangerName varchar(30),
 DateOfBirth date,
 Age int,
 Address varchar(50),
 city varchar(20),
 State varchar(20),
 pincode int,
 ContactNumber nchar(10)
)
select*from passengers
select* from Booking
drop table Booking
drop table Payment
create table Payment(
Paymentid int primary key,
Amount money,
paymentDate Date,
TransactionId int identity(1,42378890),
BookingId int FOREIGN KEY REFERENCES Book(BookingId),
PaymentMode varchar(20),
 )
 drop table Payment
 alter table payment
 alter column  BookingId int FOREIGN KEY REFERENCES Book(BookingId) 
 DELETE FROM Flights WHERE FlightNumber=23456;

 create table Booking(BookingId int Identity(23456,1) primary key,
 FlightNumber int FOREIGN KEY REFERENCES Flights(FlightNumber),
 PassangerName varchar(30),
 DateOfBirth date,
 Age int,
 Address varchar(50),
 city varchar(20),
 State varchar(20),
 pincode int,
 ContactNumber nchar(10),
 ClassType varchar(15),
  )
  alter table Booking
  add NumberOfPassengers int,
  alter table Booking
  drop column NumberOfChildren int
  
  select*from Booking

 select*from Book B
 INNER JOIN FLIGHTS F ON F.FlightNumber=B.FlightNumber
 SELECT * FROM PAYMENT
