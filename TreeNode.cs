namespace Task7
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public TreeNode<T> Parent { get; set; }

        public TreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
            Parent = null;
        }

        public override string ToString()
        {
            return Data?.ToString() ?? "(null)";
        }
    }
}
