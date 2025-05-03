using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_gerenciamento_funcionarios
{
    /// <summary>
    /// Classe responsável por consultar e exibir a lista de funcionários cadastrados.
    /// </summary>
    internal static class ConsultaFuncionarios
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("Lista de Funcionários");
            Console.WriteLine("=====================");

            List<Funcionario> funcionarios = Funcionario.Consultar(); // Obtém os funcionários cadastrados

            if (funcionarios.Count == 0)  // Tratamento especial caso não haja funcionários cadastrados
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
                Console.ReadKey(); // Espera que o usuário pressione uma tecla para sair
                return;
            }

            foreach (var funcionario in funcionarios)
            {
                funcionario.Exibir(); // Exibe as informações de cada funcionário
                Console.WriteLine();  // Aplica uma linha em branco entre os funcionários para melhor visualização
            }

            Console.ReadKey(); // Aguarda que o usuário pressione uma tecla para voltar ao menu principal
        } 
    }
}
