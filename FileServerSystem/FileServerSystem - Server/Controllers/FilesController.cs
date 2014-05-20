using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FileServerSystem___Server.Controllers
{
    public class FilesController : ApiController
    {
        private IList<string> files;
 
        public FilesController ()
	    {
            files = new List<string> { "Program.exe", "Image.jpg", "Master Thesis.txt", "Sample.txt", "Code.cs", "Script.xml" };
	    }

        // GET api/files
        public IList<string> Get()
        {
            return files;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return files.ElementAt(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            files.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            files[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            files.RemoveAt(id);
        }
    }
}