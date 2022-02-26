namespace BancoRoxinho.Dominio.Model
{

    public class Pessoa
    {
        public string Endereco;
        public ContaCorrente ContaCorrente;

        public Pessoa()
        {
            ContaCorrente = new ContaCorrente();
        }


    }
}

