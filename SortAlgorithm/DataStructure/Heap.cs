﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithm
{
    public class Heap : IEnumerable
    // MinHeap
    {
        private int[] _elements;
        private int _size;
        public int SwapCounts;

        public Heap(int[] array)
        {
            SwapCounts = 0;

            _elements = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                Add(array[i]);
            }
        }

        private int GetLeftChildIndex(int elementIndex)
        {
            return 2 * elementIndex + 1;
        }
        private int GetRightChildIndex(int elementIndex)
        {
            return 2 * elementIndex + 2;
        }
        private int GetParentIndex(int elementIndex)
        {
            return (elementIndex - 1) / 2;
        }
        private bool HasLeftChild(int elementIndex)
        {
            return GetLeftChildIndex(elementIndex) < _size;
        }
        private bool HasRightChild(int elementIndex)
        {
            return GetRightChildIndex(elementIndex) < _size;
        }
        private bool IsRoot(int elementIndex)
        {
            return elementIndex == 0;
        }
        private int GetLeftChild(int elementIndex)
        {
            return _elements[GetLeftChildIndex(elementIndex)];
        }
        private int GetRightChild(int elementIndex)
        {
            return _elements[GetRightChildIndex(elementIndex)];
        }
        private int GetParent(int elementIndex)
        {
            return _elements[GetParentIndex(elementIndex)];
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            SwapCounts++;
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        public int Pop()
        {
            if (_size == 0) 
            {
                throw new IndexOutOfRangeException();
            }

            var result = _elements[0];
            _elements[0] = _elements[_size - 1];
            _size--;

            ReCalculateDown();

            return result;
        }

        public void Add(int element)
        {
            if (_size == _elements.Length)
            {
                throw new IndexOutOfRangeException();
            }
     
            _elements[_size] = element;
            _size++;

            ReCalculateUp();
        }

        private void ReCalculateDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (_elements[smallerIndex] >= _elements[index])
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        private void ReCalculateUp()
        {
            var index = _size - 1;
            while (!IsRoot(index) && _elements[index] < GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }  

        public IEnumerator GetEnumerator()
        {
            while (_size > 0)
            {
                yield return Pop();
            }
        }
    }
}
