using System;
namespace name_sorter.Utils
{
    public static class Printer
	{
        //Print the name to the console
        public static void nameListPrinter(List<string> data)
        {
            Console.WriteLine("\nSorted Name List:");

            foreach (string line in data)
            {
                Console.WriteLine(line);
            }
        }
    }
}

