using EmailSender.TemplateModels;
using System.Threading.Tasks;

namespace EmailSender
{
    public interface IEmailSender
    {
        Task SendAsync(TemplateModel message);
    }
}
