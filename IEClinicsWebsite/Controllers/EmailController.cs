using IEClinicsWebsite.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IEClinicsWebsite.Controllers
{
    public class EmailController : Controller
    {
        public async Task<bool> EnviarEmail(string assunto, string mensagem, List<string> destinatarios)
        {
            if (ModelState.IsValid)
            {
                MailMessage message = new MailMessage();

                foreach (var destinatario in destinatarios)
                {
                    message.To.Add(new MailAddress(destinatario));
                }

                message.From = new MailAddress("no-reply@ichostweb.com");
                message.Subject = assunto;
                message.Body = mensagem;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    try
                    {
                        await smtp.SendMailAsync(message);
                    }
                    catch (SmtpException)
                    {
                        return false;
                    }

                    return true;
                }
            }

            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return false;
        }

        public string Mensagem(Marcacao marcacao)
        {
            string mensagem;
            string ficheiro = "~/Content/html/nova-consulta.html";
            using (StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(ficheiro)))
            {
                mensagem = sr.ReadToEnd();
            }

            mensagem = mensagem.Replace("{Paciente}", marcacao.Paciente);
            mensagem = mensagem.Replace("{Especialidade}", marcacao.Especialidade);
            mensagem = mensagem.Replace("{Data}", marcacao.DataConsulta.ToShortDateString());
            mensagem = mensagem.Replace("{Horario}", marcacao.HoraMarcacao);
            mensagem = mensagem.Replace("{Medico}", marcacao.Medico);
            mensagem = mensagem.Replace("{Email}", marcacao.Email);
            mensagem = mensagem.Replace("{Telefone}", marcacao.Telefone.ToString());
            mensagem = mensagem.Replace("{DataNascimento}", marcacao.DataNascimento.ToShortDateString());
            return mensagem;
        }
    }
}