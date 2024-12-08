using System;
using System.Collections.Generic;
using System.Linq;
using TasksSorter;

namespace TaskSorter_Net5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            TaskSorter taskSorter = new TaskSorter();
            string filePath = String.Empty;
            



            while (true)
                {
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Task Sorter Menu:");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1. Load a file");
                    Console.WriteLine("2. Add a task");
                    Console.WriteLine("3. Remove a task");
                    Console.WriteLine("4. Update a task completion time");
                    Console.WriteLine("5. Save tasks to Downloads folder");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine();

                    Console.Write("Enter your choice (1-6): ");
                    string choice = Console.ReadLine();
               
                if ((!string.IsNullOrWhiteSpace(filePath) ) || choice == "1" || choice == "6")
                {
                    switch (choice)
                    {
                        case "1":
                            if(string.IsNullOrWhiteSpace(filePath))
                            {
                            Repeat:
                                Console.Write("Please enter the text file name you want to input: ");
                                filePath = Console.ReadLine();
                                if(!taskSorter.LoadTasksFromFile(filePath))
                                {
                                    goto Repeat;
                                }

                            }
                            else
                            {
                                Console.Write("Task file already loaded.");
                            }
                            break;
                        case "2":

                            Console.Write("Enter the task ID: ");
                            string taskId = Console.ReadLine();
                            Console.Write("Enter the time needed to complete the task: ");
                            int time = int.Parse(Console.ReadLine());
                            Console.Write("Enter the tasks that the task depends on (comma-separated): ");
                            string dependenciesInput = Console.ReadLine();
                            List<string> dependencies = new List<string>();
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
                        case "3":
                            Console.Write("Enter the task ID to remove: ");
                            taskId = Console.ReadLine();
                            taskSorter.RemoveTask(taskId);
                            taskSorter.SaveTasksToFile();
                            break;
                        case "4":
                            Console.Write("Enter the task ID to change time: ");
                            taskId = Console.ReadLine();
                            Console.Write("Enter the new time: ");
                            time = int.Parse(Console.ReadLine());
                            taskSorter.ChangeTaskTime(taskId, time);
                            taskSorter.SaveTasksToFile();
                            break;
                        case "5":
                            taskSorter.FindTaskSequence("Sequence.txt");
                            taskSorter.FindEarliestCommencementTimes("EarliestTimes.txt");
                            break;
                        case "6":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Error: Invalid choice. Please try again.");
                            break;
                    }

                }
                else
                {
                    Console.Write("Error: No task file loaded. Please load the task file first. \n");
                }
            }
        }
    }
}
