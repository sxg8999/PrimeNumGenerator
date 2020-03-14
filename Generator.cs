using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;

/**
 *@author Steven Guan
 */
namespace PrimeGen
{
    /// <summary>
    /// This is the class that will generate all the prime numbers given the bit size and amount of
    /// prime number to generate.
    /// </summary>
    class Generator
    {
        private int size;                       //the bit size
        private int amount;                     //the amount of prime number to generate
        

        /// <summary>
        ///Initializes the size and amount 
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="a"></param>
        public Generator(int s, int a)
        {
            size = s;
            amount = a;
        }

        /// <summary>
        /// This method generates the prime numbers and will stop generating the moment the max
        /// amount to generate is reached.
        /// </summary>
        public void run()
        {
            
            var printer = new Printer(amount);  //The Printer class prints the prime number as it is generated.


            //create a task that prints the prime number================
            var printTask = new Task(() =>
            {
                printer.run();                  
            });
            printTask.Start();
            //==========================================================


            var time = new Stopwatch();
            var count = 0;
            object lockobj = new object();
            

            Console.WriteLine($"BitLength: {size} bits");
            time.Start();

            //Generates the prime number in parallel
            Parallel.For(0, amount, (i,state) =>
            {
                for (; ; )
                {
                    var num = new BigInteger(Random.generateBytes(size / 8));

                    //if (num < 0) continue;

                    if (num.isPrime() == true)
                    {
                        //lock (lockobj)
                        //{
                        printer.add(num);       //add the prime number to the printer queue.
                        count = count + 1;
                        break;
                            //if (count == amount)
                            //{
                            //    time.Stop();
                            //    Console.WriteLine($"Time to Generate: {time.Elapsed}");
                            //    Environment.Exit(0);
                            //    state.Stop();
                            //}
                        //}
                        
                        

                    }
                    
                }
            });

            TimeSpan ts = time.Elapsed;
            printTask.Wait();
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:0000000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("Time to Generate: {0}", elapsedTime);


            //time.Stop();
            
            //Console.WriteLine($"Time to Generate: {time.Elapsed}");
        }
    }
}
