using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace Интерфейс
{
    /// <summary>
    /// Деревья "по умолчанию"
    /// </summary>
    internal static partial class DefaultTrees
    {
        /// <summary>
        /// Начальный вариант дерева <see cref = "BinarySearchTree"/>
        /// </summary>
        internal static BinarySearchTree BST()
        {
            BinarySearchTree T = new BinarySearchTree
            { Root = new BST_Node(0) };
            int[] Mas = { -5, -1, 1, 3, 5, 6, 8, 13, 16, 17 };
            for (int i = 0; i < Mas.Length; i++)
                T.Insert(Mas[i]);
            return T;
        }

        /// <summary>
        /// Начальный вариант дерева <see cref = "RedBlackTree"/>
        /// </summary>
        internal static RedBlackTree RBT()
        {
            RedBlackTree T = new RedBlackTree();
            int[] Mas = { 5, 3, 7, 1, 9, -1, 11, 6 };
            for (int i = 0; i < Mas.Length; i++)
                T.Insert(Mas[i]);
            //T.Insert(-5); //g
            //T.Insert(3);
            //T.Insert(7);
            //T.Insert(1);
            //T.Insert(19); //g
            //T.Insert(-1);
            //T.Insert(11);
            //T.Insert(6);
            return T;
        }

        /// <summary>
        /// Начальный вариант дерева <see cref = "DekT_Node"/>
        /// </summary>
        /// <returns></returns>
        internal static DekT_Node DekT()
        {
            DekT_Node T = new DekT_Node(5, 14)
            { Left = new DekT_Node(2, 11) };
            T.Left.Left = new DekT_Node(0, 6);
            T.Left.Right = new DekT_Node(3, 8)
            { Right = new DekT_Node(4, 1) };
            T.Right = new DekT_Node(13, 12)
            {
                Left = new DekT_Node(7, 9),
                Right = new DekT_Node(19, 10)
            };
            return T;
        }
    }
}
