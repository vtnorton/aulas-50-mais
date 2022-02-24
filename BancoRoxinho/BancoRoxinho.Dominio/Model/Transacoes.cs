namespace BancoRoxinho.Dominio.Model
{
    public class Transacoes
    {
        public float Valor;
        public string Descricao;
        public ContaCorrente ContaOrigem = new ContaCorrente();
        public ContaCorrente ContaDestino = new ContaCorrente();
    }
}