using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    public class Book
    {
        public int _id;
        public string _title;
        public int _quantity;

        public Book(){ }

        public Book(int id, string title, int quantity)
        {
            _id = id;
            _title = title;
            _quantity = quantity;
        }

        public bool CheckExist(Book b)
        {
            return _id == b._id;
        }

        public void Display()
        {
            Console.WriteLine($"Book ID: {_id}; Title: {_title}; Quantity: {_quantity}");
        }    
    }
}
