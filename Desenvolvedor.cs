using System.Globalization;

namespace sistema_gerenciamento_funcionarios
{
    /// <summary>
    /// Classe que representa um desenvolvedor e que herda da classe Funcionario.
    /// </summary>
    internal class Desenvolvedor : Funcionario
    {
        public int HorasExtras { get; private set; } // Quantidade de horas extras realizada pelo desenvolvedor (muitas)
        public decimal ValorHoraExtra { get; private set; } // Valor ganho por cada hora extra realizada

        public Desenvolvedor(string nome, int idade, string cargo, decimal salario, string formaPagamento, string metodoEntregaPagamento, int horasExtras, decimal valorHoraExtra)
            : base(nome, idade, cargo, salario, formaPagamento, metodoEntregaPagamento)
        {
            HorasExtras = horasExtras;
            ValorHoraExtra = valorHoraExtra;
        }

        /// <summary>
        /// Implementa o método CalcularSalario da classe Funcionario, aplicando o cálculo específico de desenvolvedores.
        /// </summary>
        public override decimal CalcularSalario() => Salario + HorasExtras * ValorHoraExtra - CalcularImpostos();

        /// <summary>
        /// Exibe as informações do desenvolvedor (utilizando o método da classe base), 
        /// acrescentando o valor da hora extra e a quantidade de horas extras realizadas.
        /// </summary>
        public override void Exibir()
        {
            base.Exibir();
            Console.WriteLine($"Valor da hora extra: {ValorHoraExtra.ToString("C2", new CultureInfo("pt-BR"))}");
            Console.WriteLine($"Horas extras realizadas: {HorasExtras}");
        }

        /// <summary>
        /// Sobrescreve o método CalcularImpostos da classe Funcionario para o valor específico de desenvolvedores.
        /// </summary>
        public override decimal CalcularImpostos() => (Salario + HorasExtras * ValorHoraExtra) * 0.1m;
    }
}
