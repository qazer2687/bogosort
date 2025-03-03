partial class Utilities
{
    public static int[] GenerateRandomArray(int ARRAY_SIZE, Random r)
    {
        int[] randomArray = new int[ARRAY_SIZE];
        for (int i = 0; i < ARRAY_SIZE; i++)
        {
            randomArray[i] = r.Next(1, 100);
        }
        return randomArray;
    }
} 

