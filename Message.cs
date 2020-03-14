
/**
 *@author Steven Guan
 */
namespace PrimeGen
{
    /// <summary>
    /// This class contains all necessary strings/message for the program
    /// and have methods that can return those strings/message
    /// </summary>
    class Message
    {

        private const string help_message = "dotnet run <bits> <count=1>\n" +
            "\t- bits - the number of bits of the prime number, this must be a multiple of 8, and at least 32 bits.\n" +
            "\t- count - the number of prime numbers to generate, defaults to 1";

        /// <summary>
        /// Returns the help message
        /// </summary>
        /// <returns>help message</returns>
        public string gethelp()
        {
            return help_message;
        }
    }
}
