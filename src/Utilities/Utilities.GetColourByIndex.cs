partial class Utilities
{
    public static ConsoleColor GetColourByIndex(int index)
    {
        ConsoleColor[] availableColors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
        // Skip 0 to avoid black text.
        int colorIndex = (index + 1) % (availableColors.Length - 1) + 1;
        return availableColors[colorIndex];
    } 
}