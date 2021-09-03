using BookStore;
using Moq;
using System.Collections.Generic;

namespace NUnitTestProject
{
    public class MockDataAccess : Mock<IDataAccess>
    {
        public MockDataAccess MockGetAllData()
        {
            Setup(x => x.GetAllData())
                .Returns(TestMockData());
            return this;
        }

        public MockDataAccess MockUpdateData(List<Book> books)
        {
            Setup(x => x.UpdateData(It.IsAny<List<Book>>()));
            return this;
        }

        public MockDataAccess VerifyGetAllData(Times times)
        {
            Verify(x => x.GetAllData(), times);
            return this;
        }

        public MockDataAccess VerifyUpdateData(Times times)
        {
            Verify(x => x.UpdateData(It.IsAny<List<Book>>()), times);
            return this;
        }

        public List<Book> TestMockData()
        {
            return new List<Book>
            {
                new Book
                {
                    _id = 1,
                    _title = ".net foundation",
                    _quantity = 123
                },
                new Book
                {
                    _id = 2,
                    _title = "unit test",
                    _quantity = 10
                },
                new Book
                {
                    _id = 3,
                    _title = "ann test",
                    _quantity = 20
                }
            };
        }
    }
}
