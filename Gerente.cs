using System.Globalization;

namespace sistema_gerenciamento_funcionarios
{
    /// <summary>
    /// Classe que representa um gerente e que herda da classe Funcionario.
    /// </summary>
    internal class Gerente : Funcionario
    {
        public decimal Bonus { get; private set; } // Bônus do gerente

        public Gerente(string nome, int idade, string cargo, decimal salario, string formaPagamento, string metodoEntregaPagamento, decimal bonus)
            : base(nome, idade, cargo, salario, formaPagamento, metodoEntregaPagamento) => Bonus = bonus;

        /// <summary>
        /// Implementa o método CalcularSalario da classe Funcionario.
        /// Para o gerente, implica o cálculo do salário líquido com o bônus e a dedução dos impostos.
        /// </summary>
        public override decimal CalcularSalario() => Salario + Bonus - CalcularImpostos();

        /// <summary>
        /// Exibe as informações do gerente (utilizando o método da classe base), acrescentando o bônus do gerente.
        /// </summary>
        public override void Exibir()
        {
            base.Exibir();
            Console.WriteLine($"Bônus: {Bonus.ToString("C2", new CultureInfo("pt-BR"))}");
        }

        /// <summary>
        /// Sobrescreve o método CalcularImpostos da classe Funcionario para o valor específico de gerentes.
        /// </summary>
        /// <returns></returns>
        public override decimal CalcularImpostos() => (Salario + Bonus) * 0.275m;
    }
}
