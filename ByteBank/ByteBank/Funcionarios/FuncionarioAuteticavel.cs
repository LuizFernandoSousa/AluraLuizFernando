using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public abstract class FuncionarioAuteticavel : Funcionario , IAutenticavel
    {
        public string Senha { get; set; }

        public FuncionarioAuteticavel (string cpf, double salario): base(cpf, salario)
        {

        }

        public bool Autenticar (string senha)
        {
            return Senha == senha;
        }


    }
}
