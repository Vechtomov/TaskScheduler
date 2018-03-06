using System.Data.Entity;
using System.Linq;
using TaskScheduler.Models;

namespace TaskScheduler.Repository.SqlRepository
{
    public partial class SqlRepository
    {

        public IQueryable<Goal> Goals
        {
            get { return Db.Goals; }
        }

        public bool CreateGoal(Goal instance)
        {
            if (instance.Id != 0) {
                return false;
            }

            Db.Goals.Add(instance);
            Db.SaveChanges();
            return true;
        }

        public bool UpdateGoal(Goal instance)
        {
            Goal cache = Db.Goals.Find(instance.Id);

            if (cache == null) {
                return false;
            }

            //TODO : Update fields for Goal
            Db.Entry(instance).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }

        public bool RemoveGoal(int idGoal)
        {
            Goal instance = Db.Goals.Find(idGoal);

            if (instance == null) {
                return false;
            }

            Db.Goals.Remove(instance);
            Db.SaveChanges();
            return true;
        }


    }
}