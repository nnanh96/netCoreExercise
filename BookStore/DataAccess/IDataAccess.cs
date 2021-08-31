using System.Collections.Generic;

namespace BookStore
{
    public interface IDataAccess
    {
        List<Book> GetAllData();
        void UpdateData(List<Book> books);
    }
}