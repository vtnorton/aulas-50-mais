--Criando base de dados
CREATE DATABASE TesteSQL;

--Usando base de dados
USE TesteSQL;

CREATE TABLE PessoaFisica (
    Id          INT             IDENTITY (1,1) PRIMARY KEY,
    Nome        VARCHAR(50)     NOT NULL,
    Sobrenome   VARCHAR(100)    NOT NULL,
    Endereco    VARCHAR(MAX)    NULL,
    CPF         VARCHAR(15)     NOT NULL
);

CREATE TABLE ContaCorrente (
    Id              INT             IDENTITY(1,1)   PRIMARY KEY,
    NumeroDaConta   INT             NOT NULL,
    Saldo           FLOAT           NOT NULL
);

CREATE TABLE Transacoes(
    Id          INT             IDENTITY(1,1)   PRIMARY KEY,
    Valor       FLOAT           NOT NULL,
    Descricao   VARCHAR(MAX)    NULL
);

ALTER TABLE PessoaFisica
ADD IdContaCorrente INT NOT NULL;

ALTER TABLE PessoaFisica
ADD FOREIGN KEY (IdContaCorrente) REFERENCES ContaCorrente(Id);

ALTER TABLE Transacoes
ADD ContaOrigem    INT NOT NULL,
    ContaDestino   INT NOT NULL;

ALTER TABLE Transacoes
ADD FOREIGN KEY (ContaOrigem) REFERENCES ContaCorrente(Id),
    FOREIGN KEY (ContaDestino) REFERENCES ContaCorrente(Id);

--Inserindo dados na tabela

INSERT INTO ContaCorrente(
    NumeroDaConta,
    Saldo
)VALUES(
    25,
    0
),(42,50),(56,120); 

INSERT INTO PessoaFisica (
    Nome,
    Sobrenome,
    Idade,
    Endereco,
    CPF,
    IdContaCorrente
)VALUES(
    'Cristiane',
    'Martins',
    42,
    'Av. Sao Paulo',
    '000.000.000-00',
    1
),
(
    'Daniela',
    'Silva',
    28,
    'Rua Jona Zulske',
    '000.000.000-00',
    2
),
(
    'Camila',
    'Ribeiro',
    55,
    'Rua Parana',
    '000.000.000-00',
    3
);

SELECT * FROM PessoaFisica;

--Como deletar item

DELETE FROM PessoaFisica WHERE Id=6;

--Como atualizar item

--UPDATE PessoaFisica
    --SET IdContaCorrente = 4 WHERE Id=7;

SELECT * FROM PessoaFisica;

ALTER TABLE PessoaFisica
    ADD Idade   INT     NULL;

UPDATE PessoaFisica
    SET Idade = 24 WHERE Id=3;

SELECT * FROM PessoaFisica;

SELECT * FROM ContaCorrente;

SELECT * From Transacoes;

INSERT INTO Transacoes (
    Valor,
    Descricao,
    ContaOrigem,
    ContaDestino
)VALUES(
    51,
    'Credito',
    2,
    1
);

