using BookAPI.DAL;
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
            return Ok(db.GetAuthors());
        }

    }
}
