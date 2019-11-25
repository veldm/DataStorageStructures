using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    /// <summary>
    /// "Цвет" вершины КЧД - красный или чёрный
    /// </summary>
    public enum NodeColor
    {
        Red,
        Black
    }

    /// <summary>
    /// Узел красно-чёрного дерева
    /// </summary>
    public class RBT_Node : BinaryTreeNode
    {
        public NodeColor Color;
        public RBT_Node Left;
        public RBT_Node Right;
        public RBT_Node Parent;
        public int Value;
        //public Boolean Chosen;

        public RBT_Node(int Value) { this.Value = Value; }
        public RBT_Node(NodeColor Color) { this.Color = Color; }
        public RBT_Node(int Value, NodeColor Color) { this.Value = Value; this.Color = Color; }
    }

    public class RedBlackTree
    {
        /// <summary>
        /// Корень дерева
        /// </summary>
        public RBT_Node Root;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public RedBlackTree() { }

        /// <summary>
        /// Левый поворот
        /// Зеркальное отражение метода <see cref = "RightRotate(RBT_Node)"/> 
        /// </summary>
        /// <param name="X"></param>
        /// <returns>void</returns>
        private void LeftRotate(RBT_Node X)
        {
            RBT_Node Y = X.Right;
            X.Right = Y.Left;
            if (Y.Left != null)
            {
                Y.Left.Parent = X;
            }
            if (Y != null)
            {
                Y.Parent = X.Parent;
            }
            if (X.Parent == null)
            {
                Root = Y;
            }
            if (X == X.Parent.Left)
            {
                X.Parent.Left = Y;
            }
            else
            {
                X.Parent.Right = Y;
            }
            Y.Left = X;
            if (X != null)
            {
                X.Parent = Y;
            }

        }

        /// <summary>
        /// Правый поворот
        /// Зеркальное отражение метода <see cref = "LeftRotate(RBT_Node)"/> 
        /// </summary>
        /// <param name="Y"></param>
        /// <returns>void</returns>
        private void RightRotate(RBT_Node Y)
        {
            RBT_Node X = Y.Left;
            Y.Left = X.Right;
            if (X.Right != null)
            {
                X.Right.Parent = Y;
            }
            if (X != null)
            {
                X.Parent = Y.Parent;
            }
            if (Y.Parent == null)
            {
                Root = X;
            }
            if (Y == Y.Parent.Right)
            {
                Y.Parent.Right = X;
            }
            if (Y == Y.Parent.Left)
            {
                Y.Parent.Left = X;
            }

            X.Right = Y;
            if (Y != null)
            {
                Y.Parent = X;
            }
        }

        //public void DisplayTree()
        //{
        //    if (Root == null)
        //    {
        //        Console.WriteLine("Nothing in the tree!");
        //        return;
        //    }
        //    if (Root != null)
        //    {
        //        InOrderDisplay(Root);
        //    }
        //}

        //private void InOrderDisplay(RBT_Node current)
        //{
        //    if (current != null)
        //    {
        //        InOrderDisplay(current.left);
        //        Console.Write("({0}) ", current.Value);
        //        InOrderDisplay(current.right);
        //    }
        //}

        /// <summary>
        /// Поиск элемента в дереве
        /// </summary>
        /// <param name="Value"></param>
        public RBT_Node Search(int Value)
        {
            bool isFound = false;
            RBT_Node temp = Root;
            RBT_Node item = null;
            while (!isFound)
            {
                if (temp == null) break;
                else if (Value < temp.Value) temp = temp.Left;
                else if (Value > temp.Value) temp = temp.Right;
                else if (Value == temp.Value)
                {
                    isFound = true;
                    item = temp;
                }
            }
            if (isFound)
            {
                //Console.WriteLine("{0} was found", Key);
                return temp;
            }
            else
            {
                //Console.WriteLine("{0} not found", Value);
                return null;
            }
        }

        /// <summary>
        /// Добавление элемента в КЧД
        /// </summary>
        /// <param name="item"></param>
        public void Insert(int item)
        {
            if (Root != null) if (Search(item) != null) throw new ArgumentException
                    ("Операция невозможна - такой элемент в дереве уже существует");
            RBT_Node newItem = new RBT_Node(item);
            if (Root == null)
            {
                Root = newItem;
                Root.Color = NodeColor.Black;
                return;
            }
            RBT_Node Y = null;
            RBT_Node X = Root;
            while (X != null)
            {
                Y = X;
                if (newItem.Value < X.Value)
                {
                    X = X.Left;
                }
                else
                {
                    X = X.Right;
                }
            }
            newItem.Parent = Y;
            if (Y == null)
            {
                Root = newItem;
            }
            else if (newItem.Value < Y.Value)
            {
                Y.Left = newItem;
            }
            else
            {
                Y.Right = newItem;
            }
            newItem.Left = null;
            newItem.Right = null;
            newItem.Color = NodeColor.Red;
            InsertFixUp(newItem);
        }

        private void InsertFixUp(RBT_Node item)
        {
            while (item != Root && item.Parent.Color == NodeColor.Red)
            {
                if (item.Parent == item.Parent.Parent.Left)
                {
                    RBT_Node Y = item.Parent.Parent.Right;
                    if (Y != null && Y.Color == NodeColor.Red)
                    {
                        item.Parent.Color = NodeColor.Black;
                        Y.Color = NodeColor.Black;
                        item.Parent.Parent.Color = NodeColor.Red;
                        item = item.Parent.Parent;
                    }
                    else
                    {
                        if (item == item.Parent.Right)
                        {
                            item = item.Parent;
                            LeftRotate(item);
                        }
                        item.Parent.Color = NodeColor.Black;
                        item.Parent.Parent.Color = NodeColor.Red;
                        RightRotate(item.Parent.Parent);
                    }

                }
                else
                {
                    RBT_Node X = null;
                    X = item.Parent.Parent.Left;
                    if (X != null && X.Color == NodeColor.Black)
                    {
                        item.Parent.Color = NodeColor.Red;
                        X.Color = NodeColor.Red;
                        item.Parent.Parent.Color = NodeColor.Black;
                        item = item.Parent.Parent;
                    }
                    else
                    {
                        if (item == item.Parent.Left)
                        {
                            item = item.Parent;
                            RightRotate(item);
                        }
                        item.Parent.Color = NodeColor.Black;
                        item.Parent.Parent.Color = NodeColor.Red;
                        LeftRotate(item.Parent.Parent);

                    }

                }
                Root.Color = NodeColor.Black;
            }
        }

        /// <summary>
        /// Удаление значения из дерева
        /// </summary>
        /// <param name="item"></param>
        public void Delete(int key)
        {
            RBT_Node item = Search(key);
            RBT_Node X = null;
            RBT_Node Y = null;
            //if (Search(key) == null) throw new ArgumentException("Элемент не найден");
            if (item == null) throw new ArgumentException("Элемент не найден");
            if (item.Left == null || item.Right == null) Y = item;
            else Y = TreeSuccessor(item);
            if (Y.Left != null) X = Y.Left;
            else X = Y.Right;
            if (X != null) X.Parent = Y;
            if (Y.Parent == null) Root = X;
            else if (Y == Y.Parent.Left) Y.Parent.Left = X;
            else Y.Parent.Right = X;
            if (Y != item) item.Value = Y.Value;
            if (Y.Color == NodeColor.Black) DeleteFixUp(X);

        }
        /// <summary>
        /// Балансировка дерева после удаления элемента
        /// </summary>
        /// <param name="X"></param>
        private void DeleteFixUp(RBT_Node X)
        {
            while (X != null && X != Root && X.Color == NodeColor.Black)
            {
                if (X == X.Parent.Left)
                {
                    RBT_Node W = X.Parent.Right;
                    if (W.Color == NodeColor.Red)
                    {
                        W.Color = NodeColor.Black;
                        X.Parent.Color = NodeColor.Red;
                        LeftRotate(X.Parent);
                        W = X.Parent.Right;
                    }
                    if (W.Left.Color == NodeColor.Black && W.Right.Color == NodeColor.Black)
                    {
                        W.Color = NodeColor.Red;
                        X = X.Parent;
                    }
                    else if (W.Right.Color == NodeColor.Black)
                    {
                        W.Left.Color = NodeColor.Black;
                        W.Color = NodeColor.Red;
                        RightRotate(W);
                        W = X.Parent.Right;
                    }
                    W.Color = X.Parent.Color;
                    X.Parent.Color = NodeColor.Black;
                    W.Right.Color = NodeColor.Black;
                    LeftRotate(X.Parent);
                    X = Root;
                }
                else
                {
                    RBT_Node W = X.Parent.Left;
                    if (W.Color == NodeColor.Red)
                    {
                        W.Color = NodeColor.Black;
                        X.Parent.Color = NodeColor.Red;
                        RightRotate(X.Parent);
                        W = X.Parent.Left;
                    }
                    if (W.Right.Color == NodeColor.Black && W.Left.Color == NodeColor.Black)
                    {
                        W.Color = NodeColor.Black;
                        X = X.Parent;
                    }
                    else if (W.Left.Color == NodeColor.Black)
                    {
                        W.Right.Color = NodeColor.Black;
                        W.Color = NodeColor.Red;
                        LeftRotate(W);
                        W = X.Parent.Left;
                    }
                    W.Color = X.Parent.Color;
                    X.Parent.Color = NodeColor.Black;
                    W.Left.Color = NodeColor.Black;
                    RightRotate(X.Parent);
                    X = Root;
                }
            }
            if (X != null)
                X.Color = NodeColor.Black;
        }

        private RBT_Node Minimum(RBT_Node X)
        {
            while (X.Left/*.Left*/ != null)
            {
                X = X.Left;
            }
            if (X.Left != null) if (X.Left.Right != null)
            {
                X = X.Left.Right;
            }
            return X;
        }

        /// <summary>
        /// Возвращает "младшего наследника"
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        private RBT_Node TreeSuccessor(RBT_Node X)
        {
            if (X.Left != null)
            {
                return Minimum(X);
            }
            else
            {
                RBT_Node Y = X.Parent;
                while (Y != null && X == Y.Right)
                {
                    X = Y;
                    Y = Y.Parent;
                }
                return Y;
            }
        }
    }
}
