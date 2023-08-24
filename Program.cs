using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_ID__RandomNumber_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartProgram();
        }
        #region Controller
        /// <summary>
        /// This method creates a text file with an ID first, and then a random number between the start number, and end number
        /// the output will look like this for example.
        /// 1, 239
        /// 2, 4933
        /// 3, 123
        /// </summary>
        /// <param name="amountOfRows"></param>
        /// <param name="startnumber"></param>
        /// <param name="endnumber"></param>
        static void getNumberFile(int amountOfRows, int startnumber, int endnumber)
        {
            Random random = new Random();
            // Specifying that the textfile should be saved under my documents
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            int numbeOfRows = amountOfRows;
            // Using streamwriter to write to the textfile.
            using (StreamWriter outPutFile = new StreamWriter(Path.Combine(docPath, "sqlNumbers.txt")))
            {
                for (int i = 0; i < numbeOfRows; i++)
                {
                    // using $ to be able to use our variables in the string.
                    outPutFile.WriteLine($"{i}, {random.Next(startnumber, endnumber)}");
                }
            }
        }
        /// <summary>
        /// Calling the methods in the right order.
        /// </summary>
        static void StartProgram()
        {
            do
            {
                Console.Clear();
                Rows();
                int rows = UserRows();
                MinNumber();
                int min = UserMinNumber();
                MaxNumber();
                int max = UserMaxNumber();
                getNumberFile(rows, min, max);
                end(rows, min, max);
            } while (Console.ReadKey().Key == ConsoleKey.Escape);
        }
        #endregion
        #region View
        /// <summary>
        /// These three methods asks the user for the desired input.
        /// </summary>
        static void Rows()
        {
            Console.WriteLine("Please enter the amount rows you want:");
        }
        static void MinNumber()
        {
            Console.WriteLine("Please enter the min number you want:");
        }
        static void MaxNumber()
        {
            Console.WriteLine("Please enter the max number you want:");
        }
        /// <summary>
        /// This method just calls the ending of the program, where the user will be able to run the program again, or close it. The paramters is needed to give
        /// feed back to the user. I placed a $ in front of the string, so that we will be able to use variables in the output.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        static void end(int rows, int min, int max)
        {
            Console.WriteLine($"Your text docuemnt is now saved under your documents, with {rows} rows, min {min} number and max {max}");
            Console.WriteLine("Press ESC to exit program or any other key to run the program again.");
        }
        #endregion
        #region Model
        /// <summary>
        /// Getting user input
        /// </summary>
        /// <returns></returns>
        static int UserRows()
        {
            int rows = int.Parse(Console.ReadLine());
            return rows;
        }
        static int UserMinNumber()
        {
            int min = int.Parse(Console.ReadLine());
            return min;
        }
        static int UserMaxNumber()
        {
            int max = int.Parse(Console.ReadLine());
            return max;
        }
        #endregion
    }
}
