using BookAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL
{
    public class Repository
    {

        private DataBase _db;


        public Repository(DataBase db)
        {
            _db = db;
        }

        public Author GetAuthor(Guid Id)
        {
            return _db.GetAuthors().Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<Author> GetAuthorsList()
        {
            return _db.GetAuthors();
        }
    }
}
