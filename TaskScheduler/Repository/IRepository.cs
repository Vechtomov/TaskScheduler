using System.Collections.Generic;
using System.Linq;
using TaskScheduler.Models;

namespace TaskScheduler.Repository
{
    public interface IRepository
    {
        #region Task
        IQueryable<Task> Tasks { get; }
        bool CreateTask(Task instance);
        bool UpdateTask(Task instance);
        bool RemoveTask(int idTask);
        #endregion


        #region Goal
        IQueryable<Goal> Goals { get; }
        bool CreateGoal(Goal instance);
        bool UpdateGoal(Goal instance);
        bool RemoveGoal(int idGoal);
        #endregion


        #region Project
        IQueryable<Project> Projects { get; }
        bool CreateProject(Project instance);
        bool UpdateProject(Project instance);
        bool RemoveProject(int idProject);
        #endregion


        #region GoalAction
        IQueryable<GoalAction> GoalActions { get; }
        bool CreateGoalAction(GoalAction instance);
        bool UpdateGoalAction(GoalAction instance);
        bool RemoveGoalAction(int idGoalAction);
        #endregion

        //        IEnumerable<ApplicationUser> Users{ get; }

        //        IEnumerable<Task> Tasks { get; }
        //        bool AddTask(Task task);


        //        IEnumerable<Goal> Goals{ get; }
        //        void AddGoal(Goal goal);


        //        IEnumerable<GoalAction> GoalActions{ get; }
        //        void AddGoalAction(GoalAction goalAction);


        //        IEnumerable<Project> Projects{ get; }
        //        void AddProject(Project project);




        //        void ChangeTask(Task task);
        //        void ChangeGoal(Goal goal);
        //        void ChangeProject(Project project);
        //        void ChangeGoalAction(GoalAction goalAction);

        //        void RemoveTask(int taskId);
        //        void RemoveGoal(int goalId);
        //        void RemoveProject(int projectId);
        //        void RemoveGoalAction(int goalActionId);
    }
}
