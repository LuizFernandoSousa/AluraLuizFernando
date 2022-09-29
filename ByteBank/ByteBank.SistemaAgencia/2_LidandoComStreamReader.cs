using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparador;
using System.IO;

namespace ByteBank.SistemaAgencia
{
    partial class Program
    {
        static void LidandoComFilesStreamDiretamente()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024];

                fluxoDoArquivo.Read(buffer, 0, 1024);
                var numeroDeByteLidos = -1;


                while (numeroDeByteLidos != 0)
                {
                    numeroDeByteLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    Console.WriteLine($"Bytes lidos: {numeroDeByteLidos}");
                    EscreverBuffer(buffer, numeroDeByteLidos);
                }
            }

            Console.ReadLine();


        }
        static void EscreverBuffer(byte[] buffer, int byteLidos)
        {
            var utf8 = new UTF8Encoding();

            var texto = utf8.GetString(buffer, 0, byteLidos);

            Console.Write(texto);


            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }
        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            string[] campos = linha.Split(' ');


            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2].Replace(".", ",");
            var nomeTitular = campos[3];

            var agenciaComoInt = int.Parse(agencia);
            var numeroComoInt = int.Parse(numero);
            var saldoComoInt = Double.Parse(saldo);

            var titular = new Cliente();
            titular.Nome = nomeTitular;


            var resultado = new ContaCorrente(agenciaComoInt, numeroComoInt);
            resultado.Depositar(saldoComoInt);
            resultado.Titular = titular;

            return resultado;


        }

        static void TesteDoStreamRead()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);

                    var msg = ($"Conta número {contaCorrente.Numero}, ag. {contaCorrente.Agencia}. Saldo: {contaCorrente.Saldo}");

                    Console.WriteLine(msg);
                }

            }


        }
       


    }
}