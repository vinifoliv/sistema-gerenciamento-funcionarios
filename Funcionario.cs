using System.Globalization;

namespace sistema_gerenciamento_funcionarios
{
    /// <summary>
    /// Classe abstrata que representa um funcionário genérico.
    /// </summary>
    internal abstract class Funcionario
    {
        public int FuncionarioId { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public int Idade { get; private set; }
        public string Cargo { get; private set; } = string.Empty;
        public decimal Salario { get; private set; }
        public string FormaPagamento { get; private set; } = string.Empty;
        public string MetodoEntregaPagamento { get; private set; } = string.Empty;

        private static List<Funcionario> funcionarios = []; // Lista estática para armazenar os funcionários cadastrados

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

        /// <summary>
        /// Retorna o total de impostos a serem pagos pelo funcionário.
        /// Define como padrão o valor 0, pois não é necessário calcular impostos para todos os funcionários
        /// </summary>
        public virtual decimal CalcularImpostos() => 0;

        /// <summary>
        /// Exibe as informações do funcionário.
        /// </summary>
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

        /// <summary>
        /// Entrega o pagamento do funcionário exibindo o seu salário líquido, forma de pagamento e método de entrega.
        /// </summary>
        public virtual void EntregarPagamento()
        {
            Console.WriteLine($"Entregue pagamento {MetodoEntregaPagamento.ToString().ToLower()} " + 
                $"para {Nome} no valor de {CalcularSalario().ToString("C2", new CultureInfo("pt-BR"))} " + 
                $"via {FormaPagamento}.");
        }

        /// <summary>
        /// Método estático para adicionar um funcionário à lista de funcionários.
        /// </summary>
        /// <param name="funcionario"></param>
        public static void Adicionar(Funcionario funcionario) => funcionarios.Add(funcionario);

        /// <summary>
        /// Método estático para consultar todos os funcionários cadastrados.
        /// </summary>
        public static List<Funcionario> Consultar() => funcionarios;

        /// <summary>
        /// Método privado para gerar um ID único para cada funcionário.
        /// </summary>
        private static int GerarId() => funcionarios.Count == 0 ? 1 : funcionarios.Max(p => p.FuncionarioId) + 1;
    }
}
