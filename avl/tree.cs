namespace AVLTree
{
    class Tree<T> where T : IComparable<T>
    {
        private Node<T> root;
        public Tree()
        {
            this.root = null;
        }
        public Tree(Node<T> root){
            this.root = root;
        }
        public Node<T> getRoot()
        {
            return this.root;
        }
        public void Insert(T data)
        {
            //caso não tenha raiz
            if (this.root == null)
            {
                this.root = new Node<T>(data);
                return;
            }

            Node<T> auxNode = this.root;
            Node<T> currentNode = new Node<T>(data);

            while (true)
            {
                //caso o valor a ser inserido seja menor que o valor do nó atual
                if (auxNode.getData().CompareTo(data) > 0)
                {
                    //caso o nó atual não tenha filho a esquerda
                    if (auxNode.getLeft() == null)
                    {
                        auxNode.setLeft(currentNode); //seta o nó atual como filho a esquerda do nó auxiliar
                        currentNode.setParent(auxNode); //seta o nó auxiliar como pai do nó atual
                        return;
                    }
                    auxNode = auxNode.getLeft();
                }
                //caso o valor a ser inserido seja maior que o valor do nó atual
                else
                {
                    //caso o nó atual não tenha filho a direita
                    if (auxNode.getRight() == null)
                    {
                        auxNode.setRight(currentNode); //seta o nó atual como filho a direita do nó auxiliar
                        currentNode.setParent(auxNode); //seta o nó auxiliar como pai do nó atual
                        return;
                    }
                    auxNode = auxNode.getRight();
                }
            }
        }
        public void InOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            InOrderTraversal(node.getLeft());
            System.Console.WriteLine(node.getData());
            InOrderTraversal(node.getRight());
        }
        public void PreOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            System.Console.WriteLine(node.getData());
            PreOrderTraversal(node.getLeft());
            PreOrderTraversal(node.getRight());
        }
        public void PostOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            PostOrderTraversal(node.getLeft());
            PostOrderTraversal(node.getRight());
            System.Console.WriteLine(node.getData());
        }
        public void Remove(T data)
        {
            root = Remove(root, data);
        }

        private Node<T> Remove(Node<T> node, T data)
        {
            if (node == null)
            {
                return node;
            }

            if (data.CompareTo(node.data) < 0)
            {
                node.left = Remove(node.left, data);
            }
            else if (data.CompareTo(node.data) > 0)
            {
                node.right = Remove(node.right, data);
            }
            else
            {
                if (node.left == null && node.right == null)
                {
                    return null;
                }
                else if (node.left == null)
                {
                    return node.right;
                }
                else if (node.right == null)
                {
                    return node.left;
                }
                else
                {
                    Node<T> successor = FindMin(node.right);
                    node.data = successor.data;
                    node.right = Remove(node.right, successor.data);
                }
            }

            return node;
        }

        private Node<T> FindMin(Node<T> node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node;
        }

        public Node<T> Search(T data)
        {
            return Search(root, data);
        }

        private Node<T> Search(Node<T> node, T data)
        {
            if (node == null || node.data.Equals(data))
            {
                return node;
            }

            if (data.CompareTo(node.data) < 0)
            {
                return Search(node.left, data);
            }
            else
            {
                return Search(node.right, data);
            }
        }
        public void Display()
        {
            Display(root, 0);
        }

        private void Display(Node<T> node, int level)
        {
            if (node != null)
            {
                Display(node.right, level + 1);
                Console.WriteLine(new string(' ', 4 * level) + node.data.ToString());
                Display(node.left, level + 1);
            }
        }

        public void PrintHorizontal()
        {
            int treeHeight = GetHeight(root);
            for (int i = 0; i <= treeHeight; i++)
            {
                PrintLevel(root, i, 0);
                Console.WriteLine();
            }
        }

        private int GetHeight(Node<T> node)
        {
            if (node == null)
            {
                return -1;
            }
            int leftHeight = GetHeight(node.left);
            int rightHeight = GetHeight(node.right);
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        private void PrintLevel(Node<T> node, int targetLevel, int auxNodeLevel)
        {
            if (node == null)
            {
                return;
            }
            if (targetLevel == auxNodeLevel)
            {
                Console.Write(node.data.ToString().PadLeft(4));
            }
            else
            {
                PrintLevel(node.left, targetLevel, auxNodeLevel + 1);
                PrintLevel(node.right, targetLevel, auxNodeLevel + 1);
            }
        }
    }
}