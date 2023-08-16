using System;
namespace name_sorter.Utils
{
    public static class Sorter
    {
        //Not neccessary to use Quick Sort to sort the name, can simply use the compaer in StringComparer with custom logic to sort. Just demonstrate the understanding of the QuickSort.
        public static List<string> processSort(List<string> nameList)
        {
            Console.WriteLine("Sorting Name.......");
            quickSort(nameList, 0, nameList.Count() - 1);
            return nameList;
        }

        //using recursion to quickSort the name
        public static void quickSort(List<string> nameList, int low, int high)
        {
            if (low < high)
            {
                int pivot = partition(nameList, low, high);
                quickSort(nameList, low, pivot - 1);
                quickSort(nameList, pivot + 1, high);
            }
        }

        //Arrange the name postion on the list
        public static int partition(List<String> nameList, int low, int high)
        {
            String pivot = nameList[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (comparer(nameList[j], pivot) <= 0)
                {
                    i++;
                    swap(nameList, i, j);
                }
            }

            swap(nameList, i + 1, high);
            return i + 1;
        }

        //Name Copmarer
        public static int comparer(string strA, string strB)
        {
            //Split the name in to word for compare
            string[] wordsInStrA = strA.Split(" ");
            string[] wordsInStrB = strB.Split(" ");

            //validate the name is valid or not: at least have one last name and one given name, up to 3 given name
            if (wordsInStrA.Length < 2 || wordsInStrA.Length > 4) throw new ArgumentException($"The name {strA} should have at a last name and up to 3 given name");
            if (wordsInStrB.Length < 2 || wordsInStrB.Length > 4) throw new ArgumentException($"The name {strB} should have at a last name and up to 3 given name");

            int minLen = Math.Min(wordsInStrA.Length, wordsInStrB.Length);

            //Compare the Last Name
            int lastNameResult = StringComparer.InvariantCulture.Compare(wordsInStrA[wordsInStrA.Length - 1], wordsInStrB[wordsInStrB.Length - 1]);
            if (lastNameResult != 0) return lastNameResult;

            //Compare the Given Name
            for (int i = 0; i < minLen - 1; i++)
            {
                int givenNameResult = StringComparer.InvariantCulture.Compare(wordsInStrA[i], wordsInStrB[i]);
                if (givenNameResult == 0) continue;
                else return givenNameResult;
            }

            return 0;
        }

        //Swap function for sorting
        public static void swap<T>(IList<T> list, int i, int j)
        {
            T tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
    }
}

