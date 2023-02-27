// See https://aka.ms/new-console-template for more information
using Lab1_2023;
using System.Diagnostics.Metrics;

VM vm = new VM();

//FileInfo fileInfo = new FileInfo(vm.Path);
Random rand = new Random();
Page currentPage = vm.Pages[0];
//long numberOfPages = (fileInfo.Length - 2) / 528;
char toggler;
showPage(currentPage);
while(true)
{
    Console.WriteLine("Нажмите 'L' что-бы переместиться на следующую страницу, нажмите на 'K' что-бы переместиться на страницу назад");
    Console.WriteLine("Нажмите 'N' что-бы поменять случайный символ на текущей странице");
    if ((toggler = Console.ReadKey().KeyChar) == 'L' && currentPage.NumberOfPage < vm.AmountOfPages-1)
    {
        if (currentPage.NumberOfPage != 0 && (currentPage.NumberOfPage+1 != vm.AmountOfPages-1)) {
            vm.ReadNextPage();
            currentPage = vm.Pages[1];
        }
        else if(currentPage.NumberOfPage==0)
        {
            currentPage = vm.Pages[1];
        }
        else
        {
            currentPage= vm.Pages[2];
        }
    }

    if (toggler == 'K' && (currentPage.NumberOfPage != 0))
    {
        if(currentPage.NumberOfPage ==1) {
            currentPage = vm.Pages[0];        
        }
        else if(currentPage.NumberOfPage == vm.AmountOfPages-1)
        {
            currentPage= vm.Pages[1];
        }
        else
        {
            vm.ReadPreviousPage();
            currentPage = vm.Pages[1];
        }
    }
    if (toggler == 'N')
    {
        currentPage.Symbols[rand.Next(0, 127)] = 9;
        vm.RefreshDataInFile(currentPage);
    }
    showPage(currentPage);
}





void showPage(Page page)
{
    int counter = 0;
    Console.WriteLine();
    for (int g = 0; g < 8; g++)
    {
        for (int i = 0; i < 16; i++)
        {
            Console.Write(page.Symbols[counter]);
            counter++;
        }
        Console.WriteLine();
    }
    Console.WriteLine(page.NumberOfPage);
}
