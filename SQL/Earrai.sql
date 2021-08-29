drop view userRoles;

drop table worksheetcontents;
drop table worksheetcontentshistory;
drop table worksheets;
drop table workbooks;
drop table users;
drop table roles;

create table roles
(
	id serial primary key,
	name text
);

create table users
(
	id serial primary key,
	firstName text,
	lastName text,
	email text,
	password text,
	emailConfirmed int default 0,
	idRole int references roles(id) default 1
);

create table workbooks
(
	id serial primary key,
	idOfFile text,
	fileName text,
	createdAt timestamp,
	updatedAt timestamp
);

create table worksheets
(
	id serial primary key,
	idworkbook int references workbooks (id),
	sheetName text,
	createdAt timestamp,
	updatedAt timestamp
);

create table worksheetcontents
(
	id serial primary key,
	idworksheet int references worksheets (id),
	columnIndex int,
	rowIndex int,
	value text,
	createdAt timestamp,
	updatedAt timestamp
);

create table worksheetcontentshistory
(
	id serial primary key,
	idworksheet int references worksheets (id),
	columnIndex int,
	rowIndex int,
	value text,
	createdAt timestamp
);

create table areas
(
	id serial primary key,
	code text,
	name text
);

create table areaquantity
(
	id serial primary key,
	idArea int references areas(id),
	idUser int references users(id),
	quantity text,
	lengthDimensions text,
	createdAt timestamp,
	updatedAt timestamp
);



create or replace view userRoles as
select users.id, users.firstName, users.lastName, users.email, users.password, users.emailConfirmed, roles.name
from users 
join roles on roles.id = users.idRole;



select * from users;
select * from roles;
select * from userRoles;
select * from workbooks;
select * from worksheets;
select * from worksheetcontents;
select * from worksheetcontentshistory;
