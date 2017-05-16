using Modelos.Cadastros;
using Servico.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArduinoProjeto.Controllers
{
    public class DispositivoController : Controller
    {
        // GET: Dispositivo
        DispositivoServico dispositivoServico = new DispositivoServico();



        public ActionResult Index()
        {

            PopularViewBag() ;
            
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            GravarDispositivo(collection);
            return RedirectToAction("Index");

        }


        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            AtualizarDispositivo(collection);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Remove(long? id)
        {
            ExcluirDispositivo(id);
            return RedirectToAction("Index");
        }


        private ActionResult ExcluirDispositivo(long? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = dispositivoServico.ExcluirDispositivo((int)id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);

        }

        private ActionResult GravarDispositivo(FormCollection collection)
        {
            if (collection == null)
            {
                return HttpNotFound();
            }

            Dispositivo dispositivo = new Dispositivo()
            {
                Nome = collection["Nome"]
            };
          
            dispositivoServico.GravarDispositivos(dispositivo);
            return View(dispositivo);

        }

        private ActionResult ProcurarTodosDispositivos()
        {
           
            var dispositivos = dispositivoServico.ProcurarTodosDispositivos();
             
            return View(dispositivos);
        }

        private ActionResult AtualizarDispositivo(FormCollection collection)
        {
            if (collection == null)
            {
                return HttpNotFound();
            }

            Dispositivo dispositivo = new Dispositivo()
            {
                Nome = collection["Nome"]
            };
            dispositivoServico.AtualizarDispositivo(dispositivo);
            return View(dispositivo);
        }

        private void PopularViewBag(Dispositivo dispositivo = null)
        {
            if (dispositivo == null)
            {
                ViewBag.DispositivoId = new SelectList(dispositivoServico.ProcurarTodosDispositivos(), "DispositivoId", "Nome");
            }
            else
            {
                ViewBag.DispositivoId = new SelectList(dispositivoServico.ProcurarTodosDispositivos(), "DispositivoId", "Nome", dispositivo.DispositivoId);
            }
        }
    }
}