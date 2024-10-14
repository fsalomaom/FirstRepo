using System;

namespace FirstRepo.DataStructures.Arrays
{
    public class SalomaoArray
    {
        public int Length { get; set; }

        public List<object> Data { get; set; }

        public SalomaoArray()
        {
            this.Length = 0;
            this.Data = new List<object>();
        }

        public object Get(int index)
        {
            return this.Data[index];
        }

        public void Push(object item)
        {
            this.Data.Add(item);
            this.Length++;
        }

        public object Pop()
        {
            var lastObj = this.Data[this.Length - 1];
            this.Data.RemoveAt(this.Length - 1);
            return lastObj;
        }

        public void Delete(int index)
        {
            this.Data.RemoveAt(index);
        }

        public override string ToString()
        {
            return $"[ {string.Join(", ", this.Data)} ]";
        }

        /// <summary>
        /// Returns the text in the rever order
        /// </summary>
        public static string ReverseText(string text)
        {
            if (text.Length < 2)
                return text;

            var textArray = text.ToArray();

            var reversedText = new char[text.Length];

            string? result = string.Empty;

            int reverseIndex = 0;

            for (int i = textArray.Length - 1; i >= 0; i--)
            {
                reversedText[reverseIndex] = textArray[i];
                result += textArray[i];
                reverseIndex++;
            }

            //return string.Join("", reversedText);
            return result;
        }

        public static string ReverseText_V2(string text)
        {
            if (text.Length < 2)
                return text;

            var textCharArray = text.ToCharArray();

            var reversedCharArray = textCharArray.Reverse();

            return string.Join("", reversedCharArray);
        }

        public static List<T> MergeSortedArrays<T>(T[] first, T[] second)
        {
            var firstList = first.ToList();
            var secondList = second.ToList();

            firstList.AddRange(secondList);

            firstList.Sort();

            return firstList;
        }
    }

    public class ArrayProblems
    {
        /// <summary>
        /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target. 
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can return the answer in any order.
        /// </summary>
        public int[] TwoSum(int[] nums, int target)
        {
            int[] resultIndex = new int[2];

            if (nums.Length == 2)
            {
                resultIndex = [0, 1];

                return resultIndex.ToArray();
            }
            //Dois loops = O(n²)
            for (int i = 0; i < nums.Length; i++)
            {
                int firstNumber = nums[i];
                int secondNumber = target - firstNumber;

                //Try to find the second number
                var secondIndex = nums.ToList().FindIndex(i + 1, delegate(int x) { return x == secondNumber; });

                Console.WriteLine($"i = {i} | target = {target} | firstNum = {firstNumber} | secondNum = {secondNumber} | [] = [{string.Join(",", nums.ToList())}] | secondIndex = {secondIndex}");

                if (secondIndex > -1 && secondIndex != i)
                {
                    resultIndex = [i, secondIndex];
                }
            }

            return resultIndex;
        }

    }
}