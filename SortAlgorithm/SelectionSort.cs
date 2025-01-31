﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithm
{
    public class SelectionSort : BaseSort
    {
        /// Сортировка Выбором  

        /// Время выполнения:
        /// Всегда – О(n^2) 

        public SelectionSort(int[] array)
        {
            MaxItems = 20000;
            Items = array.ToArray();
        }
        protected override void MakeSort()
        {
            var minIndex = 0;
            for (int i = 0; i < Items.Length - 1; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < Items.Length; j++)
                {

                    if (Items[j] < Items[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (i != minIndex)
                {
                    Swap(i, minIndex);
                    SwapCount++;
                }           
            }
        }


    }
}
