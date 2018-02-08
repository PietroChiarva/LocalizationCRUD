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
        public ActionResult SearchCriteria(SearchClassLabel data)
        {
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                IQueryable<RisorseLocalizzazioneLabel> x = null;
                if (data.idModulo != 0)
                {
                    x = db.RisorseLocalizzazioneLabel.Where(l => l.idModulo == data.idModulo);
                }
                else
                {
                    x = db.RisorseLocalizzazioneLabel;
                }

                if (data.labelFor != null)
                {
                    x = x.Where(l => l.labelFor == data.labelFor);
                }
                if (data.lingua != null)
                {
                    x = x.Where(p => p.lingua == data.lingua);
                }
                if (data.label != null)
                {
                    x = x.Where(p => p.label == data.label);
                }

                data.ResultList = x.ToList();

            }
            return View(data);
        }
        public ActionResult Search()
        {
            List<RisorseLocalizzazioneLabel> pippo = new List<RisorseLocalizzazioneLabel>();

            return View(pippo);
        }
    }


}