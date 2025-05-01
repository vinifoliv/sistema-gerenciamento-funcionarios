using System.Drawing;

namespace sistema_gerenciamento_funcionarios
{
    internal static class CadastroFuncionario
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Funcionário");
            Console.WriteLine("=======================");

            string nome = ObterNome();
            int idade = ObterIdade();
            Console.WriteLine();

            string cargo = ObterCargo();
            Console.WriteLine();

            decimal salario = ObterSalario();
            Console.WriteLine();

            string formaPagamento = ObterFormaPagamento();
            Console.WriteLine();

            string metodoEntregaPagamento = ObterMetodoEntregaPagamento();
            Console.WriteLine();

            switch (cargo)
            {
                case "Gerente":
                    decimal bonus = ObterBonus();
                    Funcionario.Adicionar(new Gerente(nome, idade, cargo, salario, formaPagamento, metodoEntregaPagamento, bonus));
                    break;
                case "Desenvolvedor":
                    decimal valorHoraExtra = ObterValorHoraExtra();
                    int horasExtras = ObterHorasExtras();
                    Funcionario.Adicionar(new Desenvolvedor(nome, idade, cargo, salario, formaPagamento, metodoEntregaPagamento, horasExtras, valorHoraExtra));
                    break;
                case "Estagiário":
                    Funcionario.Adicionar(new Estagiario(nome, idade, cargo, salario, formaPagamento, metodoEntregaPagamento));
                    break;
                default:
                    throw new Exception("Cargo inválido!");
            }
        }

        private static string ObterNome()
        {
            while (true)
            {
                Console.Write("Nome: ");
                string? nome = Console.ReadLine();
                try
                {
                    if (nome == null || nome == "") throw new Exception("Nenhum nome fornecido");
                    if (nome.Any(char.IsDigit)) throw new Exception("Nome inválido!");
                    return nome;
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }

        private static int ObterIdade()
        {
            while (true)
            {
                try
                {
                    Console.Write("Idade: ");
                    string? input = Console.ReadLine();
                    if (input == null) throw new Exception("Idade não fornecida!");
                    bool ehNumerico = int.TryParse(input, out int idade);
                    if (!ehNumerico) throw new Exception("A idade deve ser um valor numérico!");
                    if (idade < 0) throw new Exception("A idade não pode ser negativa!");
                    if (idade > 130) throw new Exception($"Um sujeito de {idade} anos. Sério?");
                    return idade;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }

        private static string ObterCargo()
        {
            while (true)
            {
                Console.WriteLine("Cargos");
                Console.WriteLine("------");
                Console.WriteLine("1. Gerente");
                Console.WriteLine("2. Desenvolvedor");
                Console.WriteLine("3. Estagiário");
                Console.Write("Selecione uma opção [1-3] ");

                string? cargo = Console.ReadLine();
                switch (cargo)
                {
                    case "1":
                        return "Gerente";
                    case "2":
                        return "Desenvolvedor";
                    case "3":
                        return "Estagiário";
                    default:
                        Console.WriteLine("Cargo inválido");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
        }

        private static decimal ObterSalario()
        {
            while (true)
            {
                Console.Write("Salário: R$ ");
                string? input = Console.ReadLine();
                try
                {
                    if (input == null) throw new Exception("Salário não fornecido!");
                    bool ehNumerico = Decimal.TryParse(input, out decimal salario);
                    if (!ehNumerico) throw new Exception("Salário inválido!");
                    if (salario < 0) throw new Exception("O salário não pode ser negativo!");
                    return salario;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }

        private static string ObterFormaPagamento()
        {
            while (true)
            {
                Console.WriteLine("Formas de Pagamento");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. PIX");
                Console.WriteLine("2. Débito em conta");
                Console.WriteLine("3. Dinheiro");
                Console.Write("Selecione uma opção [1-3]: ");

                string? formaPagamento = Console.ReadLine();
                switch (formaPagamento)
                {
                    case "1":
                        return "PIX";
                    case "2":
                        return "Débito em conta";
                    case "3":
                        return "Dinheiro";
                    default:
                        Console.WriteLine("Forma de pagamento inválida!");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
        }

        private static string ObterMetodoEntregaPagamento()
        {
            while (true)
            {
                Console.WriteLine("Métodos de Entrega de Pagamento");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Automático");
                Console.WriteLine("2. Manual");
                Console.Write("Selecione uma opção [1-2]: ");

                string? metodoEntregaPagamento = Console.ReadLine();
                switch (metodoEntregaPagamento)
                {
                    case "1":
                        return "Automático";
                    case "2":
                        return "Manual";
                    default:
                        Console.WriteLine("Método de entrega de pagamento inválida!");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
        }

        private static decimal ObterBonus()
        {
            while (true)
            {
                Console.Write("Bônus: R$ ");
                string? input = Console.ReadLine();
                try
                {
                    if (input == null) throw new Exception("Bônus não fornecido!");
                    bool ehNumerico = Decimal.TryParse(input, out decimal bonus);
                    if (!ehNumerico) throw new Exception("Bônus inválido!");
                    if (bonus < 0) throw new Exception("O bônus não pode ser negativo!");
                    return bonus;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }

        private static decimal ObterValorHoraExtra()
        {
            while (true)
            {
                Console.Write("Valor da hora extra: R$ ");
                string? input = Console.ReadLine();
                try
                {
                    if (input == null) throw new Exception("Valor da hora extra não fornecido!");
                    bool ehNumerico = Decimal.TryParse(input, out decimal valorHoraExtra);
                    if (!ehNumerico) throw new Exception("Valor da hora extra inválido!");
                    if (valorHoraExtra < 0) throw new Exception("O valor da hora extra não pode ser negativo!");
                    return valorHoraExtra;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }

        private static int ObterHorasExtras()
        {
            while (true)
            {
                Console.Write("Horas extras: ");
                string? input = Console.ReadLine();
                try
                {
                    if (input == null) throw new Exception("Horas extras não fornecidas!");
                    bool ehNumerico = int.TryParse(input, out int horasExtras);
                    if (!ehNumerico) throw new Exception("Horas extras inválidas!");
                    if (horasExtras < 0) throw new Exception("As horas extras não podem ser negativas!");
                    return horasExtras;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
