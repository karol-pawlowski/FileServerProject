using FileServerSystemServer.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Web;

namespace FileServerSystemServer.CodeContracts
{
    [ContractClassFor(typeof(IFileRepositoryProxy))]
    public abstract class FileRepositoryProxyContract : IFileRepositoryProxy
    {
        public IList<string> GetFilesForToken(string token)
        {
            Contract.Requires(!string.IsNullOrEmpty(token));

            Contract.Ensures(Contract.Result<IList<string>>() != null);
            return Contract.Result<IList<string>>();
        }

        public FileStream GetSpecificFileForTokenAndId(string token, int id)
        {
            Contract.Requires(!string.IsNullOrEmpty(token));
            Contract.Requires(id > -1);

            Contract.Ensures(Contract.Result<FileStream>() != null);
            return Contract.Result<FileStream>();
        }

        public void RemoveFileForToken(string token, int id)
        {
            Contract.Requires(!string.IsNullOrEmpty(token));
            Contract.Requires(id > -1);
        }
    }
}