create database dbsistema;
use dbsistema;
create table tbusuarios(
Id int primary key,
Nome varchar(50),
Email varchar(50),
Senha varchar(25)
);
create table tbprodutos(
Id int primary key,
Nome varchar(50),
Descricao varchar(2000),
Preco numeric(10,2)
);