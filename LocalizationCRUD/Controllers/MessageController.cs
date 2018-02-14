using LocalizationCRUD.DAL;
using LocalizationCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalizationCRUD.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert(RisorseLocalizzazioneMessage data)
        {

            return View();
        }

        public ActionResult DoInsert(RisorseLocalizzazioneMessage data)
        {
            if (data.idModulo != null && data.idModulo != 0 && !string.IsNullOrEmpty(data.labelFor) && !string.IsNullOrEmpty(data.lingua) && !string.IsNullOrEmpty(data.label))
            {
                using (MobileWarehouseEntities db = new MobileWarehouseEntities())
                {
                    db.RisorseLocalizzazioneMessage.Add(data);
                    db.SaveChanges();
                }


            }
            return View("Index");
        }

        public JsonResult AJAXInsert(RisorseLocalizzazioneMessage data)
        {

            if (data.idModulo != null && data.idModulo != 0 && !string.IsNullOrEmpty(data.labelFor) && !string.IsNullOrEmpty(data.lingua) && !string.IsNullOrEmpty(data.label))
            {
                using (MobileWarehouseEntities db = new MobileWarehouseEntities())
                {
                    db.RisorseLocalizzazioneMessage.Add(data);
                    db.SaveChanges();
                }

            }
            return Json(new { messaggio = $"Messaggio {data.idModulo} aggiunto con successo" });
        }

        public ActionResult Update(int idmodulo, string labelfor, string lingua, string label)
        {
            return View();
        }

        public ActionResult DoUpdate(SearchClassMessage data)
        {
            RisorseLocalizzazioneMessage d = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                d = db.RisorseLocalizzazioneMessage.Where(l => l.idModulo == data.idModulo && l.labelFor == data.labelFor && l.lingua == data.lingua).FirstOrDefault();
                if (d != null)
                {
                    d.label = data.label;
                }
                else
                {
                    d = new RisorseLocalizzazioneMessage();
                    d.idModulo = data.idModulo.Value;
                    d.labelFor = data.labelFor;
                    d.lingua = data.lingua;
                    d.label = data.label;
                    db.RisorseLocalizzazioneMessage.Add(d);
                }
                db.SaveChanges();
            }
            return SearchCriteria(new SearchClassMessage());
        }



        public ActionResult SearchCriteria(SearchClassMessage data)
        {
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {
                IQueryable<RisorseLocalizzazioneMessage> x = null;
                if (data.idModulo.HasValue)
                {
                    x = db.RisorseLocalizzazioneMessage.Where(l => l.idModulo == data.idModulo);
                }
                else
                {
                    x = db.RisorseLocalizzazioneMessage;
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
            RisorseLocalizzazioneMessage d = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {

                d = db.RisorseLocalizzazioneMessage.Where(l => l.idModulo == idmodulo && l.labelFor == labelfor && l.lingua == lingua).FirstOrDefault();
            }
            return View(d);
        }

        public ActionResult DoDelete(int idmodulo, string labelfor, string lingua)
        {

            RisorseLocalizzazioneMessage d = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {


                d = db.RisorseLocalizzazioneMessage.Where(l => l.idModulo == idmodulo && l.labelFor == labelfor && l.lingua == lingua).FirstOrDefault();

                if (d != null)
                {
                    db.RisorseLocalizzazioneMessage.Remove(d);
                    db.SaveChanges();
                }
            }
            return SearchCriteria(new SearchClassMessage());
        }

        public ActionResult _PartialUpdate(int idModulo, string labelFor, string lingua, string label)
        {
            return PartialView();

        }

        public ActionResult _PartialDelete(int idModulo, string labelFor, string lingua, string label)
        {
            RisorseLocalizzazioneMessage d = null;
            using (MobileWarehouseEntities db = new MobileWarehouseEntities())
            {

                d = db.RisorseLocalizzazioneMessage.Where(l => l.idModulo == idModulo && l.labelFor == labelFor && l.lingua == lingua).FirstOrDefault();
            }
            return PartialView(d);
        }
    }

}
