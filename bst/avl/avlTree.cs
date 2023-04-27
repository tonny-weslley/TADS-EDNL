namespace BST{


    class AVLTree<T> : Tree<T> where T : IComparable<T>{

        public AVLTree() : base(){}

        private void LeftRotation(AvlNode<T> node){

            AvlNode<T> parent = (AvlNode<T>)node.getParent();
            AvlNode<T> rigth = (AvlNode<T>)node.getRight();
            AvlNode<T> left = (AvlNode<T>)node.getLeft();
            


            


        }

    }
    

}