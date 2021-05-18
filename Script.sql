
-- Script Para Criação do Banco e tabelas

CREATE DATABASE DesafioNaPista;

-- Table: public.produto

CREATE TABLE public.produto
(
    id serial NOT NULL,
    nome varchar(100) NOT NULL,
    valor_unitario numeric(10,2) NOT NULL,
	qtd_estoque int NOT NULL,
	CONSTRAINT produto_pkey PRIMARY KEY (id)
 
);
-- Table: public.venda

CREATE TABLE public.venda
(
    id serial NOT NULL,
	id_produto INT NOT NULL,
	qtde_comprada  INT NOT NULL,
	valor_venda numeric(10,2) NOT NULL,
	data_venda date,
	FOREIGN KEY (id_produto) REFERENCES produto (Id)
 
);


