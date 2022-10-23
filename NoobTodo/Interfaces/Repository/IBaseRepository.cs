
namespace NoobTodo.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        public bool Add(T entity);
        public bool Delete(int id);
        public bool Update(int id, T entity);
        public T GetById(int id);
        public IEnumerable<T> GetAll();
    }
}
