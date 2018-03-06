using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskScheduler.Models;

namespace TaskScheduler.Repository.SqlRepository
{
    public partial class SqlRepository
    {
        public IQueryable<GoalAction> GoalActions
        {
            get { return Db.GoalActions; }
        }

        public bool CreateGoalAction(GoalAction instance)
        {
            if (instance.Id != 0) {
                return false;
            }

            Db.GoalActions.Add(instance);
            Db.SaveChanges();
            return true;
        }

        public bool UpdateGoalAction(GoalAction instance)
        {
            GoalAction cache = Db.GoalActions.Find(instance.Id);

            if (cache == null) {
                return false;
            }

            //TODO : Update fields for GoalAction
            Db.Entry(instance).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }

        public bool RemoveGoalAction(int idGoalAction)
        {
            GoalAction instance = Db.GoalActions.Find(idGoalAction);

            if (instance == null) {
                return false;
            }

            Db.GoalActions.Remove(instance);
            Db.SaveChanges();
            return true;
        }

    }
}