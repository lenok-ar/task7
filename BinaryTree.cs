using System.Collections;

namespace Task7
{
    public partial class BinaryTree<T> : IEnumerable<T>
    {
        public TreeNode<T> Root { get; set; }
        public int Count { get; private set; } = 0;

        public BinaryTree()
        {
            Root = null;
        }

        public BinaryTree(T rootData)
        {
            Root = new TreeNode<T>(rootData);
            Count = 1;
        }

        public void Add(T data, Comparison<T> comparison = null)
        {
            TreeNode<T> newNode = new TreeNode<T>(data);
            Count++;

            if (Root == null)
            {
                Root = newNode;
                return;
            }

            TreeNode<T> current = Root;
            TreeNode<T> parent = null;

            while (current != null)
            {
                parent = current;
                int compareResult = comparison != null ? comparison(data, current.Data) : Comparer<T>.Default.Compare(data, current.Data);

                if (compareResult < 0)
                {
                    current = current.Left;
                }

                else
                {
                    current = current.Right;
                }
            }

            int finalCompareResult = comparison != null ? comparison(data, parent.Data) : Comparer<T>.Default.Compare(data, parent.Data);

            if (finalCompareResult < 0)
            {
                parent.Left = newNode;
            }

            else
            {
                parent.Right = newNode;
            }

            newNode.Parent = parent;
        }

        public TreeNode<T> Find(T data, Comparison<T> comparison = null)
        {
            TreeNode<T> current = Root;

            while (current != null)
            {
                int compareResult = comparison != null ? comparison(data, current.Data) : Comparer<T>.Default.Compare(data, current.Data);

                if (compareResult == 0)
                {
                    return current;
                }

                else if (compareResult < 0)
                {
                    current = current.Left;
                }

                else
                {
                    current = current.Right;
                }
            }

            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetInorderTraversal().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public delegate List<T> InorderTraversalDelegate();

        public InorderTraversalDelegate GetInorderTraversalDelegate()
        {
            InorderTraversalDelegate inorderTraversal = () =>
            {
                List<T> result = new List<T>();
                InorderTraversalRecursive(Root, result);
                return result;
            };

            return inorderTraversal;
        }

        private void InorderTraversalRecursive(TreeNode<T> node, List<T> result)
        {
            if (node != null)
            {
                InorderTraversalRecursive(node.Left, result);
                result.Add(node.Data);
                InorderTraversalRecursive(node.Right, result);
            }
        }

        public IEnumerable<T> GetInorderTraversal()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            TreeNode<T> current = Root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                yield return current.Data;
                current = current.Right;
            }
        }

        public T Next(T data)
        {
            TreeNode<T> node = Find(data);

            if (node == null)
            {
                return default(T);
            }

            TreeNode<T> nextNode = InorderSuccessor(node);
            return nextNode != null ? nextNode.Data : default(T);
        }

        public T Previous(T data)
        {
            TreeNode<T> node = Find(data);
            if (node == null)
            {
                return default(T);
            }

            TreeNode<T> prevNode = InorderPredecessor(node);
            return prevNode != null ? prevNode.Data : default(T);
        }

        private TreeNode<T> InorderSuccessor(TreeNode<T> node)
        {
            if (node.Right != null)
            {
                return LeftmostChild(node.Right);
            }

            TreeNode<T> parent = node.Parent;

            while (parent != null && node == parent.Right)
            {
                node = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        private TreeNode<T> InorderPredecessor(TreeNode<T> node)
        {
            if (node.Left != null)
            {
                return RightmostChild(node.Left);
            }

            TreeNode<T> parent = node.Parent;

            while (parent != null && node == parent.Left)
            {
                node = parent;
                parent = parent.Parent;
            }

            return parent;
        }

        private TreeNode<T> LeftmostChild(TreeNode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        private TreeNode<T> RightmostChild(TreeNode<T> node)
        {
            while (node.Right != null)
            {
                node = node.Right;
            }

            return node;
        }
    }
}
