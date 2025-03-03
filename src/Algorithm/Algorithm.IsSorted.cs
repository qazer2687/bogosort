partial class Algorithm
{
    public static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++) if (arr[i - 1] > arr[i]) return false;
        return true;
    }
}
