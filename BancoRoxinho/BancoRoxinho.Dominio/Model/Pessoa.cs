namespace BancoRoxinho.Dominio.Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Endereco;
        public ContaCorrente ContaCorrente;

        public Pessoa()
        {
            ContaCorrente = new ContaCorrente();
        }
    }
}
