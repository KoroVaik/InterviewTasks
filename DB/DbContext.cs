namespace DB
{
    public class DbContext
    {
        public DbSet<T> SetEntity<T>() where T : class
        {
            return new DbSet<T>();
        }
    }

    public class DbSet<T> where T : class
    {
        public IQueryable<T> Query() => Enumerable.Empty<T>().AsQueryable();
    }
}
