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
    public class AuthorsController : ApiController
    {

        Repository repo;

        public AuthorsController()
        {
            var db = DataBase.Instance;
            repo = new Repository(db);
        }

        public IHttpActionResult Get()
        {
        
            var authors = Mapper.Map<IEnumerable<AuthorDto>>(repo.GetAuthorsList());
            return Ok(authors);
        }


        public IHttpActionResult Get(Guid id)
        {
            var author = Mapper.Map<AuthorDto>(repo.GetAuthor(id));

            if(author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

    }
}
