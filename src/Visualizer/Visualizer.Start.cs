using System.Diagnostics;

partial class Visualizer
{
    public static void Start(Stopwatch swt)
    {
        Stopwatch sw = new Stopwatch();

        long targetTicks = Stopwatch.Frequency / 60;

        do
        {
            sw.Restart();
            Console.Clear();

            TimeSpan time = swt.Elapsed;

            string elapsed = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D2}ms:{4:D2}μs",
                time.Hours,
                time.Minutes,
                time.Seconds,
                time.Milliseconds,
                time.Microseconds
            );

            string ascii = @"
██████   ██████   ██████   ██████  ███████  ██████  ██████  ████████ 
██   ██ ██    ██ ██       ██    ██ ██      ██    ██ ██   ██    ██    
██████  ██    ██ ██   ███ ██    ██ ███████ ██    ██ ██████     ██    
██   ██ ██    ██ ██    ██ ██    ██      ██ ██    ██ ██   ██    ██    
██████   ██████   ██████   ██████  ███████  ██████  ██   ██    ██    
            ";

            Console.Write($"{ascii}\n\n");

            Console.WriteLine($"Elapsed Time: {elapsed}\n");
            Console.WriteLine($"Iterations: {Algorithm.iterations}\n\n---\n");


            for (int i = 0; i < Algorithm.sortThreads; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Thread {i}: [ ");
                for (int j = 0; j < Algorithm.threadArrays[i].Length; j++)
                {
                    Console.ForegroundColor = Utilities.GetColourByIndex(Algorithm.threadArrays[i][j]);
                    Console.Write($"{Algorithm.threadArrays[i][j]} ");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("]\n\n");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nOriginal: [ ");
            for (int i = 0; i < Algorithm.initialArray.Length; i++)
            {
                Console.ForegroundColor = Utilities.GetColourByIndex(Algorithm.initialArray[i]);
                Console.Write($"{Algorithm.initialArray[i]} ");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");

            if (Algorithm.sortingComplete)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nSorted:   [ ");
                int[] sortedArray;
                lock (Algorithm.lockObject) sortedArray = (int[])Algorithm.array.Clone();
                for (int i = 0; i < sortedArray.Length; i++)
                {
                    Console.ForegroundColor = Utilities.GetColourByIndex(sortedArray[i]);
                    Console.Write($"{sortedArray[i]} ");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("]");
                visualizerComplete = true;
            }

            long elapsedTicks = sw.ElapsedTicks;
            if (elapsedTicks < targetTicks)
            {
                long sleepTime = (targetTicks - elapsedTicks) * 1000 / Stopwatch.Frequency;
                if (sleepTime > 0) Thread.Sleep((int)sleepTime);
            }

            if (Console.KeyAvailable)
            {
                Console.ReadKey(true);
                Console.WriteLine("\n\nKeypress detected, quitting...");
                Algorithm.cts.Cancel();
                visualizerComplete = true;
            }
        }
        while (!Algorithm.cts.Token.IsCancellationRequested || !visualizerComplete);
    }
}