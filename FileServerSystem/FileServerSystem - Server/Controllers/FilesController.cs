using FileServerSystemServer.Common;
using FileServerSystemServer.Contracts;
using log4net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FileServerSystemServer.Controllers
{
    public class FilesController : ApiController
    {
        // http://localhost:8015/Files
        
        private IList<string> _files;    

        private IBootStrapper _bootstrapper;
        private IFileRepositoryProxy _proxy;

        public FilesController()
        {
            _proxy = new FileRepositoryProxy();
            _bootstrapper = new BootStrapper();

            _bootstrapper.InitializeApplication();
        }

        public FilesController(IBootStrapper bootstrapper, IFileRepositoryProxy proxy)
        {
            _proxy = proxy;
            _bootstrapper = bootstrapper;

            _bootstrapper.InitializeApplication();
        }

        // GET files
        public IList<string> Get(string token)
        {
            return _proxy.GetFilesForToken(token);                  
        }

        // GET values/5
        public HttpResponseMessage Get(string token, int id)
        {
            var file = _proxy.GetSpecificFileForTokenAndId(token, id);
            return null;
        }

        // POST values
        public void Post(string token, HttpPostedFileBase value)
        {
            //_proxy.AddNewFileForToken(token, value);
            // HttpPostedFileBased 
        }

        // PUT values/5
        public void Put(string token, int id, [FromBody]string value)
        {
            _files[id] = value;
        }

        // DELETE values/5
        public void Delete(string token, int id)
        {
            _proxy.RemoveFileForToken(token, id);
        }
    }
}