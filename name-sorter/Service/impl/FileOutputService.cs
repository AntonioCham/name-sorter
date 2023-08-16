using System;
using System.Text;

namespace name_sorter.Service
{
    public class FileOutputService : IFileOutputService
    {
        private readonly string _outputPath;

        public FileOutputService(string outputPath)
        {
            _outputPath = outputPath;
        }

        //Output the sorted-name to the same path of the user input
        public void Write(List<string> data)
        {
            if (File.Exists(_outputPath))
            {
                File.Delete(_outputPath);
            }

            File.WriteAllLines(_outputPath, data, Encoding.UTF8);

            Console.WriteLine($"\nOutput File Path : {_outputPath} \n");
        }

    }
}

