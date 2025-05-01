using System.Globalization;

namespace sistema_gerenciamento_funcionarios
{
    internal class Gerente : Funcionario
    {
        public decimal Bonus { get; private set; }

        public Gerente(string nome, int idade, string cargo, decimal salario, string formaPagamento, string metodoEntregaPagamento, decimal bonus)
            : base(nome, idade, cargo, salario, formaPagamento, metodoEntregaPagamento) => Bonus = bonus;

        public override decimal CalcularSalario() => Salario + Bonus - CalcularImpostos();

        public override void Exibir()
        {
            base.Exibir();
            Console.WriteLine($"Bônus: {Bonus.ToString("C2", new CultureInfo("pt-BR"))}");
        }

        public override decimal CalcularImpostos() => (Salario + Bonus) * 0.275m;
    }
}
