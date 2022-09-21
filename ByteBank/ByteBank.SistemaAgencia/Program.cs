using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;

namespace ByteBank.SistemaAgencia
{
    public class Program
    {
        static void Main(string[] args)
        {
            Lista<int> lista = new Lista<int>();



            for (int i = 0; i < lista.tamanho; i++)
            {
                int idade = (int)lista[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }





            Console.ReadLine();

        }


        public static void TesteDeArray()
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