using System.Reflection.Metadata.Ecma335;

namespace SistemaBancario.Models
{
    //Classe abstrata aplicando o Pilar da abstração uma classe abstrata não pode ser instanciada
    public class RepositorioBanco
    {
        //Pilar encapsulamento: campos privados protegidos por propiedades publicas
        private string _numeroConta;
        private decimal _saldo;

        // propiedade pública numero conta
        public string NumeroConta
        {
            get => _numeroConta;
            protected set => _numeroConta = value;
        }
        // propiedade pública saldo 
        public decimal Saldo
        {
            get => _saldo;
            protected set => _saldo = value < 0 ? 0 : value;
        }
        // Propiedade publica Nome Titular
        public string NomeTitular { get; set; }
        // Propiedade publica historico de transações para gerar extrato de transações
        public List<string> ExtratoTransacoes { get; set; } = new List<string>();
        // Construtor da classe base
        protected ContaBancaria(string numeroConta, string nome, decimal saldoInicial, string nomeTitular)
        {
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
            Saldo = saldoInicial;
            ExtratoTransacoes.Add($"Conta criada com saldo inicial de R$ {saldoInicial:f2}");
        }

        // Metodo Virtual (Polimorfismo ns classes filhas)
        public virtual void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                ExtratoTransacoes.Add($"Deposito +R$ {valor:F2} | Saldo atual: {Saldo:f2}");
            }
        }
        //Metodo abstrato: Obruiga as classes filhas a implementarem sua prorpia regra de saque

        public abstract bool Sacar (decimal Valor) 
        {
        
        }
    }


}
