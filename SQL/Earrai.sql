drop view userRoles;

drop table workbookcontent;
drop table workbooks;
drop table worksheets;
drop table users;
drop table roles;


create table worksheets
(
	id serial primary key
);

create table workbooks
(
	id serial primary key,
	idworksheet int references worksheets (id)
);

create table workbookcontent
(
	id serial primary key,
	idworkbook int references workbooks (id),
	columnNumber int,
	columnName text default 'noName',
	rowNumber int,
	value text
);

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

create or replace view userRoles as
select users.id, users.firstName, users.lastName, users.email, users.password, users.emailConfirmed, roles.name
from users 
join roles on roles.id = users.idRole;



select * from users;
select * from roles;
select * from userRoles;
