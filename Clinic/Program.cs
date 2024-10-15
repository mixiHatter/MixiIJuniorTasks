using System;
using System.Collections;

namespace Clinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countQueue;
            int queueTime;
            int consultationTimeMinutes = 10;
            int minInHour = 60;
            int hour;
            int minutes;

            Console.Write("Сколько людей в очереди:");
            countQueue = Convert.ToInt32(Console.ReadLine());
            queueTime = countQueue * consultationTimeMinutes;
            hour = queueTime / minInHour;
            minutes = queueTime % minInHour;
            Console.WriteLine($"В очереди нужно отстоять: {hour} часов, {minutes} минут.");
        }
    }
}
