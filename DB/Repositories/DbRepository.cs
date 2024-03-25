using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class DbRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public DbRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.SetEntity<TEntity>();

        }

        protected IEnumerable<TEntity> SearchByExpression(Func<TEntity, bool> expression)
        {
            return _dbSet.Query().Where(expression);
        }

        protected IEnumerable<TEntity> GetAllEntites()
        {
            return _dbSet.Query().ToList();
        }
    }
}
