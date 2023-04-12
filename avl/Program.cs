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
            tree.Insert(18);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(11);
            tree.Insert(13);

            tree.Display();

        }
    }
}
