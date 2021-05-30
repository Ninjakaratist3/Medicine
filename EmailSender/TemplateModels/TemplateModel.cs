using MimeKit;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSender.TemplateModels
{
    public abstract class TemplateModel
    {
        public User User { get; set; }

        public string Subject { get; set; }

        public abstract TextPart GetMessageBody();
    }
}
