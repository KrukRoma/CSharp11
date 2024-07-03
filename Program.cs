using System;
using System.Linq;

namespace CSharp11
{
    class ArrayOperations
    {
        public delegate int CalculateOperation(int[] array);
        public delegate void ModifyOperation(int[] array);

        public CalculateOperation GetCalculateOperation(int operation)
        {
            switch (operation)
            {
                case 1: return CountNegativeElements;
                case 2: return CalculateSum;
                case 3: return CountPrimeNumbers;
                default: throw new ArgumentException("Invalid calculate operation");
            }
        }

        public ModifyOperation GetModifyOperation(int operation)
        {
            switch (operation)
            {
                case 1: return ReplaceNegativeWithZero;
                case 2: return SortArray;
                case 3: return MoveEvenElementsToBeginning;
                default: throw new ArgumentException("Invalid modify operation");
            }
        }

        public int CountNegativeElements(int[] array)
        {
            return array.Count(x => x < 0);
        }

        public int CalculateSum(int[] array)
        {
            return array.Sum();
        }

        public int CountPrimeNumbers(int[] array)
        {
            return array.Count(x => IsPrime(x));
        }

        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        public void ReplaceNegativeWithZero(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) array[i] = 0;
            }
        }

        public void SortArray(int[] array)
        {
            Array.Sort(array);
        }

        public void MoveEvenElementsToBeginning(int[] array)
        {
            Array.Sort(array, (x, y) => x % 2 == 0 ? -1 : 1);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, -2, 3, 4, -5, 6, 7, 8, 9 };
            ArrayOperations operations = new ArrayOperations();

            while (true)
            {
                Console.WriteLine("Choose an operation type:");
                Console.WriteLine("1. Calculate operation");
                Console.WriteLine("2. Modify operation");
                Console.WriteLine("0. Exit");

                int operationType = int.Parse(Console.ReadLine());

                if (operationType == 0)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if (operationType == 1)
                {
                    Console.WriteLine("Choose a calculate operation:");
                    Console.WriteLine("1. Count negative elements");
                    Console.WriteLine("2. Calculate sum of all elements");
                    Console.WriteLine("3. Count prime numbers");

                    int calculateOperation = int.Parse(Console.ReadLine());

                    ArrayOperations.CalculateOperation calculateDelegate = operations.GetCalculateOperation(calculateOperation);
                    int result = calculateDelegate(array);
                    Console.WriteLine($"Result: {result}");
                }
                else if (operationType == 2)
                {
                    Console.WriteLine("Choose a modify operation:");
                    Console.WriteLine("1. Replace negative elements with 0");
                    Console.WriteLine("2. Sort array");
                    Console.WriteLine("3. Move even elements to the beginning");

                    int modifyOperation = int.Parse(Console.ReadLine());

                    ArrayOperations.ModifyOperation modifyDelegate = operations.GetModifyOperation(modifyOperation);
                    modifyDelegate(array);
                    Console.WriteLine("Array modified:");
                    Console.WriteLine(string.Join(", ", array));
                }
                else
                {
                    Console.WriteLine("Invalid operation type");
                }
            }
        }
    }
}