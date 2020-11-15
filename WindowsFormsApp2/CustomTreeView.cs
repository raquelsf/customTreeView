using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;

namespace WindowsFormsApp2
{
  public partial class CustomTreeView : TreeView
  {
    public CustomTreeView()
    {
      InitializeComponent();
      this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
      this.DrawNode += new DrawTreeNodeEventHandler(OnDrawNode);
      this.ItemHeight = 35;
      this.HideSelection = true;
    }

    protected void OnDrawNode(object sender, DrawTreeNodeEventArgs e)
    {
      Rectangle nodeRect = e.Node.Bounds;

      e.Node.BackColor = Color.White;
      e.Node.ForeColor = Color.Black;

      Font nodeFont = new Font(new FontFamily("Arial"), 16,  FontStyle.Regular, GraphicsUnit.Pixel);

      StringFormat stringFormat = new StringFormat();
      stringFormat.LineAlignment = StringAlignment.Center;

      if (e.Node.Nodes.Count != 0)
      {
        Point ptExpand = new Point(nodeRect.Location.X - 20, nodeRect.Location.Y + 10);
        Image expandImg = null;
        if (e.Node.IsExpanded || e.Node.Nodes.Count < 1)
          expandImg = new Bitmap(Resources.TreeViewSetaBaixo1);
        else
          expandImg = new Bitmap(Resources.TreeViewSetaDireita);
        e.Graphics.DrawImage(expandImg, ptExpand);
      }

      Color foreColor = e.Node.ForeColor;
      Color backColor = e.Node.BackColor;

      nodeRect.Width = +200;

      TreeNodeStates state = e.State;

      if ((state & TreeNodeStates.Selected) == TreeNodeStates.Selected)
      {
        backColor = Color.FromArgb(232, 247, 255);
      }

      using (Brush background = new SolidBrush(backColor))
      {
        int tamanhoImagemNode = 12;
        e.Graphics.FillRectangle(background, nodeRect);
        using (Brush textBrush = new SolidBrush(foreColor))
        {
          e.Graphics.DrawString(e.Node.Text, nodeFont, textBrush,
            Rectangle.Inflate(nodeRect, -tamanhoImagemNode, 0), stringFormat);
        }
      }


    }
  }
}
