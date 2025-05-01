namespace sistema_gerenciamento_funcionarios
{
    internal static class EntregaPagamento
    {
        public static void Executar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Entrega de Pagamento");
                Console.WriteLine("====================");

                List<Funcionario> funcionarios = Funcionario.Consultar();
                if (funcionarios.Count == 0)
                {
                    Console.WriteLine("Nenhum funcionário cadastrado.");
                    Console.ReadKey();
                    return;
                }

                ListarFuncionarios(funcionarios);

                int id = ObterID();
                Funcionario funcionario = funcionarios.Find(f => f.FuncionarioId == id) ?? throw new Exception("Funcionário inválido!");
                Console.WriteLine();
                funcionario.EntregarPagamento();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.WriteLine();
            }
        }

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

        private static void ListarFuncionarios(List<Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios)
            {
                funcionario.Exibir();
                Console.WriteLine();
            }
        }
    }
}
