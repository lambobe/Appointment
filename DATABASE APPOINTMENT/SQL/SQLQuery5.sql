use Appointment
create table appointmentform(
	AppointmentID	int	primary key not null,
	fullname	varchar(250),
	contactNo	int,
	email	varchar(250),
	homeadd	varchar(250),
	issue	varchar(250),
	charge	varchar(250),
	addinfo	varchar(250),
	technician	varchar(250),
	schedule	varchar(250),
	method	varchar(250),
);
drop table appointmentform
create table cash(
	AppointmentID int,
	cashamount int,
	cashfee varchar(50),
	cashchange varchar(50),
	
	
);
use Appointment
drop table bank
select * from bank


create table bank(
	AppointmentID int,
		bankfee varchar(50),
	banknumber int,
	bankname varchar(250)
	
	);