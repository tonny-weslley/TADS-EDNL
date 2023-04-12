using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(12);
            tree.PrintTree();
            Console.WriteLine("-------------------------------");
            tree.Remove(5);
            tree.PrintTree();

            Console.WriteLine("-------------------------------");

            Tree<string> tree2 = new Tree<string>();
            tree2.Insert("c");
            tree2.Insert("a");
            tree2.Insert("b");  
            tree2.Insert("d");

            tree2.PrintTree();

        }
    }
}
