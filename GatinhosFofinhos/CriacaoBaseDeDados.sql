CREATE DATABASE GatinhosFofinhos;
USE GatinhosFofinhos;

CREATE TABLE tb_categorias (
    Id          INT NOT NULL IDENTITY(1,1),
    Nome        NVARCHAR(25) NOT NULL,
    Descricao   NVARCHAR(140) NULL,
    IdCategoria INT NOT NULL,
)