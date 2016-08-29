using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            ViewBag.TotalUsers = getWinners.Count() + 1;
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

        //angularjs get all winners
        public JsonResult getWinners()
        {
            //var data = (from a in db.answers
            //                  select a).Distinct().Take(500);
            
            //Here we use this code to remove any duplicates in the name
            var mydata = db.answers.GroupBy(x => x.g_name).Select(y => y.FirstOrDefault());
            return Json(new { data = mydata, total = mydata.Count() }, JsonRequestBehavior.AllowGet );
        }

        //show winners
        public ActionResult showAllWinners()
        {
            return View();
        }

        public JsonResult getEmployeeByNo(string name)
        {
            try
            {
                
                var winner = from a in db.winners
                             where a.g_name.Contains(name)
                             select a;
                    return Json(winner, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception exp)
            {
                return Json("Error in getting record !", JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>  
        /// Override the JSON Result with Max integer JSON lenght  
        /// </summary>  
        /// <param name="data">Data</param>  
        /// <param name="contentType">Content Type</param>  
        /// <param name="contentEncoding">Content Encoding</param>  
        /// <param name="behavior">Behavior</param>  
        /// <returns>As JsonResult</returns>  
        protected override JsonResult Json(object data, string contentType,
            Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }
    }
}