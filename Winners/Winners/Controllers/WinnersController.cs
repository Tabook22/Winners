using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winners.Models;
using Winners.ViewModels;
namespace Winners.Controllers
{
    public class WinnersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Winners
        public ActionResult Index()
        {
            //TODO:Get a list of all the winners
            var getWinners = (from a in db.answers
                              select a);
            return View(getWinners);
        }

        //get winners

            [HttpPost]
        public JsonResult getName()
        {
            int vw = 0;
             List<VMWinners> vmwin = new List<VMWinners>();
            var getWinners = from a in db.answers
                             select a;
            foreach (var itm in getWinners)
            {
                vmwin.Add(new VMWinners { Id = vw + 1, g_name = itm.g_name, g_tel = itm.g_tel });
                vw += 1;
            }
            
            Random rnd = new Random();
    int Random = rnd.Next(1, getWinners.Count());
            var getWinners2 = (from b in vmwin
                               where b.Id == Random
                               select b).FirstOrDefault();

            return Json(getWinners2, JsonRequestBehavior.AllowGet);
        }
    }
}