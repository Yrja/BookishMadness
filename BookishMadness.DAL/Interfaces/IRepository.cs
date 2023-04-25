namespace BookishMadness.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        T Create(T item);
        T Update(T item);
        void Delete(Guid id);
        void SaveChanges();
    }
}
