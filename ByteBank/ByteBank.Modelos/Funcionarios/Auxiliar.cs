using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    internal class Auxiliar : Funcionario
    {
        public Auxiliar(string cpf, double salario) : base(cpf, salario)
        {
        }

        public override void AumentarSalario()
        {
            Salario *= 1.10;
        }

        internal override double GetBonificacao()
        {
            return Salario * 0.20;
        }
    }
}
