using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServerSystemClient.Contracts
{
    public interface IUserControllerClientProxy
    {
        void GenerateNewUser(string p1, string p2);
    }
}
