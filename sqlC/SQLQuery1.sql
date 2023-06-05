create database dotconect;

use dotconect;

create table pessoa(
id int primary key identity(1,1),
nome varchar(255) not null,
email varchar(255)
);
select * from pessoa;

drop table pessoa;