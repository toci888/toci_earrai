drop view userRoles;
drop view AreasQuantities;
drop view QuotesAndPrices;

drop table productsize;
drop table sizecategories;
drop table sizes;
drop table quoteandprice;
drop table productoptionvalues;
drop table productcategoryoptions;
drop table productoptions;
drop table products;
drop table commisions;
drop table categories;
drop table categorygroups;
drop table worksheetcontents;
drop table worksheetcontentshistory;
drop table areaquantity;
drop table areas;
drop table codesdimensions;
drop table worksheets;
drop table workbooks;
drop table users;
drop table roles;
drop table vendors;
drop table quoteandmetric;

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
	initials text,
	email text,
	password text,
	emailConfirmed int default 0,
	token text,
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

create table categorygroups
(
	id serial primary key,
	name text
);

create table categories
(
	id serial primary key,
	idcategorygroups int references categorygroups(id),
	name text,
	prefix text,
	description text
);

create table commisions
(
	id serial primary key,
	idcategories int references categories(id),
	title text,
	quotient float
);

create table products
(
 	id serial primary key,
	idcategories int references categories(id),
	idworksheet int references worksheets (id),
	rowIndex int,
	productaccountreference text,
	description text,
	length text,
	width text,
	thickness text
);

create table productoptions
(
	id serial primary key,
	code text,
	name text
);

create table productcategoryoptions
(
	id serial primary key,
	idcategories int references categories(id),
	idproductoptions int references productoptions(id)
);

create table productoptionvalues
(
	id serial primary key,
	idproductoptions int references productoptions(id),
	idproducts int references products(id),
	value text
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

create table codesdimensions
(
	id serial primary key,
	code text,
	kind int
);

create table areaquantity
(
	id serial primary key,
	idworksheet int references worksheets (id),
	idcodesdimensions int references codesdimensions (id),
	idArea int references areas(id),
	idUser int references users(id),
	rowIndex int,
	quantity text,
	length text,
	width text,
	createdAt timestamp default now(),
	updatedAt timestamp default now()
);

create table vendors
(
 	id serial primary key,
	name text
);

create table quoteandmetric
(
 	id serial primary key,
	name text,
	valuation text
);

create table quoteandprice
(
 	id serial primary key,
	idworksheet int references worksheets (id),
	rowIndex int,
	price text,
	idvendor int references vendors (id),
	idquoteandmetric int references quoteandmetric (id),
	iduser int references users (id)
);

create table sizes
(
	id serial primary key,
	name text
);

create table sizecategories
(
	id serial primary key,
	idsizes int references sizes(id),
	idcategories int references categories(id)
);

create table productsize
(
	id serial primary key,
	idsizes int references sizes(id),
	idproducts int references products(id),
	value text
);


create or replace view AreasQuantities as 
select areaquantity.id, areaquantity.idworksheet, areaquantity.idcodesdimensions, areaquantity.idArea, areaquantity.idUser, 
areaquantity.rowIndex, areaquantity.quantity, areaquantity.length, areaquantity.width, areaquantity.createdAt, areas.code as areacode, areas.name as areaname, 
users.initials 
from areaquantity join areas on areaquantity.idArea = areas.id 
join users on areaquantity.idUser = users.id;

create or replace view QuotesAndPrices as
select quoteandprice.id, quoteandprice.idworksheet, quoteandprice.rowindex, quoteandprice.price, quoteandprice.idvendor, 
quoteandprice.idquoteandmetric, quoteandprice.iduser, quoteandmetric.valuation as valuation, vendors.name as vendor, users.initials
from quoteandprice join quoteandmetric on quoteandprice.idquoteandmetric = quoteandmetric.id
join vendors on quoteandprice.idvendor = vendors.id
join users on quoteandprice.iduser = users.id;

create or replace view userRoles as
select users.id, users.firstName, users.lastName, users.email, users.password, users.emailConfirmed, users.token ,roles.name
from users 
join roles on roles.id = users.idRole;


select * from users;
select * from roles;
select * from userRoles;
select * from workbooks;
select * from worksheets;
select * from worksheetcontents;
select * from worksheetcontentshistory;
select * from areas;
select * from vendors;
select * from areaquantity;
select * from codesdimensions;
select * from AreasQuantities;
select * from quoteandmetric;
select * from quoteandprice; 
select * from QuotesAndPrices;

