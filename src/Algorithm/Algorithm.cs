partial class Algorithm
{
    const int ARRAY_SIZE = 15;

    public static Random r = new Random();
    public static object lockObject = new object();

    public static bool sortingComplete = false;
    public static bool visualizerComplete = false;
    
    public static CancellationTokenSource cts = new CancellationTokenSource();
    public static int sortThreads = Environment.ProcessorCount - 1;
    public static int[][] threadArrays = new int[sortThreads][];
    
    public static long iterations = 0;

    public static int[] array = Utilities.GenerateRandomArray(ARRAY_SIZE, r);
    public static int[] initialArray = (int[])array.Clone();
}
