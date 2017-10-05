using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookAPI.Controller;
using System.Web.Http.Results;
using System.Linq;
using System.Web.Http;
using BookAPI.DAL.Entities;
using BookAPI.Model;
using System.Collections.Generic;

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


        /// <summary>
        /// Test para probar que el metodo Get devuelve toda la lista de escritores en formato AuthorDto
        /// </summary>
        [TestMethod]
        public void AuthorsControllersReturnValues()
        {
            var controller = new AuthorsController();
            IHttpActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<AuthorDto>>;
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(contentResult);
        }

        /// <summary>
        /// Test que comprueba que el Metodo Get(Id) devuelve el escritor seleccionado en formato AuthorDTo y que el mapeo ha funcionado correctamente
        /// </summary>
        [TestMethod]
        public void AuthorsControllerReturnGetAuthorValue()
        {
            var controller = new AuthorsController();
            IHttpActionResult actionResult = controller.Get(new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"));
            var contentResult = actionResult as OkNegotiatedContentResult<AuthorDto>;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual("Stephen King", contentResult.Content.Name);
        }

        /// <summary>
        /// Test que comprueba que se devuelve el codigo 404 cuando no se encuentra un escritor
        /// </summary>
        [TestMethod]
        public void AuthorsControllerReturnGetAuthorNoExist()
        {
            var controller = new AuthorsController();
            IHttpActionResult actionResult = controller.Get(new Guid());
            var contentResult = actionResult as OkNegotiatedContentResult<AuthorDto>;
            var notFoundResult = actionResult as NotFoundResult;
            Assert.IsNull(contentResult);
            Assert.IsNotNull(notFoundResult);


        }
    }
}
