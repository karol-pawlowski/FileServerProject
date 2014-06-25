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
            HttpResponseMessage result = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            FileStream file = _proxy.GetSpecificFileForTokenAndId(token, id);
            result.Content = new StreamContent(file);
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return result;
        }

        // POST values
        public void Post(string token)
        {
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count == 1)
            {
                string file = httpRequest.Files.GetKey(0);
                
                HttpPostedFile postedFile = httpRequest.Files[file];                    

                BinaryReader b = new BinaryReader(postedFile.InputStream);
                byte[] binData = b.ReadBytes(postedFile.ContentLength);

                _proxy.SaveFileToDatabase(token, binData);                
            }            
        }

        // PUT values/5
        public void Put(string token, int id)
        {
             var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count == 1)
            {
                string file = httpRequest.Files.GetKey(0);
                
                HttpPostedFile postedFile = httpRequest.Files[file];                    

                BinaryReader b = new BinaryReader(postedFile.InputStream);
                byte[] binData = b.ReadBytes(postedFile.ContentLength);

                _proxy.UpdateFile(token, id, binData);
            }
            
        }

        // DELETE values/5
        public void Delete(string token, int id)
        {
            _proxy.RemoveFileForToken(token, id);
        }
    }
}