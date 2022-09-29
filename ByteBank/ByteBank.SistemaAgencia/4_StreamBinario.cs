using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    partial class Program
    {
        static void EscritaBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt",FileMode.Create))
            using (var sr = new BinaryWriter(fs))
            {
                sr.Write(432);
                sr.Write(423423);
                sr.Write(53254.53);
                sr.Write("Carlos Fera");
            }
        }

        static void LeituraBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
            using (var lt = new BinaryReader(fs))
            {
                var agencia = lt.ReadInt32();
                var numeroConta = lt.ReadInt32();
                var saldo = lt.ReadDouble();
                var titular = lt.ReadString();

                Console.WriteLine($"{agencia}/{numeroConta} {titular} {saldo}");

            }
        }



    }
}
