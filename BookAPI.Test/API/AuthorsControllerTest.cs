using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookAPI.Controller;
using System.Web.Http.Results;
using System.Linq;
using System.Web.Http;
using BookAPI.DAL.Entities;
using BookAPI.Model;
using System.Collections.Generic;
using BookAPI.Helpers;
using BookApi.Utils;

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
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
               .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

            });

        }
        /// <summary>
        /// Test para probar que el metodo Get devuelve toda la lista de escritores en formato AuthorDto
        /// </summary>
        [TestMethod]
        public void Authors_Controller_Return_Values()
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
        public void Authors_Controller_Return_Get_Author_Value()
        {
            SystemTime.Now = () => new DateTime(2017, 1, 1);
            var controller = new AuthorsController();
            IHttpActionResult actionResult = controller.Get(new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"));
            var contentResult = actionResult as OkNegotiatedContentResult<AuthorDto>;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual("Stephen King", contentResult.Content.Name);
            Assert.AreEqual(69, contentResult.Content.Age);

        }

        /// <summary>
        /// Test que comprueba que se devuelve el codigo 404 cuando no se encuentra un escritor
        /// </summary>
        [TestMethod]
        public void Authors_Controller_Return_Get_Author_dont_Exist()
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
