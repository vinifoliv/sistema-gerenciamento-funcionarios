using System.Globalization;

namespace sistema_gerenciamento_funcionarios
{
    internal abstract class Funcionario
    {
        public int FuncionarioId { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public int Idade { get; private set; }
        public string Cargo { get; private set; } = string.Empty;
        public decimal Salario { get; private set; }
        public string FormaPagamento { get; private set; } = string.Empty;
        public string MetodoEntregaPagamento { get; private set; } = string.Empty;

        private static List<Funcionario> funcionarios = [];

        public Funcionario(string nome, int idade, string cargo, decimal salario, string formaPagamento, string metodoEntregaPagamento)
        {
            FuncionarioId = GerarId();
            Nome = nome;
            Idade = idade;
            Cargo = cargo;
            Salario = salario;
            FormaPagamento = formaPagamento;
            MetodoEntregaPagamento = metodoEntregaPagamento;
        }

        public abstract decimal CalcularSalario();

        public virtual decimal CalcularImpostos() => 0;

        public virtual void Exibir()
        {
            Console.WriteLine($"ID: {FuncionarioId}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Idade: {Idade} anos");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Salário: {Salario.ToString("C2", new CultureInfo("pt-BR"))}");
            Console.WriteLine($"Forma de pagamento: {FormaPagamento}");
            Console.WriteLine($"Método de entrega de pagamento: {MetodoEntregaPagamento}");
        }

        public virtual void EntregarPagamento()
        {
            Console.WriteLine(Nome);
            Console.WriteLine($"Salário: R$ {CalcularSalario().ToString("C2", new CultureInfo("pt-BR"))}");
            Console.WriteLine($"Forma de pagamento: {FormaPagamento}");
            Console.WriteLine($"Método de entrega do pagamento: {MetodoEntregaPagamento}");
        }

        public static void Adicionar(Funcionario funcionario) => funcionarios.Add(funcionario);

        public static List<Funcionario> Consultar() => funcionarios;

        private static int GerarId() => funcionarios.Count == 0 ? 1 : funcionarios.Max(p => p.FuncionarioId) + 1;
    }
}
