using AutoMapper;
using BookAPI.DAL;
using BookAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BookAPI.Controller
{
   public class BooksController :ApiController
    {
        Repository repo;

        public BooksController()
        {
            var db = DataBase.Instance;
            repo = new Repository(db);
        }

   
        public IHttpActionResult Get(Guid authorId)
        {
            var author = repo.GetAuthor(authorId);

            if(author == null)
            {
                return NotFound();
            }

            var booksOfAuthor = Mapper.Map<IEnumerable<BookDto>>(author.Books);
            return Ok(booksOfAuthor);
        }


        public IHttpActionResult Get(Guid authorId, Guid bookId)
        {
            var book = repo.GetBook(authorId, bookId);

            if (book == null)
            {
                return NotFound();
            }

            var bookOfAuthor = Mapper.Map<BookDto>(book);
            return Ok(bookOfAuthor);
        }

    }
}
