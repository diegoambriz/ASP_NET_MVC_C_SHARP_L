using MiPrimerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MiPrimerApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Registra una Mascota para darla en adopcion";
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Mascota mascota)
        {
            
            try
            {
                if(ModelState.IsValid)
                {
                    DAL.Mascota sdb = new DAL.Mascota();
                    if (sdb.AgregarMascota(mascota))
                    {
                        ViewBag.Message = "Gracias por Registrar a :" + mascota.Nombre;
                        ModelState.Clear();
                    }

                }
            }
            catch(SqlException exc)
            {
                ViewBag.Message = "Error al registrar Mascota" + exc.Message;
                return View();
            }

            return View();
        }

        public ActionResult Adoptar()
        {
            ViewBag.Message = "Encuentra tu Mascota Ideal";
            DAL.Mascota sdb = new DAL.Mascota();
            List<Mascota> mascotas = sdb.ObtenerMascotas();

            return View(mascotas);
        }
    }
}