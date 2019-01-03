using IEClinicsWebsite.Models;
using IEClinicsWebsite.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IEClinicsWebsite.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();
        public async Task<ActionResult> Index()
        {
            ViewBag.Especialidades = await context.Especialidade.ToListAsync();
            ViewBag.Medicos = await context.Medico.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Marcacao marcacao)
        {
            EmailController email = new EmailController();
            if (ModelState.IsValid)
            {
                var destinatarios = new List<string> { "idiliocasimiro@outlook.com", "edsonchinendele@ichostweb.com" };
                var mensagem = email.Mensagem(marcacao);
                var enviou = await email.EnviarEmail("Novo pedido de marcação", mensagem, destinatarios);
                if (enviou)
                    ViewBag.Mensagem = "Pedido efectuado!";
                else
                    ViewBag.Mensagem = "Não foi possível efectuar o seu pedido! Tente novamente, por favor.";
            }

            ViewBag.Especialidades = await context.Especialidade.ToListAsync();
            ViewBag.Medicos = await context.Medico.ToListAsync();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}