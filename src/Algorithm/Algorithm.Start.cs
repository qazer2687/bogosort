using System.Diagnostics;

partial class Algorithm
{
    public static void Start(int threadId, Random rand, Stopwatch swt)
    {
        while (!cts.Token.IsCancellationRequested && !sortingComplete)
        {
            Array.Copy(array, threadArrays[threadId], array.Length);
            Shuffle(threadArrays[threadId], rand);
            Interlocked.Increment(ref iterations);
            if (IsSorted(threadArrays[threadId]))
            {
                lock (lockObject)
                {
                    if (!sortingComplete)
                    {
                        Array.Copy(threadArrays[threadId], array, array.Length);
                        // Stop stopwatch when sorted.
                        swt.Stop();
                        sortingComplete = true;
                        cts.Cancel();
                    }
                }
                break;
            }
        }
    }
}
