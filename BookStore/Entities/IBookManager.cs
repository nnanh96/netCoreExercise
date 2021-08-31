namespace BookStore
{
    public interface IBookManager
    {
        void AddBook(Book book);
        void DeleteBook(int id);
        void DisplayAllBooks();
        bool IsExist(Book book);
    }
}