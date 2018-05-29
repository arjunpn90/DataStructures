using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();

            /* Constructing tree given in the above figure */
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(50);
            tree.Insert(25);

            /* The constructed AVL Tree would be
                 30
                /  \
              20   40
             /  \     \
            10  25    50
            */
            Console.WriteLine("Preorder traversal" +
                            " of constructed tree is : ");
            tree.Inorder();
        }
    }

    public class AVLTree
    {
        Node root;

        public AVLTree()
        {
            root = null;
        }

        /// <summary>
        /// Return the root node.
        /// </summary>
        /// <returns></returns>
        public Node GetRoot()
        {
            return root;
        }

        /// <summary>
        /// Get the height of the node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int Height(Node node)
        {
            if (node == null)
                return 0;
            return node.height;
        }

        /// <summary>
        /// Left rotate around the node passed as parameter
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node LeftRotate(Node node)
        {
            Node newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;

            node.height = Maximum(Height(node.Left), Height(node.Right)) + 1;
            newNode.height = Maximum( Height(newNode.Left), Height(newNode.Right)) + 1;            

            return newNode;
        }

        /// <summary>
        /// Right rotate around the node passed as parameter.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node RightRotate(Node node)
        {
            Node newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            node.height = Maximum(Height(node.Left), Height(node.Right)) + 1;
            newNode.height = Maximum(Height(newNode.Left), Height(newNode.Right)) + 1;

            return newNode;
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
        private void InorderTraversal(Node root)
        {
            if (root != null)
            {
                InorderTraversal(root.Left);
                Console.Write("{0} ", root.data);
                InorderTraversal(root.Right);
            }
        }

        /// <summary>
        /// Print Root of BST
        /// </summary>
        public void PrintRoot()
        {
            Console.WriteLine("Root : {0}", root.data);
        }

        /// <summary>
        /// Get the balance factor - (left height - right height)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int GetBalanceFactor(Node node)
        {
            if (node == null)
                return 0;

            return Height(node.Left) - Height(node.Right);
        }

        /// <summary>
        /// Return maximum of two integers.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int Maximum(int a, int b)
        {
            return a > b ? a : b;
        }

        /// <summary>
        /// Exposed insert method
        /// </summary>
        /// <param name="key"></param>
        public void Insert(int key)
        {
            root = Insert(root, key);
        }

        /// <summary>
        /// Recursive insert method.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node Insert(Node node, int key)
        {
            if (node == null)
                return new Node(key);
            
            //Insert the node as in BST
            if (key < node.data)
                node.Left = Insert(node.Left, key);
            else if (key > node.data)
                node.Right = Insert(node.Right, key);
            else //Duplicate keys are not allowed.
                return node;

            //Update the height of the node
            node.height = Maximum(Height(node.Left), Height(node.Right)) + 1;

            int balancefactor = GetBalanceFactor(node);

            //Left Left Case
            if (balancefactor > 1 && key < node.Left.data)
            {
                node = RightRotate(node);
            }
            //Left Right Case
            else if (balancefactor > 1 && key > node.Left.data)
            {
                node.Left = LeftRotate(node.Left);
                node = RightRotate(node);
            }
            //Right Right Case
            else if (balancefactor < -1 && key > node.Right.data)
            {
                node = LeftRotate(node);
            }
            //Right Left Case
            else if (balancefactor < -1 && key < node.Right.data)
            {
                node.Right = RightRotate(node.Right);
                node = LeftRotate(node);
            }
            return node;
        }
    }

    public class Node
    {
        public int data, height;
        public Node Left, Right;

        public Node(int item)
        {
            data = item;
            Left = Right = null;
            height = 1;
        }
    }
}
