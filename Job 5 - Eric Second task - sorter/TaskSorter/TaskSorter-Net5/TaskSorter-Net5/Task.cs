using System.Collections.Generic;

namespace TasksSorter
{
    internal class Task
    {
        public string TaskId { get; set; }
        public int Time { get; set; }
        public List<string> Dependencies { get; set; }

        public Task(string taskId, int time, List<string> dependencies)
        {
            TaskId = taskId;
            Time = time;
            Dependencies = dependencies;
        }
    }
}
