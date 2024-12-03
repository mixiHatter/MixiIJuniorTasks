﻿using System;

namespace PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int AddDossier = 1;
            const int ShowAllDossier = 2;
            const int DeleteDossier = 3;
            const int SearchBySecondName = 4;
            const int Exit = 5;

            string[] fullNamesOfEmployees = new string[0];
            string[] positionsOfEmployees = new string[0];
            bool isWork = true;
            int userInput;

            while (isWork)
            {
                Console.Clear();
                Console.Write($"Добавить досье - {AddDossier}" +
                              $"\nПоказать все досье - {ShowAllDossier}" +
                              $"\nУдалить досье - {DeleteDossier}" +
                              $"\nИскать по фамилии - {SearchBySecondName}" +
                              $"\nВыход - {Exit}\n");

                Console.Write("\nВведите команду: ");
                userInput = ReadInt(Console.ReadLine());

                switch (userInput)
                {
                    case AddDossier:
                        Program.AddDossier(ref fullNamesOfEmployees, ref positionsOfEmployees);
                        break;

                    case ShowAllDossier:
                        ShowAllArray(fullNamesOfEmployees, positionsOfEmployees);
                        break;

                    case DeleteDossier:
                        DeleteDossierByID(ref fullNamesOfEmployees, ref positionsOfEmployees);
                        break;

                    case SearchBySecondName:
                        Program.SearchBySecondName(fullNamesOfEmployees, positionsOfEmployees);
                        break;

                    case Exit:
                        isWork = false;
                        break;
                }
            }
        }
        
        static void AddDossier(ref string[] names, ref string[] positions)
        {
            Console.WriteLine("Введите ФИО сотрудника: ");
            names = ExpandArray(names, Console.ReadLine());

            Console.WriteLine("Введите должность сотрудника: ");
            positions = ExpandArray(positions, Console.ReadLine());

            Console.WriteLine($"Сотрудник добавлен:");
            ShowArrayByID(names.Length - 1, names, positions);
            Console.ReadKey();
        }

        static int ReadInt(string text)
        {
            bool isNumber = int.TryParse(text, out int convertNumber);

            while (isNumber == false)
            {
                Console.WriteLine("Введите повторно:");

                isNumber = int.TryParse(Console.ReadLine(), out var number);
                convertNumber = number;
            }

            return convertNumber;
        }

        static string[] ExpandArray(string[] array, string text)
        {
            string[] arrayExtension = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                arrayExtension[i] = array[i];

            arrayExtension[array.Length] = text;
            array = arrayExtension;

            return array;
        }

        static void ShowAllArray(string[] firstArray, string[] secondArray)
        {
            Console.WriteLine("Список сотрудников:");

            if(firstArray.Length <= 0)
            {
                Console.WriteLine("Пусто");
            }
            else
            {
                for (int i = 0; i < firstArray.Length; ++i)
                    ShowArrayByID(i, firstArray, secondArray);
            }

            Console.ReadKey();
        }

        static void ShowArrayByID(int id, string[] firstArray, string[] secondArray)
        {
            Console.WriteLine($"{id + 1} | {firstArray[id]} - {secondArray[id]}");
        }

        static void SearchBySecondName(string[] names, string[] positions)
        {
            bool haveFind = false;
            string chekSecondName = string.Empty;

            Console.WriteLine("Поиск по имени:");
            string searchSecondName = Console.ReadLine();
            searchSecondName = searchSecondName.ToLower();

            for (int i = 0; i < names.Length; i++)
            {
                chekSecondName = names[i].Split(' ')[0];
                chekSecondName = chekSecondName.ToLower();

                if (chekSecondName == searchSecondName)
                {
                    haveFind = true;
                    ShowArrayByID(i, names, positions);
                }
            }

            if (haveFind == false)
                Console.WriteLine("Ничего не найдено.");

            Console.ReadKey();
        }

        static void DeleteDossierByID(ref string[] names, ref string[] positions)
        {
            Console.WriteLine("Введите id удаляемого досье: ");
            int id = ReadInt(Console.ReadLine());

            id--;

            if (id >= 0 && id < names.Length)
            {
                Console.WriteLine($"Успешно удалено:\n");
                ShowArrayByID(id, names, positions);

                names = RemoveElement(id, names);
                positions = RemoveElement(id, positions);
            }
            else
            {
                Console.WriteLine("Введено неверное id");
            }

            Console.ReadKey();
        }

        static string[] MoveToEndOfArray(int id, string[] array)
        {
            string bufer;

            for (int i = id; i < array.Length - 1; i++)
            {
                bufer = array[i];
                array[i] = array[i + 1];
                array[i + 1] = bufer;
            }

            return array;
        }

        static string[] DeleteLastCellOfArray(string[] array)
        {
            string[] bufer = new string[array.Length - 1];

            for (int i = 0; i < bufer.Length; i++)
                bufer[i] = array[i];

            array = bufer;

            return array;
        }

        static string[] RemoveElement(int id, string[] array)
        {
            array = MoveToEndOfArray(id, array);
            array = DeleteLastCellOfArray(array);

            return array;
        }
    }
}
