create table SizeWorksheetMap
(
	id serial primary key,
	idworksheet int references worksheets(id),
	idsizes int references sizes(id)
);

create table OptionWorksheetMap
(
	id serial primary key,
	idworksheet int references worksheets(id),
	idproductoptions int references productoptions(id)
);

create or replace view SizeWorksheetElements as
select SizeWorksheetMap.idworksheet, SizeWorksheetMap.idsizes,
sizes.name from SizeWorksheetMap join sizes on SizeWorksheetMap.idsizes = sizes.id;

create or replace view OptionWorksheetElements as
select OptionWorksheetMap.idworksheet, OptionWorksheetMap.idproductoptions,
productoptions.name from OptionWorksheetMap join productoptions 
on OptionWorksheetMap.idproductoptions = productoptions.id;

insert into SizeWorksheetMap (idsizes, idworksheet) select distinct idsizes, idworksheet 
from productsize join products on products.id = productsize.idproducts;

insert into OptionWorksheetMap (idproductoptions, idworksheet) select distinct idproductoptions, idworksheet 
from productoptionvalues join products on products.id = productoptionvalues.idproducts;
