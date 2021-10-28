using System;

namespace Homework_4
{
    class Program
    {
        //Начало вспомогательных функций
        static int[] OneDimensionalArrayToInt(string[] input)
        {
            int[] intArray = new int[input.Length];
            int counter = 0;
            foreach (string s in input)
            {
                intArray[counter] = int.Parse(s);
                counter++;
            }
            return intArray;
        }
        static int[,] TwoDimensionalArrayToInt(string[,] input)
        {
            int[,] intArray = new int[input.GetLength(0), input.GetLength(1)];
            int mark1 = input.GetLength(1);
            int counter = 0;
            int secondCounter = 0;
            foreach (string s in input)
            {
                counter++;
                if (counter == mark1)
                {
                    intArray[secondCounter, counter - 1] = int.Parse(s);
                    counter = 0;
                    secondCounter += 1;
                }
                else
                {
                    intArray[secondCounter, counter - 1] = int.Parse(s);
                }
            }
            return intArray;
        }
        /*Конец вспомогательных функций
         *-----------------------------------------------------------------------
         *Начало функций для первой задачи
         */
        static void FirstTaskInit()
        {
            Console.Write("Введите 1 для одномерного массива, 2 для двумерного массива, 3 для массива массивов в виде таблиц. > ");
            int selector = int.Parse(Console.ReadLine());
            if (selector == 1)
            {
                Console.WriteLine("Введите одномерный массив.");
                string[] input = Console.ReadLine().Split(' ');
                FirstTask1(input);
            }
            else if (selector == 2)
            {
                Console.WriteLine("Для удобства массив уже не будет вводится с рук");
                string[,] input = new string[,] { { "1", "2", "3" }, { "16", "15", "14" } };
                FirstTask2(input);
            }
            else if (selector == 3)
            {
                Console.WriteLine("Для удобства массив уже не будет вводится с рук");
                string[,,] input = new string[,,] 
                { 
                    { 
                        { "1", "2", "3" }, 
                        { "16", "15", "14" } 
                    },
                    {
                        { "UNO", "DOS", "TRES" },
                        { "W", "F", "K" }
                    }
                };
                FirstTask3(input);
            }
        }
        static void FirstTask1(string[] array)
        {
            foreach (string s in array)
            {
                Console.Write($"{s} ");
            }
        }
        static void FirstTask2(string[,] array)
        {
            int mark = array.GetLength(1);
            int counter = 0;
            foreach (string s in array)
            {
                counter++;
                Console.Write(s + " ");
                if (counter == mark)
                {
                    Console.WriteLine();
                }
            }
        }
        static void FirstTask22(int[,] array)//Не обращайте внимания на эту функцию, она использовалась для отладки, и, если вы это читаете, то я забыл ее убрать
        {
            int mark = array.GetLength(1);
            int counter = 0;
            foreach (int s in array)
            {
                counter++;
                Console.Write(Convert.ToString(s) + " ");
                if (counter == mark)
                {
                    Console.WriteLine();
                }
            }
        }
        static void FirstTask3(string[,,] array)
        {
            int mark1 = array.GetLength(1);
            int mark2 = array.GetLength(2);
            int counter = 0;
            foreach (string s in array)
            {
                counter++;
                Console.Write(s + " ");
                if (counter % (mark1*mark2) == 0)
                {
                    counter = 0;
                    Console.WriteLine();
                    Console.WriteLine("----------------");
                }
                else if (counter % mark2 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
        /*Конец функций для первой задачи
         *-----------------------------------------------------------------------
         *Начало функций для второй задачи
         */
        static void SecondTaskInit()
        {
            Console.Write("Введите разрядность массива [1/2] > ");
            int dim = int.Parse(Console.ReadLine());
            if (dim == 1)
            {
                Console.WriteLine("Введите одномерный массив.");
                string[] input = Console.ReadLine().Split(' ');
                int[] intArray = OneDimensionalArrayToInt(input);
                SecondTask1(intArray);
            }
            else if (dim == 2)
            {
                Console.WriteLine("Для удобства массив уже не будет вводится с рук");
                string[,] input = new string[,] { { "1", "2", "3" }, { "16", "15", "14" } };
                int[,] intArray = TwoDimensionalArrayToInt(input);
                SecondTask2(intArray);
            }
        }
        static void SecondTask1(int[] array)
        {
            int max = -2147483648;
            int min = 2147483647;
            int countMin = 0;
            int countMax = 0;
            foreach (int i in array)
            {
                if (i > max)
                {
                    max = i;
                    countMax = 1;
                }
                else if (i == max)
                {
                    countMax += 1;
                }
                if (i < min)
                {
                    min = i;
                    countMin = 1;
                }
                else if (i == min)
                {
                    countMin += 1;
                }
            }
            Console.WriteLine($"min = {min}, max = {max}, countMin = {countMin}, countMax = {countMax}");
        }
        static void SecondTask2(int[,] array)
        {
            int max = -2147483648;
            int min = 2147483647;
            int countMin = 0;
            int countMax = 0;
            foreach (int i in array)
            {
                if (i > max)
                {
                    max = i;
                    countMax = 1;
                }
                else if (i == max)
                {
                    countMax++;
                }
                if (i < min)
                {
                    min = i;
                    countMin = 1;
                }
                else if (i == min)
                {
                    countMin++;
                }
            }
            Console.WriteLine($"min = {min}, max = {max}, countMin = {countMin}, countMax = {countMax}");
        }
        /*Конец функций для второй задачи
         *-----------------------------------------------------------------------
         *Начало функций для третьей задачи
         */
        static void ThirdTaskInit()
        {
            Console.Write("Введите разрядности массивов через пробел. > ");
            string[] stringDim = Console.ReadLine().Split(' ');
            int[] dim = OneDimensionalArrayToInt(stringDim);
            if (dim[0] == 1)
            {
                Console.WriteLine("Введите одномерный массив.");
                string[] input = Console.ReadLine().Split(' ');
            }
            else if (dim[0] == 2)
            {
                Console.WriteLine("Для удобства массив уже не будет вводится с рук");
                string[,] input = new string[,] { { "1", "2", "3" }, { "16", "15", "14" } };
            }
            if (dim[1] == 1)
            {
                Console.WriteLine("Введите одномерный массив.");
                string[] input2 = Console.ReadLine().Split(' ');
            }
            else if (dim[1] == 2)
            {
                Console.WriteLine("Для удобства массив уже не будет вводится с рук");
                string[,] input2 = new string[,] { { "1", "2", "3" }, { "16", "15", "14" } };
            }
            //Если я правильно понял, то это все что нужно сделать по третьему заданию
        }
        /*Конец функций для третьей задачи
         *-----------------------------------------------------------------------
         *Начало функций для четвертой задачи
         */
        static void FourthTaskInit()
        {
            Console.Write("Введите разрядности массивов через пробел. > ");
            string[] stringDim = Console.ReadLine().Split(' ');
            int[] dim = OneDimensionalArrayToInt(stringDim);
            if (dim[0] == 1)
            {
                Console.WriteLine("Введите одномерный массив.");
                string[] input1 = Console.ReadLine().Split(' ');
            }
            else
            {
                Console.WriteLine("Для удобства массив уже не будет вводится с рук");
                string[,] input1 = new string[,] { { "1", "2", "3" }, { "16", "15", "14" } };
            }
            if (dim[1] == 1)
            {
                Console.WriteLine("Введите одномерный массив.");
                string[] input2 = Console.ReadLine().Split(' ');
            }
            else
            {
                Console.WriteLine("Для удобства массив уже не будет вводится с рук");
                string[,] input2 = new string[,] { { "1", "2", "3" }, { "16", "15", "14" } };
            }
            int[] cout = new int[2];
            if (dim[0] == 1 || dim[1] == 1)
            {
                cout[0] = 1;
            }
            else if (dim[0] == 1 && dim[1] == 1)
            {
                if (input1.GetLength(1) < input2.GetLength(1))
                {
                    cout[0] = input1.GetLength(1);
                }
                else
                {
                    cout[0] = input2.GetLength(1);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите номер задачи > ");
            int selector = int.Parse(Console.ReadLine());
            switch (selector)
            {
                case 1:
                    FirstTaskInit(); break;

                case 2:
                    SecondTaskInit(); break;

                case 3:
                    ThirdTaskInit(); break;
                case 4:
                    FourthTaskInit(); break;
            }
        }
    }
}
