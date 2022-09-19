using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Funcionarios;
using ByteBank.Sistemas;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            UsarSistema();

            Console.ReadLine();

        }

        public static void UsarSistema()
        {




            SistemaInterno sistemaInterno = new SistemaInterno();
            Diretor roberta = new Diretor("123.213.543-32",3233);
            roberta.Nome = "Roberta";
            roberta.Senha = "123";

            GerenteDeConta camila = new GerenteDeConta("123.213.543-32", 4122);
            camila.Nome = "Camila";
            camila.Senha = "abc";

            ParceiroComercial parceiro = new ParceiroComercial();
            parceiro.Senha = "1234";


            sistemaInterno.Logar(parceiro, "1234");
            sistemaInterno.Logar(roberta,"123");
            sistemaInterno.Logar(camila, "abc");
        }

        public void CalcularBonificacao()
        {
            GerenciadorBonificacao ger = new GerenciadorBonificacao();


        }
    }

}