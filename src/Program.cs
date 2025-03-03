using System.Diagnostics;

Stopwatch swt = new();

for (int i = 0; i < Algorithm.sortThreads; i++)
{
    Algorithm.threadArrays[i] = new int[Algorithm.array.Length];
}

Thread visualizerThread = new Thread(() => Visualizer.Start(swt));
visualizerThread.Start();

Thread[] threads = new Thread[Algorithm.sortThreads];
for (int i = 0; i < Algorithm.sortThreads; i++)
{
    int threadId = i;
    threads[i] = new Thread(() => Algorithm.Start(threadId, Algorithm.r, swt));
    threads[i].Start();
}

swt.Start();

// Join threads so that they must all finish stop before continuing.
foreach (Thread t in threads) t.Join();
visualizerThread.Join();
