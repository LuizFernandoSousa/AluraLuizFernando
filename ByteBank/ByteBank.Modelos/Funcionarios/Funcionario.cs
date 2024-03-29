﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public abstract class Funcionario
    {
        public static int TotalDeFuncionarios { get; private set; }
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }
        

        public Funcionario(string cpf, double salario)
        {
            CPF = cpf;
            Salario = salario;
            Console.WriteLine("Funcionario criado!");
            TotalDeFuncionarios++;
        }

        public double Bonificacao
        {
            get
            {
                return Salario * 0.10;
            }
        }

        
        public abstract void AumentarSalario();

        internal abstract double GetBonificacao();
        
    }
}
