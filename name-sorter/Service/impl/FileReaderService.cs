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
            Console.WriteLine("Reading file ......\n");
            //Read the file content with trim
            return File.ReadAllLines(_filePath).Where(line => !string.IsNullOrWhiteSpace(line)).Select(line => line.Trim()).ToList();
        }
    }
}

