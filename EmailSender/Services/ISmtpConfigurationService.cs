using Models.Configurations;

namespace EmailSender.Services
{
    public interface ISmtpConfigurationService
    {
        public SmtpConfiguration GetConfiguration();

        public void UpdateConfiguration(SmtpConfiguration model);
    }
}
