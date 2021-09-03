using NUnit.Framework;
using BookStore;
using System.Collections.Generic;
using Moq;

namespace NUnitTestProject
{    
    [TestFixture]
    public class Tests
    {
        private MockDataAccess _mockDb;
        private BookManager _store;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockDb = new MockDataAccess()
                .MockGetAllData();
            _store = new BookManager(_mockDb.Object);
        }        

        [Test]
        public void TestAddBook_ShouldWork()
        {
            var book = TestMockData()[0];
            var beforeCount = _store._books.Count;
            _store.AddBook(book);
            var afterCount = _store._books.Count;
            Assert.Contains(book, _store._books);
            Assert.IsTrue(beforeCount + 1 == afterCount);
        }

        [Test]
        public void TestAddBook_ShouldFail()
        {
            var book = TestMockData()[2];
            var beforeCount = _store._books.Count;
            _store.AddBook(book);
            var afterCount = _store._books.Count;
            Assert.IsTrue(beforeCount == afterCount);
        }

        [Test]
        public void TestUpdateBook_ShouldWork()
        {
            var book = TestMockData()[2];
            var beforeCount = _store._books.Count;
            _store.UpdateBook(book);
            var afterCount = _store._books.Count;
            Assert.Contains(book, _store._books);
            Assert.IsTrue(beforeCount == afterCount);
        }

        [Test]
        public void TestDelateBook_ShouldWork()
        {
            var book = TestMockData()[2];
            var beforeCount = _store._books.Count;
            _store.DeleteBook(book._id);
            var afterCount = _store._books.Count;
            Assert.IsFalse(_store._books.Contains(book));
            Assert.IsTrue(beforeCount-1 == afterCount);
        }

        private List<Book> TestMockData()
        {
            return new List<Book>
            {
                new Book
                {
                    _id = 4,
                    _title = "test new book",
                    _quantity = 123
                },
                new Book
                {
                    _id = 5,
                    _title = "another book",
                    _quantity = 10
                },
                new Book
                {
                    _id = 1,
                    _title = "changed title",
                    _quantity = 123
                },
            };
        }
    }
}