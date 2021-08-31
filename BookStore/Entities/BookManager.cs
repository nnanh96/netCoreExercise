using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BookStore
{
    public class BookManager : IBookManager
    {
        public List<Book> _books;

        public IDataAccess _db;

        public BookManager(IDataAccess dataAccess)
        {
            _db = dataAccess;
            _books = _db.GetAllData();

        }

        public void DisplayAllBooks()
        {
            _books.ForEach(b => b.Display());
        }

        public void AddBook(Book book)
        {
            if (!IsExist(book))
            {
                _books.Add(book);
                _db.UpdateData(_books);
                Console.WriteLine($"Added");
            }
            else
            {
                Console.WriteLine("Book exists");
            }
        }

        public void DeleteBook(int id)
        {
            int numOfRemovedItems =  _books.RemoveAll(b => b._id == id);
            if(numOfRemovedItems > 0)
            { 
                _db.UpdateData(_books);
                Console.WriteLine($"Deleted");
            }
            else
            {
                Console.WriteLine("Book doesn't exist");
            }
        }

        public void UpdateBook(Book book)
        {
            if (IsExist(book))
            {
                var currentIndex = _books.FindIndex(b => b._id == book._id);
                _books[currentIndex] = book;
                _db.UpdateData(_books);
                Console.WriteLine($"Updated");
            }
            else
            {
                Console.WriteLine("Book doesn't exist");
            }
        }

        public int CheckAvailability(int id)
        {
            var book = GetBookById(id);
            if(book != null && book._quantity > 0)
            {
                return book._quantity;
            }
            return 0;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b._id == id);
        }
        public bool IsExist(Book book)
        {
            return _books.Exists(b => b.CheckExist(book));
        }
    }
}
