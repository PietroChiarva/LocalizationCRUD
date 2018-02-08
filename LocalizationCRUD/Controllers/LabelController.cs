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

        public ActionResult Insert(RisorseLocalizzazioneLabel data)
        {
            
                if (data.idModulo != null && data.idModulo != 0 && !string.IsNullOrEmpty( data.labelFor) && !string.IsNullOrEmpty(data.lingua) && !string.IsNullOrEmpty(data.label))
                {
                using (MobileWarehouseEntities db = new MobileWarehouseEntities())
                {
                    db.RisorseLocalizzazioneLabel.Add(data);
                    db.SaveChanges();
                }
                

            }
                return View("Index");
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
                if (data.idModulo.HasValue)
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

        public ActionResult Delete(int idmodulo, string labelfor, string lingua)
        {
            RisorseLocalizzazioneLabel d = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                
                 d = db.RisorseLocalizzazioneLabel.Where(l => l.idModulo == idmodulo && l.labelFor == labelfor && l.lingua == lingua).FirstOrDefault();
            }
                return View(d);
        }

        public ActionResult DoDelete(int idmodulo, string labelfor, string lingua)
        {

            RisorseLocalizzazioneLabel d = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {


                d = db.RisorseLocalizzazioneLabel.Where(l => l.idModulo == idmodulo && l.labelFor == labelfor && l.lingua == lingua).FirstOrDefault();

                if (d != null)
                {
                    db.RisorseLocalizzazioneLabel.Remove(d);
                    db.SaveChanges();
                }
            }
            return View("Index");
        }
    }


}