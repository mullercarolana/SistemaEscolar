using System.Collections.Generic;
using System.Linq;

namespace SistemaEscolar
{
    public class AlunosRepositorio : IAlunosRepositorio
    {
        private readonly List<Aluno> listaAlunos = new List<Aluno>();

        public void Inserir(Aluno aluno)
        {
            listaAlunos.Add(aluno);
        }

        public List<Aluno> ListarRelatorioTurma()
        {
            return listaAlunos;
        }

        public List<Aluno> Listar()
        {
            return listaAlunos;
        }

        public List<Aluno> ContarAlunosMatriculados()
        {
            return listaAlunos;
        }
    }
}
