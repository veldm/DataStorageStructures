using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    /// <summary>
    /// Узел бинарного дерева поиска
    /// </summary>
    public class BST_Node : BinaryTreeNode
    {
        public int Value;
        public BST_Node Left;
        public BST_Node Right;
        //public Boolean Chosen;

        //public BST_Node(BST_Node Left, BST_Node Right, int Value) 
        //    : base(Left, Right, Value) { }

        public BST_Node(int Value) { this.Value = Value; }
    }

    /// <summary>
    /// Бинарное дерево поиска
    /// </summary>
    public class BinarySearchTree
    {
        public BST_Node Root;
        public int Count;

        /// <summary>
        /// Вставка элемента в дерево
        /// </summary>
        /// <param name="value"></param>
        public void Insert(int value)
        {
            BST_Node node = new BST_Node(value);
            Insert(node);
            BalanceTree();
        }

        private void Insert(BST_Node node)
        {
            if (node == null) throw new ArgumentNullException
                    ("node", "Попытка вставки пустого узла (null)");
            if (Root == null) Root = node;
            else Insert(node, ref Root);
            Count++;
        }

        /// <summary>
        /// Удаление элемента из дерева
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rebalanceTree"></param>
        public void Delete(int value)
        {
            bool rebalanceTree = true;
            BST_Node parentNode;
            BST_Node foundNode = null;
            BST_Node tree = parentNode = Root;
            //Поиск узла с сохранением ссылки на родителя
            while (tree != null)
            {
                if (value.CompareTo(tree.Value) == 0)
                {
                    foundNode = tree;
                    break;
                }
                else if (value.CompareTo(tree.Value) < 0)
                {
                    parentNode = tree;
                    tree = (BST_Node)tree.Left;
                }
                else if (value.CompareTo(tree.Value) > 0)
                {
                    parentNode = tree;
                    tree = (BST_Node)tree.Right;
                }
            }
            if (foundNode == null) throw new ArgumentException("Элемент не найден");
            bool leftOrRightNode = false;
            if (foundNode != parentNode.Left) leftOrRightNode = true;
            if (foundNode == parentNode) //Удаление корня
            {
                if (rebalanceTree)
                {
                    List<BST_Node> listOfNodes = new List<BST_Node>();
                    FillListInOrder(Root, listOfNodes);
                    RemoveChildren(listOfNodes);
                    listOfNodes.Remove(parentNode);
                    Root = null;
                    int count = Count - 1;
                    Count = 0;
                    BalanceTree(0, count - 1, listOfNodes);
                }
                else
                {
                    // Обычный способ без балансировки - просто ищется самый левый узел
                    // с правой стороны дерева, и делается корневым
                    BST_Node leftMost = FindLeftMost((BST_Node)parentNode.Right, true);
                    if (leftMost != null)
                    {
                        leftMost.Left = parentNode.Left;
                        leftMost.Right = parentNode.Right;
                        Root = leftMost;
                    }
                }
            }
            //Если это "лист"
            else if (foundNode.Left == null && foundNode.Right == null)
            {
                if (leftOrRightNode) parentNode.Right = null;
                else parentNode.Left = null;
            }
            // Если это обычный узелс 2-мя потомками
            else if (foundNode.Left != null && foundNode.Right != null)
            {
                if (leftOrRightNode)
                {
                    parentNode.Right = foundNode.Right;
                    parentNode.Right.Left = foundNode.Left;
                }
                else
                {
                    parentNode.Left = foundNode.Right;
                    parentNode.Left.Left = foundNode.Left;
                }
            }
            // Если это узел с 1 потомком
            else if (foundNode.Left != null || foundNode.Right != null)
            {
                // Если потомок левый
                if (foundNode.Left != null)
                {
                    if (leftOrRightNode) parentNode.Right = foundNode.Left;
                    else parentNode.Left = foundNode.Left;
                }
                // Если потомок правый
                else
                {
                    if (leftOrRightNode) parentNode.Right = foundNode.Right;
                    else parentNode.Left = foundNode.Right;
                }
            }
            if (foundNode != parentNode)
            {
                Count--;
                BalanceTree();
            }
        }

        /// <summary>
        /// Поиск  элемента в дереве
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public BST_Node Search(int value)
        {
            BST_Node tree = Root;
            while (Root != null)
            {
                if (value.CompareTo(tree.Value) == 0) return tree;
                else if (value.CompareTo(tree.Value) < 0)
                    tree = (BST_Node)tree.Left;
                else if (value.CompareTo(tree.Value) > 0)
                    tree = (BST_Node)tree.Right;
            }
            return null;
        }

        public IEnumerable<BST_Node> InOrder()
        {
            return InOrder(Root);
        }

        private IEnumerable<BST_Node> InOrder(BST_Node node)
        {
            if (node != null)
            {
                foreach (BST_Node left in InOrder((BST_Node)node.Left))
                    yield return left;
                yield return node;
                foreach (BST_Node right in InOrder((BST_Node)node.Right))
                    yield return right;
            }
        }

        public IEnumerable<BST_Node> PreOrder()
        {
            return PreOrder(Root);
        }

        public IEnumerable<BST_Node> PostOrder()
        {
            return PostOrder(Root);
        }

        public IEnumerable<BST_Node> BreadthFirstTraversal()
        {
            Queue<BST_Node> queue = new Queue<BST_Node>();
            queue.Enqueue(Root);
            while (queue.Count != 0)
            {
                BST_Node current = queue.Dequeue();
                if (current != null)
                {
                    queue.Enqueue((BST_Node)current.Left);
                    queue.Enqueue((BST_Node)current.Right);
                    yield return current;
                }
            }
        }

        public IEnumerable<BST_Node> DepthFirstTraversal()
        {
            Stack<BST_Node> queue = new Stack<BST_Node>();
            BST_Node current;
            queue.Push(Root);
            while (queue.Count != 0)
            {
                current = queue.Pop();
                if (current != null)
                {
                    queue.Push((BST_Node)current.Right);
                    queue.Push((BST_Node)current.Left);
                    yield return current;
                }
            }
        }

        /// <summary>
        /// Балнсировка дерева
        /// </summary>
        public void BalanceTree()
        {
            List<BST_Node> listOfNodes = new List<BST_Node>();
            FillListInOrder(Root, listOfNodes);
            RemoveChildren(listOfNodes);
            Root = null;
            int count = Count;
            Count = 0;
            BalanceTree(0, count - 1, listOfNodes);
        }

        /// <summary>
        /// Добавление элемента в БДП
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parent"></param>
        private void Insert(BST_Node node, ref BST_Node parent)
        {
            if (parent == null) parent = node;
            else
            {
                if (node.Value.CompareTo(parent.Value) < 0)
                {
                    //BST_Node A = (BST_Node)parent.Left;
                    Insert(node, ref parent.Left);
                }
                else if (node.Value.CompareTo(parent.Value) > 0)
                {
                    //BST_Node A = (BST_Node)parent.Right;
                    Insert(node, ref parent.Right);
                }
                else if (node.Value.CompareTo(parent.Value) == 0)
                    throw new ArgumentException("Операция невозможна - такой элемент" +
                        " в дереве уже существует");
            }
        }

        private void BalanceTree(int min, int max, List<BST_Node> list)
        {
            if (min <= max)
            {
                int middleNode = (int)Math.Ceiling(((double)min + max) / 2);
                Insert(list[middleNode]);
                BalanceTree(min, middleNode - 1, list);
                BalanceTree(middleNode + 1, max, list);
            }
        }

        /// <summary>
        /// Заполнение <see cref = "ICollection{BST_Node}"/> в порядке LCR
        /// </summary>
        /// <param name="node"></param>
        /// <param name="list"></param>
        public static void FillListInOrder(BST_Node node, ICollection<BST_Node> list)
        {
            if (node != null)
            {
                FillListInOrder((BST_Node)node.Left, list);
                list.Add(node);
                FillListInOrder((BST_Node)node.Right, list);
            }
        }

        private void RemoveChildren(IEnumerable<BST_Node> list)
        {
            foreach (BST_Node node in list)
            {
                node.Left = null;
                node.Right = null;
            }
        }

        private IEnumerable<BST_Node> PreOrder(BST_Node node)
        {
            if (node != null)
            {
                yield return node;
                foreach (BST_Node left in PreOrder((BST_Node)node.Left))
                    yield return left;
                foreach (BST_Node right in PreOrder((BST_Node)node.Right))
                    yield return right;
            }
        }

        private IEnumerable<BST_Node> PostOrder(BST_Node node)
        {
            if (node != null)
            {
                foreach (BST_Node left in PostOrder((BST_Node)node.Left))
                    yield return left;
                foreach (BST_Node right in PostOrder((BST_Node)node.Right))
                    yield return right;
                yield return node;
            }
        }

        private BST_Node FindLeftMost(BST_Node node, bool setParentToNull)
        {
            BST_Node leftMost = null;
            BST_Node current = leftMost = node;
            BST_Node parent = null;
            while (current != null)
            {
                if (current.Left != null)
                {
                    parent = current;
                    leftMost = (BST_Node)current.Left;
                }
                current = (BST_Node)current.Left;
            }
            if (parent != null && setParentToNull) parent.Left = null;
            return leftMost;
        }
    }
}
