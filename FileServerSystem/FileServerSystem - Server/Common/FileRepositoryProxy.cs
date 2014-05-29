using FileServerSystemServer.Contracts;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace FileServerSystemServer.Common
{
    public class FileRepositoryProxy : IFileRepositoryProxy
    {
        private Table<FILE> _files;
        private Table<TOKEN> _tokens;
        private Table<USER> _users;
        private FileRepositoryDataContext _dataContext;
        private readonly ILog _log;

        public FileRepositoryProxy()
        {
            _dataContext = new FileRepositoryDataContext();

            _files = _dataContext.GetTable<FILE>();
            _tokens = _dataContext.GetTable<TOKEN>();
            _users = _dataContext.GetTable<USER>();

            _log = LogManager.GetLogger(typeof(FileRepositoryProxy));
        }

        public IList<string> GetFilesForToken(string token)
        {
            TOKEN UserToken = (from i in _tokens where i.UserToken == token select i).FirstOrDefault();

            if(UserToken.Is_Active)
            {
                
               
            }
            return null;
        }

        public System.IO.FileStream GetSpecificFileForTokenAndId(string token, int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveFileForToken(string token, int id)
        {
            throw new NotImplementedException();
        }
    }
}