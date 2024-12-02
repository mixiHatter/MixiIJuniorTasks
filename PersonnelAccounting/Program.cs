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

            string[] FullNamesOfEmployees = new string[0];
            string[] PositionsOfEmployees = new string[0];
            bool isWork = true;
            int userInput;

            while (isWork)
            {
                Console.Clear();
                Console.Write("Добавить досье - 1" +
                              "\nПоказать все досье - 2" +
                              "\nУдалить досье - 3" +
                              "\nИскать по фамилии - 4" +
                              "\nВыход - 5\n");

                Console.Write("\nВведите команду: ");
                userInput = ReadInt(Console.ReadLine());

                switch (userInput)
                {
                    case AddDossier:
                        Console.WriteLine("Введите ФИО сотрудника: ");
                        ExpandArray(ref FullNamesOfEmployees, Console.ReadLine());

                        Console.WriteLine("Введите должность сотрудника: ");
                        ExpandArray(ref PositionsOfEmployees, Console.ReadLine());
                        break;

                    case ShowAllDossier:
                        Console.WriteLine("Список сотрудников:");
                        ShowAllArray(FullNamesOfEmployees, PositionsOfEmployees);

                        Console.ReadKey();
                        break;

                    case DeleteDossier:
                        Console.WriteLine("Введите id удаляемого досье: ");
                        userInput = ReadInt(Console.ReadLine());

                        DeleteDossierByID(userInput, ref FullNamesOfEmployees, ref PositionsOfEmployees);

                        Console.ReadKey();
                        break;

                    case SearchByLastName:
                        Console.WriteLine("Поиск по имени:");
                        SearchByName(FullNamesOfEmployees, Console.ReadLine(), out int[] findedEmpoyes);

                        ShowArrayByID(findedEmpoyes, FullNamesOfEmployees, PositionsOfEmployees);

                        Console.ReadKey();
                        break;

                    case Exit:
                        isWork = false;
                        break;
                }
            }
        }

        /// <summary>
        /// пробует перевести text в int, возвращает int, при провале просит повторно ввести text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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

        /// <summary>
        /// увеличивает массив string[] на ячейку и добавляет в неё содержимое string из text
        /// </summary>
        /// <param name="array"></param>
        /// <param name="text"></param>
        static void ExpandArray(ref string[] array, string text)
        {
            string[] arrayExtension = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                arrayExtension[i] = array[i];
            }

            arrayExtension[array.Length] = text;
            array = arrayExtension;
        }

        /// <summary>
        /// увеличивает массив int[] на ячейку и добавляет в неё содержимое int из text
        /// </summary>
        /// <param name="array"></param>
        /// <param name="text"></param>
        static void ExpandArray(ref int[] array, int text)
        {
            int[] arrayExtension = new int[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                arrayExtension[i] = array[i];
            }

            arrayExtension[array.Length] = text;
            array = arrayExtension;
        }

        /// <summary>
        /// форматированный вывод в консоль двух списков string[] вида: "id | firstArray - secondArray"
        /// </summary>
        /// <param name="firstArray"></param>
        /// <param name="secondArray"></param>
        static void ShowAllArray(string[] firstArray, string[] secondArray)
        {
            for (int i = 0; i < firstArray.Length; ++i)
            {
                Console.WriteLine($"{i + 1} | {firstArray[i]} - {secondArray[i]}");
            }
        }

        /// <summary>
        /// форматированный вывод в консоль двух списков string[] с адресами из списка int[] arrayID вида: "id | firstArray - secondArray"
        /// </summary>
        /// <param name="arrayID"></param>
        /// <param name="firstArray"></param>
        /// <param name="secondArray"></param>
        static void ShowArrayByID(int[] arrayID, string[] firstArray, string[] secondArray)
        {
            for (int i = 0; i < arrayID.Length; i++)
            {
                Console.WriteLine($"{arrayID[i] + 1} | {firstArray[arrayID[i]]} - {secondArray[arrayID[i]]}");
            }
        }
        static string ShowArrayByID(int id, string[] firstArray, string[] secondArray)
        {
            string text = id + 1 + " | " + firstArray[id] + " - " + secondArray[id];

            return text;
        }

        /// <summary>
        /// поиск 100% совпадения searchName в списке names. Возвращает список совпадений int[] findedEmployees
        /// </summary>
        /// <param name="names"></param>
        /// <param name="searchName"></param>
        /// <param name="findedEmployees"></param>
        /// <returns></returns>
        static int[] SearchByName(string[] names, string searchName, out int[] findedEmployees)
        {
            findedEmployees = new int[0];
            bool find;
            string chekName = string.Empty;
            searchName = searchName.ToLower();
            int coincides = searchName.Length;
            int countСoincides = 0;

            for (int i = 0; i < names.Length; i++)
            {
                find = false;
                chekName = names[i];
                chekName = chekName.ToLower();

                for (int j = 0; j < chekName.Length; j++)
                {
                    if (chekName[j] == searchName[0])
                    {
                        countСoincides = 0;

                        for (int k = 0; k < searchName.Length; k++)
                        {
                            if (chekName.Length > j + k)
                            {
                                if (chekName[j + k] == searchName[k])
                                    countСoincides++;
                                else if (chekName[j + k] != searchName[k])
                                    countСoincides = 0;
                            }
                        }

                        if (countСoincides == coincides)
                            find = true;
                    }
                }

                if (find)
                    ExpandArray(ref findedEmployees, i);
            }
            return findedEmployees;
        }

        static void DeleteDossierByID(int id, ref string[] names, ref string[] positions)
        {
            id--;

            if (id >= 0 && id < names.Length)
            {
                Console.WriteLine($"Успешно удалено:\n {ShowArrayByID(id, names, positions)}");

                MovingToEndOfArray(id, ref names);
                MovingToEndOfArray(id, ref positions);

                DeleteLastCellOfArray(ref names);
                DeleteLastCellOfArray(ref positions);
            }
            else
            {
                Console.WriteLine("Введено неверное id");
            }
        }

        /// <summary>
        /// сдвигает ячейку array[id] в конец массива
        /// </summary>
        /// <param name="id"></param>
        /// <param name="array"></param>
        static void MovingToEndOfArray(int id, ref string[] array)
        {
            string bufer;

            for (int i = id; i < array.Length - 1; i++)
            {
                bufer = array[i];
                array[i] = array[i + 1];
                array[i + 1] = bufer;
            }
        }

        /// <summary>
        /// Буферезует массив и укорачивает его на 1 ячейку с конца.
        /// </summary>
        /// <param name="array"></param>
        static void DeleteLastCellOfArray(ref string[] array)
        {
            string[] bufer = new string[array.Length - 1];

            for (int i = 0; i < bufer.Length; i++)
                bufer[i] = array[i];

            array = bufer;
        }
    }
}
