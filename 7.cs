using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

string pathToFile = "D:\\TestFile.txt";
Dictionary<string, List<List<string>>> cookBook = addFileToCookBook(pathToFile);

Dictionary<string, List<List<string>>> addFileToCookBook(string pathToFile)
{
    string[] linesOfText = File.ReadAllLines(pathToFile);
    Dictionary<string, List<List<string>>> cookBook = new Dictionary<string, List<List<string>>>();
    int offset = 0, totalOffset = 0;
    bool endOfText = false;
    while (!endOfText)
    {
        string dishName = linesOfText[0 + offset];
        List<List<string>> composition = new List<List<string>>();
        for (int i = 0; i < Convert.ToInt32(linesOfText[1 + offset]); i++)
        {
            List<string> ingridient = new List<string>();

            ingridient.Add("ingredientName");
            int iOFS = linesOfText[2 + offset + i].IndexOf('|');                //indexOfFirstSeparator 
            ingridient.Add(linesOfText[2 + offset + i].Substring(0, iOFS - 1));

            ingridient.Add("quantity");
            int iOSS = linesOfText[2 + offset + i].IndexOf('|', iOFS + 1);      //indexOfSecondSeparator
            ingridient.Add(linesOfText[2 + offset + i].Substring(iOFS + 2, iOSS - iOFS - 3));

            ingridient.Add("measure");
            ingridient.Add(linesOfText[2 + offset + i].Substring(iOSS + 2, linesOfText[2 + offset + i].Length - iOSS - 2));

            totalOffset++;
            composition.Add(ingridient);
        }
        totalOffset += 2;
        cookBook.Add(dishName, composition);
        if (totalOffset == linesOfText.Length)
            endOfText = true;
        totalOffset += 1;
        offset = totalOffset;
    }
    return cookBook;
}
getShopListByDishes(cookBook, new List<string> { "Омлет", "Запеченный картофель" }, 2);
Dictionary<string, List<string>> getShopListByDishes(Dictionary<string, List<List<string>>> cookBook, List<string> dishes, int personCount)
{
    Dictionary<string, List<string>> shopList = new Dictionary<string, List<string>>();
    foreach (string dish in dishes)
    {
        foreach (List<string> ingridients in cookBook[dish])
        {
            List<string> lst = ingridients.GetRange(4, 2);
            lst.Add("quantity");
            lst.Add((Convert.ToInt32(ingridients.ElementAt(3)) * personCount).ToString());
            shopList.Add(ingridients.ElementAt(1), lst);
        }
    }
    return shopList;
}