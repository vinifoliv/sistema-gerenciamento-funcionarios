namespace sistema_gerenciamento_funcionarios
{
    internal class Estagiario : Funcionario
    {
        public Estagiario(string nome, int idade, string cargo, decimal salario, string formaPagamento, string metodoEntregaPagamento)
            : base(nome, idade, cargo, salario, formaPagamento, metodoEntregaPagamento) { }

        public override decimal CalcularSalario() => Salario - CalcularImpostos();
    }
}