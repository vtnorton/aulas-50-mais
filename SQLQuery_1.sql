-- Criando base de dados
CREATE DATABASE Aulas50;

-- Usar a base de dados
USE Aulas50;

CREATE TABLE PessoaFisica (
    Id          INT         IDENTITY(1,1)  PRIMARY KEY,
    Nome        VARCHAR(50)     NOT NULL,
    Sobrenome   VARCHAR(100)    NOT NULL,
    Endereco    VARCHAR(MAX)    NULL,
    CPF         VARCHAR(15)     NOT NULL
);

CREATE TABLE ContaCorrente (
    Id              INT         IDENTITY(1,1)   PRIMARY KEY,
    NumeroDaConta   INT         NOT NULL,
    Saldo           FLOAT       not NULL
);

CREATE TABLE Transacoes (
    Id              INT             IDENTITY(1,1)   PRIMARY KEY,
    Valor           FLOAT           NOT NULL,
    Descricao       VARCHAR(MAX)    NULL
);

ALTER TABLE PessoaFisica
ADD idContaCorrente     INT     NOT NULL;

ALTER TABLE PessoaFisica
ADD FOREIGN KEY (IdContaCorrente) REFERENCES ContaCorrente(Id);

ALTER TABLE Transacoes
ADD ContaOrigem INT NOT NULL,
    ContaDestino INT NOT NULL;

ALTER TABLE Transacoes
ADD FOREIGN KEY (ContaOrigem) REFERENCES ContaCorrente(Id),
    FOREIGN KEY (ContaDestino) REFERENCES ContaCorrente(Id);


-- INSERINDO DADOS NA TABELA --
INSERT INTO ContaCorrente (
    NumeroDaConta,
    Saldo
) VALUES (45,0)

SELECT * FROM ContaCorrente;


INSERT INTO PessoaFisica (
    Nome, Sobrenome, Endereco, CPF, idContaCorrente

) VALUES (
    'Ana',
    'Rodrigues',
    'Sergio Lamarca',
    '123.446.789-00',
    1
)
-- Tem que adicionar outra conta corrente, senão ele conflita pelo relacionamento entre as tabelas ---
SELECT * FROM PessoaFisica;

INSERT INTO PessoaFisica (
    Nome, Sobrenome, Endereco, CPF, idContaCorrente

) VALUES (
    'Flavia',
    'Rodrigues',
    'Mogi Guacu',
    '999.888.777-55',
    2
)

SELECT * FROM PessoaFisica WHERE Endereco = 'Sorocaba';
SELECT * FROM PessoaFisica;

DELETE FROM PessoaFisica WHERE Id = '5';
SELECT * FROM PessoaFisica;

-- Como atualizar um item ---
UPDATE PessoaFisica
    SET Idade = '53'
    WHERE Id = 7;

ALTER TABLE PessoaFisica
ADD Idade     INT     NOT NULL DEFAULT (18);






