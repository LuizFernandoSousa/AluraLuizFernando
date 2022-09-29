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
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {

                var contaComoString = "3213,423423,432423.53,Alguma coisa";
                var encoding = Encoding.UTF8;


                var bytes = encoding.GetBytes(contaComoString);


                fluxoDeArquivo.Write(bytes, 0,bytes.Length);


            }

        }

        static void CriarArquivoComWrite()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo,FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.Write("321,432423,5234.23,Lucas algo");
            }
        }

        static void TestaEscrita()
        {
            var caminhoArquivo = "teste.txt";

            using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                for (int i = 0; i < 100; i++)
                {
                    escritor.WriteLine($"Linha {i}");
                    Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter para adicionar mais!");
                    Console.ReadLine();

                }
            }



        }





    }

}