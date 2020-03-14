using System;
using System.Numerics;

/**
 *@author Steven Guan
 */

namespace PrimeGen
{
    class PrimeGen
    {
        /// <summary>
        /// 
        ///The main method of the program. It checks the arguments that the user inputed and if everything is valid it will proceed
        ///with generating the prime numbers.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //var amount = 100;
            //var size = 128;
            //var generator = new Generator(size, amount);
            //generator.run();
            Message message = new Message();            //contains all the essentials messages(such as help message)

            try
            {
                if (args.Length < 1) throw new InvalidArgumentException("Error: Expected atleast 1 arguments");

                else if (args.Length > 2) throw new InvalidArgumentException("Error: Expected atmost 2 arguments");

                var size = Int32.Parse(args[0]);

                if (size < 32) throw new InvalidArgumentException("Error: Number of bits has to be atleast 32");
                if ((size % 8) != 0) throw new InvalidArgumentException("Error: Number of bits must be multiples of 8");

                var amount = 1;

                if (args.Length == 2)
                {
                    amount = (Int32.Parse(args[1]) > 1) ? Int32.Parse(args[1]) : 1;
                }



                var generator = new Generator(size, amount);
                generator.run();
            }

            catch (InvalidArgumentException e)
            {
                Console.WriteLine(e.Message + "\n" + message.gethelp());
            }



        }


    }




    public static class Extensions
    {
        /// <summary>
        /// This is the provided code(just changed the name)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="witnesses"></param>
        /// <returns></returns>
        public static Boolean isPrime(this BigInteger value, int witnesses = 10)
        {
            if (value <= 1) return false;
            if (witnesses <= 0) witnesses = 10;
            BigInteger d = value - 1; int s = 0;
            while (d % 2 == 0) { d /= 2; s += 1; }
            
            Byte[] bytes = new Byte[value.ToByteArray().LongLength]; BigInteger a;
            for (int i = 0; i < witnesses; i++)
            {
                do { var Gen = new System.Random(); Gen.NextBytes(bytes); a = new BigInteger(bytes); } while (a < 2 || a >= value - 2);
                BigInteger x = BigInteger.ModPow(a, d, value); if (x == 1 || x == value - 1) continue;
                for (int r = 1; r < s; r++) { x = BigInteger.ModPow(x, 2, value); if (x == 1) return false; if (x == value - 1) break; }
                if (x != value - 1) return false;
            }
            return true;
        }


    }
}
