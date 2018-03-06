using System;
using TaskScheduler.Models;

namespace TaskScheduler.Repository.SqlRepository
{
    public partial class SqlRepository : IRepository, IDisposable
    {
        public ApplicationContext Db { get; set; } = new ApplicationContext();

        protected void Dispose(bool disposing)
        {
            if (disposing) {
                if (Db != null) {
                    Db.Dispose();
                    Db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}