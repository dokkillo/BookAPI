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

        public IHttpActionResult Get()
        {
            var db = DataBase.Instance;
            var authors = Mapper.Map<IEnumerable<AuthorDto>>(db.GetAuthors());
            return Ok(authors);
        }

    }
}
