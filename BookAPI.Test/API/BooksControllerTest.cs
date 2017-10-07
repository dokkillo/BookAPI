using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookAPI.Controller;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using BookAPI.Model;

namespace BookAPI.Test.API
{
    [TestClass]
    public class BooksControllerTest
    {
       public BooksControllerTest()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BookAPI.DAL.Entities.Book, BookAPI.Model.BookDto>();
            });

        }

        [TestMethod]
        public void Books_Controller_Return_Books_from_author_exist()
        {
            var controller = new BooksController();
            IHttpActionResult actionResult = controller.Get(new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"));
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<BookDto>>;
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(contentResult);
        }

        [TestMethod]
        public void Books_Controller_Get_Author_dont_Exist()
        {
            var controller = new BooksController();
            IHttpActionResult actionResult = controller.Get(new Guid());
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<BookDto>>;
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNull(contentResult);
            Assert.IsNotNull(notFoundResult);
        }

        [TestMethod]
        public void Books_Controller_Return_one_Book_from_author_exist()
        {
            var controller = new BooksController();
            IHttpActionResult actionResult = controller.Get(new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"), new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"));
            var contentResult = actionResult as OkNegotiatedContentResult<BookDto>;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual("The Shining", contentResult.Content.Title);       
        }


        [TestMethod]
        public void Books_Controller_Return_One_Book_Get_Author_dont_Exist()
        {
            var controller = new BooksController();
            IHttpActionResult actionResult = controller.Get(new Guid(), new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"));
            var contentResult = actionResult as OkNegotiatedContentResult<BookDto>;
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNull(contentResult);
            Assert.IsNotNull(notFoundResult);
        }

        [TestMethod]
        public void Books_Controller_Return_One_Book_Get_Book_dont_Exist()
        {
            var controller = new BooksController();
            IHttpActionResult actionResult = controller.Get(new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"), new Guid());
            var contentResult = actionResult as OkNegotiatedContentResult<BookDto>;
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNull(contentResult);
            Assert.IsNotNull(notFoundResult);
        }


    }
}
