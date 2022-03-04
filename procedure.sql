CREATE PROCEDURE InserirPessoa
    @nome        VARCHAR(50),
    @sobrenome   VARCHAR(100),
    @endereco    VARCHAR(MAX),
    @cpf         VARCHAR(15),
    @numeroConta INT
AS BEGIN
    DECLARE @idDaConta INT;

    INSERT INTO ContaCorrente (
        NumeroDaConta,
        Saldo
    ) VALUES (@numeroConta, 0);

    SELECT @idDaConta = Id FROM ContaCorrente WHERE NumeroDaConta = @numeroConta;

    INSERT INTO PessoaFisica (
        Nome, Sobrenome, Endereco, CPF, IdContaCorrente
    ) VALUES 
        (@nome, @sobrenome, @endereco, @cpf, @idDaConta);
END