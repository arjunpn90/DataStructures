using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU_Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache cache = new LRUCache(3);
            Console.WriteLine(cache.GetPage(1));
            Console.WriteLine(cache.GetPage(2));
            Console.WriteLine(cache.GetPage(3));
            Console.WriteLine(cache.GetPage(4));
            Console.WriteLine(cache.GetPage(1));
            Console.WriteLine(cache.GetPage(2));
            Console.WriteLine(cache.GetPage(5));
            Console.WriteLine(cache.GetPage(1));
            Console.WriteLine(cache.GetPage(2));
            Console.WriteLine(cache.GetPage(3));
            Console.WriteLine(cache.GetPage(4));
            Console.WriteLine(cache.GetPage(5));
        }
    }

    class LRUCache
    {
        DoublyLL queue = new DoublyLL();
        Dictionary<int, Node> index = new Dictionary<int, Node>();
        int capacity = 10;

        public LRUCache(int pCapacity)
        {
            capacity = pCapacity;
        }

        public string GetPage(int page)
        {
            queue.PrintLL();
            if (index.ContainsKey(page))
            {
                //Remove the node and add it to the front
                queue.RemoveAndAddAtFront(index[page], index);
                return string.Format("Existing value : {0} from cache.", index[page].Value);
            }
            else
            {
                Node newItem = new Node(page);
                if (queue.capacity == capacity)
                {
                    index.Remove(queue.RemoveAtEnd());
                }
                queue.AddAtFront(newItem);
                index.Add(page, newItem);
                return string.Format("New value : {0} added to cache.", index[page].Value);                
            }
        }
    }

    class DoublyLL
    {
        Node front;
        Node end;
        public int capacity = 0;

        public DoublyLL()
        {
            front = null;
            end = null;
        }

        public void AddAtFront(Node newNode)
        {
            if (front == null)
            {
                front = end = newNode;
            }
            else
            {
                newNode.next = front;
                front.previous = newNode;
                front = newNode;
            }
            capacity++;
        }

        public void AddAtEnd(Node newNode)
        {
            if (end == null)
            {
                front = end = newNode;
            }
            else
            {
                end.next = newNode;
                newNode.previous = end;
                end = newNode;
            }
            capacity++;
        }

        public void RemoveAtFront()
        {
            if (front != null)           
            {
                Node current = front;
                front = front.next;
                front.previous = null;
                current.next = null;
            }
            capacity--;
        }

        public int RemoveAtEnd()
        {
            int removeKey = end.Value;
            if (end != null)            
            {
                Node current = end;
                end = end.previous;
                end.next = null;
                current.previous = null;
            }
            capacity--;
            return removeKey;
        }

        public void RemoveAndAddAtFront(Node existingNode, Dictionary<int, Node> index)
        {                        
            if (end == existingNode)
            {
                //index.Remove(RemoveAtEnd());
                RemoveAtEnd();
                AddAtFront(existingNode);
            }
            else
            {
                Node current = front;
                while (current != existingNode)
                {
                    current = current.next;
                }

                Node currPrev = current.previous;
                Node currNext = current.next;
                current.next = null;
                current.previous = null;
                if (currNext != null)
                {
                    currPrev.next = currNext;
                    currNext.previous = currPrev;
                }
                AddAtFront(current);
            }
        }

        public void PrintLL()
        {
            Node current = front;
            while (current != null)
            {
                Console.Write("{0}->", current.Value);
                current = current.next;
            }
            Console.WriteLine("{0} "," NULL");
        }
    }

    class Node
    {
        public int Value;
        public Node next;
        public Node previous;

        public Node(int value)
        {
            this.Value = value;
            this.next = null;
            this.previous = null;
        }
    }
}
