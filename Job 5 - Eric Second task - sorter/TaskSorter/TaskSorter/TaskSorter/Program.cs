using TasksSorter;
TaskSorter taskSorter = new TaskSorter();

Console.Write("Please enter the text file name you want to input: ");
string filePath = Console.ReadLine();
taskSorter.LoadTasksFromFile(filePath);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Task Sorter Menu:");
    Console.WriteLine("1. Add a task");
    Console.WriteLine("2. Remove a task");
    Console.WriteLine("3. Update a task completion time");
    Console.WriteLine("4. Save tasks to Downloads folder");
    Console.WriteLine("5. Exit");
    Console.WriteLine();

    Console.Write("Enter your choice (1-8): ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter the task ID: ");
            string taskId = Console.ReadLine();
            Console.Write("Enter the time needed to complete the task: ");
            int time = int.Parse(Console.ReadLine());
            Console.Write("Enter the tasks that the task depends on (comma-separated): ");
            string dependenciesInput = Console.ReadLine();
            List<string> dependencies= new List<string>();
            if (!string.IsNullOrWhiteSpace(dependenciesInput) && dependenciesInput != "0")
            {
                dependencies = dependenciesInput.Split(',').Select(d => d.Trim()).ToList();
                taskSorter.AddTask(taskId, time, dependencies);
            }
            else
            {
                taskSorter.AddTask(taskId, time, dependencies);
            }
            taskSorter.SaveTasksToFile();
            break;
        case "2":
            Console.Write("Enter the task ID to remove: ");
            taskId = Console.ReadLine();
            taskSorter.RemoveTask(taskId);
            taskSorter.SaveTasksToFile();
            break;
        case "3":
            Console.Write("Enter the task ID to change time: ");
            taskId = Console.ReadLine();
            Console.Write("Enter the new time: ");
            time = int.Parse(Console.ReadLine());
            taskSorter.ChangeTaskTime(taskId, time);
            taskSorter.SaveTasksToFile();
            break;
        case "4":
            taskSorter.FindTaskSequence("Sequence.txt");
            taskSorter.FindEarliestCommencementTimes("EarliestTimes.txt");
            break;
        case "5":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}