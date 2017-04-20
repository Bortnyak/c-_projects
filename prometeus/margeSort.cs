using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargeSort_v2
{
    class Program
    {

        static void Main(string[] args)
        {
            number = 0;
            int[] arr = new[]
    {
      11,86,232,28,8,145,588,1,307,179,77,792,693,678,481,888,574,695,624,866,467,434,907,259,130,37,25,373,214,268,108,672,371,866,863,279,22,233,336,830,374,439,144,234,360,617,244,5,566,847,476,493,56,618,202,576,179,972,898,970,119,214,786,38,71,404,420,827,814,201,865,341,358,794,492,27,290,672,899,512,792,20,807,367,792,615,616,753,663,287,99,49,334,366,711,160,652,105,162,955
    };
            //вывод на экран несортированного массива
            foreach (int item in arr)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine("\n");
            arr = Sort(arr);
            //выводим количество инверсий
            Console.WriteLine("Инверсий:" + number.ToString() + "\n");
            //вывод на экран отсортированного массива
            foreach (int item in arr)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.Read();
        }

        static double number;

        static int[] Sort(int[] buff)
        {
            //проверка длинны массива
            //если длина равна 1, то возвращаем массив, 
            //так как он не нуждается в сортировке
            if (buff.Length > 1)
            {
                //массивы для хранения половинок входящего буфера
                int[] left = new int[buff.Length / 2];
                //для проверки ошибки некорректного разбиения массива,
                //в случае если длина непарное число
                int[] right = new int[buff.Length - left.Length];

                //заполнение субмассивов данными из входящего массива
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = buff[i];
                }
                for (int i = 0; i < right.Length; i++)
                {
                    right[i] = buff[left.Length + i];
                }
                //если длина субмассивов больше еденици,
                //то мы повторно (рекурсивно) вызываем функцию разбиения массива
                if (left.Length > 1)
                    left = Sort(left);
                if (right.Length > 1)
                    right = Sort(right);
                //сортировка слиянием половинок
                buff = MergeSort(left, right);
            }
            //возврат отсортированного массива
            return buff;
        }

        static int[] MergeSort(int[] left, int[] right)
        {
            //буфер для отсортированного массива
            int[] buff = new int[left.Length + right.Length];
            //счетчики длины трех массивов
            int i = 0;  //соединенный массив
            int l = 0;  //левый массив
            int r = 0;  //правый массив
                        //сортировка сравнением элементов
            for (; i < buff.Length; i++)
            {
                //если правая часть уже использована, дальнейшее движение происходит только в левой
                //проверка на выход правого массива за пределы
                if (r >= right.Length)
                {
                    buff[i] = left[l];
                    l++;
                }
                //проверка на выход за пределы левого массива
                //и сравнение текущих значений обоих массивов
                else if (l < left.Length && left[l] < right[r])
                {
                    buff[i] = left[l];
                    l++;
                }
                //если текущее значение правой части больше
                else
                {
                    buff[i] = right[r];
                    r++;
                    //подсчет количества инверсий
                    if (l < left.Length)
                        number += left.Length - l;
                }
            }
            //возврат отсортированного массива
            return buff;
        }

        
    }
}
