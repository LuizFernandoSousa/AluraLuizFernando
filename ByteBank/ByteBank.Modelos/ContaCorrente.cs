using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class ContaCorrente : IComparable
    {
        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get;private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int agencia;
        public int numero;
        public double saldo;
        
        public static double Taxaoperacao { get; private set; }
        public static int TotalDeContasCriadas { get; private set; }


        public int Numero { get;}
        public int Agencia {get;}

        private double _saldo;
        public double Saldo { get; set; }


        public ContaCorrente(int agencia, int numero){

            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.",nameof(agencia));
                
            }
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.",nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            

            TotalDeContasCriadas++;
            Taxaoperacao = 30 / TotalDeContasCriadas;
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor invalido para o saque",nameof(valor));
            }
            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo,valor);
            }
            
                _saldo -= valor;
            
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor invalido para a transferencia", nameof(valor));
            }

            try 
            {

                Sacar(valor);

            } catch (SaldoInsuficienteException e) 
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.",e);
            
            }
            
            contaDestino.Depositar(valor);
               
            }



        public override bool Equals(object obj)
        {
            ContaCorrente outraConta = obj as ContaCorrente;

            if (outraConta == null)
            {
                return false;
            }

            return Numero == outraConta.Numero && Agencia == outraConta.Agencia;
        }

        public int CompareTo(object obj)
        {

            var outraConta = obj as ContaCorrente;

            if (outraConta == null)
            {
                return -1;
            }

            if (Numero < outraConta.Numero)
            {
                return -1;
            }
            if (Numero == outraConta.Numero)
            {
                return 0;
            }
            return 1;

        }
    }


}

