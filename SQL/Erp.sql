drop table ErpProductValues cascade;
drop table ErpColumns;



create table ErpColumns
(
	id serial primary key,
	name text
);

create table ErpProductValues
(
	id serial primary key,
	value text,
	idErpColumn int references ErpColumns (id),
	idProduct int references products (id)
);

create or replace view ErpProduct as 
select products.productaccountreference, ErpColumns.name, ErpProductValues.value, ErpProductValues.idProduct
from products join ErpProductValues on products.id = ErpProductValues.idProduct
join ErpColumns on ErpColumns.id = ErpProductValues.idErpColumn;

select * from ErpColumns;
select * from ErpProductValues;
select * from ErpProduct;
