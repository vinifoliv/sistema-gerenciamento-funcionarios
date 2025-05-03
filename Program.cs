namespace sistema_gerenciamento_funcionarios
{
    internal class Program
    {
        /// <summary>
        /// O método Main exibe o menu principal e redireciona o usuário para a opção escolhida.
        /// Se uma opção inválida for escolhida, uma mensagem de erro é exibida e usuário deve tentar novamente.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Menu();
                    string? opcaoUsuario = Console.ReadLine();
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

        /// <summary>
        /// Método responsável por exibir o menu principal do sistema.
        /// </summary>
        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo ao Sistema de Gerenciamento de Funcionários");
            Console.WriteLine("=====================================================");
            Console.WriteLine("1. Cadastrar funcionário");
            Console.WriteLine("2. Consultar funcionário");
            Console.WriteLine("3. Entregar pagamento do funcionário");
            Console.WriteLine("4. Sair");
            Console.Write("O que deseja fazer? [1-4] ");
        }
    }
}
