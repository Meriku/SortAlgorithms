﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithm
{
    public class ShellSort : BaseSort
    {
        /// Сортировка Шелла  

        /// Время выполнения:
        /// В лучшем случае – О(n)
        /// В среднем случае – О(nlog n)
        /// В худшем случае – О(n^2) 
        public ShellSort(int[] array)
        {
            MaxItems = 100000;
            Items = array.ToArray();
        }

        protected override void MakeSort()
        {
            var step = Items.Length / 2; 
            // Шаг равен половине длины массива (округление в меньшую сторону)

            while (step > 0)
            {

                for (int i = step; i < Items.Length; i++)
                // Выделили группу 
                {
                    int j = i;
                    while ((j >= step) && Items[j-step] > Items[j])
                    // Меняем элементы внутри группы 
                    {
                        Swap(j - step, j);
                        j -= step;
                    }
                }
                step /= 2;
                // Делим шаг на 2
            }
        }
    }
}
