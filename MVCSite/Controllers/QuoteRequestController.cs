using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace MVCSite.Controllers
{
    public class QuoteRequestController : Controller
    {
        private readonly IBankerService _bankerService;
        private readonly IProductService _productService;
        //
        // GET: /QuoteRequest/

        public QuoteRequestController(IBankerService bankerService, IProductService productService) {
            _bankerService = bankerService;
            _productService = productService;
        }

        public ActionResult New() {
            var viewModel = new QuoteRequestViewModel();

            viewModel.Bankers = _bankerService.GetBankers();
            viewModel.Products = _productService.GetProducts();
            viewModel.BankersList = new Dictionary<string, string>();
            foreach (var banker in viewModel.Bankers) {
                viewModel.BankersList.Add(banker.BankerUserId,banker.Name.FullName);
            }

            return View(viewModel);
        }

        public ActionResult Update(QuoteRequestViewModel model) {
            throw new NotImplementedException();
        }
    }
}
