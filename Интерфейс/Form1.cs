using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trees;
using Hash;

namespace Интерфейс
{
    public partial class Form1 : Form
    {
        #region Деревья
        Graphics G;
        Point S = new Point(370, 10);
        BinarySearchTree BST = DefaultTrees.BST();
        RedBlackTree RBT = DefaultTrees.RBT();
        DekT_Node DekT = DefaultTrees.DekT();
        private delegate void Draw();
        Draw DrawMethod;
        public delegate void Insert(int Value);
        Insert InsertMethod;
        public delegate void Delete(int Value);
        Delete DeleteMethod;
        public delegate BinaryTreeNode Search(int Value);
        Search SearchMethod;
        //int Dist;
        int Value, LastIndex;
        Stopwatch Timer = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            //G = PictureBox.CreateGraphics();
            ComboBox.SelectedIndex = 0;
            Refresh();
            //D.Invoke();
        }

        /// <summary>
        /// Рисует узел дерева (<see cref = "BinarySearchTree"/>)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="node"></param>
        /// <param name="S"></param>
        private void DrawBST_Node(Graphics g, BST_Node node, Point S, int Dist)
        {
            if (node != null)
            {
                //int D = (GetParent(node) == null ? 100 : 50);
                Pen P = new Pen(Color.Brown, 5);
                Pen P2 = new Pen(Color.Brown, 3);
                g.DrawEllipse(P, S.X, S.Y, 30, 30);
                P.Color = Color.Brown;
                if (node.Left != null)
                {
                    Point S2 = new Point(S.X - (Dist -= 45), S.Y + 90);
                    g.DrawLine(P2, S.X + 15, S.Y + 15, S2.X + 15, S2.Y + 15);
                    DrawBST_Node(g, node.Left, S2, Dist);
                }
                if (node.Right != null)
                {
                    Point S2 = new Point(S.X + (node.Left == null ? (Dist -= 45) : Dist), S.Y + 90);
                    g.DrawLine(P2, S.X + 15, S.Y + 15, S2.X + 15, S2.Y + 15);
                    DrawBST_Node(g, node.Right, S2, Dist);
                }
                SolidBrush B = new SolidBrush(node.Chosen ? Color.Yellow : Color.White);
                g.FillEllipse(B, S.X, S.Y, 30, 30);
                int d = 10 - (node.Value / 10 == 1 ? 3 : 0) - (node.Value < 0 ? 3 : 0);
                g.DrawString(node.Value.ToString(), Form1.DefaultFont,
                    new SolidBrush(Color.Black), S.X + d, S.Y + 10);
            }
        }

        /// <summary>
        /// Рисует узел дерева (<see cref = "RedBlackTree"/>)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="node"></param>
        /// <param name="S"></param>
        private void DrawRBT_Node(Graphics g, RBT_Node node, Point S, int Dist)
        {
            //if (node.Parent != null) Dist -= 20;
            //int D = (GetParent(node) == null ? 100 : 50);
            Pen P = new Pen(Color.Brown, 5);
            Pen P2 = new Pen(Color.Brown, 3);
            g.DrawEllipse(P, S.X, S.Y, 30, 30);
            P.Color = Color.Brown;
            if (node.Left != null)
            {
                Point S2 = new Point(S.X - (node.Parent == null ? (Dist -= 55) + 55 : (Dist -= 55)), S.Y + 90);
                g.DrawLine(P2, S.X + 15, S.Y + 15, S2.X + 15, S2.Y + 15);
                DrawRBT_Node(g, node.Left, S2, Dist);
            }
            if (node.Right != null)
            {
                Point S2 = new Point();
                if (node.Parent != null) S2 = new Point(S.X +
                    (node.Left == null ? (Dist -= 55) : Dist), S.Y + 90);
                else S2 = new Point(S.X + (node.Left == null ? (Dist -= 55) + 55 : Dist + 55), S.Y + 90);
                g.DrawLine(P2, S.X + 15, S.Y + 15, S2.X + 15, S2.Y + 15);
                DrawRBT_Node(g, node.Right, S2, Dist);
            }
            SolidBrush B = new SolidBrush(node.Color == NodeColor.Red ? Color.Red : Color.Black);
            g.FillEllipse(B, S.X, S.Y, 30, 30);
            int d = 10 - (node.Value / 10 == 1 ? 3 : 0) - (node.Value < 0 ? 3 : 0);
            g.DrawString(node.Value.ToString(), label2.Font,
                new SolidBrush(Color.FromArgb(255 - B.Color.R, 255 - B.Color.G,
                255 - B.Color.B)) /*new SolidBrush(Color.White)*/, S.X + d, S.Y + 10);
            if (node.Chosen)
            {
                Pen P3 = new Pen(Color.Yellow, 5);
                g.DrawEllipse(P3, S.X - 5, S.Y - 5, 40, 40);
            }
        }

        /// <summary>
        /// Рисует узел дерева (<see cref = "Treap"/>)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="node"></param>
        /// <param name="S"></param>
        private void DrawDekartTree_Node(Graphics g, DekT_Node node, Point S, int Dist)
        {
            if (node != null)
            {
                //int D = (GetParent(node) == null ? 100 : 50);
                Pen P = new Pen(Color.Brown, 5);
                Pen P2 = new Pen(Color.Brown, 3);
                g.DrawEllipse(P, S.X, S.Y, 50, 30);
                P.Color = Color.Brown;
                if (node.Left != null)
                {
                    Point S2 = new Point(S.X - (Dist -= 45), S.Y + 90);
                    g.DrawLine(P2, S.X + 15, S.Y + 15, S2.X + 15, S2.Y + 15);
                    DrawDekartTree_Node(g, node.Left, S2, Dist);
                }
                if (node.Right != null)
                {
                    Point S2 = new Point(S.X + (node.Left == null ? (Dist -= 45) : Dist), S.Y + 90);
                    g.DrawLine(P2, S.X + 15, S.Y + 15, S2.X + 15, S2.Y + 15);
                    DrawDekartTree_Node(g, node.Right, S2, Dist);
                }
                SolidBrush B = new SolidBrush(node.Chosen ? Color.Yellow : Color.White);
                g.FillEllipse(B, S.X, S.Y, 50, 30);
                int d = 10 - (node.Value / 10 == 1 ? 3 : 0) - (node.Value < 0 ? 3 : 0);
                g.DrawString(node.Value.ToString() + "; " + node.Key.ToString(), Form1.DefaultFont,
                    new SolidBrush(Color.Black), S.X + d, S.Y + 10);
            }
        }

        private BST_Node GetParent(BST_Node N)
        {
            List<BST_Node> listOfNodes = new List<BST_Node>();
            BinarySearchTree.FillListInOrder(BST.Root, listOfNodes);
            foreach (BST_Node A in listOfNodes)
                if (A.Left == N || A.Right == N) return A;
            return null;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Random r = new Random(DateTime.UtcNow.Millisecond);
            Random R = new Random(r.Next());
            G = e.Graphics;
            if (Text == Tag.ToString().Substring(100))
                G.Clear(Color.LightSteelBlue);
            else G.Clear(Color.FromArgb(R.Next(0, 255)));
            //DrawNode(G, Root, S);
            DrawMethod.Invoke();
        }

        public void DrawBST()
        {
            DrawBST_Node(G, BST.Root, S, 200);
        }

        public void DrawRBT()
        {
            DrawRBT_Node(G, RBT.Root, S, 200);
        }

        public void DrawDekT()
        {
            DrawDekartTree_Node(G, DekT, S, 200);
        }

        private void AddTB_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(AddTB.Text, out Value)) AddButton.Enabled = true;
            else AddButton.Enabled = false;
        }

        private void RemoveTB_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(RemoveTB.Text, out Value)) RemoveButton.Enabled = true;
            else RemoveButton.Enabled = false;
        }

        private void SearchTB_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(SearchTB.Text, out Value)) SearchButton.Enabled = true;
            else SearchButton.Enabled = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            bool W = true;
            Timer.Restart();
            try { InsertMethod.Invoke(Value); /*BST.Insert(Value);*/ }
            catch (Exception E)
            {
                Timer.Stop();
                TimeResultTB.Text = E.Message + " (прошло " + Timer.Elapsed.TotalMilliseconds + " мс)";
                W = false;
            }
            if (W)
            {
                Timer.Stop();
                TimeResultTB.Text = "Элемент добавлен за " + Timer.Elapsed.TotalMilliseconds + " мс";
                Refresh();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Boolean W = true;
            Timer.Restart();
            try
            {
                DeleteMethod.Invoke(Value);
                //BST.Delete(Value);
            }
            catch (Exception E)
            {
                Timer.Stop();
                TimeResultTB.Text = E.Message + " (прошло " + Timer.Elapsed.TotalMilliseconds + " мс)";
                W = false;
            }
            if (W)
            {
                Timer.Stop();
                TimeResultTB.Text = "Элемент удалён за " + Timer.Elapsed.TotalMilliseconds + " мс";
                Refresh();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Boolean W = true;
            BinaryTreeNode A = null;
            Timer.Restart();
            try
            {
                A = SearchMethod.Invoke(Value);
                /*BST.Search(Value).Chosen = true;*/
                A.Chosen = true;
            }
            catch
            {
                Timer.Stop();
                W = false;
                TimeResultTB.Text = "Элемент не найден (прошло " + Timer.Elapsed.TotalMilliseconds + " мс)";
            }
            Timer.Stop();
            if (W)
            {
                TimeResultTB.Text = "Элемент найден за " + Timer.Elapsed.TotalMilliseconds + " мс";
                Refresh();
                A.Chosen = false;
            }
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            if (ComboBox.SelectedIndex == -1) ComboBox.SelectedIndex = LastIndex;
            else switch (ComboBox.Text)
            {
                case "Декартово дерево":
                        DrawMethod = DrawDekT;
                        InsertMethod = DekT.Insert;
                        DeleteMethod = DekT.Delete;
                        SearchMethod = DekT.Search;
                    break;
                case "Двоичное дерево поиска":
                        DrawMethod = DrawBST;
                        InsertMethod = BST.Insert;
                        DeleteMethod = BST.Delete;
                        SearchMethod = BST.Search;
                    break;
                case "Красно-чёрное дерево":
                        DrawMethod = DrawRBT;
                        InsertMethod = RBT.Insert;
                        DeleteMethod = RBT.Delete;
                        SearchMethod = RBT.Search;
                    break;
            }
            LastIndex = ComboBox.SelectedIndex;
            Refresh();
        }
        #endregion

        #region Хэш-таблица
        String Key;
        String H_Value;
        HashTable Table = Default_HT.Table();

        private void KeyTB_Click(object sender, EventArgs e)
        {
            if (KeyTB.Text == "<Введите ключ>")
            {
                KeyTB.ResetText();
                KeyTB.ForeColor = Color.Black;
            }
        }

        private void KeyTB_Leave(object sender, EventArgs e)
        {
            if (KeyTB.Text == "")
            {
                KeyTB.Text = "<Введите ключ>";
                KeyTB.ForeColor = Color.Silver;
            }
        }

        private void KeyTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)ConsoleKey.Enter) ResultTB.Select();
        }

        private void ValueTB_TextChanged(object sender, EventArgs e)
        {
            H_Value = ValueTB.Text;
        }

        private void KeyTB_TextChanged(object sender, EventArgs e)
        {
            Key = KeyTB.Text;
        }

        private void ShowHT(HashTable Table)
        {
            ResultTB.ResetText();
            foreach (KeyValuePair<int, List<Item>> item in Table.Items)
            {
                ResultTB.Text += (ResultTB.Text != "" ? "\r\n" : "") + "Хэш = " + item.Key.ToString() + "\r\n";
                foreach (var value in item.Value)
                    ResultTB.Text += value.Key + " - " + value.Value + "\r\n";
            }
        }

        private void Hash_AddButton_Click(object sender, EventArgs e)
        {
            if (KeyTB.Text != "<Введите ключ>" && ValueTB.Text != "<Введите значение>")
            {
                Boolean W = true;
                try
                {
                    Timer.Restart();
                    Table.Insert(Key, H_Value);
                    Timer.Stop();
                }
                catch (Exception E)
                {
                    W = false;
                    Timer.Stop();
                    TimeResultLabel.Text = E.Message + " (прошло " +
                        Timer.Elapsed.TotalMilliseconds + " мс)";
                }
                if (W)
                {
                    TimeResultLabel.Text = "Элемент добавлен за " + Timer.Elapsed.TotalMilliseconds + " мс";
                    ShowHT(Table);
                }
            }
        }

        private void Hash_DeleteButton_Click(object sender, EventArgs e)
        {
            if (KeyTB.Text != "<Введите ключ>")
            {
                Boolean W = true;
                try
                {
                    Timer.Restart();
                    Table.Delete(Key);
                    Timer.Stop();
                }
                catch (Exception E)
                {
                    W = false;
                    Timer.Stop();
                    TimeResultLabel.Text = E.Message + " (прошло " +
                        Timer.Elapsed.TotalMilliseconds + " мс)";
                }
                if (W)
                {
                    TimeResultLabel.Text = "Элемент удалён за " + Timer.Elapsed.TotalMilliseconds + " мс";
                    ShowHT(Table);
                }
            }
        }

        private void Hash_SearchButton_Click(object sender, EventArgs e)
        {
            if (KeyTB.Text != "<Введите ключ>")
            {
                Boolean W = true;
                try
                {
                    Timer.Restart();
                    ResultTB.Text = Table.Search(Key);
                    Timer.Stop();
                }
                catch (Exception E)
                {
                    W = false;
                    Timer.Stop();
                    TimeResultLabel.Text = E.Message + " (прошло " +
                        Timer.Elapsed.TotalMilliseconds + " мс)";
                }
                if (W) TimeResultLabel.Text = "Элемент найден за " + 
                        Timer.Elapsed.TotalMilliseconds + " мс";
            }
        }

        private void ValueTB_Click(object sender, EventArgs e)
        {
            if (ValueTB.Text == "<Введите значение>")
            {
                ValueTB.ResetText();
                ValueTB.ForeColor = Color.Black;
            }
        }

        private void ValueTB_Leave(object sender, EventArgs e)
        {
            if (ValueTB.Text == "")
            {
                ValueTB.Text = "<Введите значение>";
                ValueTB.ForeColor = Color.Silver;
            }
        }

        private void ValueTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)ConsoleKey.Enter) ResultTB.Select();
        }
        #endregion

        private void ClearButton_Click(object sender, EventArgs e)
        {
            switch (TabControl.SelectedIndex)
            {
                case 0:
                    BST_Reset(BST.Root);
                    BST = DefaultTrees.BST();
                    RBT_Reset(RBT.Root);
                    RBT = DefaultTrees.RBT();
                    DekT = DefaultTrees.DekT();
                    ComboBox_TextChanged(sender, e);
                    TimeResultTB.ResetText();
                    AddTB.Text = RemoveTB.Text = SearchTB.Text = TimeResultTB.Text;
                    Refresh();
                    break;
                case 1:
                    ResultTB.ResetText();
                    TimeResultLabel.Text = ResultTB.Text;
                    ValueTB.Text = "<Введите значение>";
                    ValueTB.ForeColor = Color.Silver;
                    KeyTB.Text = "<Введите ключ>";
                    KeyTB.ForeColor = Color.Silver;
                    Table = Default_HT.Table();
                    ShowHT(Table);
                    break;
            }
        }

        private void BST_Reset(BST_Node N)
        {
            N.Left = null;
            N.Right = null;
            N = null;
        }

        private void RBT_Reset(RBT_Node N)
        {
            N.Left = null;
            N.Right = null;
            N = null;
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 1)
            {
                Size = new Size(700, 700);
                TabControl.Size = new Size(Width - 34, Height - 56);
                ClearButton.Location = new Point(557, 3);
                ShowHT(Table);
            }
            else
            {
                Size = MaximumSize;
                ClearButton.Location = new Point(1037, 3);
                TabControl.Size = TabControl.MaximumSize;
            }
        }
    }
}
