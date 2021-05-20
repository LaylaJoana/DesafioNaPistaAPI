
-- Script Para Criação do Banco e tabelas

CREATE DATABASE DesafioNaPista;

-- Table: produto
-- DROP TABLE produto;

CREATE TABLE produto
(
    id serial NOT NULL,
    nome varchar(100) NOT NULL,
    valor_unitario numeric(10,2) NOT NULL,
    qtde_estoque int NOT NULL,
    PRIMARY KEY (id) 
);
-- Table: venda
-- DROP TABLE venda;

CREATE TABLE venda
(
    id serial NOT NULL,
	id_produto INT NOT NULL,
	qtde_comprada  INT NOT NULL,
	valor_venda numeric(10,2) NOT NULL,
	data_venda timestamp without time zone,
         PRIMARY KEY (id),
	CONSTRAINT fk_venda_produto FOREIGN KEY (id_produto) REFERENCES produto (Id)
 
);

