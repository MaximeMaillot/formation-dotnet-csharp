// Number of sizes
int sizeLength = 3;
// Number of ranges in a size
int sizeRangeLength = 4;

(int minWeight, int maxWeight, int minHeight, int maxHeight)[,] sizes = new (int, int, int, int)[sizeLength, sizeRangeLength];

// minWeight of a range is defined at index : 0
// maxWeight of a range is defined at index : sizeRangeLength - 1
// minHeight of a range is defined at index : sizeRangeLength - 1
// maxHeight of a range is defined at index : 0
sizes[0, 0] = (43, 47, 145, 169);
sizes[0, 1] = (43, 53, 145, 166);
sizes[0, 2] = (43, 59, 145, 163);
sizes[0, 3] = (43, 65, 145, 160);

sizes[1, 0] = (48, 53, 169, 178);
sizes[1, 1] = (54, 59, 166, 175);
sizes[1, 2] = (60, 65, 163, 172);
sizes[1, 3] = (66, 71, 160, 169);

sizes[2, 0] = (54, 59, 178, 183);
sizes[2, 1] = (66, 65, 175, 183);
sizes[2, 2] = (66, 71, 172, 183);
sizes[2, 3] = (72, 77, 163, 183);

Console.Write("Taille : ");
int length = Convert.ToInt32(Console.ReadLine());
Console.Write("Poids : ");
int weight = Convert.ToInt32(Console.ReadLine());

// Check if in boundary of all sizes
if (weight < sizes[0, 0].minWeight || length < sizes[0, sizeRangeLength - 1].minHeight || weight > sizes[sizeLength - 1, sizeRangeLength - 1].maxWeight || length > sizes[sizeLength - 1, 0].maxHeight) {
    Console.WriteLine("Taille pas pris en compte");
} 
else
{
    bool found = false;
    for (int i = 0; i < sizeLength; i++)
    {
        // Check if in boundary of the size
        if (weight < sizes[i, 0].minWeight || weight > sizes[i, sizeRangeLength - 1].maxWeight || length < sizes[i, sizeRangeLength - 1].minHeight || length > sizes[i, 0].maxHeight)
        {
            continue;
        }
        // Check all interval in taille
        for (int j = 0; j < sizeRangeLength; j++)
        {
            if (weight >= sizes[i, j].minWeight && weight <= sizes[i, j].maxWeight && length >= sizes[i, j].minHeight && length <= sizes[i, j].maxHeight)
            {
                Console.WriteLine("Vous êtes de taille : " + (i+1));
                found = true;
                break;
            }
        }
        // exit loop early if already found
        if (found)
        {
            break;
        }
    }
}
