using System;

namespace TaskManagerApp
{
    public class TaskItem
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public TaskItem(string description)
        {
            Description = description;
            IsDone = false;
        }

        public override string ToString()
        {
            string status = IsDone ? "[+]" : "[ ]";
            return $"{status} {Description}";
        }
    }
}

