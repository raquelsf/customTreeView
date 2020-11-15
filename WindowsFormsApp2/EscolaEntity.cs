using System.Collections.Generic;

namespace WindowsFormsApp2
{
  public class EscolaEntity
  {
    public int codEscola { get; set; }
    public List<Professor> professores { get; set; }

    public EscolaEntity()
    {
      professores = new List<Professor>();
    }

    public class Professor
    {
      public int codProf { get; set; }
      public string nomeProfessor { get; set; }
      public List<Alunos> alunos { get; set; }

      public Professor()
      {
        alunos = new List<Alunos>();
      }
    }

    public class Alunos
    {
      public int codAluno { get; set; }
      public string nomeAluno { get; set; }

    }
  }

}
