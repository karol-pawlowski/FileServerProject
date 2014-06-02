using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.Contract
{
    public static class ServiceLocator
    {
        private static IKernel _kernel;
      
        public static IKernel Kernel
        {
            get
            {
                if(_kernel == null)
                {
                    _kernel = new StandardKernel();
                }
                return _kernel;
            }
        }
    }
}
