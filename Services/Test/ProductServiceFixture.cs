using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Services.Test
{
    [TestFixture]
    public class ProductServiceFixture
    {
        [Test]
        public void CanCreate() {
            ProductService service = GetService();

            Assert.That(service, Is.Not.Null);
        }

        private ProductService GetService() {
            return new ProductService();
        }

        [Test]
        public void GetProducts_Returns4Products() {
            var service = GetService();

            var result = service.GetProducts();

            Assert.That(4, Is.EqualTo(result.Count));
        }
    }
}
