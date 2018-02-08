using LocalizationCRUD.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocalizationCRUD.Models;

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
            SearchClassLabel search = new SearchClassLabel();

            return View(search);
        }
        public ActionResult Search()
        {
            List<RisorseLocalizzazioneLabel> pippo = new List<RisorseLocalizzazioneLabel>();

            return View(pippo);
        }
    }


}