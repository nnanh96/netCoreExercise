using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookStore
{
    public class DataAccessJson : IDataAccess
    {
        private const string dataFile = @"BookData.json";
        public List<Book> GetAllData()
        {
            string json = File.ReadAllText(dataFile, Encoding.UTF8);
            return JsonConvert.DeserializeObject<List<Book>>(json);
        }

        public void UpdateData(List<Book> books)
        {
            File.WriteAllText(dataFile, JsonConvert.SerializeObject(books), Encoding.UTF8);
        }
    }
}
