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
        static void TesteInterfaceComparacao()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(543566,9),
                new ContaCorrente(745676,5),
                new ContaCorrente(235235,2),
                new ContaCorrente(865454,6),
                new ContaCorrente(453534,1),

            };

            var listaSemNulos = new List<ContaCorrente>();

            foreach (var conta in contas)
            {
                listaSemNulos.Add(conta);
            }


            //IEnumerable<ContaCorrente> contaCorrentes =
            //    contas.Where(conta => contas != null) ;

            IOrderedEnumerable<ContaCorrente> listaOrdenada = contas
                .Where(conta => contas != null)
                .OrderBy<ContaCorrente, int>(conta => conta.Numero);


            foreach (var conta in listaOrdenada)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");

            }




            List<int> idades = new List<int>();

            idades.Add(6);
            idades.Add(32);
            idades.Add(12);
            idades.Add(64);
            idades.Add(21);



            idades.AdicionarVarios(123, 3123, 421, 4243);

            idades.AdicionarVarios(99, -1);


            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }

        }
        static void TesteDeArray()
        {


            int[] idades = new int[5];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 52;
            idades[3] = 12;
            idades[4] = 57;

            int acumulador = 0;

            for (int indice = 0; indice <= idades.Length; indice++)
            {
                int idade = idades[indice];
                acumulador += idade;
            }

            int media = acumulador / idades.Length;

            Console.WriteLine(media);


        }


    }

    
}