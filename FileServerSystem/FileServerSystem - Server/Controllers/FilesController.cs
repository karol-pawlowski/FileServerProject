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
                
        private IFileRepositoryProxy _proxy;

        public FilesController()
        {
            _proxy = new FileRepositoryProxy();           
        }

        public FilesController(IBootStrapper bootstrapper, IFileRepositoryProxy proxy)
        {
            _proxy = proxy;       
        }

        // GET files
        public IList<string> Get(string token)
        {
            return _proxy.GetFilesForToken(token);
        }

        // GET values/5
        public HttpResponseMessage Get(string token, int id)
        {
            FileStream file = _proxy.GetSpecificFileForTokenAndId(token, id);

           

                       
            return null;
        }

        // POST values
        public void Post(string token)
        {
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    HttpPostedFile postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                }
            }            

            //_proxy.AddNewFileForToken(token, value);
            // HttpPostedFileBased 
        }

        // PUT values/5
        public void Put(string token, int id, [FromBody]string value)
        {
            //_files[id] = value;
        }

        // DELETE values/5
        public void Delete(string token, int id)
        {
            _proxy.RemoveFileForToken(token, id);
        }
    }
}