--CREATE TABLE medicine (
--    mname varchar(50) NOT NULL,
--    mtype varchar(50),
--    cid int,
--    PRIMARY KEY (mname),
--	FOREIGN KEY (cid) REFERENCES company (cid)
--);

--CREATE TABLE company (
--    cname varchar(50) NOT NULL,
--    clocation varchar(199),
--	ccity varchar (50),
--    cid int,
--    PRIMARY KEY (cid)
--);

--create table adminlogin (
--	username varchar (50),
--	pass varchar (50)
--);

--CREATE TABLE stock(
--    mname varchar(50) NOT NULL,
--    price decimal (5,2) ,
--    quantity int ,
--    PRIMARY KEY (mname),
--	FOREIGN KEY (mname) REFERENCES medicine (mname)
--);

--CREATE TABLE sales (
--    saleid int IDENTITY(1,1) PRIMARY KEY,
--    mname varchar(50) NOT NULL,
--    squantity int,
--	dt date,
--	FOREIGN KEY (mname) REFERENCES medicine (mname)
--);

--insert into adminlogin values ('admin', 'admin')
--update adminlogin set name values ('abhi') where username = 'admin'
--select cname from company
--insert into company (cid, cname) values (4,'company4')
--insert into medicine values ('mname', 'mtype', 1)
--select cid from company where cname = 'company1'
--select * from medicine where mname = 'xyz'
--select max(cid) from company
--select * from company where cname = 'company1'
--insert into company values ('{cname}', '{clocation}', '{ccity}', 5)
--select mname from medicine
--select * from medicine where mname = 'mname'
--select cname from company where cid = 1
--delete from medicine where mname = 'mname'
--select * from company where cname = '{cname}'
--delete from company where cname = 'company1'
--insert into company values ('{cname}', '{clocation}', '{ccity}', 5)
--delete from company
--update company set cname = 'New pharma.', clocation = 'Punjab', ccity = 'Amritsar'where cname = 'New pharma. co.';
--select m.mname as 'Name',m.mtype as 'Type', cname as 'Company' from medicine as m left join company as c on c.cid = m.cid 
--select * from medicine 
--select * from company 
--select cid as 'Company ID', cname as 'Name',ccity as 'City', clocation as 'Location' from company
--select mname from medicine where mname like 'Cr%'
--select m.mname ,m.mtype, cname from medicine as m left join company as c on c.cid = m.cid where mname = 'Crosin'
--select cname from company where cname like 'new%'
--select mname as 'Medicine Name', price as 'Price', quantity as 'Quantity' from stock
--insert into stock (mname) values ('Cofsil')
--update stock set price = 500, quantity = 100 where mname = '{mname}'
--insert into stock values ({},300, 300)
--update stock set price = 67, quantity = 900 where mname = 'Dolo 650'
--select saleid as ID , mname as 'Name of medicine', squantity as 'Quantity', dt as 'Date', custname as 'Customer Name', contact as 'Contact no.' from sales
--alter table sales drop column saleid
--select * from sales
--insert into sales values ('crosin', 10, '1/1/1000')
--update stock set quantity = 45 where mname = 'Benadrill'
--insert into sales values ('{label5.Text}', 90 , '10/10/1000')
--select * from medicine
--select * from sales
--select c.cname as 'Company Name',m.mname 'Type', cname as 'Company' from medicine as m left join company as c on c.cid = m.cid
--select mname as 'Name' , mtype as 'Type' from medicine where cid = 1

--select saleid as 'Sale ID', mname as 'Medicine Name', squantity as 'Quantity', dt as 'Date'  from sales where dt between '' and '' 
--Select mname as 'Medicine', Sum(squantity) as 'Total sold units' from sales where mname = 'crosin' group by mname
--select mname as 'Medicine', sum(squantity) as 'Total sold units'  from sales where dt between '' and '' group by mname

--select * from sales
--select * from medicine

--update adminlogin set username = 'admins'

--truncate table company

--update stock  set mname = 'champ 450' where mname = 'Champ 550'

--delete from stock where mname = 'dolo 400'

--select saleid as 'Sale ID', mname as 'Medicine Name', squantity as 'Quantity', dt as 'Date' from sales 
--update medicine set mname = 'Clean ups' , mtype = 'Cream', cid = 4 where mname = 'clean up'

--update stock set mname = 'Clean ups' where mname = 'clean up'

select * from stock
select * from medicine

--delete from medicine where mname = 'clean up'
--delete from stock where mname = 'Dolo 400'
--insert into stock (mname) values ('xyz')