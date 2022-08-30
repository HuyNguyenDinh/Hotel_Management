using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HM.Common.DAL
{
    public class GenericRep<C, T> : IGenericRep<T> where T : class where C : DbContext, new()
    {
        #region -- Implements --

        /// <summary>
        /// Create the model
        /// </summary>
        /// <param name="m">The model</param>
        public T? Create(T m)
        {
            T? o; 
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    o = _context.Set<T>().Add(m).Entity;
                    _context.SaveChanges();
                    tran.Commit();
                } 
                catch(Exception)
                {
                    tran.Rollback();
                    o = null;
                }
                
            }
            return o;
                
        }

        /// <summary>
        /// Create list model
        /// </summary>
        /// <param name="l">List model</param>
        public bool Create(List<T> l)
        {
            bool success = true;
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<T>().AddRange(l);
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    success = false;
                }

            }
            return success;
        }

        /// <summary>
        /// Read by
        /// </summary>
        /// <param name="p">Predicate</param>
        /// <returns>Return query data</returns>
        public IQueryable<T> Read(Expression<Func<T, bool>> p)
        {
            return _context.Set<T>().Where(p);
        }

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public virtual T? Read(int id)
        {
            return null;
        }

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="code">Secondary key</param>
        /// <returns>Return the object</returns>
        public virtual T? Read(string code)
        {
            return null;
        }

        /// <summary>
        /// Update the model
        /// </summary>
        /// <param name="m">The model</param>
        public T? Update(T m)
        {
            T? o;
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    o = _context.Set<T>().Update(m).Entity;
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    o = null;
                }

            }
            return o;
        }

        /// <summary>
        /// Update list model
        /// </summary>
        /// <param name="l">List model</param>
        public bool Update(List<T> l)
        {
            bool success = true;
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Set<T>().UpdateRange(l);
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    success = false;
                }

            }
            return success;
        }

        /// <summary>
        /// Return query all data
        /// </summary>
        public IQueryable<T> All
        {
            get
            {
                return _context.Set<T>();
            }
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public GenericRep()
        {
            _context = new C();
        }

        /// <summary>
        /// Update the model
        /// </summary>
        /// <param name="old">The old model</param>
        /// <param name="new">The new model</param>
        protected object Update(T old, T @new)
        {
            _context.Entry(old).State = EntityState.Modified;
            var res = _context.Set<T>().Add(@new);
            return res;
        }

        /// <summary>
        /// Delete the model
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the object</returns>
        protected T? Delete(T m)
        {
            T? o;
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    o = _context.Set<T>().Remove(m).Entity;
                    _context.SaveChanges();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    o = null;
                }

            }
            return o;
        }

        #endregion

        #region -- Properties --

        /// <summary>
        /// The database context
        /// </summary>
        public C Context
        {
            get { return _context; }
            set { _context = value; }
        }

        #endregion

        #region -- Fields --

        /// <summary>
        /// The entities
        /// </summary>
        private C _context;

        #endregion
    }
}
