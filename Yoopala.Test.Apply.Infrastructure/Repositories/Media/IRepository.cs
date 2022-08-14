using System.Collections.Generic;

namespace Yoopala.Test.Apply.Infrastructure.Repositories.Medias
{
    public interface IRepository<T>
    {
        List<T> GetAll(int currentPage, int rowsCount);
       int GetRowsCount();

        List<T> GetAll(Query<T> query);

        T First(Query<T> query);
    }
}
