namespace Ecommerce.DAL;

public class GenericRepository<T> : IGenericRepository<T> where T : class  
{
    private readonly ApplicationDbContext _applicationDbContext;
    public GenericRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public void Add(T entity)
    {
        _applicationDbContext.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _applicationDbContext.Set<T>().Remove(entity);
    }

    public IEnumerable<T> GetAll()
    {
        return _applicationDbContext.Set<T>();
    }

    public T? GetById(int id)
    {
        return _applicationDbContext.Set<T>().Find(id);
    }

    //public int SaveChanges()
    //{
    //    return _applicationDbContext.SaveChanges();
    //}

    public void Update(T entity)
    {
    }
}
