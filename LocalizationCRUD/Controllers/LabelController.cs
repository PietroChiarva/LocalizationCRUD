using LocalizationCRUD.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalizationCRUD.Controllers
{
    public class LabelController : Controller
    {
        // GET: Label
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }
        public ActionResult SearchCriteria()
        {

            return View();
        }
        public ActionResult Search()
        {
            List<RisorseLocalizzazioneLabel> pippo = new List<RisorseLocalizzazioneLabel>();

            return View(pippo);
        }
    }


}