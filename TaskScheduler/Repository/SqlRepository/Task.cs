//using Ninject;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TaskScheduler.Models;

namespace TaskScheduler.Repository.SqlRepository
{
    public partial class SqlRepository 
    {
        public IQueryable<Task> Tasks
        {
            get { return Db.Tasks; }
        }

        public bool CreateTask(Task instance)
        {
            if (instance.Id != 0) {
                return false;
            }

            instance.CreationDate = DateTime.Now;
            instance.Priority = 0;
            instance.Status = "Не выполнена";

            Db.Tasks.Add(instance);
            Db.SaveChanges();
            return true;
        }

        public bool UpdateTask(Task instance)
        {
            Task cache = Db.Tasks.Find(instance.Id);

            if (cache == null) {
                return false;
            }

            //этот способ дает ошибку
            //Db.Entry(instance).State = EntityState.Modified;
            Db.Set<Task>().AddOrUpdate(instance);
            Db.SaveChanges();
            return true;
        }

        public bool RemoveTask(int idTask)
        {
            Task instance = Db.Tasks.Find(idTask);

            if (instance == null) {
                return false;
            }

            Db.Tasks.Remove(instance);
            Db.SaveChanges();
            return true;
        }
    }
}