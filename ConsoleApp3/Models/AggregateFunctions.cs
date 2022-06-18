using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    internal class AggregateFunctions
    {
        public void PerformDataAggregation(string outputGetList)
        {
            string[] tokens = outputGetList.Split("\r\n"); //using new line as delimiter
            int[] numbers = Regex.Matches(outputGetList, "(-?[0-9]+)").OfType<Match>().Select(m => int.Parse(m.Value)).ToArray();
            int count = numbers.Count();



            // find maximum, minimum of student ID in the Redirect.txt file
            int j, maximum, minimum;
            Console.Write("\n\nFinding maximum, minimum and average of the IDs: \n\n");
            maximum = numbers[0];
            minimum = numbers[0];
            for (j = 1; j < count; j++)
            {
                if (numbers[j] > maximum)
                    maximum = numbers[j];  //find maximum
                if (numbers[j] < minimum)
                    minimum = numbers[j];  // find minimum
            }
            Console.Write("\nThe total number of directories is {0}.\n", count);
            Console.Write("Maximum ID is : {0}\n", maximum);
            Console.Write("Minimum ID is : {0}\n", minimum);



            //finding directory name(s) that begin with letter(s) entered by the user
            Console.Write("\n\nFinding directory name : Starts With letter=>");
            string startletter = Console.ReadLine().ToUpper(); //reads starting letters entered by the user
            Match namematch;
            int counter = 0;
            for (j = 0; j < count; j++)
            {
                string namesearch = tokens[j];
                namematch = Regex.Match(namesearch, @"\b[A-Za-z ]+\b");
                string search = namematch.Value;
                string fullname = Regex.Replace(search, @"^ ", ""); //removes blank space infront of each name
                if (fullname.StartsWith(startletter))
                {
                    counter++;
                    Console.Write("\n{0}", fullname);
                }
            }
            Console.WriteLine("\n\nTotal Count Starts with letter : {0} = {1}", startletter, counter);



            //Console.Write("\n\nFinding directory name : Contains With letter=>");
            //string letter = Console.ReadLine().ToUpper(); //reads starting letters entered by the user
            //for (j = 0; j < count; j++)
            //{
            //    string namesearch = tokens[j];
            //    namematch = Regex.Match(namesearch, @"\b[A-Za-z ]+\b");
            //    string search = namematch.Value;
            //    string fullname = Regex.Replace(search, @"^ ", ""); //removes blank space infront of each name
            //    fullname = fullname.ToUpper();
            //    if (fullname.Contains(letter))
            //    {
            //        counter++;
            //        Console.Write("\n{0}", fullname);
            //    }
            //}
            //double sum = 0;
            //for (int i = 0; i < count; i++)
            //{
            //    sum += numbers[i];
            //}
            //double average = sum / count;
            //Console.WriteLine("\n\n\nAverage of Student ID: " + average);
        }



    }
}

