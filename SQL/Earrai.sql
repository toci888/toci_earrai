drop table users;

create table users
(
	id serial primary key,
	login text,
	email text,
	password text,
	phone text,
	emailConfirmed int default 0,
	token text
);

create table roles
(
	id serial primary key,
	name text
);

select * from users;
select * from roles;