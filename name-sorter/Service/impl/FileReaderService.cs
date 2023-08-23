using System;

namespace name_sorter.Service
{
    public class FileReaderService : IFileReaderService
    {
        private readonly string _filePath;

        public FileReaderService(string filePath)
        {
            _filePath = filePath;
        }

        //Read the file content
        public List<string> Read()
        {
            Console.WriteLine($"Reading file of {_filePath}......\n");

            if (string.IsNullOrWhiteSpace(_filePath)) throw new ArgumentException("Require file Path Input");
            if (!File.Exists(_filePath)) throw new FileNotFoundException($"{_filePath} Not found");

            Console.WriteLine($"File Path : {_filePath}\n");

            //Read the file content with trim
            return File.ReadAllLines(_filePath).Where(line => !string.IsNullOrWhiteSpace(line)).Select(line => line.Trim()).ToList();
        }
    }
}

