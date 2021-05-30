
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EmailSender.Helpers
{
    public class TemplateHelper
    {
        public static string ReadTepmlateBody(string templateName)
        {
            var filePath = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("\\"))
                            + Path.DirectorySeparatorChar.ToString()
                            + "EmailSender"
                            + Path.DirectorySeparatorChar.ToString()
                            + "Templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + templateName + ".html";
            var bodyBuilder = new BodyBuilder();

            using (StreamReader streamReader = new StreamReader(filePath))
            {

                bodyBuilder.HtmlBody = streamReader.ReadToEnd();

            }

            return bodyBuilder.HtmlBody;
        }
    }
}
