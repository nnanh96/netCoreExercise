using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookStore
{
    public class DataAccessTxt : IDataAccess
    {
        private const string dataFile = @"BookData.txt";
        private const string separator = ";#";
        public List<Book> GetAllData()
        {
            var rawData = File.ReadAllLines(dataFile, Encoding.UTF8);
            var _books = new List<Book>();
            foreach (var d in rawData)
            {
                var words = d.Split(separator);
                _books.Add(new Book(int.Parse(words[0]), words[1], int.Parse(words[2])));
            }
            return _books;
        }

        public void UpdateData(List<Book> books)
        {
            string dataToUpdate = string.Empty;
            books.ForEach(b =>
            {
                var data = ConvertBookToString(b);
                dataToUpdate += Environment.NewLine + data;
            });
            File.WriteAllText(dataFile, dataToUpdate, Encoding.UTF8);
        }

        private string ConvertBookToString(Book b)
        {
            return string.Join(separator, b._id, b._title, b._quantity);
        }
    }
}
