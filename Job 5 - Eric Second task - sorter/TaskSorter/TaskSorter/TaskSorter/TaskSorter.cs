namespace TasksSorter
{
    internal class TaskSorter
    {
        private string fullPath;
        private Dictionary<string, Task> tasks;

        public TaskSorter()
        {
            tasks = new Dictionary<string, Task>();
        }

        static bool IsTextFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);

            // List of text file extensions you want to consider
            string[] textExtensions = { ".txt", ".csv", ".log" }; // Add more extensions as needed

            return textExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        public void LoadTasksFromFile(string fileName)
        {
            string filePath = "\\Tasks\\" + fileName;
            string rootDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            this.fullPath = rootDirectory + filePath;

            tasks.Clear();
            try
            {
                bool isTextFile = IsTextFile(fileName);
                if (isTextFile)
                {
                    if (File.Exists(this.fullPath))
                    {
                        string[] lines = File.ReadAllLines(this.fullPath);
                        foreach (string line in lines)
                        {
                            string[] parts = line.Split(',');
                            string taskId = parts[0].Trim();
                            int time = int.Parse(parts[1].Trim());
                            List<string> dependencies = new List<string>();
                            if (parts.Length > 2)
                            {
                                for (int i = 2; i < parts.Length; i++)
                                {
                                    dependencies.Add(parts[i].Trim());
                                }
                            }
                            Task task = new Task(taskId, time, dependencies);
                            tasks.Add(taskId, task);
                        }
                      
                    }
                    else
                    {
                        Console.WriteLine("File does not exist.\nPlease enter the text file name you want to input.");
                    }
                }
                else
                {
                    Console.WriteLine("The file is not a text file.");
                }

               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading tasks: " + ex.Message);
            }
        }

        public void AddTask(string taskId, int time, List<string> dependencies)
        {
            if (!tasks.ContainsKey(taskId))
            {
                Task task = new Task(taskId, time, dependencies);
                tasks.Add(taskId, task);
                Console.WriteLine("Task Added");
            }
            else
            {
                Console.WriteLine("Task already in collection");
            }
           
        }

        public void RemoveTask(string taskId)
        {
            if (tasks.ContainsKey(taskId))
            {
                tasks.Remove(taskId);
                Console.WriteLine("Task Removed");
            }
            else
            {
                Console.WriteLine("Task not found!");
            }
        }

        public void ChangeTaskTime(string taskId, int newTime = 0)
        {
            if(newTime > 0)
            {
                if (tasks.ContainsKey(taskId))
                {
                    Task task = tasks[taskId];
                    task.Time = newTime;
                    Console.WriteLine("Task Updated");
                }
                else
                {
                    Console.WriteLine("Task not found!");
                }
            }
            else
            {
                Console.WriteLine("Enter a correct completion time!");
            }
          
        }

        public void SaveTasksToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(this.fullPath))
                {
                    foreach (Task task in tasks.Values)
                    {
                        writer.Write(task.TaskId + ", " + task.Time);
                        if (task.Dependencies.Count > 0)
                        {
                            writer.Write(", " + string.Join(", ", task.Dependencies));
                        }
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving tasks: " + ex.Message);
            }
        }
        public void FindTaskSequence(string filePath)
        {
            string sequenceFilePath = "\\Downloads\\" + filePath; // Replace with the actual file name
            string rootDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string sequenceFullPath = rootDirectory + sequenceFilePath;
            try
            {
                List<Task> sortedTasks = TopologicalSort();
                using (StreamWriter writer = File.CreateText(sequenceFullPath))
                {
                    writer.WriteLine("Sorted Order: " + string.Join(", ", sortedTasks.Select(t => t.TaskId)));
                }

                Console.WriteLine("Task sequence saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error finding task sequence: " + ex.Message);
            }
        }

        public void FindEarliestCommencementTimes(string filePath)
        {
            string earlyCommenceFilePath = "\\Downloads\\" + filePath; // Replace with the actual file name
            string rootDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string earlyCommenceFullPath = rootDirectory + earlyCommenceFilePath;
            try
            {
                Dictionary<string, int> earliestTimes = CalculateEarliestTimes();
                using (StreamWriter writer = File.CreateText(earlyCommenceFullPath))
                {
                    foreach (Task task in tasks.Values)
                    {
                        writer.WriteLine(task.TaskId + ", " + earliestTimes[task.TaskId]);
                    }
                }

                Console.WriteLine("Earliest commencement times saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error finding earliest commencement times: " + ex.Message);
            }
        }

        private List<Task> TopologicalSort()
        {
            Dictionary<string, int> inDegree = new Dictionary<string, int>();
            Queue<Task> queue = new Queue<Task>();
            List<Task> sortedTasks = new List<Task>();

            foreach (Task task in tasks.Values)
            {
                inDegree[task.TaskId] = task.Dependencies.Count;
                if (task.Dependencies.Count == 0)
                {
                    queue.Enqueue(task);
                }
            }

            while (queue.Count > 0)
            {
                Task task = queue.Dequeue();
                sortedTasks.Add(task);

                foreach (Task dependentTask in tasks.Values)
                {
                    if (dependentTask.Dependencies.Contains(task.TaskId))
                    {
                        inDegree[dependentTask.TaskId]--;
                        if (inDegree[dependentTask.TaskId] == 0)
                        {
                            queue.Enqueue(dependentTask);
                        }
                    }
                }
            }

            return sortedTasks;
        }

        private Dictionary<string, int> CalculateEarliestTimes()
        {
            Dictionary<string, int> earliestTimes = new Dictionary<string, int>();

            foreach (Task task in tasks.Values)
            {
                earliestTimes[task.TaskId] = 0;
            }
            List<Task> sortedTasks = TopologicalSort();
            foreach (Task task in sortedTasks)
            {
                int maxDependencyTime = 0;
                int earlyCommTime = 0;
                if (task.Dependencies.Count > 0)
                {

                    foreach(var dep in task.Dependencies)
                    {
                        var objTask = tasks[dep];
                        if(maxDependencyTime < objTask.Time)
                        {
                            maxDependencyTime = objTask.Time ;
                            earlyCommTime = objTask.Time + earliestTimes[dep];
                        }
                       
                    }
                    
                    earliestTimes[task.TaskId] = earlyCommTime;
                }
            }

            return earliestTimes;
        }

    }

}
