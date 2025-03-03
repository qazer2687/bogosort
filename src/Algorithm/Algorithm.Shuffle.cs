partial class Algorithm
{
    private static void Shuffle(int[] arr, Random r)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int j = r.Next(i + 1);
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
    }
}

