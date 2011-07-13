using System.Collections.Generic;
using System.Web.Mvc;
using Model;
using Services;

namespace MVCSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBankerService _bankerService;
        //
        // GET: /Home/

        public HomeController(IBankerService bankerService) {
            _bankerService = bankerService;
        }

        public ActionResult Index() {
            List<Banker> bankers = _bankerService.GetBankers();

            return View(bankers);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id) {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create() {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id) {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id) {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}