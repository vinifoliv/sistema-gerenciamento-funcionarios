using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_gerenciamento_funcionarios
{
    internal static class ConsultaFuncionarios
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("Lista de Funcionários");
            Console.WriteLine("=====================");

            List<Funcionario> funcionarios = Funcionario.Consultar();

            if (funcionarios.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
                return;
            }

            foreach (var funcionario in funcionarios)
            {
                funcionario.Exibir();
                Console.WriteLine();
            }

            Console.ReadKey();
        } 
    }
}
