using System;
class Program
{
    static void Main()
    {
        const int size = 10000;
        Random random = new Random();
        int[] numbers = prikl(size, random, 0, 1001);

        int pop = nashel(numbers);

        if (pop != -1)
        {
            Console.WriteLine($"Мажоритарное число: {pop}");
        }
        else
        {
            Console.WriteLine("Мажоритарного числа нет.");
        }
    }

    static int[] prikl(int size, Random random, int min, int max)
    {
        int[] numbers = new int[size];
        for (int i = 0; i < size; i++)
        {
            numbers[i] = random.Next(min, max);
        }
        return numbers;
    }

    static int nashel(int[] nums)
    {
        int candidate = -1;
        int count = 0;

        foreach (var num in nums)
        {
            if (count == 0)
            {
                candidate = num;
                count = 1;
            }
            else if (num == candidate)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        count = 0;
        foreach (var num in nums)
        {
            if (num == candidate)
            {
                count++;
            }
        }

        return count > nums.Length / 2 ? candidate : -1;
    }
}