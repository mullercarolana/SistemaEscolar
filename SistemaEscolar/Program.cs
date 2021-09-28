using System;
using System.Linq;

namespace SistemaEscolar
{
    class Program
    {
        private const int NUMERO_MAXIMO_DE_MATRICULAS = 10;
        private const int IDADE_MAIORIDADE = 18;        

        enum OpcaoUsuario
        {
            Matricular = 1,
            Imprimir = 2,
            Listar = 3,
            Sair = 4
        }

        static void Main(string[] args)
        {
            var repositorio = new AlunosRepositorio();
            MostrarMenu();
            int opcaoUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine();

            while (opcaoUsuario != 4)
            {
                switch(opcaoUsuario)
                {
                    case 1:
                        InserirAluno(repositorio);
                        break;

                    case 2:
                        ImprimirRelatorioTurma(repositorio);
                        break;
                    case 3:
                        ListarTodosAlunos(repositorio);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Opção inválida! Por favor, insira a opção correta.");
                }

                MostrarMenu();
                opcaoUsuario = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
        }

        private static void MostrarMenu() 
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("USUÁRIO, INSIRA POR GENTILEZA A OPÇÃO DESEJADA: ");
            Console.WriteLine("1 - MATRICULAR ALUNO..........................: ");
            Console.WriteLine("2 - IMPRIMIR RELATÓRIO DA TURMA...............: ");
            Console.WriteLine("3 - LISTAR TODOS ALUNOS.......................: ");
            Console.WriteLine("4 - SAIR DO SISTEMA...........................: ");
            Console.WriteLine("-----------------------------------------------");
        }

        private static void InserirAluno(AlunosRepositorio repositorio)
        {
            if (!PossoAdicionarNovoAluno(repositorio))
            {
                Console.WriteLine("Matriculas encerradas para essa turma.");
                return;
            }                

            var aluno = new Aluno();            

            Console.WriteLine();

            Console.Write("NOME COMPLETO DO ALUNO: ");
            aluno.Nome = Console.ReadLine();

            Console.Write("DATA DE NASCIMENTO DO ALUNO: ");
            aluno.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.Write("IDENTIDADE DE GÊNERO DO ALUNO (F - FEMININO / M - MASCULINO): ");
            aluno.Sexo = char.Parse(Console.ReadLine());

            Console.WriteLine();

            if (!AlunoEhMaiorDeIdade(aluno))
            {
                Console.WriteLine("Não é permitido matricular menores de 18 anos.");
                return;
            }                

            repositorio.Inserir(aluno);
        }

        private static void ImprimirRelatorioTurma(AlunosRepositorio repositorio)
        {
            var relatorio = repositorio.ListarRelatorioTurma();
            Console.WriteLine();
            Console.WriteLine("RELATÓRIO DA TURMA......................:");
            Console.WriteLine($"TOTAL DE ALUNOS: {relatorio.Count}");
            Console.WriteLine($"TOTAL DE ALUNOS ACIMA DE 30 ANOS: {relatorio.Where(rl => rl.Idade > 30).Count()}");
            Console.WriteLine($"TOTAL DE MULHERES (F): {relatorio.Where(rl => rl.Sexo == 'F').Count()}");
            Console.WriteLine($"TOTAL DE HOMENS (M): {relatorio.Where(rl => rl.Sexo == 'M').Count()}");
            Console.WriteLine();
        }

        private static void ListarTodosAlunos(AlunosRepositorio repositorio)
        {
            var listarTodosAlunos = repositorio.Listar();

            foreach (Aluno aluno in listarTodosAlunos)
            {
                Console.WriteLine("DESCRIÇÃO DOS ALUNOS(AS).........................:");
                Console.WriteLine(aluno);
            }
        }

        private static bool AlunoEhMaiorDeIdade(Aluno aluno)
        {
            return aluno.Idade >= IDADE_MAIORIDADE;
        }

        private static bool PossoAdicionarNovoAluno(AlunosRepositorio repositorio)
        {
            return repositorio.ContarAlunosMatriculados().Count() < NUMERO_MAXIMO_DE_MATRICULAS;
        }
    }
}
