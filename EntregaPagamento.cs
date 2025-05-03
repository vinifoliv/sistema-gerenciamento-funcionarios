namespace sistema_gerenciamento_funcionarios
{
    /// <summary>
    /// Classe responsável pela interface de entrega de pagamento.
    /// Exibe os funcionários cadastrados, solicita o ID do funcionário 
    /// escolhido e entrega o pagamento.
    /// </summary>
    internal static class EntregaPagamento
    {
        public static void Executar()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Entrega de Pagamento");
                    Console.WriteLine("====================");

                    List<Funcionario> funcionarios = Funcionario.Consultar(); // Obtém os funcionários cadastrados
                    if (funcionarios.Count == 0) // Tratamento especial caso não haja funcionários cadastrados
                    {
                        Console.WriteLine("Nenhum funcionário cadastrado.");
                        Console.ReadKey();
                        continue;
                    }

                    ListarFuncionarios(funcionarios); // Exibe os funcionários cadastrados

                    int id = ObterID();
                    // Verifica se o funcionário existe
                    Funcionario funcionario = funcionarios.Find(f => f.FuncionarioId == id) ?? throw new Exception("Funcionário inválido!");
                    Console.WriteLine(); // Linha em branco para melhor visualização
                    funcionario.EntregarPagamento(); //  Entrega o pagamento do funcionário escolhido
                    Console.ReadKey(); // Aguarda que o usuário pressione uma tecla para voltar ao menu principal
                    return; // Retorna ao menu principal
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Método responsável por obter o ID do funcionário por input do usuário.
        /// </summary>
        private static int ObterID()
        {
            while (true)
            {
                try
                {
                    Console.Write("ID do funcionário: ");
                    string? input = Console.ReadLine();
                    if (input == null || input == "") throw new Exception("Nenhum ID fornecido.");
                    bool ehNumerico = int.TryParse(input, out int id);
                    if (!ehNumerico) throw new Exception("O ID deve ser numérico!");
                    if (id <= 0) throw new Exception("ID inválido!");
                    return id;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Exibe a lista de funcionários cadastrados.
        /// </summary>
        /// <param name="funcionarios"></param>
        private static void ListarFuncionarios(List<Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine($"{funcionario.FuncionarioId}. {funcionario.Nome} ({funcionario.Cargo})");
                Console.WriteLine();
            }
        }
    }
}
