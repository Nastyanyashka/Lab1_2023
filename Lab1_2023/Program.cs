// See https://aka.ms/new-console-template for more information
using Lab1_2023;
using System.Diagnostics.Metrics;

VM vm = new VM();

FileInfo fileInfo = new FileInfo(vm.Path);
Random rand = new Random();
long numberOfPages = (fileInfo.Length - 2) / 528;
int randNum = rand.Next(0, (int)numberOfPages);






void showPage(Page page)
{
    int counter = 0;
    for (int g = 0; g < 8; g++)
    {
        for (int i = 0; i < 16; i++)
        {
            Console.Write(page.Symbols[counter]);
            counter++;
        }
        Console.WriteLine();
    }
}
