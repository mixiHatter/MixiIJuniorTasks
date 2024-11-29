using System;

namespace PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int AddDossier = 1;
            const int WriteAllDossier = 2;
            const int DeleteDossier = 3;
            const int SearchByLastName = 4;
            const int Exit = 5;

            string[] FullNamesOfEmployees = new string[0];
            string[] PositionsOfEmployees = new string[0];

            bool isWork = true;
            int userInput;

            while (isWork)
            {
                userInput = ReadInt(Console.ReadLine());

                switch (userInput)
                {
                    case AddDossier:
                        break;
                    case WriteAllDossier:
                        break;
                    case DeleteDossier:
                        break;
                    case SearchByLastName:
                        break;
                    case Exit:
                        isWork = false;
                        break;
                }
            }
        }

        static int ReadInt(string text)
        {
            bool result = int.TryParse(text, out var convertNumber);

            while (result == false)
            {
                Console.WriteLine("Введите повторно:");

                result = int.TryParse(Console.ReadLine(), out var number);
                convertNumber = number;
            }

            return convertNumber;
        }
    }
}
