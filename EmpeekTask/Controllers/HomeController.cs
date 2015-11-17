using EmpeekTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpeekTask.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            SearchRepository dataRep = new SearchRepository();
            ViewBag.Drivers = dataRep.GetDrivers();
            string currentPath = ControllerContext.HttpContext.Server.MapPath("~/");
            ViewBag.Path = currentPath;
            ViewBag.Data = dataRep.SearchFolders(currentPath, 0);
            ViewBag.FilesCount = dataRep.FilesCount();
            return View();
        }
        [HttpGet]
        public ActionResult Search(string path)
        {
            SearchRepository dataRep = new SearchRepository();
            ViewBag.Path = path;
            ViewBag.Data = dataRep.SearchFolders(path, 0);
            ViewBag.FilesCount = dataRep.FilesCount();
            return PartialView("MainInfo");
        }
        [HttpPost]
        public ActionResult Index(string path)
        {
            SearchRepository dataRep = new SearchRepository();
            ViewBag.Drivers = dataRep.GetDrivers();
            ViewBag.Path = path;
            ViewBag.Data = dataRep.SearchFolders(path, 0);
            ViewBag.FilesCount = dataRep.FilesCount();
            return View();
        }
    }
}