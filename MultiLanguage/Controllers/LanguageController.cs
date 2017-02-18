using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MultiLanguage.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Change(string Dil)
        {
            if(Dil != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Dil);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Dil);
            }
            

            // Sayfalar arasında geçiş olduğunda, dili cookie yardımıyla her sayfada geçerli kılmaya yarıyor.
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = Dil;
            Response.Cookies.Add(cookie);

            //Global.asax'ta tanımlanan fonksiyon sayesinde dil sürekli geçerli kılınıyor.

            return View("Index");
        }
    }
}