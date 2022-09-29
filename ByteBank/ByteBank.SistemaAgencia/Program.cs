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
        static void Main(string[] args)
        {
            UsarStreamDeEntrada();
            Console.WriteLine("Aplicação foi!!");
            Console.ReadLine();
        }
        

    } 
}

