using System.Collections.Generic;
using System.Web.Mvc;
using Model;
using MVCSite.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using Services;

namespace MVCSite.Test.Controllers
{
    [TestFixture]
    public class QuoteRequestControllerFixture
    {
        private IBankerService _bankerService;
        private IProductService _productService;

        [SetUp]
        public void Setup() {
            _bankerService = MockRepository.GenerateMock<IBankerService>();
            _productService = MockRepository.GenerateMock<IProductService>();
        }

        [TearDown]
        public void Teardown() {
            _bankerService.VerifyAllExpectations();
            _productService.VerifyAllExpectations();
        }

        [Test]
        public void CanCreate() {
            var controller = GetController();

            Assert.That(controller, Is.Not.Null);
        }

        [Test]
        public void New_ProductsAndBankersExist_ReturnsView() {
            var controller = GetController();

            ExpectCallOnBankerServiceReturnsBankers(new List<Banker> {new Banker(), new Banker()});
            ExpectCallOnProductServiceGetProductsReturnsProducts(new List<Product> {new Product(), new Product()});

            var result = controller.New() as ViewResult;

            Assert.That(result.Model, Is.Not.Null);

            var model = result.Model as QuoteRequestViewModel;

            Assert.That(model.Bankers.Count, Is.EqualTo(2));
            Assert.That(model.Products.Count, Is.EqualTo(2));
        }

        private void ExpectCallOnProductServiceGetProductsReturnsProducts(List<Product> products) {
            _productService.Expect(x => x.GetProducts()).Return(products);
        }

        private void ExpectCallOnBankerServiceReturnsBankers(List<Banker> bankers) {
            _bankerService.Expect(x => x.GetBankers()).Return(bankers);
        }

        [Test]
        public void New_ProductsAndBankersDoesNotExist_RedirectsToBankerMissingPage() {
        }


        private QuoteRequestController GetController() {
            return new QuoteRequestController(_bankerService, _productService);
        }

        [Test]
        public void New_ReturnsView() {
            var controller = GetController();

            var result = controller.New();
        }
    }
}