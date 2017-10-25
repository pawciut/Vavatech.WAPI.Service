using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WAPI.Service.ActionResults;

namespace Vavatech.WAPI.Service.Controllers
{
    public class FilesController : ApiController
    {
        [Route("api/files/{filename}")]
        [HttpGet]
        public IHttpActionResult Get(string filename)
        {
            var baseDir = @"C:\Temp\WebAPI_01\Projekt\Vavatech.WAPI.Service\";
            var path = Path.Combine(baseDir, filename);
            Stream stream = new FileStream(path, FileMode.Open);
            return new StreamActionResult(stream, "application/octet-stream");
        }
    }
}