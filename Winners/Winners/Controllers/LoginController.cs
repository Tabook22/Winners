using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winners.Models;

namespace Winners.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/  
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public string Login(Logins data)
        {
            bool isPasswordCorrect = false;
            string un = data.UserName;
            string Password = data.Password;
            using (ApplicationDbContext entity = new ApplicationDbContext())
            {
                var user = entity.logins.Where(u => u.UserName == un).FirstOrDefault();
                if (user != null)
                {
                    if (Password == user.Password)
                    {
                        Session["LoginID"] = user.ID;
                        Session["Username"] = user.Fname + ' ' + user.Lname;
                        return user.ID.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                else
                {
                    return "-1";
                }
            }
        }
    }
}