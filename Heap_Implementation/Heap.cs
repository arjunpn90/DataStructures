using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Implementation
{
    abstract class Heap
    {
        protected int capacity;

        protected int size;

        public int[] items;

        public Heap()
        {
            this.capacity = 10;
            this.size = 0;
            this.items = new int[capacity];
        }

        public void EnsureCapacity()
        {
            if (size == capacity)
            {
                capacity++;
                Array.Copy(items, items, capacity);
            }
        }

        public int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        public int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        public int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        public bool HasLeftChild(int parentIndex)
        {
            return GetLeftChildIndex(parentIndex) < size;
        }

        public bool HasRightChild(int parentIndex)
        {
            return GetRightChildIndex(parentIndex) < size;
        }

        public bool HasParent(int childIndex)
        {
            return GetParentIndex(childIndex) >= 0;
        }

        public int LeftChild(int index)
        {
            return items[GetLeftChildIndex(index)];
        }

        public int RightChild(int index)
        {
            return items[GetRightChildIndex(index)];
        }

        public int Parent(int index)
        {
            return items[GetParentIndex(index)];
        }

        public void Swap(int index1, int index2)
        {
            int temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }

        public int Peek()
        {
            IsEmpty("Peek");
            return items[0];
        }

        public void IsEmpty(string methodName)
        {
            if (size == 0)
                throw new Exception(string.Format("You cannot perform an operation {0} on an empty heap.", methodName));
        }

        public int Poll()
        {
            IsEmpty("Poll");

            int item = items[0];
            items[0] = items[size - 1];
            size--;
            HeapifyDown();
            return item;
        }

        public void Add(int item)
        {
            EnsureCapacity();
            items[size] = item;
            size++;
            HeapifyUp();
        }

        public abstract void HeapifyDown();

        public abstract void HeapifyUp();
    }

    class MinHeap : Heap
    {
        public override void HeapifyDown()
        {
            int index = 0;

            while(HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);

                if (HasRightChild(index) && RightChild(index) < LeftChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }
                if (items[index] < items[smallerChildIndex])
                    Swap(index, smallerChildIndex);
                else
                    break;
                index = smallerChildIndex;
            }
        }

        public override void HeapifyUp()
        {
            int index = size - 1;

            while(HasParent(index) && Parent(index) > items[index])
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }
    }

    class MaxHeap : Heap
    {
        public override void HeapifyDown()
        {
            int index = 0;
            while(HasLeftChild(index))
            {
                int largestChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index) > LeftChild(index))
                {
                    largestChildIndex = GetRightChildIndex(index);
                }

                if (items[index] < items[largestChildIndex])
                {
                    Swap(index, largestChildIndex);
                }
                else
                {
                    break;
                }
                index = largestChildIndex;
            }
        }

        public override void HeapifyUp()
        {
            int index = size - 1;

            while (HasParent(index) && Parent(index) < items[index])
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }
    }
}
