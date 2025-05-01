namespace sistema_gerenciamento_funcionarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Menu();
                Console.Write("O que deseja fazer? [1-4] ");
                string? opcaoUsuario = Console.ReadLine();

                try
                {
                    if (opcaoUsuario == null) throw new Exception("Escolha uma opção!");
                    switch (opcaoUsuario)
                    {
                        case "1":
                            CadastroFuncionario.Executar();
                            break;
                        case "2":
                            ConsultaFuncionarios.Executar();
                            break;
                        case "3":
                            EntregaPagamento.Executar();
                            break;
                        case "4":
                            return;
                        default:
                            throw new Exception("Opção inválida!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void Menu()
        {
            Console.WriteLine("Bem-vindo ao Sistema de Gerenciamento de Funcionários");
            Console.WriteLine("=====================================================");
            Console.WriteLine("1. Cadastrar funcionário");
            Console.WriteLine("2. Consultar funcionário");
            Console.WriteLine("3. Entregar pagamento do funcionário");
            Console.WriteLine("4. Sair");
        }
    }
}
