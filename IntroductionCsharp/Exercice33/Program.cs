int[] alphabetCodeAscii = new int[26];
for (int i = 0; i < alphabetCodeAscii.Length; i++)
{
    alphabetCodeAscii[i] = 65 + i;
}

string tabulation = "";
for (int i = 0; i < alphabetCodeAscii.Length; i++)
{
    Console.WriteLine(tabulation + (char)alphabetCodeAscii[i]);
    tabulation += "  ";
}
