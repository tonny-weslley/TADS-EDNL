namespace BST{


    class AvlNode<T> : Node<T>
    {
        private int BF;
        public AvlNode(T data) : base(data)
        {
        }

        public int getBF(){
            return this.BF;
        }

        public void setBF(int value){
            this.BF = value;
        }
    }


}