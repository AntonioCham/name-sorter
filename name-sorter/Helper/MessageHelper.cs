using System;
namespace name_sorter.Helper
{
	public class MessageHelper
	{
		public MessageHelper()
		{

		}

		public static void ProcessStartMsg()
		{
            Console.WriteLine("Process Started....... \n");
        }

		public static void ProcessSuccessfullyEndMsg()
		{
            Console.WriteLine("\nProcess run successfully. Press any key to exit the programme.......");
            Console.ReadKey();
        }

        public static void ProcessEndWithErrMsg()
        {
            Console.WriteLine("\nProcess end with error. Press any Key to exit the programme.......");
            Console.ReadKey();
        }
    }
}

