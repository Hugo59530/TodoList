using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TodoContext())
            {
                var taskManager = new TaskManager();
                context.Database.EnsureCreated();

                bool exitRequested = false;

                while (!exitRequested)
                {
                    Console.Clear();
                    taskManager.DisplayTodoLists(context);

                    Console.WriteLine("Bonjour Merci de choisir une option :\n\t[1] - Créer une liste\n\t[2] - Supprimer une liste et ses tâches\n\t[3] - Ajouter une tâche à une liste\n\t[4] - Afficher les tâches\n\t[5] - Modifier le status d'une tache\n\t[0] - Quitter");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("Nom de la liste : ");
                            string listName = Console.ReadLine();
                            taskManager.CreateTodoList(context, listName);
                            break;

                        case "2":
                            Console.Write("ID de la liste à supprimer : ");
                            if (int.TryParse(Console.ReadLine(), out int listIdToDelete))
                            {
                                taskManager.DeleteTodoList(context, listIdToDelete);
                            }
                            else
                            {
                                Console.WriteLine("ID de la liste invalide.");
                            }
                            break;

                        case "3":
                            Console.Write("ID de la liste à laquelle ajouter une tâche : ");
                            if (int.TryParse(Console.ReadLine(), out int listIdToAddTask))
                            {
                                Console.Write("Nom de la tâche : ");
                                string taskName = Console.ReadLine();
                                Console.Write("Description de la tâche : ");
                                string taskDescription = Console.ReadLine();
                                taskManager.AddTaskToList(context, listIdToAddTask, taskName, taskDescription);
                            }
                            else
                            {
                                Console.WriteLine("ID de la liste invalide.");
                            }
                            break;

                        case "4":
                            Console.Clear();
                            taskManager.DisplayTasks(context);
                            Console.WriteLine("Appuyez sur une touche pour revenir au menu principal.");
                            Console.ReadKey();
                            break;

                        case "5":
                            Console.Write("ID de la tache dont vous voulez changer le status : ");
                            if (int.TryParse(Console.ReadLine(), out int IdToStatusChange))
                            {
                                taskManager.ChangeTaskStatus(context, IdToStatusChange);
                            }
                            else
                            {
                                Console.WriteLine("ID de la liste invalide.");
                            }
                            break;
                        case "0":
                            exitRequested = true;
                            break;

                        default:
                            Console.WriteLine("Option invalide.");
                            break;
                    }
                }
            }
        }
    }
}