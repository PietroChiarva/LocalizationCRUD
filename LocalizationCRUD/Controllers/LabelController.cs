using LocalizationCRUD.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocalizationCRUD.Models;
using System.Web.Helpers;
using System.Web.Script.Serialization;

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

            return View();
        }
        
        public ActionResult DoInsert(RisorseLocalizzazioneLabel data)
        {
            if (data.idModulo != null && data.idModulo != 0 && !string.IsNullOrEmpty(data.labelFor) && !string.IsNullOrEmpty(data.lingua) && !string.IsNullOrEmpty(data.label))
            {
                using (MobileWarehouseEntities db = new MobileWarehouseEntities())
                {
                    db.RisorseLocalizzazioneLabel.Add(data);
                    db.SaveChanges();
                }


            }
            return View("Index");
        }
        public JsonResult AJAXInsert(RisorseLocalizzazioneLabel data)
        {
            
            if (data.idModulo != null && data.idModulo != 0 && !string.IsNullOrEmpty(data.labelFor) && !string.IsNullOrEmpty(data.lingua) && !string.IsNullOrEmpty(data.label))
            {
                using (MobileWarehouseEntities db = new MobileWarehouseEntities())
                {
                    db.RisorseLocalizzazioneLabel.Add(data);
                    db.SaveChanges();
                }

             }
            return Json(new { messaggio = $"Label {data.idModulo} aggiunta con successo" });
        }

        public ActionResult Update(int idmodulo, string labelfor, string lingua, string label)
        {
            return View();
        }
        
        public ActionResult DoUpdate(SearchClassLabel data)
        {
            RisorseLocalizzazioneLabel d = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                d = db.RisorseLocalizzazioneLabel.Where(l => l.idModulo == data.idModulo && l.labelFor == data.labelFor && l.lingua == data.lingua).FirstOrDefault();
                if(d != null)
                {
                    d.label = data.label;
                }
                else
                {
                    d = new RisorseLocalizzazioneLabel();
                    d.idModulo = data.idModulo.Value;
                    d.labelFor = data.labelFor;
                    d.lingua = data.lingua;
                    d.label = data.label;
                    db.RisorseLocalizzazioneLabel.Add(d);
                }
                db.SaveChanges();
            }
                return SearchCriteria(new SearchClassLabel());
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
            return View("SearchCriteria",data);
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
            return SearchCriteria(new SearchClassLabel());
        }

        public ActionResult _PartialUpdate(int idModulo, string labelFor, string lingua, string label)
        {
            return PartialView();

        }

        public ActionResult _PartialDelete(int idModulo, string labelFor, string lingua, string label)
        {
            RisorseLocalizzazioneLabel d = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {

                d = db.RisorseLocalizzazioneLabel.Where(l => l.idModulo == idModulo && l.labelFor == labelFor && l.lingua == lingua).FirstOrDefault();
            }
            return PartialView(d);
        }
    }


}