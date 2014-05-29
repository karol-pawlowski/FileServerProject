using FileServerSystemServer.CodeContracts;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace FileServerSystemServer.Contracts
{
    [ContractClass(typeof(FileRepositoryProxyContract))]
    public interface IFileRepositoryProxy
    {
        IList<string> GetFilesForToken(string token);
        System.IO.FileStream GetSpecificFileForTokenAndId(string token, int id);
        void RemoveFileForToken(string token, int id);
    }
}
