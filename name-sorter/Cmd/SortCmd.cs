using System;
using name_sorter.Service;
using name_sorter.Utils;
using name_sorter.Helper;

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
                MessageHelper.ProcessStartMsg();

                //Vlidate the argument
                if (_args.Length != 1) throw new ArgumentOutOfRangeException("Inputted only One Argument");

                string filePath = _args[0];

                IFileReaderService fileReaderService = new FileReaderService(filePath);
                var fileInfo = new FileInfo(filePath);
                string outputPath = Path.Join(fileInfo.Directory.FullName, "sorted-names-list.txt");
                IFileOutputService fileOutputService = new FileOutputService(outputPath);

                //Read the target file
                var nameList = fileReaderService.Read();

                //Strart sorting process
                var data = Utils.Sorter.processSort(nameList);

                //Output the file
                fileOutputService.Write(data);
                Printer.nameListPrinter(data);
                MessageHelper.ProcessSuccessfullyEndMsg();
            }
            catch (Exception ex)
            {
                //Write execption to the console if any excepetion catach
                Console.WriteLine(ex);
                MessageHelper.ProcessEndWithErrMsg();
            }
        }
    }
}

