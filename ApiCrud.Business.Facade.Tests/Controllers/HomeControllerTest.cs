using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiCrud.Business.Facade;
using ApiCrud.Business.Facade.Controllers;

namespace ApiCrud.Business.Facade.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disponer
            HomeController controller = new HomeController();

            // Actuar
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
