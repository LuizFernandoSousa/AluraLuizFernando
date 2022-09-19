using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Sistemas
{
    internal class SistemaInterno
    {
        public  bool Logar(IAutenticavel funcionario, string senha)
        {
            bool usuarioAutenticado = funcionario.Autenticar(senha);

            if (usuarioAutenticado)
            {
                Console.WriteLine("Entrou!");
                return true;
            }
            else
            {
                Console.WriteLine("Senha ou usuário incorreto!");
                return false;
            }
        }
        
    }
}
