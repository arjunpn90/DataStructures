using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            StackUsingQueue stack = new StackUsingQueue();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Console.WriteLine("Popped element : {0}", stack.Pop());
            Console.WriteLine("Popped element : {0}", stack.Pop());
            Console.WriteLine("Popped element : {0}", stack.Pop());
            Console.WriteLine("Popped element : {0}", stack.Pop());
            Console.WriteLine("Popped element : {0}", stack.Pop());
        }
    }

    class StackUsingQueue
    {
        Queue<int> queue1 = new Queue<int>();
        Queue<int> queue2 = new Queue<int>();

        #region Push - O(1) and Pop - O(n)
        //public void Push(int data)
        //{
        //    queue1.Enqueue(data);
        //}

        //public int Pop()
        //{
        //    while(queue1.Count > 1)
        //    {
        //        queue2.Enqueue(queue1.Dequeue());
        //    }            

        //    Queue<int> tempQueue = queue1;
        //    queue1 = queue2;
        //    queue2 = tempQueue;

        //    return queue2.Dequeue();
        //}
        #endregion

        #region Push - O(n) and Pop - O(1)
        public void Push(int data)
        {
            queue2.Enqueue(data);
            while (queue1.Count > 0)
            {
                queue2.Enqueue(queue1.Dequeue());
            }

            Queue<int> tempQueue = queue1;
            queue1 = queue2;
            queue2 = tempQueue;
        }

        public int Pop()
        {
            return queue1.Dequeue();
        }
        #endregion
    }
}
