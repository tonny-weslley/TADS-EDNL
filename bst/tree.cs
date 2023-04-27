namespace BST
{
    class Tree<T> where T : IComparable<T>
    {
        private Node<T> root;
        public Tree()
        {
            this.root = null;
        }
        public Tree(Node<T> root)
        {
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

            //Otimizacao 01
            //caso o no a ser removido for o root
            if(data.Equals(this.root.getData())){
                if(this.root.getLeft() == null && this.root.getRight() == null){
                    this.root = null;
                    return;
                }
                if(this.root.getLeft() != null && this.root.getRight() == null){
                    this.root = this.root.getLeft();
                    return;
                }
                if(this.root.getLeft() == null && this.root.getRight() != null){
                    this.root = this.root.getRight();
                    return;
                }
                if(this.root.getLeft() != null && this.root.getRight() != null){
                    Node<T> auxNode = FindMin(this.root.getRight());
                    this.root.setData(auxNode.getData());
                    auxNode.getParent().setLeft(null);
                    return;
                }
            }

            // caso o no a ser remodivo nao seja o raiz
            Node<T> nodeToRemove = Search(data);

            //caso o no a ser removido nao exista
            if (nodeToRemove == null)
            {
                return;
            }

            //caso o no a ser removido nao tenha filhos
            if (nodeToRemove.getLeft() == null && nodeToRemove.getRight() == null)
            {
                //caso o no a ser removido seja filho a esquerda
                if (nodeToRemove.getParent().getLeft() == nodeToRemove)
                {
                    nodeToRemove.getParent().setLeft(null);
                    return;
                }
                //caso o no a ser removido seja filho a direita
                if (nodeToRemove.getParent().getRight() == nodeToRemove)
                {
                    nodeToRemove.getParent().setRight(null);
                    return;
                }
                //?? Preciso setar o valor do no como nulo ou so o fato de nao ter mais referencia para ele ja e suficiente?
            }

            //caso o no a ser removido tenha apenas o filho da esquerda
            if (nodeToRemove.getLeft() != null && nodeToRemove.getRight() == null)
            {
                //caso o no a ser removido seja filho a esquerda
                if (nodeToRemove.getParent().getLeft() == nodeToRemove)
                {
                    nodeToRemove.getParent().setLeft(nodeToRemove.getLeft());
                    return;
                }
                //caso o no a ser removido seja filho a direita
                if (nodeToRemove.getParent().getRight() == nodeToRemove)
                {
                    nodeToRemove.getParent().setRight(nodeToRemove.getLeft());
                    return;
                }
            }

            //caso o no a ser removido tenha apenas o filho da direita
            if (nodeToRemove.getLeft() == null && nodeToRemove.getRight() != null)
            {
                //caso o no a ser removido seja filho a esquerda
                if (nodeToRemove.getParent().getLeft() == nodeToRemove)
                {
                    nodeToRemove.getParent().setLeft(nodeToRemove.getRight());
                    return;
                }
                //caso o no a ser removido seja filho a direita
                if (nodeToRemove.getParent().getRight() == nodeToRemove)
                {
                    nodeToRemove.getParent().setRight(nodeToRemove.getRight());
                    return;
                }
            }

            //caso o no a ser removido tenha os dois filhos
            if (nodeToRemove.getLeft() != null && nodeToRemove.getRight() != null)
            {
                Node<T> auxNode = FindMin(nodeToRemove.getRight());
                nodeToRemove.setData(auxNode.getData());
                auxNode.getParent().setLeft(null);
                return;
            } 
        }

        // método para encontrar o menor valor da árvore ou sub-arvore
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

        private int getDeep(Node<T> node)
        {
            if (node == null)
            {
                return -1;
            }
            return getDeep(node.getParent()) + 1;
        }

        public void PrintTree()
        {
            PrintTree(root);
        }

        private void PrintTree(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            PrintTree(node.right);
            for (int i = 0; i < getDeep(node); i++)
            {
                System.Console.Write("   ");
            }
            System.Console.WriteLine(node.data);
            PrintTree(node.left);
        }
        


    }
}   