using System;

namespace SistemaEscolar
{
    public class Aluno
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public int Idade => CalcularIdade();

        private int CalcularIdade()
        {
            int idade;
            var dataAtual = DateTime.Today;

            idade = dataAtual.Year - DataNascimento.Year;

            if (dataAtual.Month < DataNascimento.Month || (dataAtual.Month == DataNascimento.Month && dataAtual.Day < DataNascimento.Day))
            {
                --idade;
            }

            return idade;
        }

        public override string ToString()
        {
            return
                "NOME: " + Nome + Environment.NewLine
                + "DATA DE NASCIMENTO: " + DataNascimento + Environment.NewLine
                + "IDENTIDADE DE GÊNERO DO ALUNO: " + Sexo + Environment.NewLine;
        }
    }
}
