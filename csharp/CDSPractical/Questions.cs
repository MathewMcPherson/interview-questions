﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace CDSPractical {
    public class Questions {
        /// <summary>
        /// Given an enumerable of strings, attempt to parse each string and if 
        /// it is an integer, add it to the returned enumerable.
        /// 
        /// For example:
        /// 
        /// ExtractNumbers(new List<string> { "123", "hello", "234" });
        /// 
        /// ; would return:
        /// 
        /// {
        ///   123,
        ///   234
        /// }
        /// </summary>
        /// <param name="source">An enumerable containing words</param>
        /// <returns></returns>
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> source) {
            List<int> returnitems = new List<int>();
            List<string> listsource = (List<string>)source;
            //loop each value in the list
            for (int i=0; i<listsource.Count; i++)
            {
                bool validnumber = true;
                String currentItem = listsource.ToArray().GetValue(i).ToString();

                //check is number
                char[] chars = currentItem.ToCharArray();                
                byte[] values = System.Text.Encoding.ASCII.GetBytes(chars);
                foreach (int item in values)
                {
                    if (item > 57 || item < 48)
                    {
                        validnumber = false;
                    }
                }
                if (validnumber)
                {
                    returnitems.Add(int.Parse(currentItem));
                }
                listsource.GetEnumerator().MoveNext();
            }
            return (IEnumerable<int>) returnitems;
        }

        /// <summary>
        /// Given two enumerables of strings, find the longest common word.
        /// 
        /// For example:
        /// 
        /// LongestCommonWord(
        ///     new List<string> {
        ///         "love",
        ///         "wandering",
        ///         "goofy",
        ///         "sweet",
        ///         "mean",
        ///         "show",
        ///         "fade",
        ///         "scissors",
        ///         "shoes",
        ///         "gainful",
        ///         "wind",
        ///         "warn"
        ///     },
        ///     new List<string> {
        ///         "wacky",
        ///         "fabulous",
        ///         "arm",
        ///         "rabbit",
        ///         "force",
        ///         "wandering",
        ///         "scissors",
        ///         "fair",
        ///         "homely",
        ///         "wiggly",
        ///         "thankful",
        ///         "ear"
        ///     }
        /// );
        /// 
        /// ; would return "wandering" as the longest common word.
        /// </summary>
        /// <param name="first">First list of words</param>
        /// <param name="second">Second list of words</param>
        /// <returns></returns>
        public string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second) {            
            String currentLongestString="", currentString="";
            List<string> listfirst = (List<string>)first;
            List<string> listsecond = (List<string>)second;

            for (int i=0; i<listfirst.Count; i++)
            {
                currentString = listfirst.ToArray().GetValue(i).ToString();
                if (listsecond.Contains(currentString))
                {
                    if (currentString.Length > currentLongestString.Length)
                    {
                        currentLongestString = currentString;
                    }
                }
            }
            return currentLongestString;
        }

        /// <summary>
        /// Write a method that converts kilometers to miles, given that there are
        /// 1.6 kilometers per mile.
        /// 
        /// For example:
        /// 
        /// DistanceInMiles(16.00);
        /// 
        /// ; would return 10.00;
        /// </summary>
        /// <param name="km">distance in kilometers</param>
        /// <returns></returns>
        public double DistanceInMiles(double km) {
            return km / 1.6;
        }

        /// <summary>
        /// Write a method that converts miles to kilometers, give that there are
        /// 1.6 kilometers per mile.
        /// 
        /// For example:
        /// 
        /// DistanceInKm(10.00);
        /// 
        /// ; would return 16.00;
        /// </summary>
        /// <param name="miles">distance in miles</param>
        /// <returns></returns>
        public double DistanceInKm(double miles) {
            return miles * 1.6;
        }

        /// <summary>
        /// Write a method that returns true if the word is a palindrome, false if
        /// it is not.
        /// 
        /// For example:
        /// 
        /// IsPalindrome("bolton");
        /// 
        /// ; would return false, and:
        /// 
        /// IsPalindrome("Anna");
        /// 
        /// ; would return true.
        /// 
        /// Also complete the related test case for this method.
        /// </summary>
        /// <param name="word">The word to check</param>
        /// <returns></returns>
        public bool IsPalindrome(string word) {
            char[] chararray = word.ToCharArray();
            string reverseword = "";

            for (int i=chararray.Length; i>=0; i--)
            {
                reverseword += chararray[i];
            }

            if (word.Equals(reverseword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Write a method that takes an enumerable list of objects and shuffles
        /// them into a different order.
        /// 
        /// For example:
        /// 
        /// Shuffle(new List<string>{ "one", "two" });
        /// 
        /// ; would return:
        /// 
        /// {
        ///   "two",
        ///   "one"
        /// }
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<object> Shuffle(IEnumerable<object> source) {
            List<string> listsource = (List<string>)source;
            listsource.Reverse();

            return (IEnumerable<object>) listsource;
            
        }

        /// <summary>
        /// Write a method that sorts an array of integers into ascending
        /// order - do not use any built in sorting mechanisms or frameworks.
        /// 
        /// Complete the test for this method.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public int[] Sort(int[] source, int currentIndex=1, int movingIndex=1) {
            int currentItem = source[currentIndex];
            if (currentIndex==0)
            {
                if (movingIndex < source.Length)
                {
                    return Sort(source, movingIndex + 1, movingIndex + 1);
                } else
                {
                    return source;
                }
            } else
            {
                int comparitor = source[currentIndex - 1];
                if (comparitor > currentItem)
                {
                    source[currentIndex] = comparitor;
                    source[currentIndex - 1] = currentItem;
                    return Sort(source, currentIndex - 1, movingIndex);
                }
                else
                {
                    return Sort(source, currentIndex + 1, movingIndex + 1);
                }
            }

            return source;
        }    

        /// <summary>
        /// Each new term in the Fibonacci sequence is generated by adding the 
        /// previous two terms. By starting with 1 and 2, the first 10 terms will be:
        ///
        /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        ///
        /// By considering the terms in the Fibonacci sequence whose values do 
        /// not exceed four million, find the sum of the even-valued terms.
        /// </summary>
        /// <returns></returns>
        public int FibonacciSum() {
            List<int> fibonacci = new List<int>() { 1, 2 };
            int[] fibarray;
            int nextnum;
            int sum = 2;
            do
            {
                fibarray = fibonacci.ToArray();
                nextnum = (int)fibarray.GetValue(fibarray.Length - 2) + (int)fibarray.GetValue(fibarray.Length-1);
                if (nextnum < 4000000)
                {
                    fibonacci.Add(nextnum);
                    if ((double)nextnum % 2 == 0)
                    {
                        sum += nextnum;
                    }
                }
            } while (nextnum < 4000000);

            return sum;
        }

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        /// 
        /// This method is currently broken, fix it so that the tests pass.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GenerateList() {
            var ret = new List<int>();
            var numThreads = 2;

            Thread[] threads = new Thread[numThreads];
            for (var i = 0; i < numThreads; i++) {
                threads[i] = new Thread(() => {
                    var complete = false;
                    while (!complete) {                        
                        var next = ret.Count + 1;
                        //Thread.Sleep(new Random().Next(1, 10));
                        
                        if (next <= 100) {
                            ret.Add(next);
                        }

                        if (ret.Count >= 100) {
                            complete = true;
                        }
                    }                    
                });
                threads[i].Start();
            }

            for (var i = 0; i < numThreads; i++) {
                threads[i].Join();
            }

            return ret;
        }
    }
}
