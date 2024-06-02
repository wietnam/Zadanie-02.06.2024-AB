using System;
using System.Collections.Generic;

public class LeaderFinder
{
    public static int? FindLeader(int[] array)
    {
        int candidate = FindCandidate(array);
        return IsLeader(array, candidate) ? (int?)candidate : null;
    }

    private static int FindCandidate(int[] array)
    {
        int candidate = array[0];
        int count = 1;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == candidate)
            {
                count++;
            }
            else
            {
                count--;
            }

            if (count == 0)
            {
                candidate = array[i];
                count = 1;
            }
        }

        return candidate;
    }

    private static bool IsLeader(int[] array, int candidate)
    {
        int count = 0;
        foreach (int number in array)
        {
            if (number == candidate)
            {
                count++;
            }
        }
        return count > array.Length / 2;
    }

    public static void Main(string[] args)
    {
        int[] array1 = { 1, 3, 2, 3, 3, 3, 1, 3, 2 };
        int[] array2 = { 3, 4, 1, 1, 1, 1, 3, 2 };

        int? leader1 = FindLeader(array1);
        int? leader2 = FindLeader(array2);

        Console.WriteLine(leader1.HasValue ? $"Liderem jest: {leader1.Value}" : "Nie ma lidera");
        Console.WriteLine(leader2.HasValue ? $"Liderem jest: {leader2.Value}" : "Nie ma lidera");
    }
}
