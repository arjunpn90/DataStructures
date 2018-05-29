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

        /// <summary>
        /// Insert exposed method
        /// </summary>
        /// <param name="key"></param>
        public void Insert(int key)
        {
            root = InsertRecord(root, key);
        }

        /// <summary>
        /// Insert Recursive call
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node InsertRecord(Node node, int key)
        {
            if (node == null)
            {
                return new Node(key);
            }

            if (node.data > key)
            {
                node.Left = InsertRecord(node.Left, key);
            }
            else
            {
                node.Right = InsertRecord(node.Right, key);
            }

            return node;
        }

        /// <summary>
        /// Tree Traversal - Inorder
        /// </summary>
        public void Inorder()
        {
            InorderTraversal(root);
            Console.WriteLine();
            PrintRoot();
        }

        /// <summary>
        /// Inorder - Recursive function
        /// </summary>
        /// <param name="root"></param>
        void InorderTraversal(Node root)
        {
            if (root != null)
            {
                InorderTraversal(root.Left);
                Console.Write("{0} ", root.data);
                InorderTraversal(root.Right);
            }
        }

        /// <summary>
        /// Delete exposed method
        /// </summary>
        /// <param name="key"></param>
        public void Delete(int key)
        {
            Console.WriteLine("Going to delete : {0}", key);
            DeleteRecord(root, key);
        }

        /// <summary>
        /// Delete a node in BST
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node DeleteRecord(Node node, int key)
        {
            if (node == null)
            {
                return null;
            }

            if (node.data > key)
            {
                node.Left = DeleteRecord(node.Left, key);
            }
            else if (node.data < key)
            {
                node.Right = DeleteRecord(node.Right, key);
            }
            else
            {
                if (node.Right == null)
                    return node.Left;
                else if (node.Left == null)
                    return node.Right;

                //Find the inorder successor
                node.data = FindSuccessor(node.Right);
                node.Right = DeleteRecord(node.Right, node.data);
            }
            return node;
        }

        /// <summary>
        /// Find inorder successor of the node.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private int FindSuccessor(Node root)
        {
            int minValue = root.data;

            while(root.Left != null)
            {
                minValue = root.Left.data;
                root = root.Left;
            }

            return minValue;
        }

        /// <summary>
        /// Print Root of BST
        /// </summary>
        public void PrintRoot()
        {
            Console.WriteLine("Root : {0}", root.data);            
        }

        /// <summary>
        /// Fetch tree height
        /// </summary>
        /// <returns></returns>
        public int getTreeHeight()
        {
            return GetHeight(root);
        }

        /// <summary>
        /// Recursive function to get tree height
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if tree is balanced tree or not
        /// </summary>
        /// <returns></returns>
        public bool IsBalancedTree()
        {
            if (GetHeightDifference(root) > 1)
                return false;

            return true;
        }

        /// <summary>
        /// Calculates the tree height different
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        int GetHeightDifference(Node head)
        {
            if (head == null)
                return 0;

            int lh = 1 + GetHeight(head.Left);
            int rh = 1 + GetHeight(head.Right);

            return Math.Abs(lh - rh);
        }

        /// <summary>
        /// Checks if the tree is Sum Tree or not
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool IsSumTree(Node node)
        {
            //Leaf nodes are sum tree by default
            if (node == null || (node.Left == null && node.Right == null))
                return true;

            int ls, rs;

            ls = Sum(node.Left);
            rs = Sum(node.Right);

            if ((node.data == ls + rs) && IsSumTree(node.Left) && IsSumTree(node.Right))
                return true;

            return true;
        }

        /// <summary>
        /// Calculate Sum of tree - Recursive function
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        int Sum(Node root)
        {
            if (root == null)
                return 0;
            return root.data + Sum(root.Left) + Sum(root.Right);
        }   
    }

    public class Node
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
