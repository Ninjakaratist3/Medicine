using EmailSender.Helpers;
using MimeKit;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSender.TemplateModels
{
    public class RegistrationTemplateModel : TemplateModel
    {
        public override TextPart GetMessageBody()
        {
            var messageBody = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = String.Format(TemplateHelper.ReadTepmlateBody("Registration"), User.Name)
            };
            return messageBody;
        }
    }
}
