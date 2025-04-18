namespace Task7
{
    public partial class BinaryTree<T>
    {
        public PreorderIterator GetPreorderIterator()
        {
            return new PreorderIterator(this);
        }

        public PostorderIterator GetPostorderIterator()
        {
            return new PostorderIterator(this);
        }

        public class PreorderIterator
        {
            private BinaryTree<T> _tree;
            private Stack<TreeNode<T>> _stack;
            private TreeNode<T> _current;

            public PreorderIterator(BinaryTree<T> tree)
            {
                _tree = tree;
                _stack = new Stack<TreeNode<T>>();

                if (tree.Root != null)
                {
                    _stack.Push(tree.Root);
                    _current = tree.Root;
                }

                else
                {
                    _current = null;
                }
            }

            public bool MoveNext()
            {
                if (_stack.Count == 0)
                {
                    _current = null;
                    return false;
                }

                _current = _stack.Pop();

                if (_current.Right != null)
                {
                    _stack.Push(_current.Right);
                }

                if (_current.Left != null)
                {
                    _stack.Push(_current.Left);
                }

                return true;
            }

            public T Current
            {
                get
                {
                    if (_current == null)
                    {
                        throw new InvalidOperationException("Итератор находится вне диапазона");
                    }

                    return _current.Data;
                }
            }

            public void Reset()
            {
                _stack.Clear();

                if (_tree.Root != null)
                {
                    _stack.Push(_tree.Root);
                    _current = _tree.Root;
                }

                else
                {
                    _current = null;
                }
            }
        }

        public class PostorderIterator
        {
            private BinaryTree<T> _tree;
            private Stack<TreeNode<T>> _stack1;
            private Stack<TreeNode<T>> _stack2;
            private TreeNode<T> _current;

            public PostorderIterator(BinaryTree<T> tree)
            {
                _tree = tree;
                _stack1 = new Stack<TreeNode<T>>();
                _stack2 = new Stack<TreeNode<T>>();

                if (tree.Root != null)
                {
                    _stack1.Push(tree.Root);
                }

                _current = null;
            }

            public bool MoveNext()
            {
                if (_stack1.Count == 0 && _stack2.Count == 0)
                {
                    _current = null;
                    return false;
                }

                if (_stack1.Count > 0)
                {
                    TreeNode<T> node = _stack1.Pop();
                    _stack2.Push(node);

                    if (node.Left != null)
                    {
                        _stack1.Push(node.Left);
                    }

                    if (node.Right != null)
                    {
                        _stack1.Push(node.Right);
                    }
                }

                if (_stack1.Count == 0 && _stack2.Count > 0)
                {
                    _current = _stack2.Pop();
                    return true;
                }

                return false;
            }

            public T Current
            {
                get
                {
                    if (_current == null)
                    {
                        throw new InvalidOperationException("Итератор находится вне диапазона");
                    }

                    return _current.Data;
                }
            }

            public void Reset()
            {
                _stack1.Clear();
                _stack2.Clear();

                if (_tree.Root != null)
                {
                    _stack1.Push(_tree.Root);
                }

                _current = null;
            }
        }
    }
}
