using System;

/**
 *@author Steven Guan
 */

namespace PrimeGen
{
    /// <summary>
    /// This is the Exception Class that handles invalid arguments.
    /// </summary>
    public class InvalidArgumentException: Exception
    {

        public InvalidArgumentException(string message) : base(message)
        {

        }
    }
}
