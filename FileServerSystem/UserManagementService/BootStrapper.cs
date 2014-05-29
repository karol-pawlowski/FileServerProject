
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Common;
using UserManagementService.Contracts;

namespace UserManagementService
{
    public class BootStrapper : IBootStrapper
    {
        public void InitializeApplication()
        {
            log4net.Config.XmlConfigurator.Configure();
            
            // here define container
        }
    }
}
