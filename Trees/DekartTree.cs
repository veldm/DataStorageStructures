using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class DekT_Node : BinaryTreeNode
    {
        public int Value;
        public int Key;
        public DekT_Node Left;
        public DekT_Node Right;
        private DekT_Node Parent;

        public DekT_Node(int x, int y, DekT_Node left = null, DekT_Node right = null)
        {
            Value = x;
            Key = y;
            Left = left;
            Right = right;
        }

        private DekT_Node(int x, int y, DekT_Node p)
        {
            Value = x;
            Key = y;
            Parent = p;
        }

        public static DekT_Node Merge(DekT_Node L, DekT_Node R)
        {
            if (L == null) return R;
            if (R == null) return L;

            if (L.Key > R.Key)
            {
                var newR = Merge(L.Right, R);
                return new DekT_Node(L.Value, L.Key, L.Left, newR);
            }
            else
            {
                var newL = Merge(L, R.Left);
                return new DekT_Node(R.Value, R.Key, newL, R.Right);
            }
        }

        public void Split(int x, out DekT_Node L, out DekT_Node R)
        {
            DekT_Node newTree = null;
            if (Value <= x)
            {
                if (Right == null)
                    R = null;
                else
                    Right.Split(x, out newTree, out R);
                L = new DekT_Node(this.Value, Key, Left, newTree);
            }
            else
            {
                if (Left == null)
                    L = null;
                else
                    Left.Split(x, out L, out newTree);
                R = new DekT_Node(this.Value, Key, newTree, Right);
            }
        }

        public void Insert(int x)
        {
            DekT_Node A = Add(x);
            Right = A.Right;
            Left = A.Left;
            Value = A.Value;
            Key = A.Key;
        }

        private DekT_Node Add(int x)
        {
            Split(x, out DekT_Node L, out DekT_Node R);
            Random Rnd = new Random(DateTime.Now.Millisecond);
            DekT_Node M = new DekT_Node(x, Rnd.Next(0, 25));
            return Merge(Merge(L, M), R);
        }

        public void Delete(int x)
        {
            DekT_Node A = Remove(x);
            Right = A.Right;
            Left = A.Left;
            Value = A.Value;
            Key = A.Key;
        }

        private DekT_Node Remove(int x)
        {
            Split(x - 1, out DekT_Node L, out DekT_Node R);
            R.Split(x, out DekT_Node M, out R);
            return Merge(L, R);
        }

        public DekT_Node Search(int x)
        {
            DekT_Node A = this;
            while (A.Value != x && A != null)
            {
                if (A.Value < x) A = A.Right;
                else A = A.Left;
            }
            return A;
        }
    }
}
