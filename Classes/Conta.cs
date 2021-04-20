using System;

namespace DIO.Bank
{
	public class Conta
	{
		// Atributos
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private double CreditoTotal { get; set; }
		private string Nome { get; set; }

		// Métodos
		public Conta(TipoConta tipoConta, double saldo, double credito, double creditoTotal, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.CreditoTotal = creditoTotal;
			this.Nome = nome;
		}

		public bool Sacar(double valorSaque)
		{
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

            return true;
		}

		public bool UtilizarCredito(double valorSaque)
		{
            // Validação de saldo suficiente
            if (valorSaque > this.Credito){
                Console.WriteLine("Crédito insuficiente!");
                return false;
            }
            this.Credito -= valorSaque;

            Console.WriteLine("Credito atual da conta de {0} é {1}", this.Nome, this.Credito);
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

            return true;
		}
		public bool PagarFatura(int confirmacao)
		{
            if (confirmacao == 2){
                Console.WriteLine("Pagamento Cancelado!");
                return false;
            }

			this.Credito += (this.CreditoTotal - this.Credito);

			Console.WriteLine();
			Console.WriteLine("Fatura Paga! Crédito atual da conta de {0} agora é {1}", this.Nome, this.Credito);
			Console.WriteLine();
            Console.WriteLine("A fatura atual agora é {0}", (this.CreditoTotal - this.Credito));
			return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}

/*        public double ExibirFatura()
		{
            double retorno = (this.CreditoTotal - this.Credito);
			return retorno;
		} */

        public override string ToString()//Listar Contas
		{
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito + " | ";
			retorno += "Fatura Atual " + (this.CreditoTotal - this.Credito);
			return retorno;
		}
	}
}