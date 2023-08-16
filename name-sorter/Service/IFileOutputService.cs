using System;
namespace name_sorter.Service
{
    //Open-Closed Principle
    public interface IFileOutputService
    {
        void Write(List<string> data);
    }
}

