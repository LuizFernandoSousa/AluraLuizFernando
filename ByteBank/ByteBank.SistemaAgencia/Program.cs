﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparador;

namespace ByteBank.SistemaAgencia
{
    public class Program
    {
        static void Main(string[] args)
        {

            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(543566,9999),
                new ContaCorrente(745676,5233),
                new ContaCorrente(235235,2131),
                new ContaCorrente(865454,7345),
                new ContaCorrente(453534,1),

            };

            //contas.Sort();

            contas.Sort(new ComparadorContaCorrentePorAgencia());

            foreach (var conta in contas)
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

            idades.AdicionarVarios(99,-1);


            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
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