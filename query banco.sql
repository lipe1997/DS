create database restaurante;

use restaurante;

create table tb_funcionario(
id int identity primary key,
nome varchar(40) not null,
endereco varchar(40) not null,
rg varchar(11) not null,
cpf varchar(14) not null,
cidade varchar(30) not null,
numero varchar(40) not null,
telefone varchar(18) not null,
bairro varchar(40) not null,
conta varchar(15) not null,
agencia varchar(15) not null,
banco varchar(15) not null
);

create table tb_login(
id int identity primary key,
usuario varchar(50) not null,
senha varchar(40) not null 
);

insert into tb_login(usuario,senha) values('filipe','123456');

create table tb_produto(
id int identity primary key,
nome varchar(40) not null,
descricao varchar(40) not null,
categoria varchar(30) not null,
subcategoria varchar(30) not null,
qtd varchar(6) not null,
marca varchar(20) not null
);


select * from tb_funcionario;

update tb_produto set nome = 'REFRIGERANTE', descricao = 'garrafa',categoria = 'Perecível',subcategoria = 'Bebida não alcoolica', qtd = 10,marca = 'dolly' where nome = 'Cerveja' and marca ='Itaipava';

