Console.WriteLine("Table de multiplication !");
string line = "";
string separator = "";
for (int i =1; i <= 10; i++)
{
    line += i.ToString();
    // Fill the rest of the string with blank spaces until length == 5
    for (int k=i.ToString().Length; k <= 4; k++)
    {
        line += " ";
    }
    separator += "-----";
}
Console.WriteLine(line);
Console.WriteLine(separator);

for (int i=1; i <= 10; i++)
{
    line = "";
    for (int j=1; j <= 10; j++)
    {
        string res = (i * j).ToString();
        line += res;
        // Fill the rest of the string with blank spaces until length == 5
        for (int k=res.Length; k <= 4; k++)
        {
            line += " ";
        }
    }
    Console.WriteLine(line + "\n");
}
