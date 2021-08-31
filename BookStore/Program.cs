using Ninject;
using System;
using System.Reflection;
using Ninject.Modules;
namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose data format:" +
                "\n\t1. Plain text file" +
                "\n\t2. Json format");
            int mode = int.Parse(Console.ReadLine());
            IKernel kernel = new StandardKernel(new Bindings(mode == 2));
            BookManager store = kernel.Get<BookManager>();
            int input;
            do
            {
                Console.WriteLine("--------------------------------" +
                    "\nPlease choose 1 of these following actions:" +
                    "\n\t1. Display all books" +
                    "\n\t2. Add new book" +
                    "\n\t3. Update book" +
                    "\n\t4. Delete book" +
                    "\n\t5. Check book available" +
                    "\n\t0. Exit");

                input = int.Parse(Console.ReadLine());

                switch (input) {
                    case 1:
                        store.DisplayAllBooks();
                        break;
                    case 2:
                        store.AddBook(ReadBookFromConsole());
                        break;
                    case 3:
                        store.UpdateBook(ReadBookFromConsole());
                        break;
                    case 4:
                        {
                            Console.Write("Enter book id to delete: ");
                            int bookId;
                            bookId = int.Parse(Console.ReadLine());
                            store.DeleteBook(bookId);
                        }
                        break;
                    case 5:
                        {
                            Console.Write("Enter book id to check: ");
                            int bookId;
                            bookId = int.Parse(Console.ReadLine());
                            int quantity = store.CheckAvailability(bookId);
                            if (quantity > 0)
                                Console.WriteLine("This book is available, quantity: " + quantity);
                            else
                                Console.WriteLine("This book is unavailable");
                        }
                        break;
                }
            }
            while (input != 0);
            
            Console.ReadLine();
        }

        public static Book ReadBookFromConsole()
        {
            Console.Write("Enter book ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter book name: ");
            string name = Console.ReadLine();
            Console.Write("Enter book quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            return new Book(id, name, quantity);
        }
    }
}
