using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ToDoContext context)
        {
            if (context.Tasks.Any())
            {
                return;
            }
            var tasks = new TaskModel[] {
                new TaskModel { Guid = Guid.NewGuid(), Title = "Task1", Priority = "0", StartDate = DateTime.Now, EndDate = DateTime.Now, Complete = "0" },
                new TaskModel { Guid = Guid.NewGuid(), Title = "Task2", Priority = "1", StartDate = DateTime.Now, EndDate = DateTime.Now, Complete = "1" },
                new TaskModel { Guid = Guid.NewGuid(), Title = "Task3", Priority = "2", StartDate = DateTime.Now, EndDate = DateTime.Now, Complete = "0" },
                new TaskModel { Guid = Guid.NewGuid(), Title = "Task4", Priority = "0", StartDate = DateTime.Now, EndDate = DateTime.Now, Complete = "0" },
                new TaskModel { Guid = Guid.NewGuid(), Title = "Task5", Priority = "1", StartDate = DateTime.Now, EndDate = DateTime.Now, Complete = "1" },
                new TaskModel { Guid = Guid.NewGuid(), Title = "Task6", Priority = "0", StartDate = DateTime.Now, EndDate = DateTime.Now, Complete = "0" },
                new TaskModel { Guid = Guid.NewGuid(), Title = "Task7", Priority = "1", StartDate = DateTime.Now, EndDate = DateTime.Now, Complete = "1" }
            };
            context.Tasks.AddRange(tasks);
            context.SaveChanges();
        }
    }
}
