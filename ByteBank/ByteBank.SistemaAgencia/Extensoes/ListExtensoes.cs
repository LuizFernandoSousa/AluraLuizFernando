using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public static class ListExtensoes
    {
        public static void AdicionarVarios<T>(this List<T> lista, params T[]itens) 
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }

        }



        static void Teste()
        {
            List<int> idades = new List<int>();

            idades.Add(23);
            idades.Add(2);
            idades.Add(5432);


            idades.AdicionarVarios(12,321,321,34);


            List<string> nomes = new List<string>();

            nomes.Add("Luiz");


            nomes.AdicionarVarios("dasa","qwewq","jeioqwj");









        }

    }
}
