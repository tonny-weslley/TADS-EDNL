namespace BST
{
    class Node<T>
    {
        private T data;
        private Node<T> left;
        private Node<T> right;
        private Node<T> parent;
        public Node( T data )
        {
            this.data = data;
            this.left = null;
            this.right = null;
            this.parent = null;
        }


        //getters e setters
        public T getData()
        {
            return this.data;
        }

        public void setData(T data)
        {
            this.data = data;
        }

        public Node<T> getLeft()
        {
            return this.left;
        }

        public void setLeft(Node<T> left)
        {
            this.left = left;
        }

        public Node<T> getRight()
        {
            return this.right;
        }

        public void setRight(Node<T> right)
        {
            this.right = right;
        }

        public Node<T> getParent()
        {
            return this.parent;
        }
        public void setParent(Node<T> parent)
        {
            this.parent = parent;
        }

        //metodos
        public bool isRoot()
        {
            return this.left == null && this.right == null && this.parent == null;
        }
        public bool isLeaf()
        {
            return this.left == null && this.right == null && this.parent != null;
        }
    }
}