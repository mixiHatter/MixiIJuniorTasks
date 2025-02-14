using System;

namespace PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SupplementDossierCommand = 1;
            const int DossierOutputCommand = 2;
            const int DeductionDossierCommand = 3;
            const int SearchBySecondNameCommand = 4;
            const int ExitCommand = 5;

            string[] fullNamesOfEmployees = new string[0];
            string[] positionsOfEmployees = new string[0];
            bool isWork = true;
            int userInput;

            while (isWork)
            {
                Console.Clear();
                Console.Write($"Добавить досье - {SupplementDossierCommand}" +
                              $"\nПоказать все досье - {DossierOutputCommand}" +
                              $"\nУдалить досье - {DeductionDossierCommand}" +
                              $"\nПоиск по фамилии - {SearchBySecondNameCommand}" +
                              $"\nВыход - {ExitCommand}\n");

                Console.Write("\nВведите команду: ");
                userInput = ReadInt(Console.ReadLine());

                switch (userInput)
                {
                    case SupplementDossierCommand:
                        AddDossier(ref fullNamesOfEmployees, ref positionsOfEmployees);
                        break;

                    case DossierOutputCommand:
                        ShowAllDossiers(fullNamesOfEmployees, positionsOfEmployees);
                        break;

                    case DeductionDossierCommand:
                        DeleteDossier(ref fullNamesOfEmployees, ref positionsOfEmployees);
                        break;

                    case SearchBySecondNameCommand:
                        LookBySecondName(fullNamesOfEmployees, positionsOfEmployees);
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;
                }
            }
        }
        
        static void AddDossier(ref string[] names, ref string[] positions)
        {
            Console.WriteLine("Введите ФИО сотрудника: ");
            names = AddData(names, Console.ReadLine());

            Console.WriteLine("Введите должность сотрудника: ");
            positions = AddData(positions, Console.ReadLine());

            Console.WriteLine($"Сотрудник добавлен:");
            ShowArrayByIndex(names.Length - 1, names, positions);
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

        static string[] AddData(string[] array, string text)
        {
            string[] arrayExtension = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                arrayExtension[i] = array[i];

            arrayExtension[array.Length] = text;

            return arrayExtension;
        }

        static void ShowAllDossiers(string[] firstArray, string[] secondArray)
        {
            Console.WriteLine("Список сотрудников:");

            if(firstArray.Length <= 0)
            {
                Console.WriteLine("Пусто");
            }
            else
            {
                for (int i = 0; i < firstArray.Length; ++i)
                    ShowArrayByIndex(i, firstArray, secondArray);
            }

            Console.ReadKey();
        }

        static void ShowArrayByIndex(int index, string[] firstArray, string[] secondArray)
        {
            Console.WriteLine($"{index + 1} | {firstArray[index]} - {secondArray[index]}");
        }

        static void LookBySecondName(string[] names, string[] positions)
        {
            bool haveFind = false;
            string SecondNameEmployee = string.Empty;

            Console.WriteLine("Поиск по фамилии:");
            string userSecondName = Console.ReadLine();
            userSecondName = userSecondName.ToLower();

            for (int i = 0; i < names.Length; i++)
            {
                SecondNameEmployee = names[i].Split()[0];
                SecondNameEmployee = SecondNameEmployee.ToLower();

                if (SecondNameEmployee == userSecondName)
                {
                    haveFind = true;
                    ShowArrayByIndex(i, names, positions);
                }
            }

            if (haveFind == false)
                Console.WriteLine("Ничего не найдено.");

            Console.ReadKey();
        }

        static void DeleteDossier(ref string[] names, ref string[] positions)
        {
            Console.WriteLine("Введите порядковый номер удаляемого досье: ");
            int index = ReadInt(Console.ReadLine());

            index--;

            if (index >= 0 && index < names.Length)
            {
                Console.WriteLine($"Успешно удалено:\n");
                ShowArrayByIndex(index, names, positions);

                names = RemoveElement(index, names);
                positions = RemoveElement(index, positions);
            }
            else
            {
                Console.WriteLine("Введен неверный номер.");
            }

            Console.ReadKey();
        }

        static string[] MoveElementToEnd(int index, string[] array)
        {
            string bufer;

            for (int i = index; i < array.Length - 1; i++)
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

            return bufer;
        }

        static string[] RemoveElement(int index, string[] array)
        {
            array = MoveElementToEnd(index, array);
            array = DeleteLastCellOfArray(array);

            return array;
        }
    }
}
