using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
  public partial class Form1 : Form
  {
    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams cp = base.CreateParams;
        cp.ExStyle |= 0x02000000;
        return cp;
      }
    }

    public Form1()
    {
      InitializeComponent();
      EscolaEntity escolaEntity = CarregarMoqEscola();
      CarregarTreeView(escolaEntity);
    }

    private void CarregarTreeView(EscolaEntity escolaEntity)
    {
      foreach (EscolaEntity.Professor prof in escolaEntity.professores)
      {
        TreeNode ProfessorNode = new TreeNode(prof.codProf + " - " + prof.nomeProfessor);
        ProfessorNode.ToolTipText = ProfessorNode.Text;

        foreach (EscolaEntity.Alunos aluno in prof.alunos)
        {
          TreeNode AlunoNode = new TreeNode(aluno.codAluno + " - " + aluno.nomeAluno);
          AlunoNode.ToolTipText = AlunoNode.Text;

          _ = ProfessorNode.Nodes.Add(AlunoNode);
        }

        this.customTreeView1.Nodes.Add(ProfessorNode);
      }
    }

    private EscolaEntity CarregarMoqEscola()
    {
      //Metodo Apenas para simular o retorno do banco.

      EscolaEntity.Professor professorLucio = new EscolaEntity.Professor() { codProf = 1, nomeProfessor = "Lucio" };
      EscolaEntity.Professor professorNeimar = new EscolaEntity.Professor() { codProf = 1, nomeProfessor = "Neimar" };

      EscolaEntity.Alunos alunoRaquel = new EscolaEntity.Alunos() { codAluno = 1, nomeAluno = "Raquel" };


      professorLucio.alunos.Add(alunoRaquel);
      professorNeimar.alunos.Add(alunoRaquel);

      EscolaEntity escolaEntity = new EscolaEntity()
      {
        codEscola = 1,
      };

      escolaEntity.professores.Add(professorLucio);
      escolaEntity.professores.Add(professorNeimar);

      return escolaEntity;
    }

  }
}
