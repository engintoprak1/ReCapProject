using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] {1,3,7,11 };
            
            Console.WriteLine(findMissing(array));


        }
        static int findMissing(int[] nums)
        {
            int number = 0;
            for (int i = 0; i <= nums.Length; i++)
            {
                int nextNumber = nums[i] + 2;
                if (nums[i + 1] != nextNumber)
                {
                    number += nextNumber;
                    return number;
                }
                
            }
            return 1;
           

        }




    }



}
