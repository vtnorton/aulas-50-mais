-- Criando base de dados
CREATE DATABASE Aulas50Vitor; 

-- Usar a base de dados
USE Aulas50Vitor;

DROP TABLE PessoaFisica;
CREATE TABLE PessoaFisica (
    Id          INT             IDENTITY(1,1) PRIMARY KEY,
    Nome        VARCHAR(50)     NOT NULL,
    Sobrenome   VARCHAR(100)    NOT NULL,
    Endereco    VARCHAR(MAX)    NULL,
    CPF         VARCHAR(15)     NOT NULL
);

CREATE TABLE ContaCorrente(
    Id              INT             IDENTITY(1,1) PRIMARY KEY,
    NumeroDaConta   INT             NOT NULL,
    Saldo           FLOAT           NOT NULL
); 

CREATE TABLE Transacoes(
    Id              INT             IDENTITY(1,1) PRIMARY KEY,
    Valor           FLOAT           NOT NULL,
    Descricao       VARCHAR(MAX)    NULL
);

ALTER TABLE PessoaFisica 
ADD IdContaCorrente INT NOT NULL;

ALTER TABLE PessoaFisica
ADD FOREIGN KEY (IdContaCorrente) REFERENCES ContaCorrente(Id);

ALTER TABLE Transacoes 
ADD ContaOrigem INT NOT NULL, 
    ContaDestino INT NOT NULL;

ALTER TABLE Transacoes
ADD FOREIGN KEY (ContaOrigem) REFERENCES ContaCorrente(Id),
    FOREIGN KEY (ContaDestino) REFERENCES ContaCorrente(Id);

ALTER TABLE ContaCorrente
ADD Ativado BIT DEFAULT 1

-- INSERINDO DADOS NA TABELA --
INSERT INTO ContaCorrente (
    NumeroDaConta,
    Saldo
) VALUES (45, 0)
SELECT * FROM ContaCorrente;

UPDATE ContaCorrente
    SET Ativado = 0
    WHERE NumeroDaConta = 45;

INSERT INTO PessoaFisica (
    Nome, Sobrenome, Endereco, CPF, IdContaCorrente
) VALUES 
    ('Vitor', 'Norton', 'Av. Mofarrej', '000.000.000-00', 1),
    ('Luiza', 'Norton', 'Rua Dom Silverio', '009.999.985-74', 2);

SELECT * FROM PessoaFisica;
SELECT * FROM PessoaFisica WHERE Sobrenome = 'Silva';

-- COMO DELETAR UM ITEM --
DELETE FROM PessoaFisica WHERE Id = 7;
SELECT * FROM PessoaFisica;

-- COMO ATUALIZAR UM ITEM --
UPDATE PessoaFisica 
    SET Ativado = 1
    WHERE Id = 8;
SELECT * FROM PessoaFisica WHERE Ativado = 1;

UPDATE PessoaFisica 
    SET CPF = '777.555.444-22' 
    WHERE Id = 3;
SELECT * FROM PessoaFisica;


EXEC InserirPessoa  @nome = 'Michael',
                    @sobrenome = 'Jackson',
                    @endereco = 'Los Angeles',
                    @cpf = '452.854.556-52',
                    @numeroConta = 985;