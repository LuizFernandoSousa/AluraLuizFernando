using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeObjetct
    {
        private object[] _itens;
        private int _proximaPosicao;

        public int tamanho { 
            get
            {
                return _proximaPosicao;
            }
        }

        public ListaDeObjetct(int capacidadeinicial = 5)
        {            
            _itens = new object[capacidadeinicial];
            _proximaPosicao = 0;    
        }

        public void Adicionar(object item) 
        {
            VerificarCapacidade(_proximaPosicao + 1);
            //Console.WriteLine($"Adicionado item na posição: {_proximaPosicao}");
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        public void Remover(object item)
        {
            int indiceItem = -1;

            for (int i=0; i < _proximaPosicao; i++)
            {
                object itemAtual = _itens[i];
                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }
            for (int i = indiceItem; i < _proximaPosicao; i++)
            {
                _itens[i] = _itens[i + 1]; 
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;

        }

        public object GetItemNoIndice(int indice)
        {
            if(indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _itens[indice];
        }



        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }


            // Console.WriteLine("Aumento capacidade da lista! ");

            object[] novoArray = new object[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
            }

            _itens = novoArray;
        }


        public object this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }


        public void AdicionarVarios(params object[] itens)
        {
            foreach (object item in itens)
            {
                Adicionar(item);
            }
        }
    }
}
