using System;
using name_sorter.Service;
using name_sorter.Utils;

namespace name_sorter.Cmd
{
    public class SortCmd
    {
        private readonly string[] _args;

        public SortCmd(string[] args)
        {
            _args = args;
        }

        public void Process()
        {
            try
            {
                //Start the process
                Console.WriteLine("Process Started....... \n");

                //Vlidate the argument
                if (_args.Length != 1) throw new ArgumentOutOfRangeException("Inputted only One Argument");

                string filePath = _args[0];

                if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("Require file Path Input");
                if (!File.Exists(_args[0])) throw new FileNotFoundException($"{_args[0]} Not found");

                Console.WriteLine($"File Path : {filePath}\n");

                var fileReaderService = new FileReaderService(filePath);
                var fileInfo = new FileInfo(filePath);
                string outputPath = Path.Join(fileInfo.Directory.FullName, "sorted-names-list.txt");
                var fileOutputService = new FileOutputService(outputPath);

                //Read the target file
                var nameList = fileReaderService.Read();

                //Strart sorting process
                var data = Utils.Sorter.processSort(nameList);

                //Output the file
                fileOutputService.Write(data);
                Printer.nameListPrinter(data);
                Console.WriteLine("\nProcess finished, press any key to exit the programme.......");
            }
            catch (Exception ex)
            {
                //Write execption to the console if any excepetion catach
                Console.WriteLine(ex);
                Console.WriteLine("\nPress any Key to exit the programme.......");
            }
        }
    }
}

