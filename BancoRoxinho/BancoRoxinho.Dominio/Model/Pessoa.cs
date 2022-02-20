namespace BancoRoxinho.Dominio.Model
{
    public class Pessoa
    {
        public string Endereco;
        public ContaCorrente ContaCorrente = new ContaCorrente();
        public Pessoa()
        {

        }
    }
}
