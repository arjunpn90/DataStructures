using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap minHeap = new MinHeap();
            Heap maxHeap = new MaxHeap();

            minHeap.Add(1);
            minHeap.Add(2);
            minHeap.Add(3);
            minHeap.Add(4);

            maxHeap.Add(1);
            maxHeap.Add(2);
            maxHeap.Add(3);
            maxHeap.Add(4);

            PrintBFSTraversal(minHeap);
            PrintBFSTraversal(maxHeap);
        }

        static void PrintBFSTraversal(Heap heap)
        {
            Queue<int> bfsQueue = new Queue<int>();
            Console.Write("{0} ", heap.items[0]);
            if (heap.HasLeftChild(0))
                bfsQueue.Enqueue(heap.GetLeftChildIndex(0));
            if (heap.HasRightChild(0))
                bfsQueue.Enqueue(heap.GetRightChildIndex(0));

            while(bfsQueue.Count > 0)
            {
                int index = bfsQueue.Dequeue();
                Console.Write("{0} ", heap.items[index]);
                if (heap.HasLeftChild(index))
                    bfsQueue.Enqueue(heap.GetLeftChildIndex(index));
                if (heap.HasRightChild(index))
                    bfsQueue.Enqueue(heap.GetRightChildIndex(index));
            }
            Console.WriteLine();
        }
    }
}
