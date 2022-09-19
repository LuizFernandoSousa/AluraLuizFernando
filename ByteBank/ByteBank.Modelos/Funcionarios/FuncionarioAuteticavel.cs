using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;

namespace ByteBank.Funcionarios
{
    public abstract class FuncionarioAuteticavel : Funcionario , IAutenticavel
    {
        private AuteticacaoHelper _auteticacaoHelper = new AuteticacaoHelper();
        public string Senha { get; set; }

        public FuncionarioAuteticavel (string cpf, double salario): base(cpf, salario)
        {

        }

        public bool Autenticar (string senha)
        {
            return _auteticacaoHelper.CompararSenhas(Senha,senha);
        }


    }
}
