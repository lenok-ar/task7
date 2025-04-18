namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Add(50);
            tree.Add(30);
            tree.Add(20);
            tree.Add(40);
            tree.Add(70);
            tree.Add(60);
            tree.Add(80);

            Console.WriteLine("Обход по порядку (foreach):");
            
            foreach (int item in tree)
            {
                Console.Write(item + " ");
            }
           
            Console.WriteLine();

            Console.WriteLine("Предварительный обход (iterator):");
            BinaryTree<int>.PreorderIterator preorderIterator = tree.GetPreorderIterator();
           
            while (preorderIterator.MoveNext())
            {
                Console.Write(preorderIterator.Current + " ");
            }
            
            Console.WriteLine();

            Console.WriteLine("Постпорядковый обход (iterator):");
            BinaryTree<int>.PostorderIterator postorderIterator = tree.GetPostorderIterator();
            
            while (postorderIterator.MoveNext())
            {
                Console.Write(postorderIterator.Current + " ");
            }
            
            Console.WriteLine();

            Console.WriteLine("Обход по порядку (external iterator):");
            BinaryTree<int>.InorderTraversalDelegate inorderDelegate = tree.GetInorderTraversalDelegate();
            List<int> inorderList = inorderDelegate();
            
            foreach (int item in inorderList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Console.WriteLine($"Следующий из 30: {tree.Next(30)}");
            Console.WriteLine($"Предыдущий из 30: {tree.Previous(30)}");
            Console.WriteLine($"Следующий из 80: {tree.Next(80)}");
            Console.WriteLine($"Предыдущий из 20: {tree.Previous(20)}");

            Console.ReadKey();
        }
    }
}