using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        { 
            //Criando email padrão 
            string email = "CafeDuZe2020@gmail.com";

            //Stmp -> Servidor que vai enviar a mensagem
            SmtpClient sp = new SmtpClient("smtp.gmail.com", 587);
            sp.UseDefaultCredentials = false;
            sp.Credentials = new NetworkCredential(email, "CafeDuZe2020!@#$");
            sp.EnableSsl = true;

            //MailMenssagem  - > construindo mensagem
            MailMessage mensagem = new MailMessage();

            //responsável pela mensagem
            mensagem.From = new MailAddress(email);

            string corpoMgs = string.Format("<h2>Contato - Loja Virtual<h2>" +
               "<b>Nome: </b> {0} <br/>" +
               "<b>E-mail: </b> {1} <br/>" +
               "<b>Text: </b> {2} <br/>" +
               "<b/> E-email enviando automatico do site CaféDuZé" ,
               contato.Nome,
               contato.Email,
               contato.Texto
               );

            try
            {
                //destinatário
                mensagem.To.Add(new MailAddress(email));
                mensagem.Subject = "Contato - LojaVirtual - E-mail" + contato.Email;
                mensagem.Body = corpoMgs;
                mensagem.IsBodyHtml = true;

                sp.Send(mensagem);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
