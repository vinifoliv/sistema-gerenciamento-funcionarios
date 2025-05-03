namespace sistema_gerenciamento_funcionarios
{
    /// <summary>
    /// Classe que representa um estagiário e que herda da classe Funcionario.
    /// Honestamente, não sei o que mais colocar aqui.
    /// </summary>
    internal class Estagiario : Funcionario
    {
        public Estagiario(string nome, int idade, string cargo, decimal salario, string formaPagamento, string metodoEntregaPagamento)
            : base(nome, idade, cargo, salario, formaPagamento, metodoEntregaPagamento) { }

        /// <summary>
        /// Implementa o método CalcularSalario da classe Funcionario, aplicando o cálculo específico para estagiários.
        /// </summary>
        public override decimal CalcularSalario() => Salario - CalcularImpostos();
    }
}