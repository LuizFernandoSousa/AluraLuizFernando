﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    partial class Program
    {
        static void UsarStreamDeEntrada()
        {
            using (var fluxoDeEntrada = Console.OpenStandardInput())
            using (var fs = new FileStream("entradaConsole.txt",FileMode.Create))
            {
                var buffer = new byte[1024];

                while (true)
                {
                    var byteLidos = fluxoDeEntrada.Read(buffer, 0, 1024);
                    fs.Write(buffer,0,byteLidos);
                    fs.Flush();
                    Console.WriteLine($"Bytes lidos da console: {byteLidos}");
                }

            }
        }
    }
}
