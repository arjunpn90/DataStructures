using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingStack
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueUsingStack queue = new QueueUsingStack();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Console.WriteLine("Dequeued element : {0}", queue.Dequeue());
            Console.WriteLine("Dequeued element : {0}", queue.Dequeue());
            Console.WriteLine("Dequeued element : {0}", queue.Dequeue());
            Console.WriteLine("Dequeued element : {0}", queue.Dequeue());
            Console.WriteLine("Dequeued element : {0}", queue.Dequeue());
        }
    }

    class QueueUsingStack
    {
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        #region Enqueue - O(n) and Dequeue - O(1)
        //public void Enqueue(int data)
        //{            
        //    while(stack1.Count > 0)
        //    {
        //        stack2.Push(stack1.Pop());
        //    }
        //    stack1.Push(data);
        //    while (stack2.Count > 0)
        //    {
        //        stack1.Push(stack2.Pop());
        //    }
        //}

        //public int Dequeue()
        //{
        //    return stack1.Pop();
        //}
        #endregion

        #region Enqueue - O(1) and Dequeue - O(n)
        public void Enqueue(int data)
        {
            stack1.Push(data);
        }

        public int Dequeue()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
            return stack2.Pop();
        }
        #endregion
    }
}
