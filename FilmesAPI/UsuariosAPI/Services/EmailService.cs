﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class EmailService
    {

        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario,string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
            var mensagemDeEmail = CriaCorpoDoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    //client.Connect(_configuration.GetValue<string>());
                    client.Send(mensagemDeEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            };
        }

        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress("Adicionar o remetente"));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mensagemDeEmail;
        }
    }
}
