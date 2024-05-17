using Appointment_Scheduling_Application.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace Appointment_Scheduling_Application.Repositories.UnitOfWork
{
    //public interface ITransaction : IDisposable
    //{
    //    void Commit();
    //    void Rollback();
    //}
    public interface IUnitOfWork:IDisposable
    {
        //ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot);
        DbSet<T> GetEntities<T>() where T : class;
        void Add<T>(T obj) where T : class;
        Task AddAsync<T>(T obj) where T : class;
        Task AddRangeAsync<T>(T obj) where T : class;
        void Update<T>(T obj) where T : class;
        void Remove<T>(T obj) where T : class;
        void Remove<T>(List<T> obj) where T : class;
        IQueryable<T> Query<T>() where T : class;
        bool Commit();
        Task<bool> CommitAsync();
        Task<int> CommitAsync(CancellationToken cancellationToken);
        void Attach<T>(T obj) where T : class;
        void Detach<T>(T obj) where T : class;
        void Rollback();
    }
    public class UnitOfWork :IUnitOfWork
    {
        private readonly Appointment_Scheduling_Application_DbContext _context;
        public UnitOfWork()
        {
            this._context = new();
        }
        public void Add<T> (T obj) where T : class
        {
            var set=_context.Set<T>();
            set.Add(obj);
        }
        public async Task AddAsync<T>(T obj)
          where T : class
        {
            var set = _context.Set<T>();
            await set.AddAsync(obj);
        }
        public async Task AddRangeAsync<T>(T obj)
          where T : class
        {
            var set = _context.Set<T>();
            await set.AddRangeAsync(obj);
        }
        public void Update<T>(T obj)
            where T : class
        {
            var set = _context.Set<T>();
            set.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        void IUnitOfWork.Remove<T>(T obj)
        {
            var set = _context.Set<T>();
            set.Remove(obj);
        }

        void IUnitOfWork.Remove<T>(List<T> obj)
        {
            var set = _context.Set<T>();
            set.RemoveRange(obj);
        }

        public IQueryable<T> Query<T>()
            where T : class
        {
            return _context.Set<T>();
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Attach<T>(T newUser) where T : class
        {
            var set = _context.Set<T>();
            set.Attach(newUser);
        }
        public void Detach<T>(T newUser) where T : class
        {
            _context.Entry(newUser).State = EntityState.Detached;
        }
        public void Dispose()
        {
            
        }

        public DbSet<T> GetEntities<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void Rollback()
        {
            _context.Dispose();
        }
    }
}
