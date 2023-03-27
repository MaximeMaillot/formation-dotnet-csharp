Random random = new Random();
int[] tab = new int[10];
for (int i=0; i <  tab.Length; i++)
{
    tab[i] = random.Next(1, 51);
}
Console.WriteLine("Before sort :");
string tabulation = "";
foreach (int i in tab)
{
    Console.WriteLine(tabulation + i);
    tabulation += "\t";
}
int firstElement = tab[0];
Array.Sort(tab);
Console.WriteLine("After sort : ");
tabulation = "";
foreach (int i in tab)
{
    Console.WriteLine(tabulation + i);
    tabulation += "\t";
}
Console.WriteLine("First element before sort : " + firstElement);
int index = Array.FindIndex(tab, (element) => { return element == firstElement; });
Console.WriteLine("position after sort : " + index);
