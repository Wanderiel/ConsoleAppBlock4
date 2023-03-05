using System;

namespace ConsoleAppB4P1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddDossierCommand = "1";
            const string PrintDossiersCommand = "2";
            const string RemoveDossierCommand = "3";
            const string SearchDossiersCommand = "4";
            const string ExitCommand = "5";

            bool isWork = true;

            string userInput;
            string[] surnames = Array.Empty<string>();
            string[] posts = Array.Empty<string>();

            while (isWork)
            {
                Console.Clear();

                Console.WriteLine($"{AddDossierCommand}. Добавить досье" +
                    $"\n{PrintDossiersCommand}. Распечатать все досье" +
                    $"\n{RemoveDossierCommand}. Удалить досье" +
                    $"\n{SearchDossiersCommand}. Найти все досье по фамилии" +
                    $"\n{ExitCommand}. Выйти из программы" +
                    $"\n");

                userInput = Console.ReadLine();

                Console.Clear();

                switch (userInput)
                {
                    case AddDossierCommand:
                        AddDossier(ref surnames, ref posts);
                        break;

                    case PrintDossiersCommand:
                        PrintDossiers(surnames, posts);
                        break;

                    case RemoveDossierCommand:
                        RemoveDossier(ref surnames, ref posts);
                        break;

                    case SearchDossiersCommand:
                        Search(surnames, posts);
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;

                    default:
                        Console.Write("Неверная команда");
                        break;
                }

                Console.ReadKey();
            }

            Console.Write("Работа завершена, всего доброго.");

            Console.ReadKey();
        }

        static private void AddDossier(ref string[] surnames, ref string[] posts)
        {
            Console.WriteLine("Инициализация процедуры добавления новой записи...");
            Thread.Sleep(500);

            Console.Write("Введите ФИО: ");
            surnames = AddRecord(surnames, Console.ReadLine());

            Console.Write("Введите должность: ");
            posts = AddRecord(posts, Console.ReadLine());

            Console.WriteLine("\nПодождите, я записываю...");
            Thread.Sleep(1000);

            Console.WriteLine($"\nДобавлена новая запись: {surnames[^1]} - {posts[^1]}");
        }

        static private string[] AddRecord(string[] array, string record)
        {
            string[] newArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];

            newArray[^1] = record;

            return newArray;
        }

        static void PrintDossiers(string[] surnames, string[] posts)
        {
            const int RecordLength = 39;
            const int IdLength = 3;
            const int SurnameLength = 18;
            const int PostLength = 11;

            char symbol = '=';

            Console.WriteLine(new string(symbol, RecordLength));

            if (surnames.Length > 0)
            {
                for (int i = 0; i < surnames.Length; i++)
                {
                    Console.WriteLine($"|{i,IdLength}" +
                        $" |{surnames[i],SurnameLength}" +
                        $" |{posts[i],PostLength} |");
                }
            }
            else
            {
                Console.WriteLine($"{"Записей не найдено",RecordLength}");
            }

            Console.WriteLine(new string(symbol, RecordLength));
        }

        static private void RemoveDossier(ref string[] surnames, ref string[] posts)
        {
            string userInput;

            Console.WriteLine("Введите Id досье для удаления: ");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id) &&
                id >= 0 && id < surnames.Length)
            {
                surnames = RemoveRecord(surnames, id);
                posts = RemoveRecord(posts, id);

                Console.WriteLine("\nЗапись успешно удалена...");
            }
            else
            {
                Console.Write("\nВведён неверный id досье...");
            }
        }

        static string[] RemoveRecord(string[] array, int id)
        {
            string[] newArray = new string[array.Length - 1];

            for (int i = 0; i < id; i++)
                newArray[i] = array[i];

            for (int i = id; i < newArray.Length; i++)
                newArray[i] = array[i + 1];

            return newArray;
        }

        private static void Search(string[] surnames, string[] posts)
        {
            const int IdLength = 3;
            const int SurnameLength = 18;
            const int PostLength = 11;

            int recordLength = 39;
            char symbol = '=';

            string userInput;

            Console.WriteLine("Введите фамилию для поиска: ");
            userInput = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"найденые записи по фамилии {userInput}:\n" +
                new string(symbol, recordLength));

            for (int i = 0; i < surnames.Length; i++)
                if (surnames[i].Split()[0] == userInput)
                    Console.WriteLine($"|{i,IdLength}" +
                        $" |{surnames[i],SurnameLength}" +
                        $" |{posts[i],PostLength} |");

            Console.WriteLine(new string(symbol, recordLength));
        }
    }
}