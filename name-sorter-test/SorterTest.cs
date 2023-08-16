using Microsoft.VisualBasic;
using System;
using System.Diagnostics.Metrics;

namespace name_sorter_test;

public class SorterTest
{
    [Fact]
    public void name_sort_alphabetically()
    {
        //Act
        List<string> unsortedNameList = new List<string>
        {
          "Janet Parsons",
          "Vaughn Lewis",
          "Adonis Julius Archer",
          "Shelby Nathan Yoder",
          "Marin Alvarez",
          "London Lindsey",
          "Beau Tristan Bentley",
          "Leo Gardner",
          "Hunter Uriah Mathew Clarke",
          "Mikayla Lopez",
          "Frankie Conner Ritter",
        };


        List<string> expectedResult = new List<string>
        {
            "Marin Alvarez",
            "Adonis Julius Archer",
            "Beau Tristan Bentley",
            "Hunter Uriah Mathew Clarke","" +
            "Leo Gardner",
            "Vaughn Lewis",
            "London Lindsey",
            "Mikayla Lopez",
            "Janet Parsons",
            "Frankie Conner Ritter",
            "Shelby Nathan Yoder"
        };

        name_sorter.Utils.Sorter.processSort(unsortedNameList);

        //Assert
        Assert.Equal(unsortedNameList, expectedResult);
    }
}
