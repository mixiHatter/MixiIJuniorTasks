using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int AddDossier = 1;
            const int ShowAllDossier = 2;
            const int DeleteDossier = 3;
            const int SearchByLastName = 4;
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
                              $"\nИскать по фамилии - {SearchByLastName}" +
                              $"\nВыход - {Exit}\n");

                Console.Write("\nВведите команду: ");
                userInput = ReadInt(Console.ReadLine());

                switch (userInput)
                {
                    case AddDossier:
                        AddingDossier(ref fullNamesOfEmployees, ref positionsOfEmployees);
                        break;

                    case ShowAllDossier:
                        ShowAllArray(fullNamesOfEmployees, positionsOfEmployees);
                        break;

                    case DeleteDossier:
                        DeleteDossierByID(ref fullNamesOfEmployees, ref positionsOfEmployees);
                        break;

                    case SearchByLastName:
                        SearchByName(fullNamesOfEmployees, positionsOfEmployees);
                        break;

                    case Exit:
                        isWork = false;
                        break;
                }
            }
        }
        static void AddingDossier(ref string[] names, ref string[] positions)
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
            bool result = int.TryParse(text, out int convertNumber);

            while (result == false)
            {
                Console.WriteLine("Введите повторно:");

                result = int.TryParse(Console.ReadLine(), out var number);
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

        static void SearchByName(string[] names, string[] positions)
        {
            int[] findedEmployees = new int[0];
            bool find = false;
            string chekName = string.Empty;
            int countCoincides = 0;

            Console.WriteLine("Поиск по имени:");
            string searchName = Console.ReadLine();

            searchName = searchName.ToLower();
            int coincides = searchName.Length;

            for (int i = 0; i < names.Length; i++)
            {
                find = false;
                chekName = names[i];
                chekName = chekName.ToLower();

                for (int j = 0; j < chekName.Length; j++)
                {
                    if (chekName[j] == searchName[0])
                    {
                        countCoincides = 0;

                        for (int k = 0; k < searchName.Length; k++)
                        {
                            if (chekName.Length > j + k)
                            {
                                if (chekName[j + k] == searchName[k])
                                    countCoincides++;
                                else if (chekName[j + k] != searchName[k])
                                    countCoincides = 0;
                            }
                        }

                        if (countCoincides == coincides)
                            find = true;
                    }
                }

                if (find)
                    ShowArrayByID(i, names, positions);
            }

            if (find == false)
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

        static string[] MovingToEndOfArray(int id, string[] array)
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
            array = MovingToEndOfArray(id, array);
            array = DeleteLastCellOfArray(array);

            return array;
        }
    }
}
