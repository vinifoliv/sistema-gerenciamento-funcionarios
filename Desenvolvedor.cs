using System.Globalization;

namespace sistema_gerenciamento_funcionarios
{
    internal class Desenvolvedor : Funcionario
    {
        public int HorasExtras { get; private set; }
        public decimal ValorHoraExtra { get; private set; }

        public Desenvolvedor(string nome, int idade, string cargo, decimal salario, string formaPagamento, string metodoEntregaPagamento, int horasExtras, decimal valorHoraExtra)
            : base(nome, idade, cargo, salario, formaPagamento, metodoEntregaPagamento)
        {
            HorasExtras = horasExtras;
            ValorHoraExtra = valorHoraExtra;
        }

        public override decimal CalcularSalario() => Salario + HorasExtras * ValorHoraExtra - CalcularImpostos();

        public override void Exibir()
        {
            base.Exibir();
            Console.WriteLine($"Valor da hora extra: {ValorHoraExtra.ToString("C2", new CultureInfo("pt-BR"))}");
            Console.WriteLine($"Horas extras realizadas: {HorasExtras}");
        }

        public override decimal CalcularImpostos() => Salario * 0.1m;
    }
}
