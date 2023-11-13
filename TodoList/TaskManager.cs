using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace TodoList
{
    public class TaskManager
    {
        public void DisplayTasks(TodoContext context)
        {
            var tasks = context.Tasks.ToList();
            Console.WriteLine("Liste des tâches :");
            foreach (var task in tasks)
                Console.WriteLine($"ID: {task.taskId}, Nom: {task.taskName}, Description: {task.taskDescription}, Statut: {task.taskStatus}");
            Console.WriteLine();
        }
        public void CreateTask(TodoContext context, string taskName, string taskDescription)
        {
            var newTask = new Task { taskName = taskName, taskDescription = taskDescription, taskStatus = "En cours" };
            context.Tasks.Add(newTask);
            context.SaveChanges();
            Console.WriteLine("Nouvelle tâche ajoutée avec succès.\n");
        }

        public void DeleteTask(TodoContext context, int taskId)
        {
            var taskToDelete = context.Tasks.Find(taskId);
            if (taskToDelete != null)
            {
                context.Tasks.Remove(taskToDelete);
                context.SaveChanges();
                Console.WriteLine($"Tâche avec l'ID {taskId} supprimée avec succès.\n");
            }
            else
                Console.WriteLine($"Aucune tâche avec l'ID {taskId} n'a été trouvée.\n");
        }

        public void ChangeTaskStatus(TodoContext context, int taskId)
        {
            var taskToUpdate = context.Tasks.Find(taskId);

            if (taskToUpdate != null)
            {
                taskToUpdate.taskStatus = (taskToUpdate.taskStatus == "En cours") ? "Terminé" : "En cours";

                context.SaveChanges();

                Console.WriteLine($"Statut de la tâche avec l'ID {taskId} mis à jour avec succès.\n");
            }
            else
            {
                Console.WriteLine($"Aucune tâche avec l'ID {taskId} n'a été trouvée.\n");
            }
        }
        public void DisplayTodoLists(TodoContext context)
        {
            {
                var todoLists = context.TaskLists.Include(t => t.Tasks).ToList();

                Console.WriteLine("Liste des listes :");

                foreach (var todoList in todoLists)
                {
                    Console.WriteLine($"Liste ID: {todoList.ListId}, Nom: {todoList.ListName}");

                    if (todoList.Tasks.Any())
                    {
                        Console.WriteLine("Tâches dans cette liste :");
                        foreach (var task in todoList.Tasks)
                        {
                            Console.WriteLine($"    ID: {task.taskId}, Nom: {task.taskName}, Description: {task.taskDescription}, Statut: {task.taskStatus}");
                        }
                    }

                    Console.WriteLine();
                }


            }
        }

        public void CreateTodoList(TodoContext context, string listName)
        {
            var newList = new TaskList { ListName = listName, Tasks = new List<Task>() };
            context.TaskLists.Add(newList);
            context.SaveChanges();
            Console.WriteLine("Nouvelle liste créée avec succès.\n");
        }
        public void DeleteTodoList(TodoContext context, int listId)
        {
            var listToDelete = context.TaskLists.Find(listId);
            if (listToDelete != null)
            {
                context.TaskLists.Remove(listToDelete);
                context.SaveChanges();
                Console.WriteLine($"Liste avec l'ID {listId} supprimée avec succès.\n");
            }
            else
            {
                Console.WriteLine($"Aucune liste avec l'ID {listId} n'a été trouvée.\n");
            }
        }

        public void AddTaskToList(TodoContext context, int listId, string taskName, string taskDescription)
        {
            var todoList = context.TaskLists.Find(listId);
            if (todoList != null)
            {
                var newTask = new Task { taskName = taskName, taskDescription = taskDescription, taskStatus = "En cours" };
                todoList.Tasks.Add(newTask);
                context.SaveChanges();
                Console.WriteLine("Nouvelle tâche ajoutée à la liste avec succès.\n");
            }
            else
            {
                Console.WriteLine($"Aucune liste avec l'ID {listId} n'a été trouvée.\n");
            }
        }

    }
}