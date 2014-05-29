using FileServerSystemServer.Contracts;

namespace FileServerSystemServer.Common
{
    public class BootStrapper : IBootStrapper
    {
        public void InitializeApplication()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}