using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    internal class GerenteDeConta : FuncionarioAuteticavel
    {
        public GerenteDeConta(string cpf, double salario) : base(cpf,salario)
        {
        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }

        internal override double GetBonificacao()
        {
            return Salario * 0.5;
        }
    }
}
