using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCGCollector.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TCGCollector.Controllers
{
    public class XCardCatsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //var entities = new CardCatDBEntities();

            //return View(entities.MovieSet.ToList());
            return View();
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<CardCat>> Get()
        //{
        //    return _repository.GetProducts();
        //}
    }
}
