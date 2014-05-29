using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServerSystemServer.Contracts
{
    public interface IFileRepositoryProxy
    {
        IList<string> GetFilesForToken(string token);
        System.IO.FileStream GetSpecificFileForTokenAndId(string token, int id);
        void RemoveFileForToken(string token, int id);
    }
}
