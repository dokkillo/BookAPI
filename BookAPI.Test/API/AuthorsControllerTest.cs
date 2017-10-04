using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookAPI.Controller;
using System.Web.Http.Results;
using System.Linq;


namespace BookAPI.Test.API
{
    [TestClass]
    public class AuthorsControllersTest
    {

        public AuthorsControllersTest()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BookAPI.DAL.Entities.Author, BookAPI.Model.AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            });

        }


        [TestMethod]
        public void AuthorsConllersReturnValues()
        {
            var controller = new AuthorsController();
            var result = controller.Get();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));    

        }
    }
}
