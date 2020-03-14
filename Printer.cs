using System;
using System.Collections.Concurrent;
using System.Numerics;

/**
 *@author Steven Guan
 */

namespace PrimeGen
{
    public class Printer
    {
        private ConcurrentQueue<BigInteger> queue;                  //holds the prime number for printing
        private int max;                                            //total amount of prime number to find
        private int count;                                          //current number of prime numbers found

        /// <summary>
        /// Initializes the queue, max, and count
        /// </summary>
        /// <param name="amount"> the max amount of prime number to generate </param>
        public Printer(int amount)
        {
            queue = new ConcurrentQueue<BigInteger>();
            max = amount;
            count = 0;
        }

        /// <summary>
        /// Adds the primenumber onto the queue for printing
        /// </summary>
        /// <param name="bigInt"> the prime number</param>
        public void add(BigInteger bigInt)
        {
           
            queue.Enqueue(bigInt);
        }

     
        /// <summary>
        /// This method obtains the primenumber that is up next on the queue and prints it.
        /// Note: This happens as prime numbers are being found
        /// </summary>
        public void run()
        {
            for (; ; )
            {
                BigInteger bigInt;
                queue.TryDequeue(out bigInt);
                if (bigInt != null && bigInt != 0)
                {
                    count++;
                    Console.WriteLine($"{count}: {bigInt}\n");

                }

                //break out of the loop if the number of prime
                //number to generate has been reached
                if (count >= max)
                {
                    break;
                }
            }
        }

        public int get()
        {
            return count;
        }


    }
}
