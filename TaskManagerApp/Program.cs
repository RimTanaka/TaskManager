using System;
using TaskManagerApp;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        TaskManager manager = new();

        while (true)
        {
            Console.WriteLine("\n\t Менеджер задач");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Показать все задачи");
            Console.WriteLine("3. Отметить задачу как выполненную");
            Console.WriteLine("4. Удалить задачу");
            Console.WriteLine("5. Выйти");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Console.Write("Введите описание задачи: ");
                    string desc = Console.ReadLine() ?? "";
                    manager.AddTask(desc);
                    Console.WriteLine("Задача добавлена!");
                    break;

                case "2":
                    Console.WriteLine("\nСписок задач:");
                    manager.ShowTasks();
                    break;

                case "3":
                    Console.Write("Введите номер задачи для отметки: ");
                    if (int.TryParse(Console.ReadLine(), out int doneIndex))
                        manager.MarkDone(doneIndex - 1);
                    break;

                case "4":
                    Console.Write("Введите номер задачи для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out int delIndex))
                        manager.DeleteTask(delIndex - 1);
                    break;

                case "5":
                    Console.WriteLine("Сохранение и выход...");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}

