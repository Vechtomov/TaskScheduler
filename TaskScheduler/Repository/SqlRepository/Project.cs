using System.Data.Entity;
using System.Linq;
using TaskScheduler.Models;

namespace TaskScheduler.Repository.SqlRepository
{
    public partial class SqlRepository
    {

        public IQueryable<Project> Projects
        {
            get { return Db.Projects; }
        }

        public bool CreateProject(Project instance)
        {
            if (instance.Id != 0) {
                return false;
            }

            Db.Projects.Add(instance);
            Db.SaveChanges();
            return true;
        }

        public bool UpdateProject(Project instance)
        {
            Project cache = Db.Projects.Find(instance.Id);

            if (cache == null) {
                return false;
            }

            //TODO : Update fields for Project
            Db.Entry(instance).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }

        public bool RemoveProject(int idProject)
        {
            Project instance = Db.Projects.Find(idProject);

            if (instance == null) {
                return false;
            }

            Db.Projects.Remove(instance);
            Db.SaveChanges();
            return true;
        }


    }
}