using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();

            /* Let us create following BST
                  50
               /     \
              30      70
             /  \    /  \
           20   40  60   80 */

            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            // print inorder traversal of the BST
            //tree.Inorder();

            //tree.Delete(20);
            //tree.Inorder();

            //tree.Delete(30);
            //tree.Inorder();

            //tree.Delete(50);
            //tree.Inorder();

            Console.WriteLine("Tree height is : {0}.", tree.getTreeHeight());

            Console.WriteLine("Balanced Tree : {0}.", tree.IsBalancedTree());
        }
    }

    public class BinarySearchTree
    {      
        Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        public void Insert(int key)
        {
            root = InsertRecord(root, key);
        }

        private Node InsertRecord(Node root, int key)
        {
            if (root == null)
            {
                return new Node(key);
            }

            if (root.data > key)
            {
                root.Left = InsertRecord(root.Left, key);
            }
            else
            {
                root.Right = InsertRecord(root.Right, key);
            }

            return root;
        }

        public void Inorder()
        {
            InorderTraversal(root);
            Console.WriteLine();
            PrintRoot();
        }

        void InorderTraversal(Node root)
        {
            if (root != null)
            {
                InorderTraversal(root.Left);
                Console.Write("{0} ", root.data);
                InorderTraversal(root.Right);
            }
        }

        public void Delete(int key)
        {
            Console.WriteLine("Going to delete : {0}", key);
            DeleteRecord(root, key);
        }

        private Node DeleteRecord(Node root, int key)
        {
            if (root == null)
            {
                return null;
            }

            if (root.data > key)
            {
                root.Left = DeleteRecord(root.Left, key);
            }
            else if (root.data < key)
            {
                root.Right = DeleteRecord(root.Right, key);
            }
            else
            {
                if (root.Right == null)
                    return root.Left;
                else if (root.Left == null)
                    return root.Right;

                //Find the inorder successor
                root.data = FindSuccessor(root.Right);
                root.Right = DeleteRecord(root.Right, root.data);
            }
            return root;
        }

        private int FindSuccessor(Node right)
        {
            int minValue = right.data;

            while(right.Left != null)
            {
                minValue = right.Left.data;
                right = right.Left;
            }

            return minValue;
        }

        public void PrintRoot()
        {
            Console.WriteLine("Root : {0}", root.data);            
        }

        public int getTreeHeight()
        {
            return GetHeight(root);
        }

        int GetHeight(Node head)
        {
            if (head == null)
                return 0;

            int lh = 1 + GetHeight(head.Left);
            int rh = 1 + GetHeight(head.Right);

            if (lh > rh)
                return lh;
            else
                return rh;
        }

        public bool IsBalancedTree()
        {
            if (GetHeightDifference(root) > 1)
                return false;

            return true;
        }

        int GetHeightDifference(Node head)
        {
            if (head == null)
                return 0;

            int lh = 1 + GetHeight(head.Left);
            int rh = 1 + GetHeight(head.Right);

            return Math.Abs(lh - rh);
        }
    }

    class Node
    {
        public int data;
        public Node Left, Right;

        public Node(int item)
        {
            data = item;
            Left = Right = null;
        }
    }
}
