using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TaskManagerApp
{
    public class TaskManager
    {
        private const string FileName = "tasks.json";
        public List<TaskItem> Tasks { get; private set; } = new();

        public TaskManager()
        {
            LoadTasks();
        }

        public void AddTask(string description)
        {
            Tasks.Add(new TaskItem(description));
            SaveTasks();
        }

        public void ShowTasks()
        {
            if (Tasks.Count == 0)
            {
                Console.WriteLine("Нет задач.");
                return;
            }

            for (int i = 0; i < Tasks.Count; i++)
                Console.WriteLine($"{i + 1}. {Tasks[i]}");
        }

        public void MarkDone(int index)
        {
            if (index >= 0 && index < Tasks.Count)
            {
                Tasks[index].IsDone = true;
                SaveTasks();
            }
        }

        public void DeleteTask(int index)
        {
            if (index >= 0 && index < Tasks.Count)
            {
                Tasks.RemoveAt(index);
                SaveTasks();
            }
        }

        private void SaveTasks()
        {
            var json = JsonSerializer.Serialize(Tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);
        }

        private void LoadTasks()
        {
            if (File.Exists(FileName))
            {
                string json = File.ReadAllText(FileName);
                Tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
        }
    }
}

