using System.Collections.Generic;

namespace SistemaEscolar
{
    public interface IAlunosRepositorio
    {
        void Inserir(Aluno aluno);
        List<Aluno> ListarRelatorioTurma();
        List<Aluno> Listar();
        List<Aluno> ContarAlunosMatriculados();
    }
}
